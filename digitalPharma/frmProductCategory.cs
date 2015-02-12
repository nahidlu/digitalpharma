using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.DAO;
using System.Transactions;

namespace digitalPharma
{
    public partial class frmProductCategory : Form
    {
        string ProductID = "";
        string InvoiceNoHidden = "";
        public frmProductCategory()
        {
            InitializeComponent();
        }
        private void ClearUpdate()
        {
            txtProductCategoryUpdate.Text = "";
            txtProductIDUpdate.Text = "";
            txtProductNameUpdate.Text = "";
            txtSalesPrice.Text = "";
            txtSupplierName.Text = "";
            txtTotalStock.Text = "";
            txtUnitCost.Text = "";
            btnUpdate.Enabled = false;
            btnBarcode.Enabled = false;
            ProductID = "";
            InvoiceNoHidden = "";
            txtNoOfBarcode.Text = "";
            txtDosagesDescription.Text = "";
            txtProductUseFor.Text = "";
            cmbProductName.SelectedIndex = -1;
        }
        private void Clear()
        {
            txtCategoryName.Text = "";
            btnAdd.Text = "Add";
            btnDelete.Enabled = false;
            LoadDgCategory();
            LoadProductCategory();
        }
        private void ClearProductName()
        {
            //cmbCategory.Text = "";
            btnAddProduct.Text = "Add";
            btnDeleteProduct.Enabled = false;
            txtProductName.Text = "";
            txtProductID.Text = "";
            txtProductID.ReadOnly = true;
            checkBox1.Checked = false;
           LoadDgProductNameByCategory();
           cmbUseFor.SelectedIndex = 0;
           cmbSupplierName.SelectedIndex = -1;
           cmbDosageDescription.SelectedIndex = -1;
           //dgProductName.Rows.Clear();

        }
        private void LoadDgCategory()
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_ProductCategories
                    orderby p.CategoryName ascending
                    select p;
            if (q.Count() > 0)
            {
                dgCategory.DataSource = q;
                dgCategory.Columns[0].Visible = false;
            }
            else
            {
                dgCategory.DataSource = null;
            }        
        }
       
