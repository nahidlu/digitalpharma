namespace digitalPharma
{
    partial class frmReportAll
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.gbReturn = new System.Windows.Forms.GroupBox();
            this.btnReturnProduct = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gbIncome = new System.Windows.Forms.GroupBox();
            this.btnHeadIncome = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnIncome = new System.Windows.Forms.Button();
            this.cmbIncomeHeadname = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.gbExpense = new System.Windows.Forms.GroupBox();
            this.btnHead = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExpense = new System.Windows.Forms.Button();
            this.cmbHeaderName = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gbProfit = new System.Windows.Forms.GroupBox();
            this.btnLeadger = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbCategoryWise = new System.Windows.Forms.GroupBox();
            this.cmbProductCategory = new System.Windows.Forms.ComboBox();
            this.btnProductCategory = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.gbSupplierwise = new System.Windows.Forms.GroupBox();
            this.cmbSuppler = new System.Windows.Forms.ComboBox();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gbPopular = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnMinimumStock = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPopularProductList = new System.Windows.Forms.Button();
            this.btnStockSummery = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbPurchsaseDate = new System.Windows.Forms.GroupBox();
            this.btnPurchaseDatewise = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.gbPurchase = new System.Windows.Forms.GroupBox();
            this.cmbInvoiceNoPurchase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPurchaseSingle = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbSaleDate = new System.Windows.Forms.GroupBox();
            this.btnReportDateWise = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCounter = new System.Windows.Forms.Button();
            this.gbSale = new System.Windows.Forms.GroupBox();
            this.cmbInvoiceNoSales = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReportSingle = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.gbExpired = new System.Windows.Forms.GroupBox();
            this.btnExpired = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpExpired = new System.Windows.Forms.DateTimePicker();
            this.txtExpiredDays = new System.Windows.Forms.TextBox();
            this.gbStock = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.gbReturn.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.gbIncome.SuspendLayout();
            this.gbExpense.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gbProfit.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbCategoryWise.SuspendLayout();
            this.gbSupplierwise.SuspendLayout();
            this.gbPopular.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbPurchsaseDate.SuspendLayout();
            this.gbPurchase.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbSaleDate.SuspendLayout();
            this.gbSale.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.gbExpired.SuspendLayout();
            this.gbStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(254, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 71);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Date";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(256, 27);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(133, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(66, 27);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(139, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "From";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 31);
            this.label8.TabIndex = 2;
            this.label8.Text = "All Reports";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(775, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 25);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.gbReturn);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(861, 227);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Return Product";
            // 
            // gbReturn
            // 
            this.gbReturn.Controls.Add(this.btnReturnProduct);
            this.gbReturn.Controls.Add(this.label16);
            this.gbReturn.Location = new System.Drawing.Point(230, 48);
            this.gbReturn.Name = "gbReturn";
            this.gbReturn.Size = new System.Drawing.Size(386, 111);
            this.gbReturn.TabIndex = 2;
            this.gbReturn.TabStop = false;
            this.gbReturn.Text = "Date Wise Return Product Report";
            this.gbReturn.Visible = false;
            // 
            // btnReturnProduct
            // 
            this.btnReturnProduct.Location = new System.Drawing.Point(9, 34);
            this.btnReturnProduct.Name = "btnReturnProduct";
            this.btnReturnProduct.Size = new System.Drawing.Size(75, 31);
            this.btnReturnProduct.TabIndex = 2;
            this.btnReturnProduct.Text = ">>>";
            this.btnReturnProduct.UseVisualStyleBackColor = true;
            this.btnReturnProduct.Click += new System.EventHandler(this.btnReturnProduct_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(90, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(161, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = "Return Product Report";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.gbIncome);
            this.tabPage5.Controls.Add(this.gbExpense);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(861, 227);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Accounts Report";
            // 
            // gbIncome
            // 
            this.gbIncome.Controls.Add(this.btnHeadIncome);
            this.gbIncome.Controls.Add(this.label18);
            this.gbIncome.Controls.Add(this.btnIncome);
            this.gbIncome.Controls.Add(this.cmbIncomeHeadname);
            this.gbIncome.Controls.Add(this.label19);
            this.gbIncome.Location = new System.Drawing.Point(445, 35);
            this.gbIncome.Name = "gbIncome";
            this.gbIncome.Size = new System.Drawing.Size(386, 168);
            this.gbIncome.TabIndex = 2;
            this.gbIncome.TabStop = false;
            this.gbIncome.Text = "Date Wise Income Report";
            // 
            // btnHeadIncome
            // 
            this.btnHeadIncome.Location = new System.Drawing.Point(57, 106);
            this.btnHeadIncome.Name = "btnHeadIncome";
            this.btnHeadIncome.Size = new System.Drawing.Size(75, 31);
            this.btnHeadIncome.TabIndex = 2;
            this.btnHeadIncome.Text = ">>>";
            this.btnHeadIncome.UseVisualStyleBackColor = true;
            this.btnHeadIncome.Click += new System.EventHandler(this.btnHeadIncome_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Teal;
            this.label18.Location = new System.Drawing.Point(153, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(156, 16);
            this.label18.TabIndex = 4;
            this.label18.Text = "Select Account Name";
            // 
            // btnIncome
            // 
            this.btnIncome.Location = new System.Drawing.Point(57, 37);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(75, 31);
            this.btnIncome.TabIndex = 0;
            this.btnIncome.Text = ">>>";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // cmbIncomeHeadname
            // 
            this.cmbIncomeHeadname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbIncomeHeadname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIncomeHeadname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncomeHeadname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIncomeHeadname.FormattingEnabled = true;
            this.cmbIncomeHeadname.Location = new System.Drawing.Point(141, 110);
            this.cmbIncomeHeadname.Name = "cmbIncomeHeadname";
            this.cmbIncomeHeadname.Size = new System.Drawing.Size(211, 24);
            this.cmbIncomeHeadname.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(138, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 16);
            this.label19.TabIndex = 2;
            this.label19.Text = "Income Report";
            // 
            // gbExpense
            // 
            this.gbExpense.Controls.Add(this.btnHead);
            this.gbExpense.Controls.Add(this.label12);
            this.gbExpense.Controls.Add(this.btnExpense);
            this.gbExpense.Controls.Add(this.cmbHeaderName);
            this.gbExpense.Controls.Add(this.label13);
            this.gbExpense.Location = new System.Drawing.Point(27, 35);
            this.gbExpense.Name = "gbExpense";
            this.gbExpense.Size = new System.Drawing.Size(386, 168);
            this.gbExpense.TabIndex = 1;
            this.gbExpense.TabStop = false;
            this.gbExpense.Text = "Date Wise Expense Report";
            // 
            // btnHead
            // 
            this.btnHead.Location = new System.Drawing.Point(57, 106);
            this.btnHead.Name = "btnHead";
            this.btnHead.Size = new System.Drawing.Size(75, 31);
            this.btnHead.TabIndex = 3;
            this.btnHead.Text = ">>>";
            this.btnHead.UseVisualStyleBackColor = true;
            this.btnHead.Click += new System.EventHandler(this.btnHead_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Teal;
            this.label12.Location = new System.Drawing.Point(153, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 16);
            this.label12.TabIndex = 4;
            this.label12.Text = "Select Account Name";
            // 
            // btnExpense
            // 
            this.btnExpense.Location = new System.Drawing.Point(57, 37);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(75, 31);
            this.btnExpense.TabIndex = 0;
            this.btnExpense.Text = ">>>";
            this.btnExpense.UseVisualStyleBackColor = true;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
            // 
            // cmbHeaderName
            // 
            this.cmbHeaderName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbHeaderName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHeaderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeaderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHeaderName.FormattingEnabled = true;
            this.cmbHeaderName.Location = new System.Drawing.Point(141, 110);
            this.cmbHeaderName.Name = "cmbHeaderName";
            this.cmbHeaderName.Size = new System.Drawing.Size(211, 24);
            this.cmbHeaderName.TabIndex = 2;
            this.cmbHeaderName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbHeaderName_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(138, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = "Expense Report";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.gbProfit);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(861, 227);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Profit / Loss Report";
            // 
            // gbProfit
            // 
            this.gbProfit.Controls.Add(this.btnLeadger);
            this.gbProfit.Controls.Add(this.label11);
            this.gbProfit.Location = new System.Drawing.Point(217, 58);
            this.gbProfit.Name = "gbProfit";
            this.gbProfit.Size = new System.Drawing.Size(423, 96);
            this.gbProfit.TabIndex = 0;
            this.gbProfit.TabStop = false;
            this.gbProfit.Text = "Date Wise Report";
            // 
            // btnLeadger
            // 
            this.btnLeadger.Location = new System.Drawing.Point(72, 36);
            this.btnLeadger.Name = "btnLeadger";
            this.btnLeadger.Size = new System.Drawing.Size(97, 28);
            this.btnLeadger.TabIndex = 0;
            this.btnLeadger.Text = ">>>";
            this.btnLeadger.UseVisualStyleBackColor = true;
            this.btnLeadger.Click += new System.EventHandler(this.btnLeadger_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(175, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Profit / Loss (Date Wise)";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.gbStock);
            this.tabPage3.Controls.Add(this.gbCategoryWise);
            this.tabPage3.Controls.Add(this.gbSupplierwise);
            this.tabPage3.Controls.Add(this.gbPopular);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(861, 227);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Stock Report";
            // 
            // gbCategoryWise
            // 
            this.gbCategoryWise.Controls.Add(this.cmbProductCategory);
            this.gbCategoryWise.Controls.Add(this.btnProductCategory);
            this.gbCategoryWise.Controls.Add(this.label14);
            this.gbCategoryWise.Location = new System.Drawing.Point(15, 112);
            this.gbCategoryWise.Name = "gbCategoryWise";
            this.gbCategoryWise.Size = new System.Drawing.Size(407, 109);
            this.gbCategoryWise.TabIndex = 1;
            this.gbCategoryWise.TabStop = false;
            this.gbCategoryWise.Text = "Product Category Wise Stock Report";
            // 
            // cmbProductCategory
            // 
            this.cmbProductCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbProductCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCategory.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductCategory.FormattingEnabled = true;
            this.cmbProductCategory.Location = new System.Drawing.Point(15, 44);
            this.cmbProductCategory.Name = "cmbProductCategory";
            this.cmbProductCategory.Size = new System.Drawing.Size(375, 23);
            this.cmbProductCategory.TabIndex = 0;
            this.cmbProductCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProductGroup_KeyPress);
            // 
            // btnProductCategory
            // 
            this.btnProductCategory.Location = new System.Drawing.Point(160, 74);
            this.btnProductCategory.Name = "btnProductCategory";
            this.btnProductCategory.Size = new System.Drawing.Size(97, 28);
            this.btnProductCategory.TabIndex = 1;
            this.btnProductCategory.Text = ">>>";
            this.btnProductCategory.UseVisualStyleBackColor = true;
            this.btnProductCategory.Click += new System.EventHandler(this.btnProductCategory_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(176, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = "Select Product Category";
            // 
            // gbSupplierwise
            // 
            this.gbSupplierwise.Controls.Add(this.cmbSuppler);
            this.gbSupplierwise.Controls.Add(this.btnSupplier);
            this.gbSupplierwise.Controls.Add(this.label10);
            this.gbSupplierwise.Location = new System.Drawing.Point(15, 17);
            this.gbSupplierwise.Name = "gbSupplierwise";
            this.gbSupplierwise.Size = new System.Drawing.Size(407, 89);
            this.gbSupplierwise.TabIndex = 0;
            this.gbSupplierwise.TabStop = false;
            this.gbSupplierwise.Text = "Supplier Wise Stock Report";
            // 
            // cmbSuppler
            // 
            this.cmbSuppler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSuppler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSuppler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuppler.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSuppler.FormattingEnabled = true;
            this.cmbSuppler.Location = new System.Drawing.Point(132, 25);
            this.cmbSuppler.Name = "cmbSuppler";
            this.cmbSuppler.Size = new System.Drawing.Size(258, 23);
            this.cmbSuppler.TabIndex = 0;
            this.cmbSuppler.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSuppler_KeyPress);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(209, 55);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(97, 28);
            this.btnSupplier.TabIndex = 1;
            this.btnSupplier.Text = ">>>";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "Select Supplier";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(195, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 16);
            this.label15.TabIndex = 4;
            this.label15.Text = "Stock Summary";
            // 
            // gbPopular
            // 
            this.gbPopular.Controls.Add(this.label17);
            this.gbPopular.Controls.Add(this.btnMinimumStock);
            this.gbPopular.Controls.Add(this.label9);
            this.gbPopular.Controls.Add(this.btnPopularProductList);
            this.gbPopular.Location = new System.Drawing.Point(450, 129);
            this.gbPopular.Name = "gbPopular";
            this.gbPopular.Size = new System.Drawing.Size(405, 88);
            this.gbPopular.TabIndex = 3;
            this.gbPopular.TabStop = false;
            this.gbPopular.Text = "Date Wise Report";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(195, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(171, 16);
            this.label17.TabIndex = 6;
            this.label17.Text = "Minimum Stock Quantity";
            this.label17.Visible = false;
            // 
            // btnMinimumStock
            // 
            this.btnMinimumStock.Location = new System.Drawing.Point(92, 58);
            this.btnMinimumStock.Name = "btnMinimumStock";
            this.btnMinimumStock.Size = new System.Drawing.Size(97, 28);
            this.btnMinimumStock.TabIndex = 1;
            this.btnMinimumStock.Text = ">>>";
            this.btnMinimumStock.UseVisualStyleBackColor = true;
            this.btnMinimumStock.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(195, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Popular Product List";
            // 
            // btnPopularProductList
            // 
            this.btnPopularProductList.Location = new System.Drawing.Point(92, 36);
            this.btnPopularProductList.Name = "btnPopularProductList";
            this.btnPopularProductList.Size = new System.Drawing.Size(97, 28);
            this.btnPopularProductList.TabIndex = 0;
            this.btnPopularProductList.Text = ">>>";
            this.btnPopularProductList.UseVisualStyleBackColor = true;
            this.btnPopularProductList.Click += new System.EventHandler(this.btnPopularProductList_Click);
            // 
            // btnStockSummery
            // 
            this.btnStockSummery.Location = new System.Drawing.Point(92, 34);
            this.btnStockSummery.Name = "btnStockSummery";
            this.btnStockSummery.Size = new System.Drawing.Size(97, 28);
            this.btnStockSummery.TabIndex = 2;
            this.btnStockSummery.Text = ">>>";
            this.btnStockSummery.UseVisualStyleBackColor = true;
            this.btnStockSummery.Click += new System.EventHandler(this.btnStockSummery_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.gbPurchsaseDate);
            this.tabPage2.Controls.Add(this.gbPurchase);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(861, 227);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Purchase Report";
            // 
            // gbPurchsaseDate
            // 
            this.gbPurchsaseDate.Controls.Add(this.btnPurchaseDatewise);
            this.gbPurchsaseDate.Controls.Add(this.label7);
            this.gbPurchsaseDate.Location = new System.Drawing.Point(453, 43);
            this.gbPurchsaseDate.Name = "gbPurchsaseDate";
            this.gbPurchsaseDate.Size = new System.Drawing.Size(412, 107);
            this.gbPurchsaseDate.TabIndex = 1;
            this.gbPurchsaseDate.TabStop = false;
            this.gbPurchsaseDate.Text = "Date Wise Report";
            // 
            // btnPurchaseDatewise
            // 
            this.btnPurchaseDatewise.Location = new System.Drawing.Point(23, 37);
            this.btnPurchaseDatewise.Name = "btnPurchaseDatewise";
            this.btnPurchaseDatewise.Size = new System.Drawing.Size(84, 28);
            this.btnPurchaseDatewise.TabIndex = 0;
            this.btnPurchaseDatewise.Text = ">>>";
            this.btnPurchaseDatewise.UseVisualStyleBackColor = true;
            this.btnPurchaseDatewise.Click += new System.EventHandler(this.btnPurchaseDatewise_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Purchase Report";
            // 
            // gbPurchase
            // 
            this.gbPurchase.Controls.Add(this.cmbInvoiceNoPurchase);
            this.gbPurchase.Controls.Add(this.label4);
            this.gbPurchase.Controls.Add(this.btnPurchaseSingle);
            this.gbPurchase.Location = new System.Drawing.Point(15, 43);
            this.gbPurchase.Name = "gbPurchase";
            this.gbPurchase.Size = new System.Drawing.Size(412, 107);
            this.gbPurchase.TabIndex = 0;
            this.gbPurchase.TabStop = false;
            // 
            // cmbInvoiceNoPurchase
            // 
            this.cmbInvoiceNoPurchase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInvoiceNoPurchase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInvoiceNoPurchase.FormattingEnabled = true;
            this.cmbInvoiceNoPurchase.Location = new System.Drawing.Point(156, 25);
            this.cmbInvoiceNoPurchase.Name = "cmbInvoiceNoPurchase";
            this.cmbInvoiceNoPurchase.Size = new System.Drawing.Size(233, 24);
            this.cmbInvoiceNoPurchase.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Select Invoice NO";
            // 
            // btnPurchaseSingle
            // 
            this.btnPurchaseSingle.Location = new System.Drawing.Point(212, 55);
            this.btnPurchaseSingle.Name = "btnPurchaseSingle";
            this.btnPurchaseSingle.Size = new System.Drawing.Size(97, 28);
            this.btnPurchaseSingle.TabIndex = 1;
            this.btnPurchaseSingle.Text = "Report";
            this.btnPurchaseSingle.UseVisualStyleBackColor = true;
            this.btnPurchaseSingle.Click += new System.EventHandler(this.btnPurchaseSingle_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.gbSaleDate);
            this.tabPage1.Controls.Add(this.gbSale);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(861, 227);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sales Report";
            // 
            // gbSaleDate
            // 
            this.gbSaleDate.Controls.Add(this.btnReportDateWise);
            this.gbSaleDate.Controls.Add(this.label6);
            this.gbSaleDate.Controls.Add(this.label5);
            this.gbSaleDate.Controls.Add(this.btnCounter);
            this.gbSaleDate.Location = new System.Drawing.Point(442, 39);
            this.gbSaleDate.Name = "gbSaleDate";
            this.gbSaleDate.Size = new System.Drawing.Size(404, 116);
            this.gbSaleDate.TabIndex = 1;
            this.gbSaleDate.TabStop = false;
            this.gbSaleDate.Text = "Date Wise Report";
            // 
            // btnReportDateWise
            // 
            this.btnReportDateWise.Location = new System.Drawing.Point(15, 32);
            this.btnReportDateWise.Name = "btnReportDateWise";
            this.btnReportDateWise.Size = new System.Drawing.Size(84, 28);
            this.btnReportDateWise.TabIndex = 0;
            this.btnReportDateWise.Text = ">>>";
            this.btnReportDateWise.UseVisualStyleBackColor = true;
            this.btnReportDateWise.Click += new System.EventHandler(this.btnReportDateWise_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Counter Wise Report";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Sales Report";
            // 
            // btnCounter
            // 
            this.btnCounter.Location = new System.Drawing.Point(15, 66);
            this.btnCounter.Name = "btnCounter";
            this.btnCounter.Size = new System.Drawing.Size(84, 28);
            this.btnCounter.TabIndex = 1;
            this.btnCounter.Text = ">>>";
            this.btnCounter.UseVisualStyleBackColor = true;
            this.btnCounter.Visible = false;
            this.btnCounter.Click += new System.EventHandler(this.btnCounter_Click);
            // 
            // gbSale
            // 
            this.gbSale.Controls.Add(this.cmbInvoiceNoSales);
            this.gbSale.Controls.Add(this.label1);
            this.gbSale.Controls.Add(this.btnReportSingle);
            this.gbSale.Location = new System.Drawing.Point(15, 39);
            this.gbSale.Name = "gbSale";
            this.gbSale.Size = new System.Drawing.Size(405, 116);
            this.gbSale.TabIndex = 0;
            this.gbSale.TabStop = false;
            this.gbSale.Text = "Report";
            // 
            // cmbInvoiceNoSales
            // 
            this.cmbInvoiceNoSales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInvoiceNoSales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInvoiceNoSales.FormattingEnabled = true;
            this.cmbInvoiceNoSales.Location = new System.Drawing.Point(156, 25);
            this.cmbInvoiceNoSales.Name = "cmbInvoiceNoSales";
            this.cmbInvoiceNoSales.Size = new System.Drawing.Size(233, 24);
            this.cmbInvoiceNoSales.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Invoice NO";
            // 
            // btnReportSingle
            // 
            this.btnReportSingle.Location = new System.Drawing.Point(214, 55);
            this.btnReportSingle.Name = "btnReportSingle";
            this.btnReportSingle.Size = new System.Drawing.Size(97, 28);
            this.btnReportSingle.TabIndex = 1;
            this.btnReportSingle.Text = "Report";
            this.btnReportSingle.UseVisualStyleBackColor = true;
            this.btnReportSingle.Click += new System.EventHandler(this.btnReportSingle_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(-1, 133);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(869, 256);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage7.Controls.Add(this.gbExpired);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(861, 227);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Expired Product";
            // 
            // gbExpired
            // 
            this.gbExpired.Controls.Add(this.btnExpired);
            this.gbExpired.Controls.Add(this.label21);
            this.gbExpired.Controls.Add(this.label20);
            this.gbExpired.Controls.Add(this.dtpExpired);
            this.gbExpired.Controls.Add(this.txtExpiredDays);
            this.gbExpired.Location = new System.Drawing.Point(282, 38);
            this.gbExpired.Name = "gbExpired";
            this.gbExpired.Size = new System.Drawing.Size(336, 141);
            this.gbExpired.TabIndex = 0;
            this.gbExpired.TabStop = false;
            this.gbExpired.Text = "Expired Product List";
            // 
            // btnExpired
            // 
            this.btnExpired.Location = new System.Drawing.Point(161, 93);
            this.btnExpired.Name = "btnExpired";
            this.btnExpired.Size = new System.Drawing.Size(95, 26);
            this.btnExpired.TabIndex = 2;
            this.btnExpired.Text = "Report";
            this.btnExpired.UseVisualStyleBackColor = true;
            this.btnExpired.Click += new System.EventHandler(this.btnExpired_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(61, 68);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 16);
            this.label21.TabIndex = 2;
            this.label21.Text = "Enter Days";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(102, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 16);
            this.label20.TabIndex = 2;
            this.label20.Text = "From";
            // 
            // dtpExpired
            // 
            this.dtpExpired.CustomFormat = "dd-MMM-yyyy";
            this.dtpExpired.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpired.Location = new System.Drawing.Point(161, 38);
            this.dtpExpired.Name = "dtpExpired";
            this.dtpExpired.Size = new System.Drawing.Size(139, 22);
            this.dtpExpired.TabIndex = 0;
            // 
            // txtExpiredDays
            // 
            this.txtExpiredDays.Location = new System.Drawing.Point(161, 65);
            this.txtExpiredDays.Name = "txtExpiredDays";
            this.txtExpiredDays.Size = new System.Drawing.Size(139, 22);
            this.txtExpiredDays.TabIndex = 1;
            this.txtExpiredDays.Leave += new System.EventHandler(this.txtExpiredDays_Leave);
            // 
            // gbStock
            // 
            this.gbStock.Controls.Add(this.label15);
            this.gbStock.Controls.Add(this.btnStockSummery);
            this.gbStock.Location = new System.Drawing.Point(450, 20);
            this.gbStock.Name = "gbStock";
            this.gbStock.Size = new System.Drawing.Size(396, 85);
            this.gbStock.TabIndex = 5;
            this.gbStock.TabStop = false;
            this.gbStock.Text = "Stock Summary";
            // 
            // frmReportAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(867, 387);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Teal;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReportAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Date Wise Report";
            this.Load += new System.EventHandler(this.frmReportDateWiseReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportAll_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.gbReturn.ResumeLayout(false);
            this.gbReturn.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.gbIncome.ResumeLayout(false);
            this.gbIncome.PerformLayout();
            this.gbExpense.ResumeLayout(false);
            this.gbExpense.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.gbProfit.ResumeLayout(false);
            this.gbProfit.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.gbCategoryWise.ResumeLayout(false);
            this.gbCategoryWise.PerformLayout();
            this.gbSupplierwise.ResumeLayout(false);
            this.gbSupplierwise.PerformLayout();
            this.gbPopular.ResumeLayout(false);
            this.gbPopular.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbPurchsaseDate.ResumeLayout(false);
            this.gbPurchsaseDate.PerformLayout();
            this.gbPurchase.ResumeLayout(false);
            this.gbPurchase.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.gbSaleDate.ResumeLayout(false);
            this.gbSaleDate.PerformLayout();
            this.gbSale.ResumeLayout(false);
            this.gbSale.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.gbExpired.ResumeLayout(false);
            this.gbExpired.PerformLayout();
            this.gbStock.ResumeLayout(false);
            this.gbStock.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox gbReturn;
        private System.Windows.Forms.Button btnReturnProduct;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox gbExpense;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnHead;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbHeaderName;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox gbProfit;
        private System.Windows.Forms.Button btnLeadger;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gbCategoryWise;
        private System.Windows.Forms.ComboBox cmbProductCategory;
        private System.Windows.Forms.Button btnProductCategory;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gbSupplierwise;
        private System.Windows.Forms.ComboBox cmbSuppler;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbPopular;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnMinimumStock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPopularProductList;
        private System.Windows.Forms.Button btnStockSummery;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbPurchsaseDate;
        private System.Windows.Forms.Button btnPurchaseDatewise;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbPurchase;
        private System.Windows.Forms.ComboBox cmbInvoiceNoPurchase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPurchaseSingle;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbSaleDate;
        private System.Windows.Forms.Button btnReportDateWise;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCounter;
        private System.Windows.Forms.GroupBox gbSale;
        private System.Windows.Forms.ComboBox cmbInvoiceNoSales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReportSingle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox gbIncome;
        private System.Windows.Forms.Button btnHeadIncome;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.ComboBox cmbIncomeHeadname;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpExpired;
        private System.Windows.Forms.TextBox txtExpiredDays;
        private System.Windows.Forms.GroupBox gbExpired;
        private System.Windows.Forms.Button btnExpired;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox gbStock;
    }
}