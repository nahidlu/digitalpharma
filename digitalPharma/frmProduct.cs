using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.DAO;
using digitalPharma.Reports;

namespace digitalPharma
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {

        }
        /*
        private void Clear()
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtTotalStock.Enabled = true;
            txtSupplierID.Text = "";
            txtNoOfBarcode.Text = "";
            txtSalesPrice.Text = "";
            txtTotalStock.Text = "";
            txtUnitCost.Text = "";
            cmbProductGroup.Text = "";
            cmbProductName.Text = "";
            cmbSupplierName.Text = "";
            CreateProductID();
        }
        private void CreateProductID()
        {
            string month = "", day = "", hour = "", min = "", sec = "";
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

            if (Convert.ToDouble(DateTime.Now.Hour.ToString()) < 10)
            {
                hour = "0" + DateTime.Now.Hour.ToString();
            }
            else
            {
                hour = DateTime.Now.Hour.ToString();
            }

            if (Convert.ToDouble(DateTime.Now.Minute.ToString()) < 10)
            {
                min = "0" + DateTime.Now.Minute.ToString();
            }
            else
            {
                min = DateTime.Now.Minute.ToString();
            }

            if (Convert.ToDouble(DateTime.Now.Second.ToString()) < 10)
            {
                sec = "0" + DateTime.Now.Second.ToString();
            }
            else
            {
                sec = DateTime.Now.Second.ToString();
            }




            txtProductID.Text = DateTime.Now.Year.ToString().Substring(2) + month + day + hour + min + sec;
        }
        private void LoadSupplierName()
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var query = from p in DB.tbl_Suppliers
                        orderby p.SupplierName ascending
                        select p;
            if (query.Count() != 0)
            {
                cmbSupplierName.Items.Clear();
                foreach (tbl_Supplier supplier in query)
                {
                    cmbSupplierName.Items.Add(supplier.SupplierName);
                }
            }
            else
            {
                cmbSupplierName.Items.Clear();
            }
        }

        private void LoadProductName()
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            

            var query1 = from p in DB.tbl_PurchaseProducts
                         orderby p.ProductName ascending
                         group p by p.ProductName into AllGroup
                         select new { ProductName = AllGroup.Key, AllGroup };
            cmbProductName.DataSource = query1;
            cmbProductName.DisplayMember = "ProductName";
            cmbProductName.Text = "";
        }

        private void LoadProductNameByGroup()
        {
            if (cmbProductGroup.Text != "")
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                var query1 = from p in DB.tbl_PurchaseProducts
                             where p.ProductGroup == cmbProductGroup.Text.Trim()
                             orderby p.ProductName ascending
                             group p by p.ProductName into AllGroup
                             select new { ProductName = AllGroup.Key, AllGroup };
                cmbProductName.DataSource = query1;
                cmbProductName.DisplayMember = "ProductName";
            }
        }

        //private void LoadProductNameByGroup()
        //{
        //    if (cmbProductGroup.Text != "")
        //    {
        //        EasySaleDataContext DB = new EasySaleDataContext();
        //        try
        //        {
        //            var query1 = from p in DB.tbl_PurchaseProducts
        //                         where p.ProductGroup == cmbProductGroup.Text.Trim()
        //                         select p;
        //            if (query1.Count() != 0)
        //            {
        //                cmbProductName.DataSource = null;
        //                cmbProductName.Items.Clear();
        //                foreach (tbl_PurchaseProduct pro in query1)
        //                {
        //                    cmbProductName.Items.Add(pro.ProductName);
        //                }
        //            }
        //            else
        //            {
        //                cmbProductName.DataSource = null;
        //                cmbProductName.Items.Clear();
        //            }
        //        }
        //        catch
        //        { }
        //    }
        //}

        private void LoadProductGroup()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var q = from p in DB.tbl_ProductGroups
                    orderby p.GroupName ascending
                    select new { name = p.GroupName, id = p.GroupID };
            if (q.Count() > 0)
            {

                cmbProductGroup.DataSource = null;
                cmbProductGroup.DataSource = q;

                cmbProductGroup.ValueMember = "id";
                cmbProductGroup.DisplayMember = "name";

            }
            else
            {
                cmbProductGroup.DataSource = null;
            }
            cmbProductGroup.Text = "";
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadSupplierName();
            CreateProductID();
            LoadProductGroup();
            cmbProductName.Text = "";
        }

        public static double GetSingleProductStock(string ProductID)
        {
                       
            double AddQty = 0, SubQty = 0, Total = 0;
            EasySaleDataContext DB = new EasySaleDataContext();
            var query = from p in DB.tbl_StockDetails
                        where p.ProductID == ProductID && p.ShopName == GlobalVariable.Shop
                        select p;
            if (query.Count() != 0)
            {
                foreach (tbl_Stock detail in query)
                {
                    try
                    {
                        AddQty += detail.AddQty.Value;
                        SubQty += detail.SubQty.Value;
                    }
                    catch
                    {

                    }
                }
            }
            Total = AddQty - SubQty;
            return Total;
        }

        private void cmbProductID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cmbSupplierName_Leave(object sender, EventArgs e)
        {
            if (cmbSupplierName.Text != "")
            {
                tbl_Supplier supplier = ClsSupplier.GetSupplierSingleInfoByName(cmbSupplierName.Text);
                if (supplier != null)
                {
                    txtSupplierID.Text = supplier.SupplierID;
                }
                else
                {
                    txtSupplierID.Text = "";
                }
            }
        }
        private void CheckTypeInLeaveForFloat(TextBox Box)
        {
            if (Box.Text != "")
                try
                {
                    Box.ForeColor = Color.Black;
                    float.Parse(Box.Text);

                }
                catch
                {
                    MessageBox.Show("Wrong Input.");
                    Box.Focus();
                    Box.ForeColor = Color.Red;
                }
        }

        private void CheckTypeInLeaveForInt(TextBox Box)
        {
            if (Box.Text != "")
                try
                {
                    Box.ForeColor = Color.Black;
                    int.Parse(Box.Text);

                }
                catch
                {
                    MessageBox.Show("Wrong Input.");
                    Box.Focus();
                    Box.ForeColor = Color.Red;
                }
        }

        private void txtNoOfBarcode_Leave(object sender, EventArgs e)
        {
            CheckTypeInLeaveForInt(txtNoOfBarcode);
        }

        private void txtUnitCost_Leave(object sender, EventArgs e)
        {
            CheckTypeInLeaveForFloat(txtUnitCost);
        }

        private void txtSalesPrice_Leave(object sender, EventArgs e)
        {

            CheckTypeInLeaveForFloat(txtSalesPrice);
        }

        private void txtTotalStock_Leave(object sender, EventArgs e)
        {
            CheckTypeInLeaveForInt(txtTotalStock);
        }

        //ADD

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProductGroup.Text != "" && txtProductID.Text != "" && cmbProductName.Text != "" && cmbSupplierName.Text != "" && txtSupplierID.Text != "" && txtSalesPrice.Text != "" && txtTotalStock.Text != "" && txtUnitCost.Text != "")
            {
                //This part(duplicate check) is not need because if id exist then add will be stop and update will be enabled.

                //EasySaleDataContext DB = new EasySaleDataContext();
                //var Duplicate = from p in DB.tbl_PurchaseProducts
                //                where p.ProductID == txtProductID.Text.Trim()
                //                select p;
                //if (Duplicate.Count() == 0)
                //{
                    tbl_PurchaseProductInfo purchsase = new tbl_PurchaseProductInfo();
                    tbl_StockDetail stock = new tbl_StockDetail();
                    purchsase.SupplierID = int.Parse( txtSupplierID.Text.Trim());
                    try
                    {
                        purchsase.ProductCategoryID = Int64.Parse( cmbProductGroup.SelectedValue.ToString());
                    }
                    catch
                    {
                        purchsase.ProductGroup = "";
                    }
                    purchsase.ProductID = txtProductID.Text.Trim();
                    purchsase.ProductName = cmbProductName.Text.Trim();
                    purchsase.ShopName = GlobalVariable.Shop;
                    if (txtUnitCost.Text != "")
                    {
                        purchsase.UnitCost = Math.Round(float.Parse(txtUnitCost.Text.Trim()), 2);
                    }
                    else
                    {
                        purchsase.UnitCost = 0;
                    }
                    if (txtTotalStock.Text != "")
                    {
                        purchsase.Qty = int.Parse(txtTotalStock.Text.Trim());
                    }
                    else
                    {
                        purchsase.Qty = 0;
                    }
                    if (txtSalesPrice.Text != "")
                    {
                        purchsase.SalesPrice = Math.Round(float.Parse(txtSalesPrice.Text.Trim()), 2);
                    }
                    else
                    {
                        purchsase.SalesPrice = 0;
                    }
                    purchsase.Amount = Math.Round((purchsase.UnitCost.Value * purchsase.Qty.Value), 2);
                    purchsase.Discount = 0;
                    purchsase.VatAmount = 0;

                    Int64 check1 = ClsPurchase.InsertPurchaseProductInfo(purchsase);

                    //insert stock 

                    if (check1 > 0)
                    {
                        stock.ProductID = txtProductID.Text.Trim();
                        //stock.InvoiceNo = txtInvoiceNo.Text.Trim();
                        stock.SupplierID = txtSupplierID.Text.Trim();
                        stock.ShopName = GlobalVariable.ShopName;
                        if (txtTotalStock.Text != "")
                        {
                            stock.AddQty = int.Parse(txtTotalStock.Text.Trim());
                        }
                        else
                        {
                            stock.AddQty = 0;
                        }

                        stock.AddCost = Math.Round((purchsase.UnitCost.Value * purchsase.Qty.Value), 2);

                        stock.Date = DateTime.Today.Date;
                        stock.Description = "";
                        stock.ShopName = GlobalVariable.ShopName;
                        stock.SubCost = 0;
                        stock.SubQty = 0;

                        Int64 check3 = ClsStock.InsertStock(stock);

                        if (check3 > 0)
                        {
                            MessageBox.Show("Saved Successfully.");
                            Clear();
                        }
                    }
                //}
                //else
                //{
                //    MessageBox.Show("This Product ID already Saved.\n Please try with another Product ID.");                    
                //}

            }
            else
            {
                if (cmbProductGroup.Text == "")
                {
                    MessageBox.Show("Please Select Product Group.");
                    cmbProductGroup.Focus();
                }
                else if (cmbProductName.Text == "")
                {
                    MessageBox.Show("Please Select Product Name.");
                    cmbProductName.Focus();
                }
                else if (txtSupplierID.Text == "")
                {
                    MessageBox.Show("Please Select a valid Supplier Name.");
                    cmbSupplierName.Focus();
                }
                else if (txtProductID.Text == "")
                {
                    MessageBox.Show("Please Write Product ID.");
                    txtProductID.Focus();
                }
                else if (txtUnitCost.Text == "")
                {
                    MessageBox.Show("Please Write Product Unit Cost.");
                    txtUnitCost.Focus();
                }
                else if (txtSalesPrice.Text == "")
                {
                    MessageBox.Show("Please Write Sales Price.");
                    txtSalesPrice.Focus();
                }
                else if (txtTotalStock.Text == "")
                {
                    MessageBox.Show("Please Write Total Stock.");
                    txtTotalStock.Focus();
                }
            }
        }
        private void LoadProductNameInLeaveEvent()
        {
            if (cmbProductGroup.Text != "")
            {
                try
                {
                    EasySaleDataContext DB = new EasySaleDataContext();

                    var query1 = from p in DB.tbl_ProductNames
                                 where p.ProductGroup == ClsProductGroup.GetProductGroupSingleInfoByName(cmbProductGroup.Text).GroupID
                                 orderby p.ProductName ascending
                                 select p;
                    if (query1.Count() > 0)
                    {
                        cmbProductName.Text = "";
                        //cmbProductName.DataSource = null;
                        cmbProductName.Items.Clear();
                        foreach (tbl_ProductName name in query1)
                        {
                            cmbProductName.Items.Add(name.ProductName);
                        }
                    }
                    else
                    {
                        cmbProductName.Text = "";
                        cmbProductName.Items.Clear();
                    }
                }
                catch
                {
                
                }
            }
        }
        private void cmbProductGroup_Leave(object sender, EventArgs e)
        {
            LoadProductNameInLeaveEvent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbProductGroup.Text != "" && txtProductID.Text != "" && cmbProductName.Text != "" && cmbSupplierName.Text != "" && txtSupplierID.Text != "" && txtSalesPrice.Text != "" && txtTotalStock.Text != "" && txtUnitCost.Text != "")
            {
                tbl_PurchaseProduct purchsase = new tbl_PurchaseProduct();
                tbl_Stock stock = new tbl_Stock();
                purchsase.SupplierID = txtSupplierID.Text.Trim();
                try
                {
                    purchsase.ProductGroup = cmbProductGroup.SelectedValue.ToString();
                }
                catch
                {
                    purchsase.ProductGroup = "";
                }
                purchsase.ProductID = txtProductID.Text.Trim();
                purchsase.ProductName = cmbProductName.Text.Trim();
                purchsase.ShopName = GlobalVariable.Shop;
                if (txtUnitCost.Text != "")
                {
                    purchsase.UnitCost = Math.Round(float.Parse(txtUnitCost.Text.Trim()), 2);
                }
                else
                {
                    purchsase.UnitCost = 0;
                }
                if (txtTotalStock.Text != "")
                {
                    purchsase.Qty = int.Parse(txtTotalStock.Text.Trim());
                }
                else
                {
                    purchsase.Qty = 0;
                }
                if (txtSalesPrice.Text != "")
                {
                    purchsase.SalesPrice = Math.Round(float.Parse(txtSalesPrice.Text.Trim()), 2);
                }
                else
                {
                    purchsase.SalesPrice = 0;
                }
                purchsase.Amount = Math.Round((purchsase.UnitCost.Value * purchsase.Qty.Value), 2);
                purchsase.Discount = 0;
                purchsase.VatAmount = 0;

                Int64 check1 = ClsPurchase.InsertPurchaseProductInfo(purchsase);

                if (check1 > 0)
                {
                    MessageBox.Show("Updated Successfully.");
                    Clear();
                }

            }
            else
            {
                if (cmbProductGroup.Text == "")
                {
                    MessageBox.Show("Please Select Product Group.");
                    cmbProductGroup.Focus();
                }
                else if (cmbProductName.Text == "")
                {
                    MessageBox.Show("Please Select Product Name.");
                    cmbProductName.Focus();
                }
                else if (txtSupplierID.Text == "")
                {
                    MessageBox.Show("Please Select a valid Supplier Name.");
                    cmbSupplierName.Focus();
                }
                else if (txtProductID.Text == "")
                {
                    MessageBox.Show("Please Write Product ID.");
                    txtProductID.Focus();
                }
                else if (txtUnitCost.Text == "")
                {
                    MessageBox.Show("Please Write Product Unit Cost.");
                    txtUnitCost.Focus();
                }
                else if (txtSalesPrice.Text == "")
                {
                    MessageBox.Show("Please Write Sales Price.");
                    txtSalesPrice.Focus();
                }
                else if (txtTotalStock.Text == "")
                {
                    MessageBox.Show("Please Write Total Stock.");
                    txtTotalStock.Focus();
                }
            }
        }

        private void cmbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text != "")
            { if( MessageBox.Show("Are You Sure To Delete","", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Int64 che = ClsProduct.DeleteProductName(txtProductID.Text.Trim());
                    if (che > 0)
                    {
                        Int64 che1 = ClsStock.DeleteStock(txtProductID.Text.Trim());
                        if (che1 > 0)
                        {
                            MessageBox.Show("Deleted Successfully.");
                            Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select a Product ID.");
            }
        }

        private void cmbProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
           // LoadProductNameInLeaveEvent();
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text != "" && cmbProductName.Text != "" && txtSalesPrice.Text != "" && txtNoOfBarcode.Text != "")
            {

                Barcode barcodeDetails = new Barcode();
                DataTable dataTable = barcodeDetails.tbl_Barcode;

                CrBarcodeReport Report = new CrBarcodeReport();

                //int blank_labels = 0;
                //int numberofLabel = 6;


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
                    string ProductID = txtProductID.Text.Trim();
                    if (blank_labels <= i)
                    {
                        drow["Barcode"] = "*";
                        drow["Barcode"] += ProductID;
                        drow["Barcode"] += "*";

                        drow["ProductId"] = ProductID;
                        drow["ProductName"] = cmbProductName.Text.Trim();
                        drow["SalesPrice"] = "Tk " + txtSalesPrice.Text + "/-";
                        //drow["Code"] = "ABCDE" + i.ToString();
                        drow["ShopName"] = GlobalVariable.Shop;
                    }
                    dataTable.Rows.Add(drow);
                }



                GlobalVariable.DataTable = dataTable;
                // Report.Database.Tables["tbl_Barcode"].SetDataSource((DataTable)dataTable);
                // crystalReportViewer1.ReportSource = Report;
                CrvBarcode code = new CrvBarcode();
                code.Show();

            }
            else
            {
                if (cmbProductName.Text == "")
                {
                    MessageBox.Show("Please Select Product Name.");
                    cmbProductName.Focus();
                }
                else if (txtProductID.Text == "")
                {
                    MessageBox.Show("Please Write Product ID.");
                    txtProductID.Focus();
                }
                else if (txtSalesPrice.Text == "")
                {
                    MessageBox.Show("Please Write Sales Price.");
                    txtSalesPrice.Focus();
                }
                else if (txtNoOfBarcode.Text == "")
                {
                    MessageBox.Show("Please Write No of Barcode.");
                    txtNoOfBarcode.Focus();
                }
            }
    
        }

        private void cmbProductGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            tbl_PurchaseProductInfo product = ClsPurchase.GetPurchaseProductInfoSingle(txtProductID.Text.Trim());
            if (product != null)
            {
                tbl_Supplier supplier = ClsSupplier.GetSupplierSingleInfo(int.Parse( product.SupplierID.ToString()));
                if (supplier != null)
                {
                    cmbSupplierName.Text = supplier.SupplierName;
                }
                else
                {
                    cmbSupplierName.Text = "";
                }
                txtSupplierID.Text = product.SupplierID.ToString();

                // load group name form group id
                try
                {
                    cmbProductGroup.Text = ClsProductGroup.GetProductGroupSingleInfo(product.ProductGroup).GroupName;
                }
                catch
                {
                    cmbProductGroup.Text = "";
                }
                cmbProductName.Text = product.ProductName;
                txtUnitCost.Text = product.UnitCost.ToString();
                txtSalesPrice.Text = product.SalesPrice.ToString();
                try
                {
                    double stock = GetSingleProductStock(txtProductID.Text.Trim());
                    txtTotalStock.Text = stock.ToString();
                }
                catch
                {
                    txtTotalStock.Text = "0";
                }
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                txtTotalStock.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                txtTotalStock.Enabled = true;
            }
        }

        private void cmbSupplierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }*/
    }
}
