using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WinWMS
{
    public partial class InboundQueryForm : Form
    {
        public InboundQueryForm()
        {
            InitializeComponent();
            LoadMaterials();
            LoadWarehouses();
            LoadInboundRecords();

            btnSearch.Click += BtnSearch_Click;
        }

        private void LoadMaterials()
        {
            string query = "SELECT id, name FROM materials";
            DataTable dt = DbHelper.ExecuteQuery(query);
            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["name"] = "所有物料";
            dt.Rows.InsertAt(dr, 0);
            cmbMaterial.DataSource = dt;
            cmbMaterial.DisplayMember = "name";
            cmbMaterial.ValueMember = "id";
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

        private void LoadInboundRecords()
        {
            StringBuilder query = new StringBuilder(@"
                SELECT 
                    m.material_code AS '物资编号',
                    m.name AS '名称',
                    m.spec AS '规格',
                    w.name AS '仓库',
                    ir.quantity AS '入库数量',
                    ir.price AS '入库单价',
                    (ir.quantity * ir.price) AS '总金额',
                    u.username AS '操作员',
                    ir.inbound_date AS '入库时间'
                FROM inbound_records ir
                JOIN materials m ON ir.material_id = m.id
                JOIN warehouses w ON ir.warehouse_id = w.id
                JOIN users u ON ir.user_id = u.id
                WHERE ir.inbound_date BETWEEN @start_date AND @end_date");

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@start_date", dtpStartDate.Value.Date),
                new MySqlParameter("@end_date", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1))
            };

            if (cmbMaterial.SelectedIndex > 0)
            {
                query.Append(" AND ir.material_id = @material_id");
                parameters.Add(new MySqlParameter("@material_id", cmbMaterial.SelectedValue));
            }
            if (cmbWarehouse.SelectedIndex > 0)
            {
                query.Append(" AND ir.warehouse_id = @warehouse_id");
                parameters.Add(new MySqlParameter("@warehouse_id", cmbWarehouse.SelectedValue));
            }

            DataTable dt = DbHelper.ExecuteQuery(query.ToString(), parameters.ToArray());
            dataGridView1.DataSource = dt;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadInboundRecords();
        }
    }
}
