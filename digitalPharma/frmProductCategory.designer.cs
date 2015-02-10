namespace digitalPharma
{
    partial class frmProductCategory
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
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgCategory = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClearProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.dgProductName = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbUseFor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDosageDescription = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSupplierName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtProductUseFor = new System.Windows.Forms.TextBox();
            this.txtDosagesDescription = new System.Windows.Forms.TextBox();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.txtNoOfBarcode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalStock = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProductNameUpdate = new System.Windows.Forms.TextBox();
            this.txtProductCategoryUpdate = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClearUpdate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSalesPrice = new System.Windows.Forms.TextBox();
            this.txtUnitCost = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtProductIDUpdate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductName)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(27, 44);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(237, 22);
            this.txtCategoryName.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(27, 72);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Product Category Name";
            // 
            // dgCategory
            // 
            this.dgCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCategory.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgCategory.Location = new System.Drawing.Point(13, 112);
            this.dgCategory.Name = "dgCategory";
            this.dgCategory.Size = new System.Drawing.Size(251, 359);
            this.dgCategory.TabIndex = 4;
            this.dgCategory.TabStop = false;
            this.dgCategory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCategory_CellDoubleClick_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(108, 72);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(189, 72);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClearProduct
            // 
            this.btnClearProduct.Location = new System.Drawing.Point(332, 204);
            this.btnClearProduct.Name = "btnClearProduct";
            this.btnClearProduct.Size = new System.Drawing.Size(75, 26);
            this.btnClearProduct.TabIndex = 8;
            this.btnClearProduct.Text = "Clear";
            this.btnClearProduct.UseVisualStyleBackColor = true;
            this.btnClearProduct.Click += new System.EventHandler(this.btnClearProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Enabled = false;
            this.btnDeleteProduct.Location = new System.Drawing.Point(251, 204);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(75, 26);
            this.btnDeleteProduct.TabIndex = 7;
            this.btnDeleteProduct.Text = "Delete";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // dgProductName
            // 
            this.dgProductName.AllowUserToDeleteRows = false;
            this.dgProductName.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProductName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2});
            this.dgProductName.Location = new System.Drawing.Point(13, 236);
            this.dgProductName.Name = "dgProductName";
            this.dgProductName.ReadOnly = true;
            this.dgProductName.Size = new System.Drawing.Size(417, 233);
            this.dgProductName.TabIndex = 5;
            this.dgProductName.TabStop = false;
            this.dgProductName.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductName_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "sn";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Product ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Product Name";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(170, 204);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 26);
            this.btnAddProduct.TabIndex = 6;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(170, 148);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(269, 22);
            this.txtProductName.TabIndex = 4;
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(127, 24);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(312, 24);
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.DropDown += new System.EventHandler(this.cmbCategory_DropDown);
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Category Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbUseFor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbDosageDescription);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbSupplierName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtProductID);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.btnClearProduct);
            this.groupBox1.Controls.Add(this.btnDeleteProduct);
            this.groupBox1.Controls.Add(this.dgProductName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblProductID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAddProduct);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Location = new System.Drawing.Point(296, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 475);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Name";
            // 
            // cmbUseFor
            // 
            this.cmbUseFor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbUseFor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUseFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUseFor.FormattingEnabled = true;
            this.cmbUseFor.Items.AddRange(new object[] {
            "Human",
            "Veterinary"});
            this.cmbUseFor.Location = new System.Drawing.Point(170, 118);
            this.cmbUseFor.Name = "cmbUseFor";
            this.cmbUseFor.Size = new System.Drawing.Size(269, 24);
            this.cmbUseFor.Sorted = true;
            this.cmbUseFor.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Product Use For";
            // 
            // cmbDosageDescription
            // 
            this.cmbDosageDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDosageDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDosageDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDosageDescription.FormattingEnabled = true;
            this.cmbDosageDescription.Location = new System.Drawing.Point(170, 88);
            this.cmbDosageDescription.Name = "cmbDosageDescription";
            this.cmbDosageDescription.Size = new System.Drawing.Size(269, 24);
            this.cmbDosageDescription.Sorted = true;
            this.cmbDosageDescription.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Dosages Description";
            // 
            // cmbSupplierName
            // 
            this.cmbSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplierName.FormattingEnabled = true;
            this.cmbSupplierName.Location = new System.Drawing.Point(127, 54);
            this.cmbSupplierName.Name = "cmbSupplierName";
            this.cmbSupplierName.Size = new System.Drawing.Size(312, 24);
            this.cmbSupplierName.Sorted = true;
            this.cmbSupplierName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Supplier Name";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(170, 176);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(236, 22);
            this.txtProductID.TabIndex = 5;
            this.txtProductID.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(412, 179);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(84, 179);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(80, 16);
            this.lblProductID.TabIndex = 7;
            this.lblProductID.Text = "Product ID";
            this.lblProductID.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.dgCategory);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtCategoryName);
            this.groupBox2.Location = new System.Drawing.Point(8, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 477);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Category";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtProductUseFor);
            this.groupBox3.Controls.Add(this.txtDosagesDescription);
            this.groupBox3.Controls.Add(this.cmbProductName);
            this.groupBox3.Controls.Add(this.btnBarcode);
            this.groupBox3.Controls.Add(this.txtNoOfBarcode);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtTotalStock);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtProductNameUpdate);
            this.groupBox3.Controls.Add(this.txtProductCategoryUpdate);
            this.groupBox3.Controls.Add(this.txtSupplierName);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.btnClearUpdate);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtSalesPrice);
            this.groupBox3.Controls.Add(this.txtUnitCost);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtProductIDUpdate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(747, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 469);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Product Price Update";
            // 
            // txtProductUseFor
            // 
            this.txtProductUseFor.Location = new System.Drawing.Point(150, 171);
            this.txtProductUseFor.Name = "txtProductUseFor";
            this.txtProductUseFor.ReadOnly = true;
            this.txtProductUseFor.Size = new System.Drawing.Size(164, 22);
            this.txtProductUseFor.TabIndex = 49;
            this.txtProductUseFor.TabStop = false;
            // 
            // txtDosagesDescription
            // 
            this.txtDosagesDescription.Location = new System.Drawing.Point(150, 144);
            this.txtDosagesDescription.Name = "txtDosagesDescription";
            this.txtDosagesDescription.ReadOnly = true;
            this.txtDosagesDescription.Size = new System.Drawing.Size(164, 22);
            this.txtDosagesDescription.TabIndex = 49;
            this.txtDosagesDescription.TabStop = false;
            // 
            // cmbProductName
            // 
            this.cmbProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(8, 45);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(311, 23);
            this.cmbProductName.TabIndex = 48;
            this.cmbProductName.SelectedIndexChanged += new System.EventHandler(this.cmbProductName_SelectedIndexChanged);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Enabled = false;
            this.btnBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarcode.Location = new System.Drawing.Point(235, 334);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(87, 28);
            this.btnBarcode.TabIndex = 10;
            this.btnBarcode.Text = "Barcode";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Visible = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // txtNoOfBarcode
            // 
            this.txtNoOfBarcode.Location = new System.Drawing.Point(153, 338);
            this.txtNoOfBarcode.Name = "txtNoOfBarcode";
            this.txtNoOfBarcode.Size = new System.Drawing.Size(73, 22);
            this.txtNoOfBarcode.TabIndex = 9;
            this.txtNoOfBarcode.TabStop = false;
            this.txtNoOfBarcode.Visible = false;
            this.txtNoOfBarcode.Leave += new System.EventHandler(this.txtNoOfBarcode_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(40, 341);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 16);
            this.label15.TabIndex = 47;
            this.label15.Text = "No of Barcode";
            this.label15.Visible = false;
            // 
            // txtTotalStock
            // 
            this.txtTotalStock.Location = new System.Drawing.Point(150, 267);
            this.txtTotalStock.Name = "txtTotalStock";
            this.txtTotalStock.ReadOnly = true;
            this.txtTotalStock.Size = new System.Drawing.Size(169, 22);
            this.txtTotalStock.TabIndex = 6;
            this.txtTotalStock.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(57, 270);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 16);
            this.label13.TabIndex = 44;
            this.label13.Text = "Total Stock";
            // 
            // txtProductNameUpdate
            // 
            this.txtProductNameUpdate.Location = new System.Drawing.Point(159, 384);
            this.txtProductNameUpdate.Name = "txtProductNameUpdate";
            this.txtProductNameUpdate.ReadOnly = true;
            this.txtProductNameUpdate.Size = new System.Drawing.Size(164, 22);
            this.txtProductNameUpdate.TabIndex = 3;
            this.txtProductNameUpdate.TabStop = false;
            this.txtProductNameUpdate.Visible = false;
            // 
            // txtProductCategoryUpdate
            // 
            this.txtProductCategoryUpdate.Location = new System.Drawing.Point(150, 116);
            this.txtProductCategoryUpdate.Name = "txtProductCategoryUpdate";
            this.txtProductCategoryUpdate.ReadOnly = true;
            this.txtProductCategoryUpdate.Size = new System.Drawing.Size(164, 22);
            this.txtProductCategoryUpdate.TabIndex = 2;
            this.txtProductCategoryUpdate.TabStop = false;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(150, 88);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(164, 22);
            this.txtSupplierName.TabIndex = 1;
            this.txtSupplierName.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(153, 302);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 26);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClearUpdate
            // 
            this.btnClearUpdate.Location = new System.Drawing.Point(243, 302);
            this.btnClearUpdate.Name = "btnClearUpdate";
            this.btnClearUpdate.Size = new System.Drawing.Size(79, 26);
            this.btnClearUpdate.TabIndex = 8;
            this.btnClearUpdate.Text = "Clear";
            this.btnClearUpdate.UseVisualStyleBackColor = true;
            this.btnClearUpdate.Click += new System.EventHandler(this.btnClearUpdate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Supplier Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Product Use For";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 387);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 16);
            this.label11.TabIndex = 35;
            this.label11.Text = "Product Name";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "Product Category";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 16);
            this.label10.TabIndex = 34;
            this.label10.Text = "Doses Description";
            // 
            // txtSalesPrice
            // 
            this.txtSalesPrice.Location = new System.Drawing.Point(150, 239);
            this.txtSalesPrice.Name = "txtSalesPrice";
            this.txtSalesPrice.Size = new System.Drawing.Size(169, 22);
            this.txtSalesPrice.TabIndex = 5;
            this.txtSalesPrice.Leave += new System.EventHandler(this.txtSalesPrice_Leave);
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.Location = new System.Drawing.Point(150, 211);
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(169, 22);
            this.txtUnitCost.TabIndex = 4;
            this.txtUnitCost.Leave += new System.EventHandler(this.txtUnitCost_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(26, 242);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 16);
            this.label17.TabIndex = 32;
            this.label17.Text = "Unit Sales Price";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 211);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 16);
            this.label14.TabIndex = 33;
            this.label14.Text = "Unit Cost Price";
            // 
            // txtProductIDUpdate
            // 
            this.txtProductIDUpdate.Location = new System.Drawing.Point(289, 17);
            this.txtProductIDUpdate.Name = "txtProductIDUpdate";
            this.txtProductIDUpdate.Size = new System.Drawing.Size(33, 22);
            this.txtProductIDUpdate.TabIndex = 0;
            this.txtProductIDUpdate.Visible = false;
            this.txtProductIDUpdate.TextChanged += new System.EventHandler(this.txtProductIDUpdate_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(100, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Select Product Name";
            // 
            // frmProductCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 499);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Teal;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Product Category";
            this.Load += new System.EventHandler(this.frmProductCategory_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductCategory_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductName)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgCategory;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClearProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.DataGridView dgProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtProductIDUpdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSalesPrice;
        private System.Windows.Forms.TextBox txtUnitCost;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClearUpdate;
        private System.Windows.Forms.TextBox txtProductNameUpdate;
        private System.Windows.Forms.TextBox txtProductCategoryUpdate;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtTotalStock;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.TextBox txtNoOfBarcode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ComboBox cmbUseFor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDosageDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSupplierName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.TextBox txtProductUseFor;
        private System.Windows.Forms.TextBox txtDosagesDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
    }
}