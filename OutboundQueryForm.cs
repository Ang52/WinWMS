using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WinWMS
{
    public partial class OutboundQueryForm : Form
    {
        public OutboundQueryForm()
        {
            InitializeComponent();
            
            // 应用统一的ComboBox样式
            ComboBoxStyleHelper.ApplyStyle(cmbMaterial);
            ComboBoxStyleHelper.ApplyStyle(cmbWarehouse);
            
            LoadMaterials();
            LoadWarehouses();
            LoadOutboundRecords();

            btnSearch.Click += BtnSearch_Click;
        }

        private void LoadMaterials()
        {
            string query = "SELECT id, name FROM materials";
            DataTable dt = DbHelper.ExecuteQuery(query);
            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["name"] = "所有物资";
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

        private void LoadOutboundRecords()
        {
            StringBuilder query = new StringBuilder(@"
                SELECT 
                    m.material_code AS '物资编码',
                    m.name AS '名称',
                    m.spec AS '规格',
                    w.name AS '仓库',
                    obr.quantity AS '出库数量',
                    i.unit_price AS '出库时单价',
                    (obr.quantity * i.unit_price) AS '总金额',
                    u.username AS '操作员',
                    obr.outbound_date AS '出库时间'
                FROM outbound_records obr
                JOIN materials m ON obr.material_id = m.id
                JOIN warehouses w ON obr.warehouse_id = w.id
                JOIN users u ON obr.user_id = u.id
                LEFT JOIN inventory i ON obr.material_id = i.material_id AND obr.warehouse_id = i.warehouse_id
                WHERE obr.outbound_date BETWEEN @start_date AND @end_date");

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@start_date", dtpStartDate.Value.Date),
                new MySqlParameter("@end_date", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1))
            };

            if (cmbMaterial.SelectedIndex > 0)
            {
                query.Append(" AND obr.material_id = @material_id");
                parameters.Add(new MySqlParameter("@material_id", cmbMaterial.SelectedValue));
            }
            if (cmbWarehouse.SelectedIndex > 0)
            {
                query.Append(" AND obr.warehouse_id = @warehouse_id");
                parameters.Add(new MySqlParameter("@warehouse_id", cmbWarehouse.SelectedValue));
            }

            DataTable dt = DbHelper.ExecuteQuery(query.ToString(), parameters.ToArray());
            dataGridView1.DataSource = dt;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadOutboundRecords();
        }
    }
}
