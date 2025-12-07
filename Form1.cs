namespace WinWMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userManagementToolStripMenuItem.Click += UserManagementToolStripMenuItem_Click;
            materialManagementToolStripMenuItem.Click += MaterialManagementToolStripMenuItem_Click;
            warehouseManagementToolStripMenuItem.Click += WarehouseManagementToolStripMenuItem_Click;
            inboundToolStripMenuItem.Click += InboundToolStripMenuItem_Click;
            outboundToolStripMenuItem.Click += OutboundToolStripMenuItem_Click;
            inventoryQueryToolStripMenuItem.Click += InventoryQueryToolStripMenuItem_Click;
            inboundQueryToolStripMenuItem.Click += InboundQueryToolStripMenuItem_Click;
            outboundQueryToolStripMenuItem.Click += OutboundQueryToolStripMenuItem_Click;
            monthlyReportToolStripMenuItem.Click += MonthlyReportToolStripMenuItem_Click;
        }

        private void MonthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyReportForm monthlyReportForm = new MonthlyReportForm();
            monthlyReportForm.ShowDialog();
        }

        private void OutboundQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutboundQueryForm outboundQueryForm = new OutboundQueryForm();
            outboundQueryForm.ShowDialog();
        }

        private void InboundQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InboundQueryForm inboundQueryForm = new InboundQueryForm();
            inboundQueryForm.ShowDialog();
        }

        private void InventoryQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryQueryForm inventoryQueryForm = new InventoryQueryForm();
            inventoryQueryForm.ShowDialog();
        }

        private void OutboundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutboundForm outboundForm = new OutboundForm();
            outboundForm.ShowDialog();
        }

        private void InboundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InboundForm inboundForm = new InboundForm();
            inboundForm.ShowDialog();
        }

        private void WarehouseManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarehouseManagementForm warehouseForm = new WarehouseManagementForm();
            warehouseForm.ShowDialog();
        }

        private void MaterialManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialManagementForm materialForm = new MaterialManagementForm();
            materialForm.ShowDialog();
        }

        private void UserManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagementForm userForm = new UserManagementForm();
            userForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
