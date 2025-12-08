-- ============================================
-- WinWMS 仓储管理系统数据库初始化脚本
-- 数据库名称: winwms
-- 字符集: UTF-8
-- 创建日期: 2024
-- ============================================

-- 创建数据库
DROP DATABASE IF EXISTS winwms;
CREATE DATABASE winwms CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE winwms;

-- ============================================
-- 1. 用户表 (users)
-- 用于存储系统用户信息
-- ============================================
CREATE TABLE users (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '用户ID',
    username VARCHAR(50) NOT NULL UNIQUE COMMENT '用户名',
    password_hash VARCHAR(255) NOT NULL COMMENT '密码哈希值',
    role VARCHAR(20) NOT NULL COMMENT '角色(管理员/普通用户)',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    INDEX idx_username (username)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='用户表';

-- ============================================
-- 2. 仓库表 (warehouses)
-- 用于存储仓库信息
-- ============================================
CREATE TABLE warehouses (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '仓库ID',
    name VARCHAR(100) NOT NULL COMMENT '仓库名称',
    location VARCHAR(200) COMMENT '仓库位置',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    INDEX idx_name (name)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='仓库表';

-- ============================================
-- 3. 物料表 (materials)
-- 用于存储物料信息
-- ============================================
CREATE TABLE materials (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '物料ID',
    material_code VARCHAR(50) NOT NULL COMMENT '物料编码',
    name VARCHAR(100) NOT NULL COMMENT '物料名称',
    spec VARCHAR(100) COMMENT '规格',
    unit VARCHAR(20) COMMENT '单位',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    INDEX idx_material_code (material_code),
    INDEX idx_name (name),
    INDEX idx_name_spec (name, spec)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='物料表';

-- ============================================
-- 4. 库存表 (inventory)
-- 用于存储实时库存信息
-- ============================================
CREATE TABLE inventory (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '库存ID',
    material_id INT NOT NULL COMMENT '物料ID',
    warehouse_id INT NOT NULL COMMENT '仓库ID',
    quantity INT NOT NULL DEFAULT 0 COMMENT '库存数量',
    unit_price DECIMAL(10, 2) NOT NULL DEFAULT 0.00 COMMENT '单价',
    total_amount DECIMAL(15, 2) NOT NULL DEFAULT 0.00 COMMENT '总金额',
    last_updated DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
    UNIQUE KEY uk_material_warehouse (material_id, warehouse_id),
    FOREIGN KEY (material_id) REFERENCES materials(id) ON DELETE CASCADE,
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id) ON DELETE CASCADE,
    INDEX idx_material_id (material_id),
    INDEX idx_warehouse_id (warehouse_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='库存表';

-- ============================================
-- 5. 入库记录表 (inbound_records)
-- 用于记录物料入库信息
-- ============================================
CREATE TABLE inbound_records (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '入库记录ID',
    material_id INT NOT NULL COMMENT '物料ID',
    warehouse_id INT NOT NULL COMMENT '仓库ID',
    quantity INT NOT NULL COMMENT '入库数量',
    price DECIMAL(10, 2) NOT NULL COMMENT '入库单价',
    remark VARCHAR(500) COMMENT '备注',
    inbound_date DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '入库日期',
    user_id INT NOT NULL COMMENT '操作用户ID',
    FOREIGN KEY (material_id) REFERENCES materials(id) ON DELETE CASCADE,
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    INDEX idx_material_id (material_id),
    INDEX idx_warehouse_id (warehouse_id),
    INDEX idx_inbound_date (inbound_date),
    INDEX idx_user_id (user_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='入库记录表';

-- ============================================
-- 6. 出库记录表 (outbound_records)
-- 用于记录物料出库信息
-- ============================================
CREATE TABLE outbound_records (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '出库记录ID',
    material_id INT NOT NULL COMMENT '物料ID',
    warehouse_id INT NOT NULL COMMENT '仓库ID',
    quantity INT NOT NULL COMMENT '出库数量',
    price DECIMAL(10, 2) DEFAULT 0.00 COMMENT '出库单价(用于统计)',
    remark VARCHAR(500) COMMENT '备注',
    outbound_date DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '出库日期',
    user_id INT NOT NULL COMMENT '操作用户ID',
    FOREIGN KEY (material_id) REFERENCES materials(id) ON DELETE CASCADE,
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    INDEX idx_material_id (material_id),
    INDEX idx_warehouse_id (warehouse_id),
    INDEX idx_outbound_date (outbound_date),
    INDEX idx_user_id (user_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='出库记录表';

-- ============================================
-- 初始化数据
-- ============================================

-- 插入默认管理员用户 (密码: admin123，使用BCrypt加密)
-- 注意：这是BCrypt加密后的 "admin123"，你可以根据需要修改
INSERT INTO users (username, password_hash, role) VALUES 
('admin', '$2a$11$N0DkVHuNHLLCCXKoMZsMAO2zq8vVxiEFMg9H7K9kVJ8LCCXKoMZsM', '管理员'),
('user1', '$2a$11$N0DkVHuNHLLCCXKoMZsMAO2zq8vVxiEFMg9H7K9kVJ8LCCXKoMZsM', '普通用户');

-- 插入示例仓库
INSERT INTO warehouses (name, location) VALUES 
('主仓库', '一楼A区'),
('副仓库', '二楼B区'),
('原料仓库', '地下一层'),
('成品仓库', '三楼C区');

-- 插入示例物料
INSERT INTO materials (material_code, name, spec, unit) VALUES 
('MAT001', '螺丝', 'M8x20', '个'),
('MAT002', '螺丝', 'M10x25', '个'),
('MAT003', '螺母', 'M8', '个'),
('MAT004', '螺母', 'M10', '个'),
('MAT005', '钢板', '1000x2000x2mm', '张'),
('MAT006', '钢板', '1000x2000x3mm', '张'),
('MAT007', '铝型材', '40x40', '米'),
('MAT008', '铝型材', '50x50', '米'),
('MAT009', '焊条', 'J422 φ3.2', '公斤'),
('MAT010', '切削液', '通用型', '升');

-- 插入示例库存数据
INSERT INTO inventory (material_id, warehouse_id, quantity, unit_price, total_amount) VALUES 
(1, 1, 1000, 0.50, 500.00),
(2, 1, 800, 0.60, 480.00),
(3, 1, 500, 0.30, 150.00),
(4, 2, 600, 0.35, 210.00),
(5, 3, 100, 150.00, 15000.00),
(6, 3, 80, 180.00, 14400.00),
(7, 1, 200, 25.00, 5000.00),
(8, 1, 150, 30.00, 4500.00),
(9, 4, 50, 45.00, 2250.00),
(10, 4, 100, 35.00, 3500.00);

-- 插入示例入库记录
INSERT INTO inbound_records (material_id, warehouse_id, quantity, price, remark, inbound_date, user_id) VALUES 
(1, 1, 1000, 0.50, '初始入库', '2024-01-15 09:00:00', 1),
(2, 1, 800, 0.60, '初始入库', '2024-01-15 09:30:00', 1),
(5, 3, 100, 150.00, '采购入库', '2024-01-20 10:00:00', 1),
(7, 1, 200, 25.00, '采购入库', '2024-02-01 14:00:00', 1);

-- 插入示例出库记录
INSERT INTO outbound_records (material_id, warehouse_id, quantity, price, remark, outbound_date, user_id) VALUES 
(1, 1, 50, 0.50, '生产领料', '2024-02-10 10:00:00', 1),
(5, 3, 10, 150.00, '项目使用', '2024-02-15 11:00:00', 1);

-- ============================================
-- 创建视图（可选）
-- ============================================

-- 库存详情视图
CREATE VIEW v_inventory_detail AS
SELECT 
    i.id,
    m.material_code AS 物料编码,
    m.name AS 物料名称,
    m.spec AS 规格,
    m.unit AS 单位,
    w.name AS 仓库名称,
    w.location AS 仓库位置,
    i.quantity AS 库存数量,
    i.unit_price AS 单价,
    i.total_amount AS 总金额,
    i.last_updated AS 最后更新时间
FROM inventory i
INNER JOIN materials m ON i.material_id = m.id
INNER JOIN warehouses w ON i.warehouse_id = w.id;

-- 入库记录详情视图
CREATE VIEW v_inbound_detail AS
SELECT 
    ir.id,
    m.material_code AS 物料编码,
    m.name AS 物料名称,
    m.spec AS 规格,
    w.name AS 仓库名称,
    ir.quantity AS 入库数量,
    ir.price AS 入库单价,
    ir.quantity * ir.price AS 入库金额,
    ir.remark AS 备注,
    ir.inbound_date AS 入库日期,
    u.username AS 操作人
FROM inbound_records ir
INNER JOIN materials m ON ir.material_id = m.id
INNER JOIN warehouses w ON ir.warehouse_id = w.id
INNER JOIN users u ON ir.user_id = u.id;

-- 出库记录详情视图
CREATE VIEW v_outbound_detail AS
SELECT 
    obr.id,
    m.material_code AS 物料编码,
    m.name AS 物料名称,
    m.spec AS 规格,
    w.name AS 仓库名称,
    obr.quantity AS 出库数量,
    obr.price AS 出库单价,
    obr.quantity * obr.price AS 出库金额,
    obr.remark AS 备注,
    obr.outbound_date AS 出库日期,
    u.username AS 操作人
FROM outbound_records obr
INNER JOIN materials m ON obr.material_id = m.id
INNER JOIN warehouses w ON obr.warehouse_id = w.id
INNER JOIN users u ON obr.user_id = u.id;

-- ============================================
-- 创建存储过程（可选）
-- ============================================

-- 获取物料库存汇总
DELIMITER //
CREATE PROCEDURE sp_get_material_inventory_summary(IN p_material_id INT)
BEGIN
    SELECT 
        m.material_code,
        m.name,
        m.spec,
        w.name AS warehouse,
        i.quantity,
        i.unit_price,
        i.total_amount
    FROM inventory i
    INNER JOIN materials m ON i.material_id = m.id
    INNER JOIN warehouses w ON i.warehouse_id = w.id
    WHERE i.material_id = p_material_id;
END //
DELIMITER ;

-- ============================================
-- 数据库初始化完成
-- ============================================

-- 显示所有表
SHOW TABLES;

-- 显示数据库信息
SELECT 
    '数据库初始化完成！' AS 状态,
    COUNT(*) AS 表数量
FROM information_schema.tables 
WHERE table_schema = 'winwms' AND table_type = 'BASE TABLE';

-- 显示初始数据统计
SELECT 
    '用户数' AS 项目, COUNT(*) AS 数量 FROM users
UNION ALL
SELECT '仓库数', COUNT(*) FROM warehouses
UNION ALL
SELECT '物料数', COUNT(*) FROM materials
UNION ALL
SELECT '库存记录数', COUNT(*) FROM inventory
UNION ALL
SELECT '入库记录数', COUNT(*) FROM inbound_records
UNION ALL
SELECT '出库记录数', COUNT(*) FROM outbound_records;
