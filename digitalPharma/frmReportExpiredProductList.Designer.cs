namespace digitalPharma
{
    partial class frmReportExpiredProductList
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnExpired = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpExpired = new System.Windows.Forms.DateTimePicker();
            this.txtExpiredDays = new System.Windows.Forms.TextBox();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnExpired);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.dtpExpired);
            this.groupBox7.Controls.Add(this.txtExpiredDays);
            this.groupBox7.Location = new System.Drawing.Point(42, 29);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(336, 141);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Expired Product List";
            // 
            // btnExpired
            // 
            this.btnExpired.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(153)))));
            this.btnExpired.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpired.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpired.ForeColor = System.Drawing.Color.White;
            this.btnExpired.Location = new System.Drawing.Point(184, 97);
            this.btnExpired.Name = "btnExpired";
            this.btnExpired.Size = new System.Drawing.Size(95, 38);
            this.btnExpired.TabIndex = 2;
            this.btnExpired.Text = "Report";
            this.btnExpired.UseVisualStyleBackColor = false;
            this.btnExpired.Click += new System.EventHandler(this.btnExpired_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(61, 68);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 19);
            this.label21.TabIndex = 2;
            this.label21.Text = "Enter Days";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(102, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 19);
            this.label20.TabIndex = 2;
            this.label20.Text = "From";
            // 
            // dtpExpired
            // 
            this.dtpExpired.CustomFormat = "dd-MMM-yyyy";
            this.dtpExpired.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpired.Location = new System.Drawing.Point(161, 38);
            this.dtpExpired.Name = "dtpExpired";
            this.dtpExpired.Size = new System.Drawing.Size(139, 26);
            this.dtpExpired.TabIndex = 0;
            // 
            // txtExpiredDays
            // 
            this.txtExpiredDays.Location = new System.Drawing.Point(161, 65);
            this.txtExpiredDays.Name = "txtExpiredDays";
            this.txtExpiredDays.Size = new System.Drawing.Size(139, 26);
            this.txtExpiredDays.TabIndex = 1;
            this.txtExpiredDays.Leave += new System.EventHandler(this.txtExpiredDays_Leave);
            // 
            // frmReportExpiredProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(426, 202);
            this.Controls.Add(this.groupBox7);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReportExpiredProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expired Product List";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportExpiredProductList_KeyDown);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnExpired;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpExpired;
        private System.Windows.Forms.TextBox txtExpiredDays;
    }
}