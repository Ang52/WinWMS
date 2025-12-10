using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinWMS
{
    public partial class InboundForm : Form
    {
        public InboundForm()
        {
            InitializeComponent();
            
            // 应用统一的ComboBox样式
            ComboBoxStyleHelper.ApplyStyle(cmbMaterial);
            ComboBoxStyleHelper.ApplyStyle(cmbSpec);
            ComboBoxStyleHelper.ApplyStyle(cmbWarehouse);
            
            LoadMaterialNames();
            LoadWarehouses();

            // 绑定事件
            cmbMaterial.SelectedIndexChanged += CmbMaterial_SelectedIndexChanged;
            btnInbound.Click += BtnInbound_Click;
            
            // 初始禁用规格选择
            cmbSpec.Enabled = false;
        }

        private void LoadMaterialNames()
        {
            // 只加载不重复的物料名称
            string query = "SELECT DISTINCT name FROM materials ORDER BY name";
            DataTable dt = DbHelper.ExecuteQuery(query);
            
            // 添加"请选择"提示项
            DataRow emptyRow = dt.NewRow();
            emptyRow["name"] = "-- 请选择物料 --";
            dt.Rows.InsertAt(emptyRow, 0);
            
            cmbMaterial.DataSource = dt;
            cmbMaterial.DisplayMember = "name";
            cmbMaterial.ValueMember = "name";
        }

        private void CmbMaterial_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // 清空规格选择
            cmbSpec.DataSource = null;
            cmbSpec.Items.Clear();
            
            if (cmbMaterial.SelectedIndex > 0 && cmbMaterial.SelectedValue != null)
            {
                string materialName = cmbMaterial.SelectedValue.ToString() ?? "";
                if (!string.IsNullOrEmpty(materialName))
                {
                    LoadMaterialSpecs(materialName);
                    cmbSpec.Enabled = true;
                }
            }
            else
            {
                cmbSpec.Enabled = false;
            }
        }

        private void LoadMaterialSpecs(string materialName)
        {
            // 根据物料名称加载所有规格，显示格式：规格 [编码] - 单价：XX元
            string query = @"SELECT 
                                id, 
                                spec, 
                                material_code,
                                price,
                                CONCAT(spec, '  [编码: ', material_code, ']  - 单价: ¥', FORMAT(price, 2)) as display_spec 
                            FROM materials 
                            WHERE name = @name 
                            ORDER BY spec, material_code";
            MySqlParameter[] parameters = {
                new MySqlParameter("@name", materialName)
            };
            
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                // 添加"请选择"提示项
                DataRow emptyRow = dt.NewRow();
                emptyRow["id"] = 0;
                emptyRow["spec"] = "";
                emptyRow["material_code"] = "";
                emptyRow["price"] = 0;
                emptyRow["display_spec"] = "-- 请选择规格 --";
                dt.Rows.InsertAt(emptyRow, 0);
                
                cmbSpec.DataSource = dt;
                cmbSpec.DisplayMember = "display_spec";
                cmbSpec.ValueMember = "id";
                
                // 设置下拉列表的宽度以完整显示内容
                cmbSpec.DropDownWidth = 500;
            }
            else
            {
                MessageBox.Show("该物料没有规格信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSpec.Enabled = false;
            }
        }

        private void LoadWarehouses()
        {
            string query = "SELECT id, name FROM warehouses";
            DataTable dt = DbHelper.ExecuteQuery(query);
            
            // 添加"请选择"提示项
            DataRow emptyRow = dt.NewRow();
            emptyRow["id"] = 0;
            emptyRow["name"] = "-- 请选择仓库 --";
            dt.Rows.InsertAt(emptyRow, 0);
            
            cmbWarehouse.DataSource = dt;
            cmbWarehouse.DisplayMember = "name";
            cmbWarehouse.ValueMember = "id";
        }

        private string GenerateBatchNo(int materialId, int warehouseId)
        {
            // 生成批次号: PC + 物料ID(4位) + 仓库ID(2位) + 日期(8位) + 序号(3位)
            string dateStr = DateTime.Now.ToString("yyyyMMdd");
            
            // 查询当天该物料在该仓库的入库次数
            string query = @"SELECT COUNT(*) FROM inventory_batches 
                           WHERE material_id = @material_id 
                           AND warehouse_id = @warehouse_id
                           AND DATE(inbound_date) = CURDATE()";
            MySqlParameter[] parameters = {
                new MySqlParameter("@material_id", materialId),
                new MySqlParameter("@warehouse_id", warehouseId)
            };
            
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            int seq = 1;
            if (dt.Rows.Count > 0)
            {
                seq = Convert.ToInt32(dt.Rows[0][0]) + 1;
            }
            
            return $"PC{materialId:D4}{warehouseId:D2}{dateStr}{seq:D3}";
        }

        private void ClearForm()
        {
            // 重置物料选择
            if (cmbMaterial.Items.Count > 0)
            {
                cmbMaterial.SelectedIndex = 0;
            }
            
            // 清空规格选择
            cmbSpec.DataSource = null;
            cmbSpec.Items.Clear();
            cmbSpec.Enabled = false;
            
            // 重置仓库选择
            if (cmbWarehouse.Items.Count > 0)
            {
                cmbWarehouse.SelectedIndex = 0;
            }
            
            // 重置数量
            numQuantity.Value = 0;
            
            // 清空备注
            txtRemark.Clear();
        }

        private void BtnInbound_Click(object sender, EventArgs e)
        {
            // 验证输入
            if (cmbMaterial.SelectedIndex <= 0)
            {
                MessageBox.Show("请选择物料名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaterial.Focus();
                return;
            }
            
            if (cmbSpec.SelectedIndex <= 0)
            {
                MessageBox.Show("请选择物料规格！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSpec.Focus();
                return;
            }
            
            if (cmbWarehouse.SelectedIndex <= 0)
            {
                MessageBox.Show("请选择仓库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                return;
            }
            
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("入库数量必须大于0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQuantity.Focus();
                return;
            }
            
            int materialId = (int)cmbSpec.SelectedValue;  // 从规格下拉框获取material_id
            int warehouseId = (int)cmbWarehouse.SelectedValue;
            int quantity = (int)numQuantity.Value;
            string remark = txtRemark.Text.Trim();

            try
            {
                // 从materials表获取标准单价
                string getPriceQuery = "SELECT price, spec, material_code FROM materials WHERE id = @material_id";
                MySqlParameter[] priceParams = {
                    new MySqlParameter("@material_id", materialId)
                };
                DataTable priceDt = DbHelper.ExecuteQuery(getPriceQuery, priceParams);
                
                if (priceDt.Rows.Count == 0)
                {
                    MessageBox.Show("无法获取物料信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                decimal price = Convert.ToDecimal(priceDt.Rows[0]["price"]);
                string specInfo = priceDt.Rows[0]["spec"].ToString() ?? "";
                string materialCode = priceDt.Rows[0]["material_code"].ToString() ?? "";
                
                if (price <= 0)
                {
                    MessageBox.Show("该物料的标准单价未设置！\n\n请先在物料管理中设置该物料的标准单价。", 
                        "单价未设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. Add inbound record
                string inboundQuery = "INSERT INTO inbound_records (material_id, warehouse_id, quantity, price, remark, inbound_date, user_id) VALUES (@material_id, @warehouse_id, @quantity, @price, @remark, NOW(), 1)";
                MySqlParameter[] inboundParams = {
                    new MySqlParameter("@material_id", materialId),
                    new MySqlParameter("@warehouse_id", warehouseId),
                    new MySqlParameter("@quantity", quantity),
                    new MySqlParameter("@price", price),
                    new MySqlParameter("@remark", string.IsNullOrEmpty(remark) ? DBNull.Value : (object)remark)
                };
                DbHelper.ExecuteNonQuery(inboundQuery, inboundParams);
                
                // 获取刚插入的入库记录ID
                string getLastIdQuery = "SELECT LAST_INSERT_ID()";
                DataTable lastIdDt = DbHelper.ExecuteQuery(getLastIdQuery);
                int inboundRecordId = Convert.ToInt32(lastIdDt.Rows[0][0]);

                // 2. 生成批次号并创建批次记录
                string batchNo = GenerateBatchNo(materialId, warehouseId);
                string batchQuery = @"INSERT INTO inventory_batches 
                                     (material_id, warehouse_id, batch_no, quantity, unit_price, total_amount, inbound_date, inbound_record_id, remark) 
                                     VALUES (@material_id, @warehouse_id, @batch_no, @quantity, @unit_price, @total_amount, NOW(), @inbound_record_id, @remark)";
                MySqlParameter[] batchParams = {
                    new MySqlParameter("@material_id", materialId),
                    new MySqlParameter("@warehouse_id", warehouseId),
                    new MySqlParameter("@batch_no", batchNo),
                    new MySqlParameter("@quantity", quantity),
                    new MySqlParameter("@unit_price", price),
                    new MySqlParameter("@total_amount", quantity * price),
                    new MySqlParameter("@inbound_record_id", inboundRecordId),
                    new MySqlParameter("@remark", string.IsNullOrEmpty(remark) ? DBNull.Value : (object)remark)
                };
                DbHelper.ExecuteNonQuery(batchQuery, batchParams);

                // 3. Update inventory (仍然保持加权平均价格用于快速查询)
                string checkInventoryQuery = "SELECT quantity, total_amount FROM inventory WHERE material_id = @material_id AND warehouse_id = @warehouse_id";
                MySqlParameter[] checkParams = {
                    new MySqlParameter("@material_id", materialId),
                    new MySqlParameter("@warehouse_id", warehouseId)
                };
                DataTable dt = DbHelper.ExecuteQuery(checkInventoryQuery, checkParams);

                if (dt.Rows.Count > 0)
                {
                    // Update existing inventory
                    int currentQuantity = Convert.ToInt32(dt.Rows[0]["quantity"]);
                    decimal currentAmount = Convert.ToDecimal(dt.Rows[0]["total_amount"]);
                    int newQuantity = currentQuantity + quantity;
                    decimal newAmount = currentAmount + (quantity * price);
                    decimal newUnitPrice = newAmount / newQuantity;

                    string updateInventoryQuery = "UPDATE inventory SET quantity = @quantity, unit_price = @unit_price, total_amount = @total_amount, last_updated = NOW() WHERE material_id = @material_id AND warehouse_id = @warehouse_id";
                    MySqlParameter[] updateParams = {
                        new MySqlParameter("@quantity", newQuantity),
                        new MySqlParameter("@unit_price", newUnitPrice),
                        new MySqlParameter("@total_amount", newAmount),
                        new MySqlParameter("@material_id", materialId),
                        new MySqlParameter("@warehouse_id", warehouseId)
                    };
                    DbHelper.ExecuteNonQuery(updateInventoryQuery, updateParams);
                }
                else
                {
                    // Insert new inventory record
                    string insertInventoryQuery = "INSERT INTO inventory (material_id, warehouse_id, quantity, unit_price, total_amount, last_updated) VALUES (@material_id, @warehouse_id, @quantity, @unit_price, @total_amount, NOW())";
                    MySqlParameter[] insertParams = {
                        new MySqlParameter("@material_id", materialId),
                        new MySqlParameter("@warehouse_id", warehouseId),
                        new MySqlParameter("@quantity", quantity),
                        new MySqlParameter("@unit_price", price),
                        new MySqlParameter("@total_amount", quantity * price)
                    };
                    DbHelper.ExecuteNonQuery(insertInventoryQuery, insertParams);
                }

                MessageBox.Show($"入库成功！\n\n物料名称：{cmbMaterial.Text}\n物料规格：{specInfo}\n物料编码：{materialCode}\n批次号：{batchNo}\n入库数量：{quantity}\n标准单价：¥{price:F2}\n总金额：¥{quantity * price:F2}", 
                    "入库成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // 清空表单，准备下一次操作
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"入库失败！\n错误信息：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
