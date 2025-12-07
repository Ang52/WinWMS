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
