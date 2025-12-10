-- =================================================================================
-- WinWMS 仓储管理系统 - MySQL 数据库初始化脚本
-- 版本: 1.0
-- 描述: 该脚本用于创建 `winwms` 数据库、所有必要的表结构，并插入初始测试数据。
-- =================================================================================

-- ----------------------------
-- 数据库创建
-- ----------------------------
-- 如果 `winwms` 数据库已存在，则删除它，以确保一个干净的开始
DROP DATABASE IF EXISTS `winwms`;

-- 创建 `winwms` 数据库，并设置默认字符集为 utf8mb4
CREATE DATABASE `winwms` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- 切换到新创建的 `winwms` 数据库
USE `winwms`;

-- ----------------------------
-- 1. 用户表 (users)
-- 描述: 存储系统用户信息，包括登录凭证和角色。
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '用户ID，主键',
  `username` VARCHAR(50) NOT NULL COMMENT '用户名，必须唯一',
  `password_hash` VARCHAR(255) NOT NULL COMMENT '加密后的密码哈希 (使用 BCrypt)',
  `role` VARCHAR(20) NOT NULL DEFAULT 'Operator' COMMENT '用户角色 (例如: Admin, Operator)',
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '用户创建时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='用户表';

-- ----------------------------
-- 2. 仓库表 (warehouses)
-- 描述: 存储仓库的基本信息。
-- ----------------------------
DROP TABLE IF EXISTS `warehouses`;
CREATE TABLE `warehouses` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '仓库ID，主键',
  `name` VARCHAR(100) NOT NULL COMMENT '仓库名称，必须唯一',
  `location` VARCHAR(255) DEFAULT NULL COMMENT '仓库位置描述',
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_warehouse_name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='仓库信息表';

-- ----------------------------
-- 3. 物料表 (materials)
-- 描述: 存储所有物料的详细信息，包括编码、名称、规格和标准单价。
-- ----------------------------
DROP TABLE IF EXISTS `materials`;
CREATE TABLE `materials` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '物料ID，主键',
  `material_code` VARCHAR(50) NOT NULL COMMENT '物料编码',
  `name` VARCHAR(100) NOT NULL COMMENT '物料名称',
  `spec` VARCHAR(100) NOT NULL COMMENT '物料规格',
  `unit` VARCHAR(20) DEFAULT '个' COMMENT '计量单位',
  `price` DECIMAL(10, 2) NOT NULL DEFAULT 0.00 COMMENT '标准单价 (用于入库)',
  `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_material_code_spec` (`material_code`, `spec`) COMMENT '物料编码和规格组合必须唯一'
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='物料信息表';

-- ----------------------------
-- 4. 入库记录表 (inbound_records)
-- 描述: 记录每一次物料入库的操作历史。
-- ----------------------------
DROP TABLE IF EXISTS `inbound_records`;
CREATE TABLE `inbound_records` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '入库记录ID，主键',
  `material_id` INT NOT NULL COMMENT '物料ID (外键)',
  `warehouse_id` INT NOT NULL COMMENT '仓库ID (外键)',
  `user_id` INT NOT NULL COMMENT '操作员ID (外键)',
  `quantity` INT NOT NULL COMMENT '入库数量',
  `price` DECIMAL(10, 2) NOT NULL COMMENT '入库时的单价',
  `remark` TEXT DEFAULT NULL COMMENT '备注信息',
  `inbound_date` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '入库时间',
  PRIMARY KEY (`id`),
  KEY `idx_material_id` (`material_id`),
  KEY `idx_warehouse_id` (`warehouse_id`),
  CONSTRAINT `fk_inbound_material` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_inbound_warehouse` FOREIGN KEY (`warehouse_id`) REFERENCES `warehouses` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_inbound_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='入库记录表';

-- ----------------------------
-- 5. 出库记录表 (outbound_records)
-- 描述: 记录每一次物料出库的操作历史。
-- ----------------------------
DROP TABLE IF EXISTS `outbound_records`;
CREATE TABLE `outbound_records` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '出库记录ID，主键',
  `material_id` INT NOT NULL COMMENT '物料ID (外键)',
  `warehouse_id` INT NOT NULL COMMENT '仓库ID (外键)',
  `user_id` INT NOT NULL COMMENT '操作员ID (外键)',
  `quantity` INT NOT NULL COMMENT '出库数量',
  `price` DECIMAL(10, 2) NOT NULL COMMENT '出库时的成本单价 (FIFO计算得出)',
  `remark` TEXT DEFAULT NULL COMMENT '备注信息',
  `outbound_date` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '出库时间',
  PRIMARY KEY (`id`),
  KEY `idx_material_id` (`material_id`),
  KEY `idx_warehouse_id` (`warehouse_id`),
  CONSTRAINT `fk_outbound_material` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_outbound_warehouse` FOREIGN KEY (`warehouse_id`) REFERENCES `warehouses` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_outbound_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='出库记录表';

