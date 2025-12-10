WinWMS 项目文档

概述
- 项目名称: WinWMS (Windows 仓储管理系统)
- 技术栈: .NET 8, Windows 桌面 (WinForms), MySQL
- 目标: 提供物料与仓库的入库/出库、库存汇总、月度报表、基础资料管理（物料、仓库、用户）以及查询统计能力。
- 主要特性:
  - 入库与出库操作（支持备注与单价）
  - FIFO 成本计算（通过库存批次）
  - 库存汇总与查询（加权平均单价）
  - 月度报表统计
  - 基础资料维护（用户、仓库、物料）

系统架构
- 前端: WinForms 多窗体应用
  - 主窗体: `Form1`
  - 功能窗体:
    - `InboundForm` 入库
    - `OutboundForm` 出库
    - `InboundQueryForm` 入库查询
    - `OutboundQueryForm` 出库查询
    - `InventoryQueryForm` 库存查询
    - `MonthlyReportForm` 月度报表
    - `MaterialManagementForm` 物料管理
    - `WarehouseManagementForm` 仓库管理
    - `UserManagementForm` 用户管理
- 数据访问: `DbHelper`
  - 提供数据库连接、SQL 执行与查询封装
  - 建议使用参数化查询防注入、事务维护一致性
- UI 辅助: `ComboBoxStyleHelper`
  - 统一下拉框样式与数据绑定体验

数据库设计（MySQL）
- 库: `winwms`
- 字符集: `utf8mb4`, 排序规则: `utf8mb4_unicode_ci`
- 表与关系（摘要）:
  - `users`: 用户、角色、密码哈希
  - `warehouses`: 仓库基本信息
  - `materials`: 物料编码、规格、单价（入库参考价）
  - `inbound_records`: 入库历史（用户、物料、仓库、数量、单价、备注、时间）
  - `outbound_records`: 出库历史（用户、物料、仓库、数量、成本单价、备注、时间）
  - `inventory_batches`: 库存批次（入库批次、单价、剩余量、总金额、时间）
  - `inventory`: 库存汇总（每物料-仓库的当前数量与金额、加权单价）
- 关键约束与级联：
  - 入库/出库/批次/库存均与 `materials`、`warehouses` 外键关联
  - `inventory` 唯一键 `(material_id, warehouse_id)`
  - `inventory_batches` 与 `inbound_records` 一对多（FIFO 依据入库时间/ID）

运行与开发
- 环境要求:
  - .NET SDK 8.0+
  - MySQL 8.0+（或兼容版本）
  - Windows 10/11 桌面环境
- 获取源码:
  - Git: https://github.com/Ang52/WinWMS
- 构建:
  - 在解决方案目录执行: `dotnet build`
  - 或在 Visual Studio 中打开 `WinWMS.csproj` 并构建
- 启动:
  - 运行 `Program.cs` 启动 WinForms 应用

配置
- 数据库连接:
  - 由 `DbHelper` 统一管理连接字符串（建议放置在 `appsettings.json` 或 `User Secrets`）
  - 推荐格式: `Server=localhost;Database=winwms;User Id=...;Password=...;Charset=utf8mb4;`
- UI 配置:
  - 使用 `ComboBoxStyleHelper` 统一控件风格

