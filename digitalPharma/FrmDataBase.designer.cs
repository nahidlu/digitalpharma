namespace digitalPharma
{
    partial class FrmDataBase
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
            this.GBBackup = new System.Windows.Forms.GroupBox();
            this.txtBshow = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnRestore = new System.Windows.Forms.Button();
            this.cmd1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.GBBackup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // GBBackup
            // 
            this.GBBackup.Controls.Add(this.txtBshow);
            this.GBBackup.Controls.Add(this.button3);
            this.GBBackup.Controls.Add(this.button2);
            this.GBBackup.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBBackup.Location = new System.Drawing.Point(164, 174);
            this.GBBackup.Name = "GBBackup";
            this.GBBackup.Size = new System.Drawing.Size(497, 97);
            this.GBBackup.TabIndex = 0;
            this.GBBackup.TabStop = false;
            this.GBBackup.Text = "Backup DataBase";
            // 
            // txtBshow
            // 
            this.txtBshow.Location = new System.Drawing.Point(170, 19);
            this.txtBshow.Name = "txtBshow";
            this.txtBshow.Size = new System.Drawing.Size(185, 26);
            this.txtBshow.TabIndex = 5;
            this.txtBshow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBshow_KeyPress);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(295, 56);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Backup Database";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.BtnRestore);
            this.groupBox1.Controls.Add(this.cmd1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(164, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Restore DataBase";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnRestore
            // 
            this.BtnRestore.Location = new System.Drawing.Point(198, 78);
            this.BtnRestore.Name = "BtnRestore";
            this.BtnRestore.Size = new System.Drawing.Size(80, 29);
            this.BtnRestore.TabIndex = 1;
            this.BtnRestore.Text = "Restore";
            this.BtnRestore.UseVisualStyleBackColor = true;
            this.BtnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // cmd1
            // 
            this.cmd1.FormattingEnabled = true;
            this.cmd1.Location = new System.Drawing.Point(202, 36);
            this.cmd1.Name = "cmd1";
            this.cmd1.Size = new System.Drawing.Size(173, 27);
            this.cmd1.TabIndex = 0;
            this.cmd1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmd1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Backup DataBase:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(61, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(620, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Note: If You Restore Database the System will be restarted. So, Save and close al" +
                "l other operation.";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::digitalPharma.Properties.Resources.backup_vault;
            this.pictureBox4.Location = new System.Drawing.Point(533, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(138, 141);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::digitalPharma.Properties.Resources.backup;
            this.pictureBox3.Location = new System.Drawing.Point(14, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(131, 124);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::digitalPharma.Properties.Resources.databse;
            this.pictureBox2.Location = new System.Drawing.Point(170, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(339, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // FrmDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(686, 480);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GBBackup);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.KeyPreview = true;
            this.Name = "FrmDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Base Backup and Restore";
            this.Load += new System.EventHandler(this.FrmDataBase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDataBase_KeyDown);
            this.GBBackup.ResumeLayout(false);
            this.GBBackup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.GroupBox GBBackup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnRestore;
        private System.Windows.Forms.ComboBox cmd1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBshow;
        private System.Windows.Forms.Label label2;
    }
}