-- ----------------------------
-- 6. 库存批次表 (inventory_batches)
-- 描述: 存储每个物料的库存批次信息，用于实现先进先出(FIFO)成本计算。
-- ----------------------------
DROP TABLE IF EXISTS `inventory_batches`;
CREATE TABLE `inventory_batches` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '批次ID，主键',
  `material_id` INT NOT NULL COMMENT '物料ID (外键)',
  `warehouse_id` INT NOT NULL COMMENT '仓库ID (外键)',
  `inbound_record_id` INT NOT NULL COMMENT '关联的入库记录ID (外键)',
  `batch_no` VARCHAR(50) NOT NULL COMMENT '批次号',
  `quantity` INT NOT NULL COMMENT '当前批次剩余数量',
  `unit_price` DECIMAL(10, 2) NOT NULL COMMENT '该批次的单位成本',
  `total_amount` DECIMAL(12, 2) NOT NULL COMMENT '该批次的总金额',
  `inbound_date` TIMESTAMP NOT NULL COMMENT '批次入库时间',
  `remark` TEXT DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_batch_no` (`batch_no`),
  KEY `idx_material_warehouse` (`material_id`, `warehouse_id`),
  CONSTRAINT `fk_batch_material` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_batch_warehouse` FOREIGN KEY (`warehouse_id`) REFERENCES `warehouses` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_batch_inbound_record` FOREIGN KEY (`inbound_record_id`) REFERENCES `inbound_records` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='库存批次表 (用于FIFO)';

-- ----------------------------
-- 7. 库存汇总表 (inventory)
-- 描述: 实时汇总每个物料在不同仓库的库存总量和加权平均成本。
-- ----------------------------
DROP TABLE IF EXISTS `inventory`;
CREATE TABLE `inventory` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '库存ID，主键',
  `material_id` INT NOT NULL COMMENT '物料ID (外键)',
  `warehouse_id` INT NOT NULL COMMENT '仓库ID (外键)',
  `quantity` INT NOT NULL COMMENT '当前总库存数量',
  `unit_price` DECIMAL(10, 2) NOT NULL COMMENT '加权平均单价',
  `total_amount` DECIMAL(12, 2) NOT NULL COMMENT '库存总金额',
  `last_updated` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后更新时间',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_material_warehouse` (`material_id`, `warehouse_id`),
  CONSTRAINT `fk_inventory_material` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_inventory_warehouse` FOREIGN KEY (`warehouse_id`) REFERENCES `warehouses` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='库存汇总表';


-- =================================================================================
-- 插入测试数据
-- =================================================================================

-- ----------------------------
-- 1. 插入用户数据
-- 密码 "123456" 的 BCrypt 哈希值
-- ----------------------------
INSERT INTO `users` (`id`, `username`, `password_hash`, `role`) VALUES
(1, 'admin', '$2a$11$D.f5jXJ4x4gH.wO9.p5s9.SjL4wJg2pG3j.X/lY.z.f8U.zH.zH.z', 'Admin'),
(2, 'operator01', '$2a$11$D.f5jXJ4x4gH.wO9.p5s9.SjL4wJg2pG3j.X/lY.z.f8U.zH.zH.z', 'Operator');

-- ----------------------------
-- 2. 插入仓库数据
-- ----------------------------
INSERT INTO `warehouses` (`id`, `name`, `location`) VALUES
(1, '主仓库A', '一号楼东侧'),
(2, '备用仓库B', '三号楼南侧');

-- ----------------------------
-- 3. 插入物料数据
-- ----------------------------
INSERT INTO `materials` (`id`, `material_code`, `name`, `spec`, `unit`, `price`) VALUES
(1, 'CPU-I7', '中央处理器', 'Intel Core i7-13700K', '个', 2800.00),
(2, 'CPU-I9', '中央处理器', 'Intel Core i9-13900K', '个', 4500.00),
(3, 'MEM-DDR5-16', '内存条', 'DDR5 16GB 5600MHz', '条', 350.50),
(4, 'MEM-DDR5-32', '内存条', 'DDR5 32GB 5600MHz', '条', 680.00),
(5, 'SSD-NVME-1T', '固态硬盘', 'NVMe M.2 1TB', '个', 450.00),
(6, 'SSD-NVME-2T', '固态硬盘', 'NVMe M.2 2TB', '个', 899.99),
(7, 'GPU-4070', '显卡', 'NVIDIA RTX 4070', '张', 4799.00);

-- ----------------------------
-- 4. 插入入库、批次和库存数据 (模拟操作)
-- 这是一个简化的过程，实际应用中应由程序通过事务完成
-- ----------------------------
-- 第一次入库: 10个 i7-13700K 到主仓库A
INSERT INTO `inbound_records` (`id`, `material_id`, `warehouse_id`, `user_id`, `quantity`, `price`, `inbound_date`) VALUES (1, 1, 1, 1, 10, 2800.00, '2023-10-01 10:00:00');
INSERT INTO `inventory_batches` (`id`, `material_id`, `warehouse_id`, `inbound_record_id`, `batch_no`, `quantity`, `unit_price`, `total_amount`, `inbound_date`) VALUES (1, 1, 1, 1, 'PC00010120231001001', 10, 2800.00, 28000.00, '2023-10-01 10:00:00');
INSERT INTO `inventory` (`material_id`, `warehouse_id`, `quantity`, `unit_price`, `total_amount`) VALUES (1, 1, 10, 2800.00, 28000.00);

-- 第二次入库: 20条 16G内存 到主仓库A
INSERT INTO `inbound_records` (`id`, `material_id`, `warehouse_id`, `user_id`, `quantity`, `price`, `inbound_date`) VALUES (2, 3, 1, 2, 20, 350.50, '2023-10-02 11:00:00');
INSERT INTO `inventory_batches` (`id`, `material_id`, `warehouse_id`, `inbound_record_id`, `batch_no`, `quantity`, `unit_price`, `total_amount`, `inbound_date`) VALUES (2, 3, 1, 2, 'PC00030120231002001', 20, 350.50, 7010.00, '2023-10-02 11:00:00');
INSERT INTO `inventory` (`material_id`, `warehouse_id`, `quantity`, `unit_price`, `total_amount`) VALUES (3, 1, 20, 350.50, 7010.00);

-- 第三次入库: 5个 i7-13700K 到主仓库A (价格上涨)
INSERT INTO `inbound_records` (`id`, `material_id`, `warehouse_id`, `user_id`, `quantity`, `price`, `inbound_date`) VALUES (3, 1, 1, 1, 5, 2850.00, '2023-10-10 09:30:00');
INSERT INTO `inventory_batches` (`id`, `material_id`, `warehouse_id`, `inbound_record_id`, `batch_no`, `quantity`, `unit_price`, `total_amount`, `inbound_date`) VALUES (3, 1, 1, 3, 'PC00010120231010001', 5, 2850.00, 14250.00, '2023-10-10 09:30:00');
-- 更新库存汇总 (加权平均)
-- (10*2800 + 5*2850) / (10+5) = 2816.67
UPDATE `inventory` SET `quantity` = 15, `total_amount` = 42250.00, `unit_price` = 2816.67 WHERE `material_id` = 1 AND `warehouse_id` = 1;

-- 第四次入库: 5张 RTX 4070 到备用仓库B
INSERT INTO `inbound_records` (`id`, `material_id`, `warehouse_id`, `user_id`, `quantity`, `price`, `inbound_date`) VALUES (4, 7, 2, 2, 5, 4799.00, '2023-10-11 14:00:00');
INSERT INTO `inventory_batches` (`id`, `material_id`, `warehouse_id`, `inbound_record_id`, `batch_no`, `quantity`, `unit_price`, `total_amount`, `inbound_date`) VALUES (4, 7, 2, 4, 'PC00070220231011001', 5, 4799.00, 23995.00, '2023-10-11 14:00:00');
INSERT INTO `inventory` (`material_id`, `warehouse_id`, `quantity`, `unit_price`, `total_amount`) VALUES (7, 2, 5, 4799.00, 23995.00);


-- ----------------------------
-- 5. 插入出库数据 (模拟操作)
-- 这是一个简化的过程，实际应用中应由程序通过事务完成
-- ----------------------------
-- 第一次出库: 2个 i7-13700K 从主仓库A
-- FIFO: 从第一批出库，成本2800.00
INSERT INTO `outbound_records` (`id`, `material_id`, `warehouse_id`, `user_id`, `quantity`, `price`, `outbound_date`) VALUES (1, 1, 1, 2, 2, 2800.00, '2023-10-15 16:00:00');
-- 更新第一批次数量
UPDATE `inventory_batches` SET `quantity` = 8, `total_amount` = 22400.00 WHERE `id` = 1;
-- 更新库存汇总
-- (8*2800 + 5*2850) / (8+5) = 2819.23
UPDATE `inventory` SET `quantity` = 13, `total_amount` = 36650.00, `unit_price` = 2819.23 WHERE `material_id` = 1 AND `warehouse_id` = 1;


-- 脚本结束
SELECT '数据库和测试数据创建成功！' AS '状态';