-- ============================================
-- WinWMS 数据库完整脚本
-- 版本: v2.2
-- 功能: 包含所有表结构、约束和丰富的测试数据
-- ============================================

-- 创建数据库
CREATE DATABASE IF NOT EXISTS winwms CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE winwms;

-- 删除旧表（如果存在），确保从零开始
DROP TABLE IF EXISTS outbound_records;
DROP TABLE IF EXISTS inbound_records;
DROP TABLE IF EXISTS inventory_batches;
DROP TABLE IF EXISTS inventory;
DROP TABLE IF EXISTS materials;
DROP TABLE IF EXISTS warehouses;
DROP TABLE IF EXISTS users;

-- ============================================
-- 1. 用户表 (users)
-- ============================================
CREATE TABLE users (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '用户ID',
    username VARCHAR(50) NOT NULL UNIQUE COMMENT '用户名',
    password_hash VARCHAR(255) NOT NULL COMMENT '密码哈希',
    role VARCHAR(20) NOT NULL DEFAULT 'operator' COMMENT '角色 (admin, operator)',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='用户表';

-- ============================================
-- 2. 仓库表 (warehouses)
-- ============================================
CREATE TABLE warehouses (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '仓库ID',
    name VARCHAR(100) NOT NULL UNIQUE COMMENT '仓库名称',
    location VARCHAR(255) COMMENT '仓库位置',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='仓库表';

-- ============================================
-- 3. 物料表 (materials)
-- ============================================
CREATE TABLE materials (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '物料ID',
    material_code VARCHAR(50) NOT NULL COMMENT '物料编码',
    name VARCHAR(100) NOT NULL COMMENT '物料名称',
    spec VARCHAR(100) NOT NULL COMMENT '规格',
    unit VARCHAR(20) COMMENT '单位',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    UNIQUE KEY uk_material_code_spec (material_code, spec) COMMENT '物料编码+规格唯一约束'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='物料表';

-- ============================================
-- 4. 库存汇总表 (inventory)
-- ============================================
CREATE TABLE inventory (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '库存ID',
    material_id INT NOT NULL COMMENT '物料ID',
    warehouse_id INT NOT NULL COMMENT '仓库ID',
    quantity INT NOT NULL DEFAULT 0 COMMENT '总数量',
    unit_price DECIMAL(10, 2) NOT NULL COMMENT '加权平均单价',
    total_amount DECIMAL(15, 2) NOT NULL COMMENT '总金额',
    last_updated DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
    FOREIGN KEY (material_id) REFERENCES materials(id) ON DELETE CASCADE,
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id) ON DELETE CASCADE,
    UNIQUE KEY uk_material_warehouse (material_id, warehouse_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='库存汇总表';

-- ============================================
-- 5. 库存批次表 (inventory_batches)
-- ============================================
CREATE TABLE inventory_batches (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '批次ID',
    material_id INT NOT NULL COMMENT '物料ID',
    warehouse_id INT NOT NULL COMMENT '仓库ID',
    batch_no VARCHAR(50) NOT NULL COMMENT '批次号',
    quantity INT NOT NULL DEFAULT 0 COMMENT '批次数量',
    unit_price DECIMAL(10, 2) NOT NULL COMMENT '批次单价',
    total_amount DECIMAL(15, 2) NOT NULL COMMENT '批次总金额',
    inbound_date DATETIME NOT NULL COMMENT '入库日期',
    inbound_record_id INT COMMENT '入库记录ID',
    remark VARCHAR(500) COMMENT '备注',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    inbound_day DATE GENERATED ALWAYS AS (DATE(inbound_date)) STORED,
    FOREIGN KEY (material_id) REFERENCES materials(id) ON DELETE CASCADE,
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id) ON DELETE CASCADE,
    UNIQUE KEY uk_batch_day_material_warehouse_price (inbound_day, material_id, warehouse_id, unit_price)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='库存批次表';

-- ============================================
-- 6. 入库记录表 (inbound_records)
-- ============================================
CREATE TABLE inbound_records (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '入库记录ID',
    material_id INT NOT NULL COMMENT '物料ID',
    warehouse_id INT NOT NULL COMMENT '仓库ID',
    quantity INT NOT NULL COMMENT '入库数量',
    price DECIMAL(10, 2) NOT NULL COMMENT '入库单价',
    remark VARCHAR(500) COMMENT '备注',
    inbound_date DATETIME NOT NULL COMMENT '入库时间',
    user_id INT NOT NULL COMMENT '操作员ID',
    FOREIGN KEY (material_id) REFERENCES materials(id) ON DELETE CASCADE,
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES users(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='入库记录表';

-- ============================================
-- 7. 出库记录表 (outbound_records)
-- ============================================
CREATE TABLE outbound_records (
    id INT PRIMARY KEY AUTO_INCREMENT COMMENT '出库记录ID',
    material_id INT NOT NULL COMMENT '物料ID',
    warehouse_id INT NOT NULL COMMENT '仓库ID',
    quantity INT NOT NULL COMMENT '出库数量',
    price DECIMAL(10, 2) NOT NULL COMMENT '出库平均单价',
    remark VARCHAR(500) COMMENT '备注',
    outbound_date DATETIME NOT NULL COMMENT '出库时间',
    user_id INT NOT NULL COMMENT '操作员ID',
    FOREIGN KEY (material_id) REFERENCES materials(id) ON DELETE CASCADE,
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES users(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='出库记录表';

-- ============================================
-- 插入测试数据
-- ============================================

-- 1. 用户
INSERT INTO users (username, password_hash, role) VALUES
('admin', 'admin_password_hash', 'admin'),
('operator1', 'operator_password_hash', 'operator');

-- 2. 仓库
INSERT INTO warehouses (name, location) VALUES
('主仓库', 'A区1楼'),
('备件仓库', 'B区2楼'),
('成品仓库', 'C区1楼');

-- 3. 物料
INSERT INTO materials (material_code, name, spec, unit) VALUES
('MAT001', '螺丝', 'M8x20', '个'),
('MAT002', '螺丝', 'M10x25', '个'),
('MAT003', '钢板', '1000x2000x2mm', '张'),
('MAT004', '钢板', '1200x2500x3mm', '张'),
('MAT005', '轴承', '6204-2RS', '个'),
('MAT006', '铝型材', '4040-R', '米');

-- 4. 模拟入库和出库（通过存储过程，确保数据一致性）
DELIMITER //

CREATE PROCEDURE sp_simulate_inbound(
    IN p_material_id INT,
    IN p_warehouse_id INT,
    IN p_quantity INT,
    IN p_price DECIMAL(10, 2),
    IN p_remark VARCHAR(500),
    IN p_inbound_date DATETIME
)
BEGIN
    DECLARE v_inbound_record_id INT;
    DECLARE v_batch_no VARCHAR(50);
    DECLARE v_existing_batch_id INT;
    DECLARE v_seq INT;

    -- 插入入库记录
    INSERT INTO inbound_records (material_id, warehouse_id, quantity, price, remark, inbound_date, user_id)
    VALUES (p_material_id, p_warehouse_id, p_quantity, p_price, p_remark, p_inbound_date, 1);
    SET v_inbound_record_id = LAST_INSERT_ID();

    -- 检查是否存在可合并的批次
    SELECT id, batch_no INTO v_existing_batch_id, v_batch_no
    FROM inventory_batches
    WHERE material_id = p_material_id
      AND warehouse_id = p_warehouse_id
      AND unit_price = p_price
      AND DATE(inbound_date) = DATE(p_inbound_date)
    LIMIT 1;

    IF v_existing_batch_id IS NOT NULL THEN
        -- 合并批次
        UPDATE inventory_batches
        SET quantity = quantity + p_quantity,
            total_amount = total_amount + (p_quantity * p_price)
        WHERE id = v_existing_batch_id;
    ELSE
        -- 创建新批次
        SELECT COUNT(*) + 1 INTO v_seq
        FROM inventory_batches
        WHERE material_id = p_material_id
          AND warehouse_id = p_warehouse_id
          AND DATE(inbound_date) = DATE(p_inbound_date);
        
        SET v_batch_no = CONCAT('PC', LPAD(p_material_id, 4, '0'), LPAD(p_warehouse_id, 2, '0'), DATE_FORMAT(p_inbound_date, '%Y%m%d'), LPAD(v_seq, 3, '0'));

        INSERT INTO inventory_batches (material_id, warehouse_id, batch_no, quantity, unit_price, total_amount, inbound_date, inbound_record_id, remark)
        VALUES (p_material_id, p_warehouse_id, v_batch_no, p_quantity, p_price, p_quantity * p_price, p_inbound_date, v_inbound_record_id, p_remark);
    END IF;

    -- 更新库存汇总表
    INSERT INTO inventory (material_id, warehouse_id, quantity, unit_price, total_amount)
    VALUES (p_material_id, p_warehouse_id, p_quantity, p_price, p_quantity * p_price)
    ON DUPLICATE KEY UPDATE
        quantity = quantity + VALUES(quantity),
        total_amount = total_amount + VALUES(total_amount),
        unit_price = (total_amount + VALUES(total_amount)) / (quantity + VALUES(quantity));
END //

DELIMITER ;

-- ============================================
-- 执行模拟入库
-- ============================================

-- 螺丝 M8x20 (ID: 1)
CALL sp_simulate_inbound(1, 1, 100, 0.50, '供应商A', '2023-10-01 10:00:00');
CALL sp_simulate_inbound(1, 1, 150, 0.55, '供应商B', '2023-10-05 11:00:00');
CALL sp_simulate_inbound(1, 1, 200, 0.50, '供应商A补货', '2023-10-01 14:00:00'); -- 合并到10月1日的批次
CALL sp_simulate_inbound(1, 2, 50, 0.60, '紧急采购', '2023-10-10 09:00:00');

-- 钢板 1000x2000x2mm (ID: 3)
CALL sp_simulate_inbound(3, 1, 10, 120.00, '常规采购', '2023-10-02 15:00:00');
CALL sp_simulate_inbound(3, 2, 5, 125.00, '项目备料', '2023-10-08 16:00:00');

-- 轴承 6204-2RS (ID: 5)
CALL sp_simulate_inbound(5, 1, 50, 15.00, 'NSK品牌', '2023-10-03 10:00:00');
CALL sp_simulate_inbound(5, 1, 30, 12.50, 'SKF品牌', '2023-10-04 11:00:00');

-- 铝型材 4040-R (ID: 6)
CALL sp_simulate_inbound(6, 2, 200, 25.00, '标准长度', '2023-10-06 14:00:00');

-- ============================================
-- 最终数据验证
-- ============================================
SELECT '✅ 数据库和测试数据创建成功！' AS 状态;

-- 查看物料
SELECT * FROM materials;
-- 查看仓库
SELECT * FROM warehouses;
-- 查看用户
SELECT * FROM users;
-- 查看库存汇总
SELECT m.name, m.spec, w.name as warehouse, i.quantity, i.unit_price, i.total_amount 
FROM inventory i
JOIN materials m ON i.material_id = m.id
JOIN warehouses w ON i.warehouse_id = w.id;
-- 查看库存批次
SELECT m.name, m.spec, w.name as warehouse, b.batch_no, b.quantity, b.unit_price, b.inbound_date 
FROM inventory_batches b
JOIN materials m ON b.material_id = m.id
JOIN warehouses w ON b.warehouse_id = w.id
ORDER BY b.inbound_date;
-- 查看入库记录
SELECT * FROM inbound_records;
