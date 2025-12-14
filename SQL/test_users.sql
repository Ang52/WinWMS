-- 添加测试用户的SQL脚本
-- 注意：这些密码哈希是使用 SHA256 生成的
-- 默认密码都是 "123456"

-- 管理员账户
-- 用户名: admin  密码: 123456
INSERT INTO users (username, password_hash, role, created_at) 
VALUES ('admin', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Admin', NOW())
ON DUPLICATE KEY UPDATE password_hash = '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92';

-- 操作员账户
-- 用户名: operator  密码: 123456
INSERT INTO users (username, password_hash, role, created_at) 
VALUES ('operator', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Operator', NOW())
ON DUPLICATE KEY UPDATE password_hash = '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92';

-- 如果您想修改密码，可以使用以下查询来生成新的哈希值：
-- SELECT SHA2('您的新密码', 256);
-- 然后更新用户表：
-- UPDATE users SET password_hash = '新生成的哈希值' WHERE username = '用户名';
