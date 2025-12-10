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
            FROM materials
            ORDER BY material_code, spec";
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
            // 验证输入
            if (string.IsNullOrWhiteSpace(txtMaterialCode.Text))
            {
                MessageBox.Show("请输入物料编码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaterialCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入物料名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSpec.Text))
            {
                MessageBox.Show("请输入物料规格！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpec.Focus();
                return;
            }

            try
            {
                string query = "INSERT INTO materials (material_code, name, spec, unit, created_at) VALUES (@material_code, @name, @spec, @unit, NOW())";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@material_code", txtMaterialCode.Text.Trim()),
                    new MySqlParameter("@name", txtName.Text.Trim()),
                    new MySqlParameter("@spec", txtSpec.Text.Trim()),
                    new MySqlParameter("@unit", string.IsNullOrWhiteSpace(txtUnit.Text) ? "个" : txtUnit.Text.Trim())
                };
                DbHelper.ExecuteNonQuery(query, parameters);
                
                MessageBox.Show($"物料添加成功！\n\n物料编码：{txtMaterialCode.Text}\n物料名称：{txtName.Text}\n规格：{txtSpec.Text}", 
                    "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadMaterials();
                ClearInputs();
            }
            catch (MySqlException ex) when (ex.Number == 1062) // Duplicate entry error
            {
                MessageBox.Show($"该物料已存在！\n\n物料编码：{txtMaterialCode.Text}\n规格：{txtSpec.Text}\n\n相同编码和规格的物料不能重复添加。\n如需添加不同规格，请修改规格信息。", 
                    "重复数据", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpec.Focus();
                txtSpec.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加失败！\n\n错误信息：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要修改的物料！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 验证输入
            if (string.IsNullOrWhiteSpace(txtMaterialCode.Text))
            {
                MessageBox.Show("请输入物料编码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaterialCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入物料名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSpec.Text))
            {
                MessageBox.Show("请输入物料规格！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpec.Focus();
                return;
            }

            try
            {
                int materialId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                string query = "UPDATE materials SET material_code = @material_code, name = @name, spec = @spec, unit = @unit WHERE id = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@material_code", txtMaterialCode.Text.Trim()),
                    new MySqlParameter("@name", txtName.Text.Trim()),
                    new MySqlParameter("@spec", txtSpec.Text.Trim()),
                    new MySqlParameter("@unit", string.IsNullOrWhiteSpace(txtUnit.Text) ? "个" : txtUnit.Text.Trim()),
                    new MySqlParameter("@id", materialId)
                };
                DbHelper.ExecuteNonQuery(query, parameters);
                
                MessageBox.Show($"物料修改成功！\n\n物料编码：{txtMaterialCode.Text}\n物料名称：{txtName.Text}\n规格：{txtSpec.Text}", 
                    "修改成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadMaterials();
            }
            catch (MySqlException ex) when (ex.Number == 1062) // Duplicate entry error
            {
                MessageBox.Show($"修改失败！该物料已存在！\n\n物料编码：{txtMaterialCode.Text}\n规格：{txtSpec.Text}\n\n相同编码和规格的物料已存在，不能重复。", 
                    "重复数据", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpec.Focus();
                txtSpec.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"修改失败！\n\n错误信息：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的物料！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string materialCode = row.Cells["物料编码"].Value?.ToString() ?? "";
            string materialName = row.Cells["名称"].Value?.ToString() ?? "";
            string spec = row.Cells["规格"].Value?.ToString() ?? "";

            DialogResult result = MessageBox.Show(
                $"确定要删除以下物料吗？\n\n物料编码：{materialCode}\n物料名称：{materialName}\n规格：{spec}\n\n⚠️ 删除物料会同时删除相关的库存、批次和出入库记录！", 
                "删除确认", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int materialId = Convert.ToInt32(row.Cells["id"].Value);
                    string query = "DELETE FROM materials WHERE id = @id";
                    MySqlParameter[] parameters = { new MySqlParameter("@id", materialId) };
                    DbHelper.ExecuteNonQuery(query, parameters);
                    
                    MessageBox.Show($"物料删除成功！\n\n物料编码：{materialCode}\n物料名称：{materialName}", 
                        "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadMaterials();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除失败！\n\n错误信息：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            txtMaterialCode.Clear();
            txtName.Clear();
            txtSpec.Clear();
            txtUnit.Clear();
            txtMaterialCode.Focus();
        }
    }
}
