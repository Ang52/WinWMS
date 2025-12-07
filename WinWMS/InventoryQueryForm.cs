using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WinWMS
{
    public partial class InventoryQueryForm : Form
    {
        public InventoryQueryForm()
        {
            InitializeComponent();
            LoadWarehouses();
            LoadInventory();

            btnSearch.Click += BtnSearch_Click;
        }

        private void LoadWarehouses()
        {
            string query = "SELECT id, name FROM warehouses";
            DataTable dt = DbHelper.ExecuteQuery(query);
            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["name"] = "所有仓库";
            dt.Rows.InsertAt(dr, 0);
            cmbWarehouse.DataSource = dt;
            cmbWarehouse.DisplayMember = "name";
            cmbWarehouse.ValueMember = "id";
        }

        private void LoadInventory()
        {
            StringBuilder query = new StringBuilder(@"
                SELECT 
                    m.material_code AS '物资编号',
                    m.name AS '名称',
                    m.spec AS '规格',
                    w.name AS '仓库',
                    i.quantity AS '数量',
                    i.unit_price AS '单价',
                    i.total_amount AS '总金额',
                    i.last_updated AS '最后更新时间'
                FROM inventory i
                JOIN materials m ON i.material_id = m.id
                JOIN warehouses w ON i.warehouse_id = w.id
                WHERE 1=1");

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(txtMaterialCode.Text))
            {
                query.Append(" AND m.material_code LIKE @material_code");
                parameters.Add(new MySqlParameter("@material_code", $"%{txtMaterialCode.Text}%"));
            }
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                query.Append(" AND m.name LIKE @name");
                parameters.Add(new MySqlParameter("@name", $"%{txtName.Text}%"));
            }
            if (!string.IsNullOrWhiteSpace(txtSpec.Text))
            {
                query.Append(" AND m.spec LIKE @spec");
                parameters.Add(new MySqlParameter("@spec", $"%{txtSpec.Text}%"));
            }
            if (cmbWarehouse.SelectedIndex > 0)
            {
                query.Append(" AND i.warehouse_id = @warehouse_id");
                parameters.Add(new MySqlParameter("@warehouse_id", cmbWarehouse.SelectedValue));
            }

            DataTable dt = DbHelper.ExecuteQuery(query.ToString(), parameters.ToArray());
            dataGridView1.DataSource = dt;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }
    }
}
