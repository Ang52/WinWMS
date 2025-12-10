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
        // 定义阈值宽度
        private const int COMPACT_WIDTH_THRESHOLD = 900;
        
        public InventoryQueryForm()
        {
            InitializeComponent();
            
            // 应用统一的ComboBox样式
            ComboBoxStyleHelper.ApplyStyle(cmbWarehouse);
            
            LoadWarehouses();
            LoadInventory();
            
            // 绑定搜索按钮事件
            btnSearch.Click += BtnSearch_Click;
            
            // 绑定面板大小变化事件
            panel1.SizeChanged += Panel1_SizeChanged;
            
            // 初始调整布局
            AdjustLayoutForWindowSize();
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
        
        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            AdjustLayoutForWindowSize();
        }
        
        private void AdjustLayoutForWindowSize()
        {
            // 使用 panel1 的实际宽度来判断
            bool isCompact = panel1.Width < COMPACT_WIDTH_THRESHOLD;
            
            if (isCompact)
            {
                // 紧凑模式：缩小控件尺寸
                // 缩小输入框
                txtMaterialCode.Size = new System.Drawing.Size(70, 23);
                txtName.Size = new System.Drawing.Size(70, 23);
                txtSpec.Size = new System.Drawing.Size(70, 23);
                cmbWarehouse.Size = new System.Drawing.Size(90, 25);
                
                // 缩小标签字体和尺寸
                lblMaterialCode.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
                lblName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
                lblSpec.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
                lblWarehouse.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
                
                // 简化标签文字
                lblMaterialCode.Text = "编号：";
                lblWarehouse.Text = "仓库：";
                
                // 搜索按钮只显示图标
                btnSearch.Text = "🔍";
                btnSearch.Size = new System.Drawing.Size(35, 28);
                btnSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold);
                
                // 减小边距
                lblMaterialCode.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
                txtMaterialCode.Margin = new System.Windows.Forms.Padding(1, 2, 4, 2);
                lblName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
                txtName.Margin = new System.Windows.Forms.Padding(1, 2, 4, 2);
                lblSpec.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
                txtSpec.Margin = new System.Windows.Forms.Padding(1, 2, 4, 2);
                lblWarehouse.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
                cmbWarehouse.Margin = new System.Windows.Forms.Padding(1, 2, 5, 2);
                btnSearch.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
                
                // 调整面板高度和内边距
                panel1.Height = 45;
                panel1.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            }
            else
            {
                // 标准模式：恢复默认尺寸
                // 恢复输入框大小
                txtMaterialCode.Size = new System.Drawing.Size(100, 25);
                txtName.Size = new System.Drawing.Size(120, 25);
                txtSpec.Size = new System.Drawing.Size(120, 25);
                cmbWarehouse.Size = new System.Drawing.Size(150, 27);
                
                // 恢复标签字体
                lblMaterialCode.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
                lblName.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
                lblSpec.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
                lblWarehouse.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
                
                // 恢复标签文字
                lblMaterialCode.Text = "物资编号：";
                lblWarehouse.Text = "仓库：";
                
                // 搜索按钮显示完整文字
                btnSearch.Text = "🔍 查询";
                btnSearch.Size = new System.Drawing.Size(100, 35);
                btnSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold);
                
                // 恢复边距
                lblMaterialCode.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                txtMaterialCode.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
                lblName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                txtName.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
                lblSpec.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                txtSpec.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
                lblWarehouse.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                cmbWarehouse.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
                btnSearch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
                
                // 恢复面板高度和内边距
                panel1.Height = 65;
                panel1.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            }
            
            // 强制刷新布局
            searchFlowPanel.SuspendLayout();
            searchFlowPanel.PerformLayout();
            searchFlowPanel.ResumeLayout(true);
            panel1.PerformLayout();
        }
    }
}
