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
    public partial class frmStockManagement : Form
    {
        public frmStockManagement()
        {
            InitializeComponent();
        }
        private void Clear()
        {
            txtSupplier.Text = "";
            txtProductCategory.Text = "";
            txtProductName.Text = "";
            txtUnitCostPrice.Text = "";
            txtUnitSalesPrice.Text = "";
            txtTotalPurchase.Text = "";
            txtTotalSale.Text = "";
            txtCurrentStock.Text = "";
            txtStockAmount.Text = "";
            txtProductID.Text = "";
            dtpDate.Value = DateTime.Today;
            txtAddProduct.Text = "";
            txtTotalCost.Text = "";
            txtSubProduct.Text = "";
            txtTotalPrice.Text = "";
            txtDescription.Text = "";
            cbReturnToSupplier.Checked = false;
            
        }      
        
        private void LoadProductName()
        {

            EasySaleDataContext DB = new EasySaleDataContext();
            var query = from p in DB.tbl_Products
                        orderby p.ProductName ascending
                        select p;
            if (query.Count() != 0)
            {
                cmbProductName.DisplayMember = "ProductName";
                cmbProductName.DataSource = query;

                cmbProductNameStock.DisplayMember = "ProductName";
                cmbProductNameStock.ValueMember = "ProductID";
                cmbProductNameStock.DataSource = query;
            }
            else
            {
                cmbProductName.DataSource = null;
                cmbProductNameStock.DataSource = null;
            }
        }

        private void frmStockManagement_Load(object sender, EventArgs e)
        {
            LoadProductName();
            Clear();            
        }
        private void SearchProduct()
        {
            if (cmbProductName.Text != "")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var query = from p in DB.tbl_Products
                            where p.ProductName.Contains(cmbProductName.Text.Trim())
                            select p;
                if (query.Count() != 0)
                {
                    dgSearch.Rows.Clear();
                    foreach (tbl_Product product in query)
                    {
                        double availAble = 0;
                        availAble = ClsStockSummary.GetStockQuantityByProductID(product.ProductID);
                        try
                        {
                            dgSearch.Rows.Add(product.ProductID, ClsProductCategory.GetProductCategorySingleInfo(Int64.Parse(product.CategoryID.ToString())).CategoryName, availAble);

                        }
                        catch
                        {
                            dgSearch.Rows.Clear();
                        }
                    }


                }
                else
                {
                    dgSearch.Rows.Clear();
                }
            }
            else
            {
                dgSearch.Rows.Clear();
                MessageBox.Show("Please Write Product Name.");
                cmbProductName.Focus();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProduct();
        }
        

        public static double GetSingleProductStock(string ProductID)
        {
            double Total = 0;
            EasySaleDataContext DB = new EasySaleDataContext();
            var query = from p in DB.tbl_StockSummaries
                        where p.ProductID == ProductID 
                        select p;
            if (query.Count() != 0)
            {
                Total = query.Single().StockQty.Value;
            }
            
            return Total;
        }
        public void GetTotalSale(string ProductID)
        {
            double  SubQty = 0;
            EasySaleDataContext DB = new EasySaleDataContext();
            var query = from p in DB.tbl_StockDetails
                        where p.ProductID == ProductID && p.ShopID == GlobalVariable.ShopID && p.SalesInvoiceNo != null
                        select p.SubQty.Value;
            if (query.Count() != 0)
            {
                SubQty = Convert.ToDouble(query.Sum());
            }           
            txtTotalSale.Text = SubQty.ToString();
           // return Total;
        }
        public void GetTotalPurchase(string ProductID)
        {
            double AddQty = 0;
            EasySaleDataContext DB = new EasySaleDataContext();
            var query = from p in DB.tbl_StockDetails
                        where p.ProductID == ProductID && p.ShopID == GlobalVariable.ShopID && p.PurchaseInvoiceNo != null
                        select p.AddQty.Value;
            if (query.Count() != 0)
            {
                AddQty = Convert.ToDouble(query.Sum());
            }      
            txtTotalPurchase.Text = AddQty.ToString();
        }
       


        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbProductName.Text = "";
            dgSearch.Rows.Clear();
        }     
       

        private void txtSubProduct_Leave(object sender, EventArgs e)
        {
            if (txtProductID.Text != "")
            {
                ClsGlobalClass.CheckTypeInLeaveForInt(txtSubProduct);
                try
                {
                    if (Convert.ToDouble(txtCurrentStock.Text.Trim()) >= Convert.ToDouble(txtSubProduct.Text.Trim()))
                    {
                        CalculateAddSubProduct();
                    }
                    else
                    {
                        MessageBox.Show("Please Check Sub Product Quantity.\n Sub Product Quantity should not be more than Current Stock Quantity.");
                        txtSubProduct.Focus();
                    }
                }
                catch
                { 
                
                }
                
            }
            
        }

        private void txtAddProduct_Leave(object sender, EventArgs e)
        {
            if (txtProductID.Text != "")
            {                
                try
                {
                    ClsGlobalClass.CheckTypeInLeaveForInt(txtAddProduct);
                    CalculateAddSubProduct();
                }
                catch
                { 
                
                }
            }
            
        }
        private void CalculateAddSubProduct()
        {
            try
            {
                double Add = 0, Sub = 0, UnitCost = 0;
                Add = txtAddProduct.Text == "" ? 0 : Convert.ToDouble(txtAddProduct.Text.Trim());
                Sub = txtSubProduct.Text == "" ? 0 : Convert.ToDouble(txtSubProduct.Text.Trim());
                UnitCost = txtUnitCostPrice.Text == "" ? 0 : Convert.ToDouble(txtUnitCostPrice.Text.Trim());
                txtTotalCost.Text = Math.Round(Add * UnitCost, 2).ToString();
                txtTotalPrice.Text = Math.Round(Sub * UnitCost, 2).ToString();
            }
            catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbProductNameStock.Text != "" && txtUnitSalesPrice.Text != "" && (txtSubProduct.Text != "" || txtAddProduct.Text != ""))
            {
                int check = 0;
                EasySaleDataContext DB = new EasySaleDataContext();
                tbl_StockDetail stock = new tbl_StockDetail();
                tbl_StockSummary summery = new tbl_StockSummary();
                string ProductID = cmbProductNameStock.SelectedValue.ToString();
                tbl_Supplier supplier = ClsSupplier.GetSupplierSingleInfoByName(txtSupplier.Text.Trim());
                //check valid product id
                var r = from p in DB.tbl_Products
                        where p.ProductID ==cmbProductNameStock.SelectedValue.ToString()
                        select p;
                if (r.Count() > 0)
                {
                    if (cbReturnToSupplier.Checked == true)
                    {
                        if (cbReturnToSupplier.Checked == true && txtSubProduct.Text != "")
                        {
                            using (TransactionScope Trans = new TransactionScope())
                            {
                                try
                                {                                   
                                    tbl_ProductReturn product = new tbl_ProductReturn();
                                    product.Date = dtpDate.Value.Date;
                                    product.ProductID = ProductID;
                                    product.ReturnQty = txtSubProduct.Text == "" ? 0 : Int16.Parse(txtSubProduct.Text.Trim());

                                    product.SupplierID = supplier == null ? 0 : supplier.SupplierID;

                                    product.ShopID = GlobalVariable.ShopID;

                                    DB.tbl_ProductReturns.InsertOnSubmit(product);
                                    DB.SubmitChanges();



                                    if (txtAddProduct.Text != "")
                                    {
                                        stock.AddQty = Int16.Parse(txtAddProduct.Text.Trim());
                                    }
                                    else
                                    {
                                        stock.AddQty = 0;
                                    }
                                    if (txtSubProduct.Text != "")
                                    {
                                        stock.SubQty = Int16.Parse(txtSubProduct.Text.Trim());
                                    }
                                    else
                                    {
                                        stock.SubQty = 0;
                                    }
                                    if (txtTotalCost.Text != "")
                                    {
                                        stock.AddCost = float.Parse(txtTotalCost.Text.Trim());
                                    }
                                    else
                                    {
                                        stock.AddCost = 0;
                                    }
                                    if (txtTotalPrice.Text != "")
                                    {
                                        stock.SubCost = float.Parse(txtTotalPrice.Text.Trim());
                                    }
                                    else
                                    {
                                        stock.SubCost = 0;
                                    }

                                    stock.ShopID = GlobalVariable.ShopID;
                                    stock.ProductID = ProductID;
                                    stock.CreateDate = dtpDate.Value.Date;

                                    stock.SupplierID = supplier == null ? 0 : supplier.SupplierID;

                                    DB.tbl_StockDetails.InsertOnSubmit(stock);
                                    DB.SubmitChanges();
                                    //Update stock qty
                                    var q = from p in DB.tbl_StockSummaries
                                            where p.ProductID == ProductID && p.ShopID == GlobalVariable.ShopID
                                            select p;
                                    foreach (tbl_StockSummary sum in q)
                                    {
                                        sum.StockQty = sum.StockQty + stock.AddQty - stock.SubQty;
                                    }
                                    DB.SubmitChanges();

                                    Trans.Complete();
                                    check = 1;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                            if (check > 0)
                            {
                                MessageBox.Show("Stock Changed Successfully.");
                                Clear();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please Write Sub Product Quantity.");
                            txtSubProduct.Focus();
                        }

                    }
                    else
                    {
                        //if check box not selected
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            try
                            {
                                if (txtAddProduct.Text != "")
                                {
                                    stock.AddQty = Int16.Parse(txtAddProduct.Text.Trim());
                                }
                                else
                                {
                                    stock.AddQty = 0;
                                }
                                if (txtSubProduct.Text != "")
                                {
                                    stock.SubQty = Int16.Parse(txtSubProduct.Text.Trim());
                                }
                                else
                                {
                                    stock.SubQty = 0;
                                }
                                if (txtTotalCost.Text != "")
                                {
                                    stock.AddCost = float.Parse(txtTotalCost.Text.Trim());
                                }
                                else
                                {
                                    stock.AddCost = 0;
                                }
                                if (txtTotalPrice.Text != "")
                                {
                                    stock.SubCost = float.Parse(txtTotalPrice.Text.Trim());
                                }
                                else
                                {
                                    stock.SubCost = 0;
                                }

                                stock.ShopID = GlobalVariable.ShopID;
                                stock.ProductID = ProductID;
                                stock.CreateDate = dtpDate.Value.Date;
                                stock.SupplierID = supplier == null ? 0 : supplier.SupplierID;
                                DB.tbl_StockDetails.InsertOnSubmit(stock);
                                DB.SubmitChanges();

                                //Update stock qty
                                var q = from p in DB.tbl_StockSummaries
                                        where p.ProductID ==   ProductID && p.ShopID == GlobalVariable.ShopID
                                        select p;
                                if (q.Count() > 0)
                                {
                                    foreach (tbl_StockSummary sum in q)
                                    {
                                        sum.StockQty = sum.StockQty + stock.AddQty - stock.SubQty;
                                    }
                                    DB.SubmitChanges();
                                }
                                else //insert 
                                {
                                    summery.CategoryID = int.Parse(ClsProduct.GetProductInfoByID(ProductID).CategoryID.ToString());
                                    summery.ProductID = ProductID;
                                    summery.ShopID = GlobalVariable.ShopID;
                                    summery.StockQty = stock.AddQty;
                                    summery.SupplierID = ClsProduct.GetProductInfoByID(ProductID).SupplierID;

                                    DB.tbl_StockSummaries.InsertOnSubmit(summery);
                                    DB.SubmitChanges();
                                }
                                Trans.Complete();
                                check = 1;
                            }
                            catch
                            {

                            }
                        }
                        if (check > 0)
                        {
                            MessageBox.Show("Stock Updated Successfully.");
                            Clear();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Product ID.\n Please Enter a valid Product ID.");
                    txtProductID.Focus();
                }
            }
            else
            {
                if (cmbProductNameStock.Text == "")
                {
                    MessageBox.Show("Please Select Product Name.");
                    cmbProductNameStock.Focus();
                }
                else if (txtUnitSalesPrice.Text == "")
                {
                    MessageBox.Show("Please Purchase First and Then Try Again.");
                    //txtUnitSalesPrice.Focus();
                }
                else if (txtAddProduct.Text == "" || txtSubProduct.Text == "")
                {
                    MessageBox.Show("Please Enter Add Product Quantity Or Sub Product Quantity.");
                    txtAddProduct.Focus();
                }

            }
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbl_PurchaseProductInfo singleInfo = new tbl_PurchaseProductInfo();
                string BarcodeText = txtProductID.Text.Trim();
                string ProductID = "";
                string InvoiceNoHidden = "";
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
                    singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNo(ProductID, ClsRecentProductPrice.GetProductInfoByID(ProductID).InvoiceNo);
                }

                //get product Name and Category name
                ProductInfo = ClsProduct.GetProductNameAndCategoryNameByID(ProductID);
                ProductName = ProductInfo[0];
                CategoryName = ProductInfo[1];

                if (singleInfo != null)
                {
                    tbl_Supplier supplier = ClsSupplier.GetSupplierSingleInfo(int.Parse(singleInfo.SupplierID.ToString()));
                    txtSupplier.Text = supplier.SupplierName;
                    try
                    {
                        txtProductCategory.Text = CategoryName;
                    }
                    catch
                    {
                        txtProductCategory.Text = "";
                    }
                    txtProductName.Text = ProductName;
                    txtUnitCostPrice.Text = singleInfo.UnitCost.ToString();
                    txtUnitSalesPrice.Text = singleInfo.SalesPrice.ToString();
                    txtCurrentStock.Text = ClsStockSummary.GetStockQuantityByProductID(ProductID).ToString();
                    GetTotalPurchase(ProductID);
                    GetTotalSale(ProductID);
                    txtStockAmount.Text = (Math.Round(Convert.ToDouble(txtCurrentStock.Text.Trim()) * Convert.ToDouble(txtUnitCostPrice.Text.Trim()), 2)).ToString();

                }
                else
                {
                    txtSupplier.Text = "";
                    txtProductCategory.Text = "";
                    txtProductName.Text = "";
                    txtUnitCostPrice.Text = "";
                    txtUnitSalesPrice.Text = "";
                    txtTotalPurchase.Text = "";
                    txtTotalSale.Text = "";
                    txtCurrentStock.Text = "";
                    txtStockAmount.Text = "";
                }
            }

            catch
            {

            }

        }

        private void frmStockManagement_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchProduct();
            }
        }

        private void cmbProductNameStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbl_PurchaseProductInfo singleInfo;
                string BarcodeText = cmbProductNameStock.SelectedValue.ToString();
                string ProductID = "";
                string InvoiceNoHidden = "";
                string ProductName = "";
                string CategoryName = "";
                string[] ProductInfo = new string[2];

                ////check Barcode label with invoce no or not
                //if (BarcodeText.Contains(GlobalVariable.BarcodeCharacter))
                //{
                //    //with barcode label   
                //    string[] Info = ClsBarcodeLabel.GetProductIDandInvoiceNoFromBarcode(BarcodeText);
                //    ProductID = Info[0];
                //    InvoiceNoHidden = Info[1];
                //    //GetSingleInfoFromPurchaseProduct(ProductID, InvoiceNo);    
                //    singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNoHidden(ProductID, InvoiceNoHidden);
                //}
                //else
                {
                    try
                    {
                        ProductID = BarcodeText;

                        singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNo(ProductID, ClsRecentProductPrice.GetProductInfoByID(ProductID).InvoiceNo);

                    }
                    catch
                    {
                        singleInfo = null;
                    }
                }
                //get product Name and Category name
                ProductInfo = ClsProduct.GetProductNameAndCategoryNameByID(ProductID);
                ProductName = ProductInfo[0];
                CategoryName = ProductInfo[1];

                if (singleInfo != null)
                {
                    tbl_Supplier supplier = ClsSupplier.GetSupplierSingleInfo(int.Parse(singleInfo.SupplierID.ToString()));
                    txtSupplier.Text = supplier.SupplierName;
                    try
                    {
                        txtProductCategory.Text = CategoryName;
                    }
                    catch
                    {
                        txtProductCategory.Text = "";
                    }
                    txtProductName.Text = ProductName;
                    txtUnitCostPrice.Text = singleInfo.UnitCost.ToString();
                    txtUnitSalesPrice.Text = singleInfo.SalesPrice.ToString();
                    txtCurrentStock.Text = ClsStockSummary.GetStockQuantityByProductID(ProductID).ToString();
                    GetTotalPurchase(ProductID);
                    GetTotalSale(ProductID);
                    txtStockAmount.Text = (Math.Round(Convert.ToDouble(txtCurrentStock.Text.Trim()) * Convert.ToDouble(txtUnitCostPrice.Text.Trim()), 2)).ToString();

                }
                else
                {
                    txtSupplier.Text = "";
                    txtProductCategory.Text = "";
                    txtProductName.Text = "";
                    txtUnitCostPrice.Text = "";
                    txtUnitSalesPrice.Text = "";
                    txtTotalPurchase.Text = "";
                    txtTotalSale.Text = "";
                    txtCurrentStock.Text = "";
                    txtStockAmount.Text = "";
                }
            }

            catch
            {

            }
        }

       
        
    }
}