        private void LoadDgProductNameByCategory()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_Products
                        where p.CategoryID == Int64.Parse( cmbCategory.SelectedValue.ToString())
                        orderby p.ProductName ascending
                        select p;
                if (q.Count() > 0)
                {
                    dgProductName.Rows.Clear();
                    foreach (tbl_Product pro in q)
                    {
                        dgProductName.Rows.Add(pro.SN, pro.ProductName, pro.ProductID);
                    }
                }
                else
                {
                    dgProductName.Rows.Clear();
                }
            }
            catch
            {

            }
        }
        private void LoadDgProductName()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_Products
                        orderby p.ProductName ascending
                        select p;
                if (q.Count() > 0)
                {
                    dgProductName.Rows.Clear();
                    foreach (tbl_Product pro in q)
                    {
                        dgProductName.Rows.Add(pro.SN, ClsProductCategory.GetProductCategorySingleInfo(Int64.Parse( pro.CategoryID.ToString())).CategoryName.ToString(), pro.ProductName);
                    }
                }
                else
                {
                    dgProductName.Rows.Clear();
                }
            }
            catch
            { 
            
            }
        }
        private void LoadProductCategory()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var q = from p in DB.tbl_ProductCategories
                    orderby p.CategoryName ascending 
                    select p;
            if (q.Count() > 0)
            {
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.DataSource = q;  
                cmbCategory.SelectedIndex = -1;
            }
            else
            {
                cmbCategory.DataSource = null;
            }            
        }

        private void LoadDosagesDescription()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var q = from p in DB.tbl_DosagesDescriptions
                    orderby p.DosagesDescription ascending
                    select p;
            if (q.Count() > 0)
            {
                cmbDosageDescription.DataSource = q;
                cmbDosageDescription.DisplayMember = "DosagesDescription";
                cmbDosageDescription.ValueMember = "DosagesID";
                
                cmbDosageDescription.SelectedIndex = -1;
            }
            else
            {
                cmbDosageDescription.DataSource = null;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text != "")
            {
                if (btnAdd.Text == "Add")
                {
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var q = from p in DB.tbl_ProductCategories
                            where p.CategoryName == txtCategoryName.Text.Trim()
                            select p;
                    if (q.Count() == 0)
                    {
                        tbl_ProductCategory entry = new tbl_ProductCategory();
                        entry.CategoryName = txtCategoryName.Text.Trim();
                        Int64 check = ClsProductCategory.InsertProductCategory(entry);
                        if (check > 0)
                        {
                            MessageBox.Show("Saved Successfully.");
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Name Already Saved. \n Please try with another Name.");
                    }

                }
                else // update
                {
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var q = from p in DB.tbl_ProductCategories
                            where p.CategoryID != GlobalVariable.CategoryID && p.CategoryName == txtCategoryName.Text.Trim()
                            select p;
                    if (q.Count() == 0)
                    {
                        tbl_ProductCategory entry = new tbl_ProductCategory();
                        entry.CategoryName = txtCategoryName.Text.Trim();
                        entry.CategoryID = GlobalVariable.CategoryID;
                        Int64 check = ClsProductCategory.UpdateProductCategory(entry);
                        if (check > 0)
                        {
                            MessageBox.Show("Updated Successfully.");
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Name Already Saved. \n Please try with another Name.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Category Name.");
                txtCategoryName.Focus();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        } 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to Delete? \n If You Delete Product Category, Then Product Name Under This Group Will Be Deleted.","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {                
                int check = ClsProductCategory.DeleteProductCategory(GlobalVariable.CategoryID);
                if (check > 0)
                {
                    int check1 = ClsProduct.DeleteProductNameByCategoryID(GlobalVariable.CategoryID);
                    if (check1 > 0)
                    {
                        MessageBox.Show("Deleted Successfully.");
                        Clear();                        
                    }
                }
            }
        }   
        private void dgProductName_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgProductName.SelectedRows[0].Cells[0].Value.ToString() != "")
                {
                    GlobalVariable.SN = Convert.ToInt64( dgProductName.SelectedRows[0].Cells[0].Value.ToString());
                    tbl_Product ProductInfo = ClsProduct.GetProductInfoByID(dgProductName.SelectedRows[0].Cells[2].Value.ToString());
                    if (ProductInfo != null)
                    {
                        cmbSupplierName.Text = ClsSupplier.GetSupplierSingleInfo(int.Parse(ProductInfo.SupplierID.ToString())).SupplierName;
                        cmbUseFor.Text = ProductInfo.ProductUse;
                        cmbDosageDescription.Text = ClsDosageDescription.GetDosagesDescriptionSingleInfo(int.Parse(ProductInfo.DosagesID.ToString())).DosagesDescription;
                    }
                    //cmbCategory.Text = dgProductName.SelectedRows[0].Cells[1].Value.ToString();
                    txtProductName.Text = dgProductName.SelectedRows[0].Cells[1].Value.ToString();
                    btnDeleteProduct.Enabled = true;
                    btnAddProduct.Text = "Update";
                }
            }
            catch
            {

            }
        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            ClearProductName();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to Delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int check = ClsProduct.DeleteProductName(GlobalVariable.SN);
                if (check > 0)
                {
                    MessageBox.Show("Deleted Successfully.");
                    ClearProductName();
                }
            }
        }


        private void LoadSupplierName()
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var query = from p in DB.tbl_Suppliers
                        orderby p.SupplierName ascending
                        select new { name = p.SupplierName, id = p.SupplierID };
            if (query.Count() > 0)
            {
                cmbSupplierName.DataSource = query;
                cmbSupplierName.DisplayMember = "name";
                cmbSupplierName.ValueMember = "id";
                cmbSupplierName.SelectedIndex = -1;
            }
            else
            {
                cmbSupplierName.DataSource = null;
            }
        }
        private void LoadAllProductName()
        {
            try
            {

                {
                    cmbProductName.DisplayMember = "name";
                    cmbProductName.ValueMember = "id";
                    cmbProductName.DataSource = GlobalVariable.AllProductName;                    
                    cmbProductName.SelectedIndex = -1;

                }

            }
            catch
            {

            }
        }
        private void frmProductCategory_Load_1(object sender, EventArgs e)
        {
            LoadDgCategory();
            LoadProductCategory();
            //LoadDgProductNameByCategory();
            LoadSupplierName();
            LoadAllProductName();
            LoadDosagesDescription();
            cmbUseFor.SelectedIndex = 0;
            if (GlobalVariable.userType == "Admin")
            {
                groupBox3.Visible = true;
            }
            else
            {
                groupBox3.Visible = false;
            }
        }

        private void dgCategory_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgCategory.SelectedRows[0].Cells[0].Value.ToString() != "")
                {
                    GlobalVariable.CategoryID = Int64.Parse(dgCategory.SelectedRows[0].Cells[0].Value.ToString());
                    txtCategoryName.Text = dgCategory.SelectedRows[0].Cells[1].Value.ToString();
                    btnDelete.Enabled = true;
                    btnAdd.Text = "Update";
                }
            }
            catch
            {

            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgProductNameByCategory();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                lblProductID.Visible = true;
                txtProductID.ReadOnly = false;
            }
            else
            {
                txtProductID.ReadOnly = true; ;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            if (cmbCategory.Text != "" && cmbSupplierName.Text != "" && cmbDosageDescription.Text != "" && cmbUseFor.Text != "" && txtProductName.Text != "" && ((checkBox1.Checked == true && txtProductID.Text != "") || (checkBox1.Checked == false)))
            {
                if (btnAddProduct.Text == "Add")
                {
                    string ProductID = "";
                    int LastMaxValue = 0, SerialNo = 0;
                    EasySaleDataContext DB = new EasySaleDataContext();
                    
                    if (!ClsProduct.CheckIsDuplicatName(txtProductName.Text.Trim()))
                    {
                        tbl_Product entry = new tbl_Product();
                        entry.ProductName = txtProductName.Text.Trim();
                        entry.CategoryID = Int64.Parse(cmbCategory.SelectedValue.ToString());
                        entry.SupplierID = int.Parse(cmbSupplierName.SelectedValue.ToString());
                        entry.DosagesID = int.Parse(cmbDosageDescription.SelectedValue.ToString());
                        entry.ProductUse =cmbUseFor.Text.Trim();
                        //check is user given product id
                        if (checkBox1.Checked == true)
                        {
                            //check product id where string - does not present...
                            if (!ClsProduct.CheckIsDuplicatId(txtProductID.Text.Trim()))
                            {
                                entry.ProductID = txtProductID.Text.Trim();
                                entry.BarcodeNeeded = 0; 
                            }
                            else
                            {
                                MessageBox.Show("This Product ID is Already Used. \n Please try with another ID.");
                                txtProductID.Focus();
                            }
                        }
                        else
                        {
                            // get new productID, Last Max value and serial no
                            ClsProduct.GetIDandLastValue(out LastMaxValue,out ProductID ,out SerialNo);
                            
                            entry.ProductID = ProductID;
                            entry.BarcodeNeeded = 1;
                           
                        }
                        //For Last max value update
                        tbl_LastMaxValueOfPID max = new tbl_LastMaxValueOfPID();
                        max.LastIdValue = LastMaxValue;
                        max.SN = SerialNo;
                        Int64 check = ClsProduct.InsertProductName(entry);
                        if (check > 0)
                        {
                            Int64 check2 = ClsLastMaxValueOfPID.UpdateMaxValue(max);
                            if (check2 > 0)
                            {
                                MessageBox.Show("Saved Successfully.");
                                ClearProductName();
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Product not saved. Please Try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Product Name is Already Saved. \n Please try with another Name.");
                        txtProductName.Focus();
                    }

                }
                else // update
                {
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var q = from p in DB.tbl_Products
                            where p.ProductName == txtProductName.Text.Trim() && p.SN != GlobalVariable.SN
                            select p;
                    if (q.Count() == 0)
                    {
                        tbl_Product entry = new tbl_Product();
                        entry.ProductName = txtProductName.Text.Trim();
                        entry.CategoryID = ClsProductCategory.GetProductCategorySingleInfoByName(cmbCategory.Text.Trim()).CategoryID;
                        entry.SN = GlobalVariable.SN;
                        entry.SupplierID = int.Parse(cmbSupplierName.SelectedValue.ToString());
                        entry.DosagesID = int.Parse(cmbDosageDescription.SelectedValue.ToString());
                        entry.ProductUse = cmbUseFor.Text.Trim();
                        Int64 check = ClsProduct.UpdateProductName(entry);
                        if (check > 0)
                        {
                            MessageBox.Show("Updated Successfully.");
                            ClearProductName();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Name Already Saved. \n Please try with another Name.");
                    }
                }
            }
            else
            {
                if (cmbCategory.Text == "")
                {
                    MessageBox.Show("Please select Product Category.");
                    cmbCategory.Focus();
                }
                else if (cmbSupplierName.Text == "")
                {
                    MessageBox.Show("Please select Supplier Name.");
                    cmbSupplierName.Focus();
                }
                else if (cmbDosageDescription.Text == "")
                {
                    MessageBox.Show("Please select Dosages Description.");
                    cmbDosageDescription.Focus();
                }
                else if (cmbUseFor.Text == "")
                {
                    MessageBox.Show("Please select Product Use For.");
                    cmbUseFor.Focus();
                }
                else if (txtProductName.Text == "")
                {
                    MessageBox.Show("Please Enter Product Name.");
                    txtProductName.Focus();
                }
                else if (checkBox1.Checked == true && txtProductID.Text == "")
                {
                    MessageBox.Show("Please Enter Product ID.");
                    txtProductID.Focus();
                }

            }
        }

        private void btnClearUpdate_Click(object sender, EventArgs e)
        {
            ClearUpdate();
        }

        private void txtProductIDUpdate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbl_PurchaseProductInfo singleInfo = new tbl_PurchaseProductInfo();
                string BarcodeText = txtProductIDUpdate.Text.Trim();
                ProductID = "";
                InvoiceNoHidden = "";
                string ProductName = "";
                string CategoryName = "";
                string[] ProductInfo = new string[2];

                //check Barcode label with invoce no or not
                if (BarcodeText.Contains(GlobalVariable.BarcodeCharacter))
                {
                    //with barcode label   
                    string[] Info = ClsBarcodeLabel.GetProductIDandInvoiceNoFromBarcode(BarcodeText);
                    ProductID = Info[0];
                    InvoiceNoHidden = Info[1];
                    //GetSingleInfoFromPurchaseProduct(ProductID, InvoiceNo);    
                    singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNoHidden(ProductID, InvoiceNoHidden);
                }
                else
                {
                    ProductID = BarcodeText;
                    InvoiceNoHidden = "";
                    singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNo(ProductID, ClsRecentProductPrice.GetProductInfoByID(ProductID).InvoiceNo);
                }
                txtTotalStock.Text = ClsStockSummary.GetStockQuantityByProductID(ProductID).ToString();
                //get product Name and Category name
                ProductInfo = ClsProduct.GetProductNameAndCategoryNameByID(ProductID);
                ProductName = ProductInfo[0];
                CategoryName = ProductInfo[1];

                txtSupplierName.Text = ClsSupplier.GetSupplierSingleInfo(int.Parse(singleInfo.SupplierID.ToString())).SupplierName;
                txtProductCategoryUpdate.Text = CategoryName;
                txtProductNameUpdate.Text = ProductName;
                txtUnitCost.Text = singleInfo.UnitCost.ToString();
                txtSalesPrice.Text = singleInfo.SalesPrice.ToString();


                btnUpdate.Enabled = true;
                btnBarcode.Enabled = true;
            }
            catch
            {
                txtSupplierName.Text = "";
                txtProductCategoryUpdate.Text = "";
                txtProductNameUpdate.Text = "";
                txtUnitCost.Text = "";
                txtSalesPrice.Text = "";
                txtTotalStock.Text = "";
                btnUpdate.Enabled = false;
                btnBarcode.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProductCategoryUpdate.Text != "" && txtProductNameUpdate.Text != "" && txtSalesPrice.Text != "" && txtUnitCost.Text != "")
            {
                int check = 0;
                using (TransactionScope Trans = new TransactionScope())
                {
                    try
                    {
                        EasySaleDataContext DB = new EasySaleDataContext();
                        IQueryable query;

                       /* if (txtProductIDUpdate.Text.Trim().Contains(GlobalVariable.BarcodeCharacter))
                        {
                            query = (from p in DB.tbl_PurchaseProductInfos
                                     where p.ProductID == ProductID && p.InvoiceNoHidden == InvoiceNoHidden
                                     select p);
                        }
                        else*/
                        {
                            query = (from p in DB.tbl_PurchaseProductInfos
                                     where p.ProductID == ProductID && p.InvoiceNo == ClsRecentProductPrice.GetProductInfoByID(ProductID).InvoiceNo
                                     select p);
                        }
                        foreach (tbl_PurchaseProductInfo entry in query)
                        {
                            entry.SalesPrice = float.Parse(txtSalesPrice.Text.Trim());
                            entry.UnitCost = float.Parse(txtUnitCost.Text.Trim());
                        }
                        DB.SubmitChanges();

                        //Update recent table
                        var q = from p in DB.tbl_RecentProductPrices
                                where p.ProductID == ProductID
                                select p;
                        foreach (tbl_RecentProductPrice entry in q)
                        {
                            entry.SalePrice = float.Parse(txtSalesPrice.Text.Trim());
                            entry.UnitCost = float.Parse(txtUnitCost.Text.Trim());
                        }
                        DB.SubmitChanges();

                        Trans.Complete();
                        check = 1;
                    }
                    catch
                    {

                    }
                }
                if (check > 0)
                {
                    MessageBox.Show("Updated Successfully.");
                    ClearUpdate();
                }
            }
            else
            {
                 if (txtUnitCost.Text == "")
                {
                    MessageBox.Show("Please Write Unit Cost.");
                    txtUnitCost.Focus();
                }
                else if (txtSalesPrice.Text == "")
                {
                    MessageBox.Show("Please Write Sales Price.");
                    txtSalesPrice.Focus();
                }
                else
                {
                    MessageBox.Show("Please select Valid Product Name.");
                    cmbProductName.Focus();
                }

            }
        }

        private void txtUnitCost_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtUnitCost);   
        }

        private void txtSalesPrice_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtSalesPrice);
        }
        private void createInvoiceNoHidden()
        {
            string month = "", day = "", FirstString = "";
            if (Convert.ToDouble(DateTime.Now.Month.ToString()) < 10)
            {
                month = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                month = DateTime.Now.Month.ToString();
            }
            if (Convert.ToDouble(DateTime.Now.Day.ToString()) < 10)
            {
                day = "0" + DateTime.Now.Day.ToString();
            }
            else
            {
                day = DateTime.Now.Day.ToString();
            }

            FirstString = DateTime.Now.Year.ToString().Substring(2) + month + day;
            EasySaleDataContext DB = new EasySaleDataContext();
            try
            {
                var q = (from p in DB.tbl_PurchaseProductInfos
                         orderby p.SN ascending
                         where p.InvoiceNoHidden.StartsWith(FirstString)
                         select p.InvoiceNoHidden).ToList();
                if (q.Count() > 0)
                {
                    string invoiceNO = q.LastOrDefault().ToString();
                    string LastNo = invoiceNO.Substring(6);
                    InvoiceNoHidden = FirstString + (Convert.ToDouble(LastNo) + 1).ToString();
                }
                else
                {
                    InvoiceNoHidden = FirstString + "1";
                }
            }
            catch
            {
            }
        }
        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (txtProductIDUpdate.Text != "" && txtProductNameUpdate.Text != "" && txtSalesPrice.Text != "" && txtNoOfBarcode.Text != "")
            {
                createInvoiceNoHidden();
                Barcode barcodeDetails = new Barcode();
                DataTable dataTable = barcodeDetails.tbl_Barcode;
                if (GlobalVariable.BarcodePrintNeededForOldProductID == "1")
                {/*
                    // check barcode print needed or not 
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var q = from p in DB.tbl_Products
                            where p.ProductID == ProductID && p.BarcodeNeeded == 1
                            select p;
                  * */
                    try
                    {
                        //if (q.Count() == 1)
                        {
                            int blank_labels = 0;
                            Int64 numberofLabel = 0;
                            try
                            {
                                numberofLabel = Convert.ToInt64(txtNoOfBarcode.Text.Trim());
                            }
                            catch
                            {

                            }
                            for (int i = 0; i < numberofLabel; i++)
                            {
                                DataRow drow = dataTable.NewRow();
                                // string ProductID = dgPurchase.Rows[k].Cells[2].Value.ToString();
                                if (blank_labels <= i)
                                {
                                    drow["Barcode"] = "*";
                                    drow["Barcode"] += ProductID;
                                    drow["Barcode"] += GlobalVariable.BarcodeCharacter;
                                    drow["Barcode"] += InvoiceNoHidden;
                                    drow["Barcode"] += "*";
                                    if (InvoiceNoHidden != "")
                                    {
                                        drow["ProductId"] = ProductID + GlobalVariable.BarcodeCharacter + InvoiceNoHidden;
                                    }
                                    else
                                    {
                                        drow["ProductId"] = ProductID;
                                    }
                                    drow["ProductName"] = txtProductNameUpdate.Text.Trim();
                                    drow["SalesPrice"] = "Tk " + txtSalesPrice.Text.Trim() + "/-";
                                    //drow["Code"] = "ABCDE" + i.ToString();
                                    drow["ShopName"] = GlobalVariable.ShopName;
                                }
                                dataTable.Rows.Add(drow);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                else //Default barcode not print
                {
                    // check barcode print needed or not 
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var q = from p in DB.tbl_Products
                            where p.ProductID == ProductID && p.BarcodeNeeded == 1
                            select p;
                    try
                    {
                        if (q.Count() == 1)
                        {
                            int blank_labels = 0;
                            Int64 numberofLabel = 0;
                            try
                            {
                                numberofLabel = Convert.ToInt64(txtNoOfBarcode.Text.Trim());
                            }
                            catch
                            {

                            }
                            for (int i = 0; i < numberofLabel; i++)
                            {
                                DataRow drow = dataTable.NewRow();
                                // string ProductID = dgPurchase.Rows[k].Cells[2].Value.ToString();
                                if (blank_labels <= i)
                                {
                                    drow["Barcode"] = "*";
                                    drow["Barcode"] += ProductID;
                                    drow["Barcode"] += GlobalVariable.BarcodeCharacter;
                                    drow["Barcode"] += InvoiceNoHidden;
                                    drow["Barcode"] += "*";
                                    if (InvoiceNoHidden != "")
                                    {
                                        drow["ProductId"] = ProductID + GlobalVariable.BarcodeCharacter + InvoiceNoHidden;
                                    }
                                    else
                                    {
                                        drow["ProductId"] = ProductID;
                                    }
                                    drow["ProductName"] = txtProductNameUpdate.Text.Trim();
                                    drow["SalesPrice"] = "Tk " + txtSalesPrice.Text.Trim() + "/-";
                                    //drow["Code"] = "ABCDE" + i.ToString();
                                    drow["ShopName"] = GlobalVariable.ShopName;
                                }
                                dataTable.Rows.Add(drow);
                            }
                        }
                    }
                    catch
                    {

                    }
                }

                
                GlobalVariable.DataTable = dataTable;
                // Report.Database.Tables["tbl_Barcode"].SetDataSource((DataTable)dataTable);
                // crystalReportViewer1.ReportSource = Report;
                CrvBarcode code = new CrvBarcode();
                code.Show();
            }
            else
            {
                if (txtProductIDUpdate.Text == "")
                {
                    MessageBox.Show("Please Enter Product ID.");
                    txtProductIDUpdate.Focus();
                }
                else if (txtSalesPrice.Text == "")
                {
                    MessageBox.Show("Please Write Sales Price.");
                    txtSalesPrice.Focus();
                }

                else
                {
                    MessageBox.Show("Please Enter Valid Product ID");
                    txtProductIDUpdate.Focus();
                }
            }

            
        }

        private void txtNoOfBarcode_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForInt(txtNoOfBarcode);
        }

        private void cmbCategory_DropDown(object sender, EventArgs e)
        {
            /*try
            {
                ComboBox comboBox = (ComboBox)sender; // Catch the combo firing this event
                int width = comboBox.Width; // Current width for ComboBox
                Graphics g = comboBox.CreateGraphics(); // Get graphics for ComboBox
                Font font = comboBox.Font; // Doesn't change original font

                //checks if a scrollbar will be displayed.
                int vertScrollBarWidth;
                if (comboBox.Items.Count > comboBox.MaxDropDownItems)
                {
                    //If yes, then get its width to adjust the size of the drop down list.
                    vertScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
                }
                else
                {
                    //Otherwise set to 0
                    vertScrollBarWidth = 0;
                }
                //Loop through list items and check size of each items.
                //set the width of the drop down list to the width of the largest item.
                int newWidth;
                foreach (string s in comboBox.Items)
                {
                    if (s != null)
                    {
                        newWidth = (int)g.MeasureString(s.Trim(), font).Width + vertScrollBarWidth;
                        if (width < newWidth)
                            width = newWidth;
                    }
                }
                // Finally, adjust the new width
                comboBox.DropDownWidth = width;
            }
            catch { }
             */
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbl_PurchaseProductInfo singleInfo = new tbl_PurchaseProductInfo();
                string BarcodeText = cmbProductName.SelectedValue.ToString();
                ProductID = "";
                InvoiceNoHidden = "";
                string ProductName = "";
                string CategoryName = "";
               tbl_Product ProductInfo = new tbl_Product();

                //check Barcode label with invoce no or not
               /* if (BarcodeText.Contains(GlobalVariable.BarcodeCharacter))
                {
                    //with barcode label   
                    string[] Info = ClsBarcodeLabel.GetProductIDandInvoiceNoFromBarcode(BarcodeText);
                    ProductID = Info[0];
                    InvoiceNoHidden = Info[1];
                    //GetSingleInfoFromPurchaseProduct(ProductID, InvoiceNo);    
                    singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNoHidden(ProductID, InvoiceNoHidden);
                }
                else*/
                {
                    ProductID = BarcodeText;
                    InvoiceNoHidden = "";
                    singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNo(ProductID, ClsRecentProductPrice.GetProductInfoByID(ProductID).InvoiceNo);
                
                }
                ProductInfo = ClsProduct.GetProductInfoByID(ProductID);
                txtTotalStock.Text = ClsStockSummary.GetStockQuantityByProductID(ProductID).ToString();
                //get product Name and Category name
               

                txtSupplierName.Text = ClsSupplier.GetSupplierSingleInfo(int.Parse(singleInfo.SupplierID.ToString())).SupplierName;
                txtDosagesDescription.Text = ClsDosageDescription.GetDosagesDescriptionSingleInfo(int.Parse(ProductInfo.DosagesID.ToString())).DosagesDescription;
                txtProductUseFor.Text = ProductInfo.ProductUse;
                txtProductCategoryUpdate.Text = ClsProductCategory.GetProductCategorySingleInfo(Int64.Parse(ProductInfo.CategoryID.ToString())).CategoryName;
                txtProductNameUpdate.Text = ProductInfo.ProductName;
                txtUnitCost.Text = singleInfo.UnitCost.ToString();
                txtSalesPrice.Text = singleInfo.SalesPrice.ToString();


                btnUpdate.Enabled = true;
                btnBarcode.Enabled = true;
            }
            catch
            {
                txtSupplierName.Text = "";
                txtProductCategoryUpdate.Text = "";
                txtProductNameUpdate.Text = "";
                txtUnitCost.Text = "";
                txtSalesPrice.Text = "";
                txtTotalStock.Text = "";
                txtDosagesDescription.Text = "";
                txtProductUseFor.Text = "";
                
                btnUpdate.Enabled = false;
                btnBarcode.Enabled = false;
            }
        }

        private void frmProductCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                if (MessageBox.Show("Are You Sure To Exit?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    e.SuppressKeyPress = true;
                }

            }
        }
    }
}
