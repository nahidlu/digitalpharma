namespace digitalPharma
{
    partial class frmTransferData
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
            this.Category = new System.Windows.Forms.Button();
            this.Product = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(56, 40);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(209, 44);
            this.btnSupplier.TabIndex = 0;
            this.btnSupplier.Text = "Transfer Supplier";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // Category
            // 
            this.Category.Location = new System.Drawing.Point(56, 100);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(209, 44);
            this.Category.TabIndex = 1;
            this.Category.Text = "Transfer Category Name";
            this.Category.UseVisualStyleBackColor = true;
            this.Category.Click += new System.EventHandler(this.Category_Click);
            // 
            // Product
            // 
            this.Product.Location = new System.Drawing.Point(56, 161);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(209, 44);
            this.Product.TabIndex = 2;
            this.Product.Text = "Transfer Product";
            this.Product.UseVisualStyleBackColor = true;
            this.Product.Click += new System.EventHandler(this.Product_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "Transfer Dosages Description";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(239, 44);
            this.button2.TabIndex = 4;
            this.button2.Text = "Replace Dosages Description";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(302, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(239, 44);
            this.button3.TabIndex = 5;
            this.button3.Text = "Create Supplier Accounts";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmTransferData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 361);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Product);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.btnSupplier);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTransferData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Data";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button Category;
        private System.Windows.Forms.Button Product;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}