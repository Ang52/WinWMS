using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinWMS
{
    public partial class OutboundForm : Form
    {
        public OutboundForm()
        {
            InitializeComponent();
            
            // 应用统一的ComboBox样式
            ComboBoxStyleHelper.ApplyStyle(cmbMaterial);
            ComboBoxStyleHelper.ApplyStyle(cmbSpec);
            ComboBoxStyleHelper.ApplyStyle(cmbWarehouse);
            
            LoadMaterialNames();

            // 绑定事件
            cmbMaterial.SelectedIndexChanged += CmbMaterial_SelectedIndexChanged;
            cmbSpec.SelectedIndexChanged += CmbSpec_SelectedIndexChanged;
            btnOutbound.Click += BtnOutbound_Click;
            
            // 初始禁用规格和仓库选择
            cmbSpec.Enabled = false;
            cmbWarehouse.Enabled = false;
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
            
            // 清空仓库选择
            cmbWarehouse.DataSource = null;
            cmbWarehouse.Items.Clear();
            cmbWarehouse.Enabled = false;
            
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

        private void CmbSpec_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // 清空仓库选择
            cmbWarehouse.DataSource = null;
            cmbWarehouse.Items.Clear();
            
            if (cmbSpec.SelectedIndex > 0 && cmbSpec.SelectedValue != null)
            {
                int materialId = (int)cmbSpec.SelectedValue;
                LoadWarehousesWithStock(materialId);
                cmbWarehouse.Enabled = true;
            }
            else
            {
                cmbWarehouse.Enabled = false;
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

        private void LoadWarehousesWithStock(int materialId)
        {
            // 根据物料ID加载有库存的仓库，显示格式：仓库名称 [库存: xxx]
            string query = @"SELECT 
                                w.id, 
                                w.name,
                                i.quantity,
                                CONCAT(w.name, '  [库存: ', i.quantity, ']') as display_name
                            FROM warehouses w
                            INNER JOIN inventory i ON w.id = i.warehouse_id
                            WHERE i.material_id = @material_id AND i.quantity > 0
                            ORDER BY w.name";
            MySqlParameter[] parameters = {
                new MySqlParameter("@material_id", materialId)
            };
            
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                // 添加"请选择"提示项
                DataRow emptyRow = dt.NewRow();
                emptyRow["id"] = 0;
                emptyRow["name"] = "";
                emptyRow["quantity"] = 0;
                emptyRow["display_name"] = "-- 请选择仓库 --";
                dt.Rows.InsertAt(emptyRow, 0);
                
                cmbWarehouse.DataSource = dt;
                cmbWarehouse.DisplayMember = "display_name";
                cmbWarehouse.ValueMember = "id";
                
                // 设置下拉列表的宽度以完整显示内容
                cmbWarehouse.DropDownWidth = 350;
            }
            else
            {
                MessageBox.Show("该物料在所有仓库中都没有库存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Enabled = false;
            }
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
            
            // 清空仓库选择
            cmbWarehouse.DataSource = null;
            cmbWarehouse.Items.Clear();
            cmbWarehouse.Enabled = false;
            
            // 重置数量
            numQuantity.Value = 0;
            
            // 清空备注
            txtRemark.Clear();
        }

        private void BtnOutbound_Click(object sender, EventArgs e)
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
                MessageBox.Show("出库数量必须大于0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQuantity.Focus();
                return;
            }
            
            int materialId = (int)cmbSpec.SelectedValue;  // 从规格下拉框获取material_id
            int warehouseId = (int)cmbWarehouse.SelectedValue;
            int quantity = (int)numQuantity.Value;
            string remark = txtRemark.Text.Trim();

            try
            {
                // 1. Check inventory
                string checkInventoryQuery = "SELECT quantity, unit_price, total_amount FROM inventory WHERE material_id = @material_id AND warehouse_id = @warehouse_id";
                MySqlParameter[] checkParams = {
                    new MySqlParameter("@material_id", materialId),
                    new MySqlParameter("@warehouse_id", warehouseId)
                };
                DataTable dt = DbHelper.ExecuteQuery(checkInventoryQuery, checkParams);

                if (dt.Rows.Count > 0)
                {
                    int currentQuantity = Convert.ToInt32(dt.Rows[0]["quantity"]);
                    if (currentQuantity < quantity)
                    {
                        MessageBox.Show($"库存不足！\n\n当前库存：{currentQuantity}\n需要出库：{quantity}\n缺少数量：{quantity - currentQuantity}", 
                            "库存不足", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        numQuantity.Focus();
                        return;
                    }

                    // 2. Add outbound record
                    string outboundQuery = "INSERT INTO outbound_records (material_id, warehouse_id, quantity, remark, outbound_date, user_id) VALUES (@material_id, @warehouse_id, @quantity, @remark, NOW(), 1)";
                    MySqlParameter[] outboundParams = {
                        new MySqlParameter("@material_id", materialId),
                        new MySqlParameter("@warehouse_id", warehouseId),
                        new MySqlParameter("@quantity", quantity),
                        new MySqlParameter("@remark", string.IsNullOrEmpty(remark) ? DBNull.Value : (object)remark)
                    };
                    DbHelper.ExecuteNonQuery(outboundQuery, outboundParams);

                    // 3. Update inventory
                    decimal unitPrice = Convert.ToDecimal(dt.Rows[0]["unit_price"]);
                    int newQuantity = currentQuantity - quantity;
                    decimal newAmount = newQuantity * unitPrice;

                    string updateInventoryQuery = "UPDATE inventory SET quantity = @quantity, total_amount = @total_amount, last_updated = NOW() WHERE material_id = @material_id AND warehouse_id = @warehouse_id";
                    MySqlParameter[] updateParams = {
                        new MySqlParameter("@quantity", newQuantity),
                        new MySqlParameter("@total_amount", newAmount),
                        new MySqlParameter("@material_id", materialId),
                        new MySqlParameter("@warehouse_id", warehouseId)
                    };
                    DbHelper.ExecuteNonQuery(updateInventoryQuery, updateParams);

                    // 获取选中的规格信息用于显示
                    DataRowView selectedRow = (DataRowView)cmbSpec.SelectedItem;
                    string specInfo = selectedRow["spec"].ToString() ?? "";
                    string materialCode = selectedRow["material_code"].ToString() ?? "";

                    MessageBox.Show($"出库成功！\n\n物料名称：{cmbMaterial.Text}\n物料规格：{specInfo}\n物料编码：{materialCode}\n出库数量：{quantity}\n剩余库存：{newQuantity}", 
                        "出库成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 清空表单，准备下一次操作
                    ClearForm();
                }
                else
                {
                    // 获取选中的规格信息用于显示
                    DataRowView selectedRow = (DataRowView)cmbSpec.SelectedItem;
                    string specInfo = selectedRow["spec"].ToString() ?? "";
                    string materialCode = selectedRow["material_code"].ToString() ?? "";
                    
                    MessageBox.Show($"该物料在所选仓库没有库存！\n\n物料名称：{cmbMaterial.Text}\n物料规格：{specInfo}\n物料编码：{materialCode}\n仓库：{cmbWarehouse.Text}", 
                        "库存不足", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"出库失败！\n错误信息：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