核心业务流程（含关键代码）
- 入库流程（`InboundForm`）
  - 输入: 物料、规格（选中后 `ValueMember` 为材料 `id`）、仓库、数量、备注。
  - 验证: 物料/规格/仓库必选、数量>0。
  - 获取单价: 读取 `materials` 表 `price` 作为标准单价。
  - 写入入库记录: 插入 `inbound_records` 并用 `SELECT LAST_INSERT_ID()` 获取主键。
  - 生成批次号: 使用 `GenerateBatchNo(materialId, warehouseId)`（规则: PC+物料ID(4位)+仓库ID(2位)+日期(8位)+序号(3位)）。
    - 关键实现（节选）：
      - 查询当天该物料在该仓库的批次数量：`SELECT COUNT(*) FROM inventory_batches WHERE material_id=@material_id AND warehouse_id=@warehouse_id AND DATE(inbound_date)=CURDATE()`
      - 扩展序号：`seq = count + 1`
      - 拼接批次号：`$"PC{materialId:D4}{warehouseId:D2}{dateStr}{seq:D3}"`
  - 写入批次: 插入 `inventory_batches`（`quantity`, `unit_price`, `total_amount`）。
  - 更新库存汇总 `inventory`:
    - 若存在则加量加金额，重算加权价：`newUnitPrice = newAmount / newQuantity`
    - 若不存在则写入初始记录（单价即标准单价）。
  - 关键代码路径：
    - `InboundForm.BtnInbound_Click` 完整管线
    - `InboundForm.GenerateBatchNo`

- 出库流程（`OutboundForm`）
  - 输入: 物料、规格（`ValueMember` 为材料 `id`）、仓库（仅显示有库存的仓库）、数量、备注。
  - 验证: 同入库；且校验 `inventory` 当前数量是否足够。
  - 扣减批次（FIFO）:
    - 查询可用批次：`SELECT id,batch_no,quantity,unit_price FROM inventory_batches WHERE material_id=@material_id AND warehouse_id=@warehouse_id AND quantity>0 ORDER BY inbound_date ASC`
    - 循环逐批扣减：对于每批次 `deductQuantity = Min(remainingQuantity, batchQuantity)`，更新批次剩余量 `UPDATE inventory_batches SET quantity=@quantity WHERE id=@id`，累计成本 `totalOutboundAmount += deductQuantity * batchPrice`。
    - 平均出库价：`avgOutboundPrice = totalOutboundAmount / quantity`。
  - 写入出库记录：插入 `outbound_records(material_id, warehouse_id, quantity, price, remark, outbound_date, user_id)`，`price` 为平均出库价。
  - 更新库存汇总 `inventory`：`newQuantity = currentQuantity - quantity`，`newAmount = newQuantity * unit_price`（保持加权价不变，快速查询）。
  - 关键代码路径：
    - `OutboundForm.BtnOutbound_Click` 完整管线

- 查询与过滤
  - `InboundQueryForm`/`OutboundQueryForm`：按时间范围、物料、仓库条件查询（典型 SQL：`SELECT * FROM inbound_records WHERE inbound_date BETWEEN @start AND @end AND material_id=@materialId AND warehouse_id=@whId`）。
  - `InventoryQueryForm`：展示 `inventory` 汇总（可扩展联表批次 `inventory_batches` 查看明细）。

窗体与模块说明（功能明细）
- `Form1`
  - 导航主界面，菜单或按钮进入各功能模块。
- `InboundForm`
  - 物料名称下拉（去重 `SELECT DISTINCT name FROM materials`）。
  - 规格下拉（按名称加载，显示 `规格 [编码] - 单价: ¥xx.xx`）。
  - 仓库下拉（全部仓库）。
  - 数量输入（`NumericUpDown`），备注。
  - 关键交互:
    - `CmbMaterial_SelectedIndexChanged` 动态加载规格。
    - `LoadMaterialSpecs` 绑定规格并设置 `ValueMember = id`。
    - `LoadWarehouses` 绑定仓库并设置 `ValueMember = id`。
    - `ClearForm` 重置控件状态。
- `OutboundForm`
  - 物料名称、规格、仓库（仅显示有库存：联查 `inventory`）。
  - 数量输入、备注。
  - 关键交互:
    - `CmbMaterial_SelectedIndexChanged` 加载规格并重置仓库。
    - `CmbSpec_SelectedIndexChanged` 加载有库存的仓库（显示 `仓库名称 [库存: xxx]`）。
    - 批次扣减与平均成本计算（FIFO）。
- `InboundQueryForm`/`OutboundQueryForm`
  - 条件区域（时间、物料、仓库），结果表格展示。
