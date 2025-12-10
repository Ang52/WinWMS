-- ============================================
-- 为物料表添加标准单价字段
-- 用途: 将价格管理从入库环节移到物料管理
-- ============================================

USE winwms;

-- 检查并添加 price 列
ALTER TABLE materials 
ADD COLUMN IF NOT EXISTS price DECIMAL(10, 2) DEFAULT 0 COMMENT '标准单价' AFTER unit;

-- 为现有物料设置默认价格 (可根据实际情况调整)
-- 这里设置一些示例价格
UPDATE materials SET price = 0.52 WHERE material_code = 'MAT001';  -- 螺丝 M8x20
UPDATE materials SET price = 0.75 WHERE material_code = 'MAT002';  -- 螺丝 M10x25
UPDATE materials SET price = 120.00 WHERE material_code = 'MAT003';  -- 钢板 1000x2000x2mm
UPDATE materials SET price = 150.00 WHERE material_code = 'MAT004';  -- 钢板 1200x2500x3mm
UPDATE materials SET price = 13.75 WHERE material_code = 'MAT005';  -- 轴承 6204-2RS
UPDATE materials SET price = 25.00 WHERE material_code = 'MAT006';  -- 铝型材 4040-R

-- 验证修改
SELECT 
    material_code AS '物料编码', 
    name AS '名称', 
    spec AS '规格', 
    unit AS '单位',
    price AS '标准单价', 
    created_at AS '创建时间' 
FROM materials
ORDER BY material_code;

SELECT '? 价格字段添加成功！物料表已更新。' AS 状态;
