-- 仓储管理系统 (WMS) 数据库表创建脚本
-- 数据库: wms_db
-- ------------------------------------------------------

-- 如果存在，则删除旧表，以便重新创建
DROP TABLE IF EXISTS `outbound_records`;
DROP TABLE IF EXISTS `inbound_records`;
DROP TABLE IF EXISTS `inventory`;
DROP TABLE IF EXISTS `materials`;
DROP TABLE IF EXISTS `warehouses`;
DROP TABLE IF EXISTS `users`;


--
-- 表结构 `users`
--
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `role` varchar(50) NOT NULL,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 表结构 `warehouses`
--
CREATE TABLE `warehouses` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `location` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 表结构 `materials`
--
CREATE TABLE `materials` (
  `id` int NOT NULL AUTO_INCREMENT,
  `material_code` varchar(100) NOT NULL,
  `name` varchar(255) NOT NULL,
  `spec` varchar(255) DEFAULT NULL,
  `unit` varchar(50) NOT NULL,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `material_code_UNIQUE` (`material_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 表结构 `inventory`
--
CREATE TABLE `inventory` (
  `warehouse_id` int NOT NULL,
  `material_id` int NOT NULL,
  `quantity` int NOT NULL DEFAULT '0',
  `unit_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `total_amount` decimal(18,2) NOT NULL DEFAULT '0.00',
  `last_updated` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`warehouse_id`,`material_id`),
  KEY `fk_inventory_materials_idx` (`material_id`),
  CONSTRAINT `fk_inventory_materials` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_inventory_warehouses` FOREIGN KEY (`warehouse_id`) REFERENCES `warehouses` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 表结构 `inbound_records`
--
CREATE TABLE `inbound_records` (
  `id` int NOT NULL AUTO_INCREMENT,
  `material_id` int NOT NULL,
  `warehouse_id` int NOT NULL,
  `user_id` int NOT NULL,
  `quantity` int NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `inbound_date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_inbound_materials_idx` (`material_id`),
  KEY `fk_inbound_warehouses_idx` (`warehouse_id`),
  KEY `fk_inbound_users_idx` (`user_id`),
  CONSTRAINT `fk_inbound_materials` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`),
  CONSTRAINT `fk_inbound_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`),
  CONSTRAINT `fk_inbound_warehouses` FOREIGN KEY (`warehouse_id`) REFERENCES `warehouses` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 表结构 `outbound_records`
--
CREATE TABLE `outbound_records` (
  `id` int NOT NULL AUTO_INCREMENT,
  `material_id` int NOT NULL,
  `warehouse_id` int NOT NULL,
  `user_id` int NOT NULL,
  `quantity` int NOT NULL,
  `outbound_date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_outbound_materials_idx` (`material_id`),
  KEY `fk_outbound_warehouses_idx` (`warehouse_id`),
  KEY `fk_outbound_users_idx` (`user_id`),
  CONSTRAINT `fk_outbound_materials` FOREIGN KEY (`material_id`) REFERENCES `materials` (`id`),
  CONSTRAINT `fk_outbound_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`),
  CONSTRAINT `fk_outbound_warehouses` FOREIGN KEY (`warehouse_id`) REFERENCES `warehouses` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 插入一些示例数据 (可选)
INSERT INTO `users` (`username`, `password_hash`, `role`) VALUES ('admin', '$2a$11$FakeHashForExamplePurpose123u', 'admin');
INSERT INTO `warehouses` (`name`, `location`) VALUES ('主仓库', 'A区1栋');
INSERT INTO `materials` (`material_code`, `name`, `spec`, `unit`) VALUES ('MT-001', '螺丝钉', 'M5*20', '个');
