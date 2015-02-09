namespace digitalPharma
{
    partial class frmSubMenu
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
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnDB = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnExpired = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSupplier.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.Location = new System.Drawing.Point(12, 204);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(245, 51);
            this.btnSupplier.TabIndex = 3;
            this.btnSupplier.Text = "Supplier Form";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.Color.White;
            this.btnSale.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.Location = new System.Drawing.Point(12, 33);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(245, 51);
            this.btnSale.TabIndex = 0;
            this.btnSale.Text = "Sales Form";
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCategory.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.Location = new System.Drawing.Point(12, 147);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(245, 51);
            this.btnCategory.TabIndex = 2;
            this.btnCategory.Text = "Product Category";
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnDB
            // 
            this.btnDB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDB.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDB.Location = new System.Drawing.Point(12, 316);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(245, 51);
            this.btnDB.TabIndex = 5;
            this.btnDB.Text = "DB Backup";
            this.btnDB.UseVisualStyleBackColor = false;
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(12, 373);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(245, 51);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPurchase.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.Location = new System.Drawing.Point(12, 90);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(245, 51);
            this.btnPurchase.TabIndex = 1;
            this.btnPurchase.Text = "Purchase Form";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnExpired
            // 
            this.btnExpired.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExpired.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpired.Location = new System.Drawing.Point(12, 259);
            this.btnExpired.Name = "btnExpired";
            this.btnExpired.Size = new System.Drawing.Size(245, 51);
            this.btnExpired.TabIndex = 4;
            this.btnExpired.Text = "Expired List";
            this.btnExpired.UseVisualStyleBackColor = false;
            this.btnExpired.Click += new System.EventHandler(this.btnExpired_Click);
            // 
            // frmSubMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(265, 545);
            this.ControlBox = false;
            this.Controls.Add(this.btnExpired);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDB);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnSupplier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sub Menu";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSubMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSubMenu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnDB;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnExpired;
    }
}