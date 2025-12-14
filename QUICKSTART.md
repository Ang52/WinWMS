# 🚀 快速开始指南 - WinWMS 登录功能

## ⚡ 一键初始化数据库

### Windows 用户（推荐）

**方法1：使用命令行**
```cmd
cd D:\C#\25秋\WinWMS
mysql -u root -p < SQL\WMS_DB_Test.sql
```

**方法2：使用 MySQL Workbench**
1. 打开 MySQL Workbench
2. File → Open SQL Script → 选择 `SQL/WMS_DB_Test.sql`
3. 点击闪电图标 ⚡ 执行

### 验证初始化结果

执行成功后，您将看到：

```
✅ 数据库初始化成功！
- 数据库: winwms
- 用户: admin, operator  
- 密码: 123456
- 物料: 7种
- 仓库: 2个
```

## 📝 完成代码修改（必需）

### 修改 InboundForm.cs（约第233行）

找到这段代码：
```csharp
string inboundQuery = "INSERT INTO inbound_records ... VALUES (..., NOW(), 1)";
MySqlParameter[] inboundParams = {
    // ... 其他参数
};
```

修改为：
```csharp
string inboundQuery = "INSERT INTO inbound_records ... VALUES (..., NOW(), @user_id)";
MySqlParameter[] inboundParams = {
    // ... 其他参数
    new MySqlParameter("@user_id", UserSession.UserId)  // 👈 添加这一行
};
```

### 修改 OutboundForm.cs（约第275行）

找到这段代码：
```csharp
string outboundQuery = "INSERT INTO outbound_records ... VALUES (..., NOW(), 1)";
MySqlParameter[] outboundParams = {
    // ... 其他参数
};
```

修改为：
```csharp
string outboundQuery = "INSERT INTO outbound_records ... VALUES (..., NOW(), @user_id)";
MySqlParameter[] outboundParams = {
    // ... 其他参数
    new MySqlParameter("@user_id", UserSession.UserId)  // 👈 添加这一行
};
```

详细说明请查看：`MANUAL_CHANGES_REQUIRED.md`

## 🎯 测试登录功能

### 1. 编译运行
```bash
dotnet build
dotnet run
```

或在 Visual Studio 中按 F5

### 2. 使用测试账户

#### 管理员账户
- 用户名：`admin`
- 密码：`123456`
- 权限：✅ 全部功能

#### 操作员账户
- 用户名：`operator`
- 密码：`123456`
- 权限：⚠️ 入库/出库/查询/报表（无管理功能）

### 3. 验证权限控制

**用操作员登录时，应该看不到：**
- 📦 物料管理
- 🏭 仓库管理
- 👥 用户管理

**用管理员登录时，应该看到所有按钮**

## ✅ 检查清单

- [ ] 数据库初始化成功
- [ ] 修改了 InboundForm.cs
- [ ] 修改了 OutboundForm.cs
- [ ] 项目编译成功
- [ ] 登录窗口正常显示（带粒子动画）
- [ ] admin 账户可以登录
- [ ] operator 账户可以登录
- [ ] 操作员看不到管理功能
- [ ] 状态栏显示当前用户信息

## 🔍 验证操作记录

登录后进行一次入库操作，然后在数据库中查询：

```sql
-- 查看最新的入库记录及操作员
SELECT 
    ibr.*,
    u.username AS '操作员',
    m.name AS '物料',
    w.name AS '仓库'
FROM inbound_records ibr
JOIN users u ON ibr.user_id = u.id
JOIN materials m ON ibr.material_id = m.id
JOIN warehouses w ON ibr.warehouse_id = w.id
ORDER BY ibr.inbound_date DESC
LIMIT 5;
```

如果 `user_id` 正确对应当前登录用户，说明功能正常！✅

## 🐛 常见问题

### 问题1：无法登录，提示"用户名或密码错误"

**解决方案：**
```sql
-- 检查用户是否存在
SELECT * FROM users;

-- 检查密码哈希是否正确
SELECT username, password_hash FROM users WHERE username = 'admin';
-- 应该显示: 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92
```

### 问题2：粒子动画不显示

- 检查 `LoginForm` 构造函数中 `animationTimer` 是否启动
- 确保 `DoubleBuffered = true`

### 问题3：编译错误 "UserSession does not exist"

- 确认 `WinWMS/UserSession.cs` 文件已添加到项目
- 重新生成解决方案

### 问题4：数据库连接失败

检查 `DbHelper.cs` 中的连接字符串：
```csharp
private static readonly string connectionString = 
    "server=localhost;port=3306;user=root;password=your_password;database=winwms;charset=utf8;";
```

## 📚 相关文档

- **登录功能详细说明**: `LOGIN_README.md`
- **手动修改指南**: `MANUAL_CHANGES_REQUIRED.md`
- **SQL合并说明**: `SQL/SQL_MERGE_README.md`
- **项目整体文档**: `ProjectDocumentation.md`

## 🎉 完成后

恭喜！您已经成功集成了登录功能！

现在您可以：
- ✅ 使用不同角色登录系统
- ✅ 体验基于角色的权限控制
- ✅ 追踪所有操作的操作员信息
- ✅ 享受带动态粒子效果的登录界面

---

**需要帮助？** 查看文档或检查代码注释
**发现问题？** 参考故障排查部分
**准备部署？** 记得修改默认密码！🔐
