namespace digitalPharma
{
    partial class frmSubMenuForSalesMan
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExpired = new System.Windows.Forms.Button();
            this.btnDB = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExit.BackgroundImage = global::digitalPharma.Properties.Resources.exit1;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Location = new System.Drawing.Point(8, 342);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(234, 62);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExpired
            // 
            this.btnExpired.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExpired.BackgroundImage = global::digitalPharma.Properties.Resources.reports1;
            this.btnExpired.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExpired.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpired.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExpired.Location = new System.Drawing.Point(9, 135);
            this.btnExpired.Name = "btnExpired";
            this.btnExpired.Size = new System.Drawing.Size(234, 62);
            this.btnExpired.TabIndex = 1;
            this.btnExpired.UseVisualStyleBackColor = false;
            this.btnExpired.Click += new System.EventHandler(this.btnExpired_Click);
            // 
            // btnDB
            // 
            this.btnDB.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDB.BackgroundImage = global::digitalPharma.Properties.Resources.backup1;
            this.btnDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDB.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDB.Location = new System.Drawing.Point(9, 203);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(234, 62);
            this.btnDB.TabIndex = 2;
            this.btnDB.UseVisualStyleBackColor = false;
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSale.BackgroundImage = global::digitalPharma.Properties.Resources.sales;
            this.btnSale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSale.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnSale.Location = new System.Drawing.Point(9, 67);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(233, 62);
            this.btnSale.TabIndex = 0;
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnReceipt
            // 
            this.btnReceipt.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReceipt.BackgroundImage = global::digitalPharma.Properties.Resources.receipt;
            this.btnReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReceipt.Location = new System.Drawing.Point(9, 274);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(234, 62);
            this.btnReceipt.TabIndex = 3;
            this.btnReceipt.UseVisualStyleBackColor = false;
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            // 
            // frmSubMenuForSalesMan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(245, 650);
            this.ControlBox = false;
            this.Controls.Add(this.btnReceipt);
            this.Controls.Add(this.btnExpired);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDB);
            this.Controls.Add(this.btnSale);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubMenuForSalesMan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Sub Menu";
            this.Load += new System.EventHandler(this.frmSubMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSubMenu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnDB;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExpired;
        private System.Windows.Forms.Button btnReceipt;
    }
}