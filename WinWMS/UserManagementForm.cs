using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinWMS
{
    public partial class UserManagementForm : Form
    {
        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void LoadUsers()
        {
            string query = @"SELECT 
                id, 
                username AS '用户名', 
                role AS '角色', 
                created_at AS '创建时间' 
            FROM users";
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
                txtUsername.Text = row.Cells["用户名"].Value?.ToString() ?? "";
                cmbRole.SelectedItem = row.Cells["角色"].Value?.ToString();
                txtPassword.Text = ""; // Do not display password
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO users (username, password_hash, role, created_at) VALUES (@username, @password, @role, NOW())";
            MySqlParameter[] parameters = {
                new MySqlParameter("@username", txtUsername.Text),
                new MySqlParameter("@password", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text)),
                new MySqlParameter("@role", cmbRole.SelectedItem.ToString())
            };
            DbHelper.ExecuteNonQuery(query, parameters);
            LoadUsers();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                string query = "UPDATE users SET username = @username, role = @role";
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    query += ", password_hash = @password";
                }
                query += " WHERE id = @id";

                MySqlParameter[] parameters;
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    parameters = new MySqlParameter[] {
                        new MySqlParameter("@username", txtUsername.Text),
                        new MySqlParameter("@role", cmbRole.SelectedItem.ToString()),
                        new MySqlParameter("@password", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text)),
                        new MySqlParameter("@id", userId)
                    };
                }
                else
                {
                    parameters = new MySqlParameter[] {
                        new MySqlParameter("@username", txtUsername.Text),
                        new MySqlParameter("@role", cmbRole.SelectedItem.ToString()),
                        new MySqlParameter("@id", userId)
                    };
                }

                DbHelper.ExecuteNonQuery(query, parameters);
                LoadUsers();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                string query = "DELETE FROM users WHERE id = @id";
                MySqlParameter[] parameters = { new MySqlParameter("@id", userId) };
                DbHelper.ExecuteNonQuery(query, parameters);
                LoadUsers();
            }
        }
    }
}
