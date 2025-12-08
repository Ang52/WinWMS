using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinWMS
{
    public partial class MaterialManagementForm : Form
    {
        public MaterialManagementForm()
        {
            InitializeComponent();
            LoadMaterials();

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void LoadMaterials()
        {
            string query = @"SELECT 
                id, 
                material_code AS '物料编码', 
                name AS '名称', 
                spec AS '规格', 
                unit AS '单位', 
                created_at AS '创建时间' 
            FROM materials";
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
                txtMaterialCode.Text = row.Cells["物料编码"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["名称"].Value?.ToString() ?? "";
                txtSpec.Text = row.Cells["规格"].Value?.ToString() ?? "";
                txtUnit.Text = row.Cells["单位"].Value?.ToString() ?? "";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO materials (material_code, name, spec, unit, created_at) VALUES (@material_code, @name, @spec, @unit, NOW())";
            MySqlParameter[] parameters = {
                new MySqlParameter("@material_code", txtMaterialCode.Text),
                new MySqlParameter("@name", txtName.Text),
                new MySqlParameter("@spec", txtSpec.Text),
                new MySqlParameter("@unit", txtUnit.Text)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
            LoadMaterials();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int materialId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                string query = "UPDATE materials SET material_code = @material_code, name = @name, spec = @spec, unit = @unit WHERE id = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@material_code", txtMaterialCode.Text),
                    new MySqlParameter("@name", txtName.Text),
                    new MySqlParameter("@spec", txtSpec.Text),
                    new MySqlParameter("@unit", txtUnit.Text),
                    new MySqlParameter("@id", materialId)
                };
                DbHelper.ExecuteNonQuery(query, parameters);
                LoadMaterials();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int materialId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                string query = "DELETE FROM materials WHERE id = @id";
                MySqlParameter[] parameters = { new MySqlParameter("@id", materialId) };
                DbHelper.ExecuteNonQuery(query, parameters);
                LoadMaterials();
            }
        }
    }
}
