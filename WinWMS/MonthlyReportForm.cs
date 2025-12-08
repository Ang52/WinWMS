using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinWMS
{
    public partial class MonthlyReportForm : Form
    {
        public MonthlyReportForm()
        {
            InitializeComponent();
            btnGenerate.Click += BtnGenerate_Click;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            DateTime selectedMonth = dtpMonth.Value;
            DateTime startDate = new DateTime(selectedMonth.Year, selectedMonth.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddSeconds(-1);

            // Clear existing report
            reportPanel.Controls.Clear();

            // Create main container
            FlowLayoutPanel mainContainer = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                Dock = DockStyle.Top,
                Padding = new Padding(30)
            };

            // Add report title
            Label titleLabel = new Label
            {
                Text = "📋 仓储管理月度报表",
                Font = new Font("Microsoft YaHei UI", 22, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.FromArgb(219, 112, 147),  // 玫瑰粉
                Margin = new Padding(0, 0, 0, 10)
            };
            mainContainer.Controls.Add(titleLabel);

            // Add month label
            Label monthLabel = new Label
            {
                Text = $"📅 报表月份：{selectedMonth.ToString("yyyy年MM月")}",
                Font = new Font("Microsoft YaHei UI", 13),
                AutoSize = true,
                ForeColor = Color.FromArgb(255, 105, 180),  // 深粉色
                Margin = new Padding(0, 0, 0, 30)
            };
            mainContainer.Controls.Add(monthLabel);

            // Get data
            DataTable inboundData = GetInboundSummary(startDate, endDate);
            DataTable outboundData = GetOutboundSummary(startDate, endDate);
            DataTable inventoryData = GetCurrentInventory();

            // Generate Inbound Summary Section
            Panel inboundSection = CreateReportSection(
                "📥 入库汇总",
                inboundData,
                new[] { "物料名称", "总数量", "总金额（元）" },
                new[] { "name", "TotalQuantity", "TotalAmount" },
                new[] { 350, 150, 200 }
            );
            mainContainer.Controls.Add(inboundSection);

            // Generate Outbound Summary Section
            Panel outboundSection = CreateReportSection(
                "📤 出库汇总",
                outboundData,
                new[] { "物料名称", "总数量", "总金额（元）" },
                new[] { "name", "TotalQuantity", "TotalAmount" },
                new[] { 350, 150, 200 }
            );
            mainContainer.Controls.Add(outboundSection);

            // Generate Inventory Summary Section
            Panel inventorySection = CreateReportSection(
                "📦 库存汇总",
                inventoryData,
                new[] { "物料名称", "仓库", "数量", "单价（元）", "总金额（元）" },
                new[] { "name", "Warehouse", "quantity", "unit_price", "total_amount" },
                new[] { 220, 180, 100, 130, 140 }
            );
            mainContainer.Controls.Add(inventorySection);

            reportPanel.Controls.Add(mainContainer);
        }

        private Panel CreateReportSection(string title, DataTable data,
            string[] columnHeaders, string[] columnFields, int[] columnWidths)
        {
            // Calculate total width
            int totalWidth = 0;
            foreach (int width in columnWidths)
            {
                totalWidth += width;
            }

            // Create section container with shadow effect
            Panel sectionPanel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Width = totalWidth + 20,
                Margin = new Padding(0, 0, 0, 35),
                Padding = new Padding(10),
                BackColor = Color.White
            };

            int yPos = 0;

            // Add section title with colored background
            Panel titlePanel = new Panel
            {
                Width = totalWidth,
                Height = 45,
                Location = new Point(10, yPos),
                BackColor = Color.FromArgb(255, 182, 193)  // 粉色标题背景
            };
            
            Label sectionTitle = new Label
            {
                Text = title,
                Font = new Font("Microsoft YaHei UI", 14, FontStyle.Bold),
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0)
            };
            titlePanel.Controls.Add(sectionTitle);
            sectionPanel.Controls.Add(titlePanel);
            yPos += 50;

            // Create table using TableLayoutPanel
            TableLayoutPanel table = new TableLayoutPanel
            {
                Location = new Point(10, yPos),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.FromArgb(255, 218, 224)  // 浅粉色边框
            };

            // Set column styles
            table.ColumnCount = columnHeaders.Length;
            for (int i = 0; i < columnHeaders.Length; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, columnWidths[i]));
            }

            // Add header row
            table.RowCount = 1;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45));
            
            for (int i = 0; i < columnHeaders.Length; i++)
            {
                Label headerLabel = new Label
                {
                    Text = columnHeaders[i],
                    Font = new Font("Microsoft YaHei UI", 11, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(255, 182, 193),  // 粉色表头
                    ForeColor = Color.White,
                    Margin = new Padding(0)
                };
                table.Controls.Add(headerLabel, i, 0);
            }

            // Add data rows
            if (data != null && data.Rows.Count > 0)
            {
                int rowIndex = 1;
                foreach (DataRow row in data.Rows)
                {
                    table.RowCount++;
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, 38));

                    for (int i = 0; i < columnFields.Length; i++)
                    {
                        object value = row[columnFields[i]];
                        string displayValue = "";

                        // Format values
                        if (value is decimal decimalValue)
                        {
                            displayValue = decimalValue.ToString("N2");
                        }
                        else if (value is int || value is long)
                        {
                            displayValue = value.ToString();
                        }
                        else
                        {
                            displayValue = value?.ToString() ?? "";
                        }

                        Label cellLabel = new Label
                        {
                            Text = displayValue,
                            Font = new Font("Microsoft YaHei UI", 10),
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = rowIndex % 2 == 0 ? Color.White : Color.FromArgb(255, 240, 245),  // 交替粉白色
                            ForeColor = Color.FromArgb(64, 64, 64),
                            Margin = new Padding(0)
                        };
                        table.Controls.Add(cellLabel, i, rowIndex);
                    }
                    rowIndex++;
                }
            }
            else
            {
                // No data row
                table.RowCount++;
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                
                Label noDataLabel = new Label
                {
                    Text = "💭 暂无数据",
                    Font = new Font("Microsoft YaHei UI", 11),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(150, 150, 150),
                    Margin = new Padding(0)
                };
                table.SetColumnSpan(noDataLabel, columnHeaders.Length);
                table.Controls.Add(noDataLabel, 0, 1);
            }

            sectionPanel.Controls.Add(table);
            sectionPanel.Height = yPos + table.Height + 20;

            return sectionPanel;
        }

        private DataTable GetInboundSummary(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT m.name, SUM(ir.quantity) AS TotalQuantity, SUM(ir.quantity * ir.price) AS TotalAmount
                FROM inbound_records ir
                JOIN materials m ON ir.material_id = m.id
                WHERE ir.inbound_date BETWEEN @start_date AND @end_date
                GROUP BY m.name
                ORDER BY TotalAmount DESC";
            MySqlParameter[] parameters = {
                new MySqlParameter("@start_date", startDate),
                new MySqlParameter("@end_date", endDate)
            };
            return DbHelper.ExecuteQuery(query, parameters);
        }

        private DataTable GetOutboundSummary(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT m.name, SUM(obr.quantity) AS TotalQuantity, SUM(obr.quantity * obr.price) AS TotalAmount
                FROM outbound_records obr
                JOIN materials m ON obr.material_id = m.id
                WHERE obr.outbound_date BETWEEN @start_date AND @end_date AND obr.price > 0
                GROUP BY m.name
                ORDER BY TotalAmount DESC";
            MySqlParameter[] parameters = {
                new MySqlParameter("@start_date", startDate),
                new MySqlParameter("@end_date", endDate)
            };
            return DbHelper.ExecuteQuery(query, parameters);
        }

        private DataTable GetCurrentInventory()
        {
            string query = @"
                SELECT m.name, w.name AS Warehouse, i.quantity, i.unit_price, i.total_amount
                FROM inventory i
                JOIN materials m ON i.material_id = m.id
                JOIN warehouses w ON i.warehouse_id = w.id
                WHERE i.quantity > 0
                ORDER BY w.name, m.name";
            return DbHelper.ExecuteQuery(query) ?? new DataTable();
        }
    }
}
