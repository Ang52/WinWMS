# 仓储管理系统 E-R 图

这是一个基于 Mermaid.js 格式的实体关系图，描述了仓储管理系统的核心数据结构。

```mermaid
erDiagram
    users {
        int id PK "用户ID"
        varchar username "用户名"
        varchar password_hash "密码哈希"
        varchar role "角色 (e.g., admin, user)"
        datetime created_at "创建时间"
    }

    materials {
        int id PK "物料ID"
        varchar material_code UK "物资编号"
        varchar name "名称"
        varchar spec "规格"
        varchar unit "计量单位"
        datetime created_at "创建时间"
    }

    warehouses {
        int id PK "仓库ID"
        varchar name UK "仓库名"
        varchar location "位置"
        datetime created_at "创建时间"
    }

    inventory {
        int warehouse_id PK,FK "仓库ID"
        int material_id PK,FK "物料ID"
        int quantity "库存数量"
        decimal unit_price "单价"
        decimal total_amount "总金额"
        datetime last_updated "最后更新时间"
    }

    inbound_records {
        int id PK "入库记录ID"
        int material_id FK "物料ID"
        int warehouse_id FK "仓库ID"
        int quantity "入库数量"
        decimal price "入库单价"
        datetime inbound_date "入库时间"
        int user_id FK "操作员ID"
    }

    outbound_records {
        int id PK "出库记录ID"
        int material_id FK "物料ID"
        int warehouse_id FK "仓库ID"
        int quantity "出库数量"
        datetime outbound_date "出库时间"
        int user_id FK "操作员ID"
    }

    users ||--o{ inbound_records : "records"
    users ||--o{ outbound_records : "records"
    materials ||--o{ inventory : "has"
    materials ||--o{ inbound_records : "details"
    materials ||--o{ outbound_records : "details"
    warehouses ||--o{ inventory : "contains"
    warehouses ||--o{ inbound_records : "to"
    warehouses ||--o{ outbound_records : "from"
```

### 表关系说明：

*   一个 `users` (用户) 可以有多条 `inbound_records` (入库记录) 和 `outbound_records` (出库记录)。
*   一个 `materials` (物料) 可以存在于多个 `inventory` (库存) 条目中（每个仓库一个），并且可以有多条入库和出库记录。
*   一个 `warehouses` (仓库) 可以包含多种物料的 `inventory` (库存)，并且是入库和出库操作的目标或来源。
*   `inventory` (库存) 表是 `materials` 和 `warehouses` 的关联表，通过 `material_id` 和 `warehouse_id` 联合主键来唯一确定一种物料在特定仓库的库存情况。
