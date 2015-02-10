namespace digitalPharma
{
    partial class frmHeadEntry
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
            this.cmbGL = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubHeadName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgSubHead = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearLHead = new System.Windows.Forms.Button();
            this.cmbSubHeadName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGL2 = new System.Windows.Forms.ComboBox();
            this.dgLedgerHead = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteLHead = new System.Windows.Forms.Button();
            this.btnSaveLHead = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubHead)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedgerHead)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbGL
            // 
            this.cmbGL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGL.FormattingEnabled = true;
            this.cmbGL.Location = new System.Drawing.Point(136, 35);
            this.cmbGL.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGL.Name = "cmbGL";
            this.cmbGL.Size = new System.Drawing.Size(199, 27);
            this.cmbGL.TabIndex = 0;
            this.cmbGL.SelectedIndexChanged += new System.EventHandler(this.cmbGL_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selelct GL";
            // 
            // txtSubHeadName
            // 
            this.txtSubHeadName.Location = new System.Drawing.Point(136, 70);
            this.txtSubHeadName.Name = "txtSubHeadName";
            this.txtSubHeadName.Size = new System.Drawing.Size(198, 26);
            this.txtSubHeadName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sub Head Name";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(136, 102);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.dgSubHead);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtSubHeadName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbGL);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 421);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sub Head";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(273, 102);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(61, 29);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(207, 102);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 29);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgSubHead
            // 
            this.dgSubHead.AllowUserToDeleteRows = false;
            this.dgSubHead.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSubHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgSubHead.Location = new System.Drawing.Point(8, 143);
            this.dgSubHead.Name = "dgSubHead";
            this.dgSubHead.ReadOnly = true;
            this.dgSubHead.Size = new System.Drawing.Size(326, 272);
            this.dgSubHead.TabIndex = 4;
            this.dgSubHead.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSubHead_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "SubGLID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "GL";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Sub Head Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearLHead);
            this.groupBox2.Controls.Add(this.cmbSubHeadName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbGL2);
            this.groupBox2.Controls.Add(this.dgLedgerHead);
            this.groupBox2.Controls.Add(this.btnDeleteLHead);
            this.groupBox2.Controls.Add(this.btnSaveLHead);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtAccountName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(381, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 420);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ledger Head";
            // 
            // btnClearLHead
            // 
            this.btnClearLHead.Location = new System.Drawing.Point(382, 195);
            this.btnClearLHead.Name = "btnClearLHead";
            this.btnClearLHead.Size = new System.Drawing.Size(63, 29);
            this.btnClearLHead.TabIndex = 16;
            this.btnClearLHead.Text = "Clear";
            this.btnClearLHead.UseVisualStyleBackColor = true;
            this.btnClearLHead.Click += new System.EventHandler(this.btnClearLHead_Click);
            // 
            // cmbSubHeadName
            // 
            this.cmbSubHeadName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSubHeadName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubHeadName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubHeadName.FormattingEnabled = true;
            this.cmbSubHeadName.Location = new System.Drawing.Point(221, 53);
            this.cmbSubHeadName.Name = "cmbSubHeadName";
            this.cmbSubHeadName.Size = new System.Drawing.Size(223, 27);
            this.cmbSubHeadName.TabIndex = 7;
            this.cmbSubHeadName.SelectedIndexChanged += new System.EventHandler(this.cmbSubHeadName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Selelct GL";
            // 
            // cmbGL2
            // 
            this.cmbGL2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGL2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGL2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGL2.FormattingEnabled = true;
            this.cmbGL2.Location = new System.Drawing.Point(219, 19);
            this.cmbGL2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGL2.Name = "cmbGL2";
            this.cmbGL2.Size = new System.Drawing.Size(226, 27);
            this.cmbGL2.TabIndex = 6;
            this.cmbGL2.SelectedIndexChanged += new System.EventHandler(this.cmbGL2_SelectedIndexChanged);
            // 
            // dgLedgerHead
            // 
            this.dgLedgerHead.AllowUserToDeleteRows = false;
            this.dgLedgerHead.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLedgerHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLedgerHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgLedgerHead.Location = new System.Drawing.Point(6, 232);
            this.dgLedgerHead.Name = "dgLedgerHead";
            this.dgLedgerHead.ReadOnly = true;
            this.dgLedgerHead.Size = new System.Drawing.Size(481, 182);
            this.dgLedgerHead.TabIndex = 13;
            this.dgLedgerHead.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLedgerHead_CellDoubleClick);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "SN";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "GL Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Sub Head Name";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Account Name";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Description";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Account No";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // btnDeleteLHead
            // 
            this.btnDeleteLHead.Enabled = false;
            this.btnDeleteLHead.Location = new System.Drawing.Point(299, 195);
            this.btnDeleteLHead.Name = "btnDeleteLHead";
            this.btnDeleteLHead.Size = new System.Drawing.Size(74, 29);
            this.btnDeleteLHead.TabIndex = 12;
            this.btnDeleteLHead.Text = "Delete";
            this.btnDeleteLHead.UseVisualStyleBackColor = true;
            this.btnDeleteLHead.Click += new System.EventHandler(this.btnDeleteLHead_Click);
            // 
            // btnSaveLHead
            // 
            this.btnSaveLHead.Location = new System.Drawing.Point(219, 195);
            this.btnSaveLHead.Name = "btnSaveLHead";
            this.btnSaveLHead.Size = new System.Drawing.Size(74, 29);
            this.btnSaveLHead.TabIndex = 11;
            this.btnSaveLHead.Text = "Save";
            this.btnSaveLHead.UseVisualStyleBackColor = true;
            this.btnSaveLHead.Click += new System.EventHandler(this.btnSaveLHead_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(220, 129);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(225, 60);
            this.txtDescription.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Description";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(220, 94);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(225, 26);
            this.txtAccountName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Select Sub Head Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Account Name";
            // 
            // frmHeadEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(886, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHeadEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Head Entry";
            this.Load += new System.EventHandler(this.frmSubHead_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHeadEntry_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubHead)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedgerHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbGL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubHeadName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgSubHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgLedgerHead;
        private System.Windows.Forms.Button btnDeleteLHead;
        private System.Windows.Forms.Button btnSaveLHead;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGL2;
        private System.Windows.Forms.ComboBox cmbSubHeadName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClearLHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}