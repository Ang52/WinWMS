# 登录功能实现 - 手动修改指南

## 已完成的文件

✅ 以下文件已自动创建：
1. `WinWMS/UserSession.cs` - 用户会话管理类
2. `WinWMS/LoginForm.cs` - 登录窗体逻辑（带粒子动画）
3. `WinWMS/LoginForm.Designer.cs` - 登录窗体界面设计
4. `SQL/test_users.sql` - 测试用户SQL脚本
5. `LOGIN_README.md` - 登录功能使用说明

✅ 以下文件已修改：
1. `Program.cs` - 启动时先显示登录窗口
2. `Form1.cs` - 添加权限控制逻辑

## 需要手动修改的文件

由于文件编辑器限制，以下两个文件需要您手动修改：

### 1. `WinWMS/InboundForm.cs`

**位置**: 约第 233 行，`BtnInbound_Click` 方法中

**需要修改的代码**:
```csharp
// 原代码（第 233-239 行）
string inboundQuery = "INSERT INTO inbound_records (material_id, warehouse_id, quantity, price, remark, inbound_date, user_id) VALUES (@material_id, @warehouse_id, @quantity, @price, @remark, NOW(), 1)";
MySqlParameter[] inboundParams = {
    new MySqlParameter("@material_id", materialId),
    new MySqlParameter("@warehouse_id", warehouseId),
    new MySqlParameter("@quantity", quantity),
    new MySqlParameter("@price", price),
    new MySqlParameter("@remark", string.IsNullOrEmpty(remark) ? DBNull.Value : (object)remark)
};
```

**修改为**:
```csharp
// 新代码：使用当前登录用户ID
string inboundQuery = "INSERT INTO inbound_records (material_id, warehouse_id, quantity, price, remark, inbound_date, user_id) VALUES (@material_id, @warehouse_id, @quantity, @price, @remark, NOW(), @user_id)";
MySqlParameter[] inboundParams = {
    new MySqlParameter("@material_id", materialId),
    new MySqlParameter("@warehouse_id", warehouseId),
    new MySqlParameter("@quantity", quantity),
    new MySqlParameter("@price", price),
    new MySqlParameter("@remark", string.IsNullOrEmpty(remark) ? DBNull.Value : (object)remark),
    new MySqlParameter("@user_id", UserSession.UserId)  // 添加这一行
};
```

**说明**: 将硬编码的用户ID `1` 改为 `@user_id` 参数，并添加 `UserSession.UserId` 参数。

---

### 2. `WinWMS/OutboundForm.cs`

**位置**: 约第 275 行，`BtnOutbound_Click` 方法中

**需要修改的代码**:
```csharp
// 原代码（第 275-280 行）
string outboundQuery = "INSERT INTO outbound_records (material_id, warehouse_id, quantity, price, remark, outbound_date, user_id) VALUES (@material_id, @warehouse_id, @quantity, @price, @remark, NOW(), 1)";
MySqlParameter[] outboundParams = {
    new MySqlParameter("@material_id", materialId),
    new MySqlParameter("@warehouse_id", warehouseId),
    new MySqlParameter("@quantity", quantity),
    new MySqlParameter("@price", avgOutboundPrice),  // 使用实际出库的平均价格
    new MySqlParameter("@remark", string.IsNullOrEmpty(remark) ? DBNull.Value : (object)remark)
};
```

**修改为**:
```csharp
// 新代码：使用当前登录用户ID
string outboundQuery = "INSERT INTO outbound_records (material_id, warehouse_id, quantity, price, remark, outbound_date, user_id) VALUES (@material_id, @warehouse_id, @quantity, @price, @remark, NOW(), @user_id)";
MySqlParameter[] outboundParams = {
    new MySqlParameter("@material_id", materialId),
    new MySqlParameter("@warehouse_id", warehouseId),
    new MySqlParameter("@quantity", quantity),
    new MySqlParameter("@price", avgOutboundPrice),  // 使用实际出库的平均价格
    new MySqlParameter("@remark", string.IsNullOrEmpty(remark) ? DBNull.Value : (object)remark),
    new MySqlParameter("@user_id", UserSession.UserId)  // 添加这一行
};
```

**说明**: 将硬编码的用户ID `1` 改为 `@user_id` 参数，并添加 `UserSession.UserId` 参数。

---

## 修改步骤

1. 在 Visual Studio 中打开 `WinWMS/InboundForm.cs`
2. 按 `Ctrl + G` 跳转到第 233 行
3. 找到 `INSERT INTO inbound_records` 语句
4. 按上面的说明进行修改
5. 保存文件

6. 在 Visual Studio 中打开 `WinWMS/OutboundForm.cs`
7. 按 `Ctrl + G` 跳转到第 275 行
8. 找到 `INSERT INTO outbound_records` 语句
9. 按上面的说明进行修改
10. 保存文件

## 初始化数据库

在首次运行程序前，请执行以下SQL脚本：

```bash
# 在MySQL客户端中执行
mysql -u your_username -p winwms < SQL/test_users.sql
```

或者直接在MySQL Workbench中打开并执行 `SQL/test_users.sql` 文件。

## 测试登录功能

1. 编译并运行项目
2. 应该会自动显示登录窗口
3. 使用以下账户测试：
   - 管理员：`admin` / `123456`
   - 操作员：`operator` / `123456`
4. 登录成功后检查：
   - 状态栏是否显示正确的用户信息
   - 操作员是否看不到物料/仓库/用户管理按钮
   - 管理员是否能看到所有按钮

## 验证记录追踪

登录后进行入库或出库操作，然后在数据库中查询：

```sql
-- 查看最近的入库记录及操作员
SELECT ibr.*, u.username 
FROM inbound_records ibr
JOIN users u ON ibr.user_id = u.id
ORDER BY ibr.inbound_date DESC
LIMIT 10;

-- 查看最近的出库记录及操作员
SELECT obr.*, u.username 
FROM outbound_records obr
JOIN users u ON obr.user_id = u.id
ORDER BY obr.outbound_date DESC
LIMIT 10;
```

如果 `user_id` 正确对应当前登录用户，说明修改成功！

## 常见问题

### 编译错误 "UserSession does not exist"
确保 `WinWMS/UserSession.cs` 文件已正确添加到项目中。如果没有，请在 Visual Studio 中右键点击项目 → 添加 → 现有项 → 选择 `UserSession.cs`。

### 登录后立即退出
检查 `Program.cs` 中的修改是否正确，应该使用 `ShowDialog()` 而不是 `Show()`。

### 粒子动画不显示
确保 `LoginForm` 的 `DoubleBuffered` 属性设置为 `true`，并且定时器已正确启动。

---

**完成以上手动修改后，登录功能就完全集成到系统中了！**
