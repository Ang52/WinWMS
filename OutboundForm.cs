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
            ComboBoxStyleHelper.ApplyStyle(cmbWarehouse);
            
            LoadMaterials();
            LoadWarehouses();

            btnOutbound.Click += BtnOutbound_Click;
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

        private void BtnOutbound_Click(object sender, EventArgs e)
        {
            int materialId = (int)cmbMaterial.SelectedValue;
            int warehouseId = (int)cmbWarehouse.SelectedValue;
            int quantity = (int)numQuantity.Value;

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
                    MessageBox.Show("库存不足！");
                    return;
                }

                // 2. Add outbound record
                string outboundQuery = "INSERT INTO outbound_records (material_id, warehouse_id, quantity, outbound_date, user_id) VALUES (@material_id, @warehouse_id, @quantity, NOW(), 1)"; // Assuming user_id 1 for now
                MySqlParameter[] outboundParams = {
                    new MySqlParameter("@material_id", materialId),
                    new MySqlParameter("@warehouse_id", warehouseId),
                    new MySqlParameter("@quantity", quantity)
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

                MessageBox.Show("出库成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("库存不足！");
            }
        }
    }
}