- `InventoryQueryForm`
  - 展示 `inventory` 当前数量、加权单价、总金额；可扩展查看批次。
- `MonthlyReportForm`
  - 指定年月，统计入库/出库数量与金额，计算差额与趋势；支持导出（可扩展）。
- `MaterialManagementForm`
  - 维护 `material_code`、`name`、`spec`、`unit`、`price` 等；支持新增/编辑/删除。
- `WarehouseManagementForm`
  - 维护仓库 `name`、`location` 等；支持新增/编辑/删除。
- `UserManagementForm`
  - 维护 `username`、`role`、`password_hash`；设置密码时需加密存储。

数据访问与事务
- `DbHelper` 封装（建议清单）:
  - 连接管理与异常包装。
  - 参数化查询与命名参数。
  - 通用方法：`ExecuteNonQuery`、`ExecuteScalar`、`ExecuteQuery`（DataTable）。
  - 事务支持：开始/提交/回滚。
- 事务边界建议:
  - 入库：写入入库 -> 写入批次 -> 更新库存（单事务）。
  - 出库：扣减批次 -> 写入出库 -> 更新库存（单事务）。

关键 SQL 与参数化示例
- 读取物料规格：`SELECT id,spec,material_code,price FROM materials WHERE name=@name`。
- 插入入库记录：`INSERT INTO inbound_records(material_id, warehouse_id, quantity, price, remark, inbound_date, user_id) VALUES(@material_id,@warehouse_id,@quantity,@price,@remark,NOW(),@user_id)`。
- 插入批次：`INSERT INTO inventory_batches(material_id,warehouse_id,batch_no,quantity,unit_price,total_amount,inbound_date,inbound_record_id,remark) VALUES(...)`。
- 更新库存：`UPDATE inventory SET quantity=@quantity, unit_price=@unit_price, total_amount=@total_amount, last_updated=NOW() WHERE material_id=@material_id AND warehouse_id=@warehouse_id`。
- FIFO 扣减：`UPDATE inventory_batches SET quantity=@quantity WHERE id=@id`。

错误处理与用户体验
- 输入校验:
  - 数量为正整数，单价为非负，必填项不能为空。
- 异常处理:
  - 捕获数据库异常并提示；必要时回滚事务。
- 交互体验:
  - 在处理过程中禁用按钮，防止重复提交；成功后清空并提示。

安全与权限
- 密码哈希:
  - 建议使用 BCrypt/Argon2；仅存储哈希。
- 角色与权限:
  - `Admin` 管理用户与基础数据；`Operator` 入/出库与查询。
- SQL 安全:
  - 全面使用参数化查询。

部署与运维
- 发布:
  - `dotnet publish -c Release -r win-x64 --self-contained false`。
- 数据库迁移:
  - 使用脚本或迁移工具初始化 `winwms` 与表结构。
- 备份与恢复:
  - 定期备份（全量+增量）。

测试
- 单元测试（建议）:
  - 批次扣减与 FIFO 成本计算。
  - 入库/出库事务一致性。
- 集成测试（建议）:
  - UI 表单与数据库交互端到端测试。

日志与监控
- 日志: 操作与错误日志。
- 监控: 数据库连接健康检查（可选）。

性能与扩展性
- 性能:
  - 批量操作使用事务与批处理；查询分页与索引（物料/仓库/时间）。
- 扩展:
  - 增加盘点/调拨模块；报表导出 Excel/CSV；多语言与多租户支持。

开发规范
- 代码风格: 统一命名与注释，遵循 .NET 规范。
- 依赖管理: 优先内置库，第三方库评估许可证与可靠性。

附录
- 表结构与约束详见 `DatabaseDocumentation.md`
- 关键文件:
  - `Program.cs`: 应用入口
  - `Form1.cs`: 主界面
  - 各 `*Form.cs`: 具体功能实现
  - `DbHelper.cs`: 数据访问封装
  - `ComboBoxStyleHelper.cs`: UI 辅助
