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
            ComboBoxStyleHelper.ApplyStyle(cmbWarehouse);
            
            LoadMaterials();
            LoadWarehouses();

            btnInbound.Click += BtnInbound_Click;
        }

        private void LoadMaterials()
        {
            string query = "SELECT id, name FROM materials";
            DataTable dt = DbHelper.ExecuteQuery(query);
            cmbMaterial.DataSource = dt;
            cmbMaterial.DisplayMember = "name";
            cmbMaterial.ValueMember = "id";
        }

        private void LoadWarehouses()
        {
            string query = "SELECT id, name FROM warehouses";
            DataTable dt = DbHelper.ExecuteQuery(query);
            cmbWarehouse.DataSource = dt;
            cmbWarehouse.DisplayMember = "name";
            cmbWarehouse.ValueMember = "id";
        }

        private void BtnInbound_Click(object sender, EventArgs e)
        {
            int materialId = (int)cmbMaterial.SelectedValue;
            int warehouseId = (int)cmbWarehouse.SelectedValue;
            int quantity = (int)numQuantity.Value;
            decimal price = decimal.Parse(txtPrice.Text);

            // 1. Add inbound record
            string inboundQuery = "INSERT INTO inbound_records (material_id, warehouse_id, quantity, price, inbound_date, user_id) VALUES (@material_id, @warehouse_id, @quantity, @price, NOW(), 1)"; // Assuming user_id 1 for now
            MySqlParameter[] inboundParams = {
                new MySqlParameter("@material_id", materialId),
                new MySqlParameter("@warehouse_id", warehouseId),
                new MySqlParameter("@quantity", quantity),
                new MySqlParameter("@price", price)
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

            MessageBox.Show("入库成功！");
            this.Close();
        }
    }
}
