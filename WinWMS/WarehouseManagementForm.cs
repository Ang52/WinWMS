using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinWMS
{
    public partial class WarehouseManagementForm : Form
    {
        public WarehouseManagementForm()
        {
            InitializeComponent();
            LoadWarehouses();

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void LoadWarehouses()
        {
            string query = @"SELECT 
                id, 
                name AS '仓库名称', 
                location AS '位置', 
                created_at AS '创建时间' 
            FROM warehouses";
            DataTable dt = DbHelper.ExecuteQuery(query);
            dataGridView1.DataSource = dt;
            
            // 隐藏ID列
            if (dataGridView1.Columns["id"] != null)
            {
                dataGridView1.Columns["id"].Visible = false;
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtName.Text = row.Cells["仓库名称"].Value?.ToString() ?? "";
                txtLocation.Text = row.Cells["位置"].Value?.ToString() ?? "";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO warehouses (name, location, created_at) VALUES (@name, @location, NOW())";
            MySqlParameter[] parameters = {
                new MySqlParameter("@name", txtName.Text),
                new MySqlParameter("@location", txtLocation.Text)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
            LoadWarehouses();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int warehouseId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                string query = "UPDATE warehouses SET name = @name, location = @location WHERE id = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@name", txtName.Text),
                    new MySqlParameter("@location", txtLocation.Text),
                    new MySqlParameter("@id", warehouseId)
                };
                DbHelper.ExecuteNonQuery(query, parameters);
                LoadWarehouses();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int warehouseId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                string query = "DELETE FROM warehouses WHERE id = @id";
                MySqlParameter[] parameters = { new MySqlParameter("@id", warehouseId) };
                DbHelper.ExecuteNonQuery(query, parameters);
                LoadWarehouses();
            }
        }
    }
}
