using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
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
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            // Get data
            DataTable inboundData = GetInboundSummary(startDate, endDate);
            DataTable outboundData = GetOutboundSummary(startDate, endDate);
            DataTable inventoryData = GetCurrentInventory();

            // Setup ReportViewer
            reportViewer.LocalReport.ReportEmbeddedResource = "WinWMS.Report.rdlc";
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("InboundDataSet", inboundData));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("OutboundDataSet", outboundData));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("InventoryDataSet", inventoryData));

            // Set parameters
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("ReportMonth", selectedMonth.ToString("yyyy-MM"));
            reportViewer.LocalReport.SetParameters(parameters);

            reportViewer.RefreshReport();
        }

        private DataTable GetInboundSummary(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT m.name, SUM(ir.quantity) AS TotalQuantity, SUM(ir.quantity * ir.price) AS TotalAmount
                FROM inbound_records ir
                JOIN materials m ON ir.material_id = m.id
                WHERE ir.inbound_date BETWEEN @start_date AND @end_date
                GROUP BY m.name";
            MySqlParameter[] parameters = {
                new MySqlParameter("@start_date", startDate),
                new MySqlParameter("@end_date", endDate)
            };
            return DbHelper.ExecuteQuery(query, parameters);
        }

        private DataTable GetOutboundSummary(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT m.name, SUM(obr.quantity) AS TotalQuantity, SUM(obr.quantity * i.unit_price) AS TotalAmount
                FROM outbound_records obr
                JOIN materials m ON obr.material_id = m.id
                LEFT JOIN inventory i ON obr.material_id = i.material_id AND obr.warehouse_id = i.warehouse_id
                WHERE obr.outbound_date BETWEEN @start_date AND @end_date
                GROUP BY m.name";
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
                ORDER BY w.name, m.name";
            return DbHelper.ExecuteQuery(query);
        }
    }
}
