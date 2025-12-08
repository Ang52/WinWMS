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
            // 根据物料名称加载所有规格，显示格式：规格 [编码]
            string query = @"SELECT 
                                id, 
                                spec, 
                                material_code,
                                CONCAT(spec, '  [编码: ', material_code, ']') as display_spec 
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
                emptyRow["display_spec"] = "-- 请选择规格 --";
                dt.Rows.InsertAt(emptyRow, 0);
                
                cmbSpec.DataSource = dt;
                cmbSpec.DisplayMember = "display_spec";
                cmbSpec.ValueMember = "id";
                
                // 设置下拉列表的宽度以完整显示内容
                cmbSpec.DropDownWidth = 400;
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
            
            // 清空单价和备注
            txtPrice.Clear();
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
            
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("请输入入库单价！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("请输入有效的单价（必须大于0）！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            
            int materialId = (int)cmbSpec.SelectedValue;  // 从规格下拉框获取material_id
            int warehouseId = (int)cmbWarehouse.SelectedValue;
            int quantity = (int)numQuantity.Value;
            string remark = txtRemark.Text.Trim();

            try
            {
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

                // 2. Update inventory
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

                // 获取选中的规格信息用于显示
                DataRowView selectedRow = (DataRowView)cmbSpec.SelectedItem;
                string specInfo = selectedRow["spec"].ToString() ?? "";
                string materialCode = selectedRow["material_code"].ToString() ?? "";

                MessageBox.Show($"入库成功！\n\n物料名称：{cmbMaterial.Text}\n物料规格：{specInfo}\n物料编码：{materialCode}\n入库数量：{quantity}\n入库单价：{price:F2}", 
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
