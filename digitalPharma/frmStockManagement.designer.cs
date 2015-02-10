namespace digitalPharma
{
    partial class frmStockManagement
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbProductNameStock = new System.Windows.Forms.ComboBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear1 = new System.Windows.Forms.Button();
            this.cbReturnToSupplier = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtSubProduct = new System.Windows.Forms.TextBox();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.txtAddProduct = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUnitSalesPrice = new System.Windows.Forms.TextBox();
            this.txtStockAmount = new System.Windows.Forms.TextBox();
            this.txtCurrentStock = new System.Windows.Forms.TextBox();
            this.txtTotalSale = new System.Windows.Forms.TextBox();
            this.txtTotalPurchase = new System.Windows.Forms.TextBox();
            this.txtUnitCostPrice = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCategory = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgSearch = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(901, 501);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cmbProductNameStock);
            this.tabPage1.Controls.Add(this.txtProductID);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(893, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Change Stock";
            // 
            // cmbProductNameStock
            // 
            this.cmbProductNameStock.FormattingEnabled = true;
            this.cmbProductNameStock.Location = new System.Drawing.Point(214, 40);
            this.cmbProductNameStock.Name = "cmbProductNameStock";
            this.cmbProductNameStock.Size = new System.Drawing.Size(275, 24);
            this.cmbProductNameStock.TabIndex = 5;
            this.cmbProductNameStock.SelectedIndexChanged += new System.EventHandler(this.cmbProductNameStock_SelectedIndexChanged);
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(736, 19);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(46, 22);
            this.txtProductID.TabIndex = 2;
            this.txtProductID.Visible = false;
            this.txtProductID.TextChanged += new System.EventHandler(this.txtProductID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Product Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClear1);
            this.groupBox2.Controls.Add(this.cbReturnToSupplier);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.dtpDate);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtTotalPrice);
            this.groupBox2.Controls.Add(this.txtSubProduct);
            this.groupBox2.Controls.Add(this.txtTotalCost);
            this.groupBox2.Controls.Add(this.txtAddProduct);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(494, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 297);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add / Sub Product";
            // 
            // btnClear1
            // 
            this.btnClear1.Location = new System.Drawing.Point(282, 239);
            this.btnClear1.Name = "btnClear1";
            this.btnClear1.Size = new System.Drawing.Size(75, 23);
            this.btnClear1.TabIndex = 5;
            this.btnClear1.Text = "Clear";
            this.btnClear1.UseVisualStyleBackColor = true;
            this.btnClear1.Click += new System.EventHandler(this.btnClear1_Click);
            // 
            // cbReturnToSupplier
            // 
            this.cbReturnToSupplier.Location = new System.Drawing.Point(31, 241);
            this.cbReturnToSupplier.Name = "cbReturnToSupplier";
            this.cbReturnToSupplier.Size = new System.Drawing.Size(164, 20);
            this.cbReturnToSupplier.TabIndex = 3;
            this.cbReturnToSupplier.Text = "Return To Supplier";
            this.cbReturnToSupplier.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(201, 241);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(182, 36);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(196, 22);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(181, 175);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(198, 57);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Text = "";
            this.txtDescription.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Total Cost (+)";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(181, 147);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(197, 22);
            this.txtTotalPrice.TabIndex = 0;
            this.txtTotalPrice.TabStop = false;
            // 
            // txtSubProduct
            // 
            this.txtSubProduct.Location = new System.Drawing.Point(181, 118);
            this.txtSubProduct.Name = "txtSubProduct";
            this.txtSubProduct.Size = new System.Drawing.Size(197, 22);
            this.txtSubProduct.TabIndex = 2;
            this.txtSubProduct.Leave += new System.EventHandler(this.txtSubProduct_Leave);
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(181, 91);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(197, 22);
            this.txtTotalCost.TabIndex = 0;
            this.txtTotalCost.TabStop = false;
            // 
            // txtAddProduct
            // 
            this.txtAddProduct.Location = new System.Drawing.Point(182, 62);
            this.txtAddProduct.Name = "txtAddProduct";
            this.txtAddProduct.Size = new System.Drawing.Size(197, 22);
            this.txtAddProduct.TabIndex = 1;
            this.txtAddProduct.Leave += new System.EventHandler(this.txtAddProduct_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Add Product";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 178);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 16);
            this.label16.TabIndex = 1;
            this.label16.Text = "Description";
            this.label16.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 16);
            this.label14.TabIndex = 1;
            this.label14.Text = "Sub Product";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 16);
            this.label15.TabIndex = 1;
            this.label15.Text = "Total Price (-)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUnitSalesPrice);
            this.groupBox1.Controls.Add(this.txtStockAmount);
            this.groupBox1.Controls.Add(this.txtCurrentStock);
            this.groupBox1.Controls.Add(this.txtTotalSale);
            this.groupBox1.Controls.Add(this.txtTotalPurchase);
            this.groupBox1.Controls.Add(this.txtUnitCostPrice);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.txtProductCategory);
            this.groupBox1.Controls.Add(this.txtSupplier);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(45, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Information";
            // 
            // txtUnitSalesPrice
            // 
            this.txtUnitSalesPrice.Location = new System.Drawing.Point(169, 147);
            this.txtUnitSalesPrice.Name = "txtUnitSalesPrice";
            this.txtUnitSalesPrice.ReadOnly = true;
            this.txtUnitSalesPrice.Size = new System.Drawing.Size(197, 22);
            this.txtUnitSalesPrice.TabIndex = 0;
            this.txtUnitSalesPrice.TabStop = false;
            // 
            // txtStockAmount
            // 
            this.txtStockAmount.Location = new System.Drawing.Point(169, 260);
            this.txtStockAmount.Name = "txtStockAmount";
            this.txtStockAmount.ReadOnly = true;
            this.txtStockAmount.Size = new System.Drawing.Size(197, 22);
            this.txtStockAmount.TabIndex = 0;
            this.txtStockAmount.TabStop = false;
            // 
            // txtCurrentStock
            // 
            this.txtCurrentStock.Location = new System.Drawing.Point(169, 233);
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Size = new System.Drawing.Size(197, 22);
            this.txtCurrentStock.TabIndex = 0;
            this.txtCurrentStock.TabStop = false;
            // 
            // txtTotalSale
            // 
            this.txtTotalSale.Location = new System.Drawing.Point(169, 202);
            this.txtTotalSale.Name = "txtTotalSale";
            this.txtTotalSale.ReadOnly = true;
            this.txtTotalSale.Size = new System.Drawing.Size(197, 22);
            this.txtTotalSale.TabIndex = 0;
            this.txtTotalSale.TabStop = false;
            // 
            // txtTotalPurchase
            // 
            this.txtTotalPurchase.Location = new System.Drawing.Point(169, 172);
            this.txtTotalPurchase.Name = "txtTotalPurchase";
            this.txtTotalPurchase.ReadOnly = true;
            this.txtTotalPurchase.Size = new System.Drawing.Size(197, 22);
            this.txtTotalPurchase.TabIndex = 0;
            this.txtTotalPurchase.TabStop = false;
            // 
            // txtUnitCostPrice
            // 
            this.txtUnitCostPrice.Location = new System.Drawing.Point(169, 118);
            this.txtUnitCostPrice.Name = "txtUnitCostPrice";
            this.txtUnitCostPrice.ReadOnly = true;
            this.txtUnitCostPrice.Size = new System.Drawing.Size(197, 22);
            this.txtUnitCostPrice.TabIndex = 0;
            this.txtUnitCostPrice.TabStop = false;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(169, 91);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(197, 22);
            this.txtProductName.TabIndex = 0;
            this.txtProductName.TabStop = false;
            // 
            // txtProductCategory
            // 
            this.txtProductCategory.Location = new System.Drawing.Point(169, 62);
            this.txtProductCategory.Name = "txtProductCategory";
            this.txtProductCategory.ReadOnly = true;
            this.txtProductCategory.Size = new System.Drawing.Size(197, 22);
            this.txtProductCategory.TabIndex = 0;
            this.txtProductCategory.TabStop = false;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(169, 33);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(197, 22);
            this.txtSupplier.TabIndex = 0;
            this.txtSupplier.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Stock Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Current Stock";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Total Sale";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Total Purchase";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Unit Sales Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Unit Cost Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Product Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Product Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Supplier";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.cmbProductName);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(893, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search Stock";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(698, 32);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 27);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(607, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbProductName
            // 
            this.cmbProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(287, 32);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(314, 24);
            this.cmbProductName.TabIndex = 0;
            this.cmbProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProductName_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(175, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 16);
            this.label17.TabIndex = 3;
            this.label17.Text = "Product Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgSearch);
            this.groupBox3.Location = new System.Drawing.Point(36, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(837, 393);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // dgSearch
            // 
            this.dgSearch.AllowUserToDeleteRows = false;
            this.dgSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgSearch.Location = new System.Drawing.Point(20, 21);
            this.dgSearch.Name = "dgSearch";
            this.dgSearch.ReadOnly = true;
            this.dgSearch.Size = new System.Drawing.Size(799, 355);
            this.dgSearch.TabIndex = 0;
            this.dgSearch.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Product ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Product Category";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Available Stock";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // frmStockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 497);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Teal;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStockManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stock Management";
            this.Load += new System.EventHandler(this.frmStockManagement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStockManagement_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgSearch;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAddProduct;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtUnitSalesPrice;
        private System.Windows.Forms.TextBox txtStockAmount;
        private System.Windows.Forms.TextBox txtCurrentStock;
        private System.Windows.Forms.TextBox txtTotalSale;
        private System.Windows.Forms.TextBox txtTotalPurchase;
        private System.Windows.Forms.TextBox txtUnitCostPrice;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCategory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtSubProduct;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbReturnToSupplier;
        private System.Windows.Forms.Button btnClear1;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox cmbProductNameStock;
    }
}