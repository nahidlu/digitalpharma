namespace digitalPharma
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseHeadEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDiscountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Teal;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.expenseToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.sETToolStripMenuItem,
            this.databaseBackupToolStripMenuItem,
            this.stockManagementToolStripMenuItem,
            this.setToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageAccountToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageAccountToolStripMenuItem
            // 
            this.manageAccountToolStripMenuItem.Name = "manageAccountToolStripMenuItem";
            this.manageAccountToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.manageAccountToolStripMenuItem.Text = "Manage Employee Account";
            this.manageAccountToolStripMenuItem.Click += new System.EventHandler(this.manageAccountToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesFormToolStripMenuItem,
            this.purchaseFormToolStripMenuItem,
            this.productGroupToolStripMenuItem,
            this.supplierFormToolStripMenuItem});
            this.manageToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // salesFormToolStripMenuItem
            // 
            this.salesFormToolStripMenuItem.Name = "salesFormToolStripMenuItem";
            this.salesFormToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.salesFormToolStripMenuItem.Text = "Sales Form";
            this.salesFormToolStripMenuItem.Click += new System.EventHandler(this.salesFormToolStripMenuItem_Click);
            // 
            // purchaseFormToolStripMenuItem
            // 
            this.purchaseFormToolStripMenuItem.Name = "purchaseFormToolStripMenuItem";
            this.purchaseFormToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.purchaseFormToolStripMenuItem.Text = "Purchase Form";
            this.purchaseFormToolStripMenuItem.Click += new System.EventHandler(this.purchaseFormToolStripMenuItem_Click);
            // 
            // productGroupToolStripMenuItem
            // 
            this.productGroupToolStripMenuItem.Name = "productGroupToolStripMenuItem";
            this.productGroupToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.productGroupToolStripMenuItem.Text = "Product Category / Name";
            this.productGroupToolStripMenuItem.Click += new System.EventHandler(this.productGroupToolStripMenuItem_Click);
            // 
            // supplierFormToolStripMenuItem
            // 
            this.supplierFormToolStripMenuItem.Name = "supplierFormToolStripMenuItem";
            this.supplierFormToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.supplierFormToolStripMenuItem.Text = "Supplier Form";
            this.supplierFormToolStripMenuItem.Click += new System.EventHandler(this.supplierFormToolStripMenuItem_Click);
            // 
            // expenseToolStripMenuItem
            // 
            this.expenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expenseHeadEntryToolStripMenuItem,
            this.ledgerToolStripMenuItem,
            this.expenseEntryToolStripMenuItem,
            this.supplierPaymentToolStripMenuItem});
            this.expenseToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.expenseToolStripMenuItem.Name = "expenseToolStripMenuItem";
            this.expenseToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.expenseToolStripMenuItem.Text = "Accounts";
            // 
            // expenseHeadEntryToolStripMenuItem
            // 
            this.expenseHeadEntryToolStripMenuItem.Name = "expenseHeadEntryToolStripMenuItem";
            this.expenseHeadEntryToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.expenseHeadEntryToolStripMenuItem.Text = "Head Entry";
            this.expenseHeadEntryToolStripMenuItem.Click += new System.EventHandler(this.expenseHeadEntryToolStripMenuItem_Click);
            // 
            // ledgerToolStripMenuItem
            // 
            this.ledgerToolStripMenuItem.Name = "ledgerToolStripMenuItem";
            this.ledgerToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.ledgerToolStripMenuItem.Text = "Income Entry";
            this.ledgerToolStripMenuItem.Click += new System.EventHandler(this.ledgerToolStripMenuItem_Click);
            // 
            // expenseEntryToolStripMenuItem
            // 
            this.expenseEntryToolStripMenuItem.Name = "expenseEntryToolStripMenuItem";
            this.expenseEntryToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.expenseEntryToolStripMenuItem.Text = "Expense Entry";
            this.expenseEntryToolStripMenuItem.Click += new System.EventHandler(this.expenseEntryToolStripMenuItem_Click);
            // 
            // supplierPaymentToolStripMenuItem
            // 
            this.supplierPaymentToolStripMenuItem.Name = "supplierPaymentToolStripMenuItem";
            this.supplierPaymentToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.supplierPaymentToolStripMenuItem.Text = "Supplier Payment";
            this.supplierPaymentToolStripMenuItem.Click += new System.EventHandler(this.supplierPaymentToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allReportsToolStripMenuItem});
            this.reportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // allReportsToolStripMenuItem
            // 
            this.allReportsToolStripMenuItem.Name = "allReportsToolStripMenuItem";
            this.allReportsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.allReportsToolStripMenuItem.Text = "All Reports";
            this.allReportsToolStripMenuItem.Click += new System.EventHandler(this.allReportsToolStripMenuItem_Click);
            // 
            // sETToolStripMenuItem
            // 
            this.sETToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDiscountToolStripMenuItem});
            this.sETToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sETToolStripMenuItem.Name = "sETToolStripMenuItem";
            this.sETToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.sETToolStripMenuItem.Text = "SET";
            this.sETToolStripMenuItem.Visible = false;
            // 
            // setDiscountToolStripMenuItem
            // 
            this.setDiscountToolStripMenuItem.Name = "setDiscountToolStripMenuItem";
            this.setDiscountToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.setDiscountToolStripMenuItem.Text = "Set Discount";
            // 
            // databaseBackupToolStripMenuItem
            // 
            this.databaseBackupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.databaseBackupToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.databaseBackupToolStripMenuItem.Name = "databaseBackupToolStripMenuItem";
            this.databaseBackupToolStripMenuItem.Size = new System.Drawing.Size(144, 20);
            this.databaseBackupToolStripMenuItem.Text = "Database Backup";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // stockManagementToolStripMenuItem
            // 
            this.stockManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockManagementToolStripMenuItem1});
            this.stockManagementToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.stockManagementToolStripMenuItem.Name = "stockManagementToolStripMenuItem";
            this.stockManagementToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.stockManagementToolStripMenuItem.Text = "Stock Management";
            // 
            // stockManagementToolStripMenuItem1
            // 
            this.stockManagementToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stockManagementToolStripMenuItem1.Name = "stockManagementToolStripMenuItem1";
            this.stockManagementToolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            this.stockManagementToolStripMenuItem1.Text = "Stock Management";
            this.stockManagementToolStripMenuItem1.Click += new System.EventHandler(this.stockManagementToolStripMenuItem1_Click);
            // 
            // setToolStripMenuItem1
            // 
            this.setToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem2});
            this.setToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.setToolStripMenuItem1.Name = "setToolStripMenuItem1";
            this.setToolStripMenuItem1.Size = new System.Drawing.Size(76, 20);
            this.setToolStripMenuItem1.Text = "Settings";
            // 
            // setToolStripMenuItem2
            // 
            this.setToolStripMenuItem2.Name = "setToolStripMenuItem2";
            this.setToolStripMenuItem2.Size = new System.Drawing.Size(99, 22);
            this.setToolStripMenuItem2.Text = "Set";
            this.setToolStripMenuItem2.Click += new System.EventHandler(this.setToolStripMenuItem2_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 616);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenseHeadEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDiscountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockManagementToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem supplierFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenseEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem supplierPaymentToolStripMenuItem;
    }
}

