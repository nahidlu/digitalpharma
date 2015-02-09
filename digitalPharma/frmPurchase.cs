using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;
using digitalPharma.DAO;
using digitalPharma.Reports;
using System.Transactions;
using digitalPharma.AccountSystem.DAO;
//using KeepDynamic.Barcode.Generator;

namespace digitalPharma
{
    public partial class frmPurchase : Form
    {
        string InvoiceNoHidden = "";

        public frmPurchase()
        {
            InitializeComponent();
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

        private void Clear()
        {
            cmbProductCategory.Text = "";
            cmbProductName.Text = "";
            cmbSupplierName.Text = "";
            dtpExpiredDate.Value = DateTime.Today;
            dtpInvoiceDate.Value = DateTime.Today;
            dtpReceivedDate.Value = DateTime.Today;
            txtAddress.Text = "";
            txtBatchNo.Text = "";
            txtAmount.Text = "";
            txtContactName.Text = "";
            txtContactNo.Text = "";
            txtDiscount.Text = "";
            txtInvTotal.Text = "";
            txtInvoiceNo.Text = "";
            txtPersent.Text = "";
            txtPID.Text = "";
            txtQuantity.Text = "";
            txtSalesPrice.Text = "";
            txtCarryingCost.Text = "";
            txtSubTotal.Text = "";
            txtSupplierID.Text = "";
            txtTotalVat.Text = "";
            txtUnitCost.Text = "";
            txtVat.Text = "";
            dgPurchase.Rows.Clear();
            btnAdd.Text = "Add";
            btnDelete.Enabled = false;
            InvoiceNoHidden = "";
            cmbProductName.SelectedIndex = -1;
            cmbSupplierName.SelectedIndex = -1;
            // LoadProductName();
            //txtShopName.Text = "";
        }

        private void ClearForDataGrid()
        {
            //cmbProductGroup.Text = "";
            txtProductID.Text = "";
            cmbProductName.Text = "";
            txtPID.Text = "";
            txtQuantity.Text = "";
            txtUnitCost.Text = "";
            txtAmount.Text = "";
            txtPersent.Text = "";
            txtSalesPrice.Text = "";
            txtVat.Text = "";
            txtQtyRupee.Text = "";
            txtUnitCostInRupee.Text = "";
            txtUnitCostWithLC.Text = "";
            txtBatchNo.Text = "";
            dtpExpiredDate.Value = DateTime.Today;
            btnAdd.Text = "Add";
            cmbProductName.SelectedIndex = -1;
            btnDelete.Enabled = false;
            GlobalVariable.RowNo = 0;
            cmbProductName.Focus();
        }
        private int CheckDuplicateProductID()
        {
            int counter = 0;
            for (int i = 0; i < dgPurchase.Rows.Count - 1; i++)
            {
                if (dgPurchase.Rows[i].Cells[0].Value != null)
                {
                    if (dgPurchase.Rows[i].Cells[2].Value.ToString() == txtPID.Text.Trim())
                    {
                        counter += 1;
                    }
                }
            }
            return counter;

        }
        private int CheckDuplicateProductIDInUpdate()
        {
            int counter = 0;
            for (int i = 0; i < dgPurchase.Rows.Count - 1; i++)
            {
                if (dgPurchase.Rows[i].Cells[0].Value != null && GlobalVariable.RowNo != i)
                {
                    if (dgPurchase.Rows[i].Cells[2].Value.ToString() == txtPID.Text.Trim())
                    {
                        counter += 1;
                    }
                }
            }
            return counter;

        }




        private void ChangeFontColor(TextBox Box)
        {
            if (Box.Text != "")
                try
                {
                    Box.ForeColor = Color.Black;
                    float.Parse(Box.Text);
                }
                catch
                {
                    Box.ForeColor = Color.Red;
                }
        }

        public static void LoadSupplierName(ComboBox box)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var query = from p in DB.tbl_Suppliers
                        orderby p.SupplierName ascending
                        select new { name = p.SupplierName, id = p.SupplierID };
            if (query.Count() > 0)
            {
                box.DataSource = query;
                box.DisplayMember = "name";
                box.ValueMember = "id";
                box.SelectedIndex = -1;

            }
            else
            {
                box.DataSource = null;
            }
        }
       /* private void LoadSupplierName()
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
        }*/

        private void LoadProductNameInLeaveEvent()
        {
            if (cmbProductCategory.Text != "")
            {
                try
                {
                    EasySaleDataContext DB = new EasySaleDataContext();

                    var query1 = from p in DB.tbl_Products
                                 where p.CategoryID == int.Parse(cmbProductCategory.SelectedValue.ToString())
                                 orderby p.ProductName ascending
                                 select p;
                    if (query1.Count() > 0)
                    {
                        cmbProductName.DataSource = query1;
                        cmbProductName.DisplayMember = "ProductName";
                        cmbProductName.ValueMember = "ProductID";
                        cmbProductName.Text = "";
                        txtPID.Text = "";
                        txtUnitCost.Text = "";
                        txtSalesPrice.Text = "";
                    }
                    else
                    {
                        cmbProductName.Text = "";
                        txtPID.Text = "";
                        cmbProductName.DataSource = null; ;
                        txtUnitCost.Text = "";
                        txtSalesPrice.Text = "";
                    }
                }
                catch
                {
                    cmbProductName.Text = "";
                    txtPID.Text = "";
                    cmbProductName.DataSource = null; ;
                    txtUnitCost.Text = "";
                    txtSalesPrice.Text = "";
                }
            }
        }
        private void LoadProductGroup()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var q = from p in DB.tbl_ProductCategories
                    orderby p.CategoryName ascending
                    select new { name = p.CategoryName, id = p.CategoryID };
            if (q.Count() > 0)
            {

                cmbProductCategory.DataSource = null;
                cmbProductCategory.DataSource = q;

                cmbProductCategory.ValueMember = "id";
                cmbProductCategory.DisplayMember = "name";
                cmbSupplierName.SelectedIndex = -1;
            }
            else
            {
                cmbProductCategory.DataSource = null;
            }
            cmbProductCategory.Text = "";
        }
        private void frmPurchase_Load(object sender, EventArgs e)
        {
            txtShopName.Text = GlobalVariable.ShopName;
            LoadSupplierName(cmbSupplierName);
            LoadProductGroup();           
            cmbProductCategory.SelectedIndex = -1;
            cmbProductName.SelectedIndex = -1;
        }

        private void CalculateRupee()
        {
            double LC = 0, TotalRupee = 0, ExchangeRate = 0, Qty = 0, UnitCostInRupee = 0, ConvertedTaka = 0;
            try
            {
                LC = double.Parse(txtLC.Text.Trim());
            }
            catch
            {
                LC = 0;
            }
            try
            {
                TotalRupee = double.Parse(txtTotalRupee.Text.Trim());
            }
            catch
            {
                TotalRupee = 0;
            }
            try
            {
                ExchangeRate = double.Parse(txtER.Text.Trim());
            }
            catch
            {
                ExchangeRate = 0;
            }
            try
            {
                Qty = double.Parse(txtQtyRupee.Text.Trim());
            }
            catch
            {
                Qty = 0;
            }
            try
            {
                UnitCostInRupee = double.Parse(txtUnitCostInRupee.Text.Trim());
            }
            catch
            {
                UnitCostInRupee = 0;
            }
            ConvertedTaka = (((LC / TotalRupee) * UnitCostInRupee) + UnitCostInRupee) * ExchangeRate;
            txtUnitCostWithLC.Text = (((LC / TotalRupee) * UnitCostInRupee) + UnitCostInRupee).ToString();
            txtUnitCost.Text = ConvertedTaka.ToString();
            txtQuantity.Text = txtQtyRupee.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProductCategory.Text != "" && cmbProductName.Text != "" && txtPID.Text != "" && txtQuantity.Text != "" && txtAmount.Text != "" && txtUnitCost.Text != "" && txtSalesPrice.Text != "" && txtBatchNo.Text != "" && (dtpExpiredDate.Value > dtpReceivedDate.Value))
            {
                if (btnAdd.Text == "Add")
                {
                    // check duplicate product id entry
                    int Check = CheckDuplicateProductID();
                    if (Check > 0)
                    {
                        MessageBox.Show("You Already Entered This Product.");
                    }
                    else
                    {
                        dgPurchase.Rows.Add(cmbProductCategory.Text, cmbProductName.Text, txtPID.Text,
                        txtQuantity.Text == "" ? 0 : Math.Round((Convert.ToDouble(txtQuantity.Text)), 2),
                        txtUnitCost.Text == "" ? 0 : Math.Round(Convert.ToDouble(txtUnitCost.Text), 2), txtAmount.Text,
                        txtPersent.Text == "" ? 0 : (Math.Round(Convert.ToDouble(txtPersent.Text), 2)),
                        txtSalesPrice.Text == "" ? 0 : Math.Round(Convert.ToDouble(txtSalesPrice.Text), 2),
                        txtVat.Text == "" ? 0 : Math.Round(Convert.ToDouble(txtVat.Text), 2), cmbProductCategory.SelectedValue.ToString(),
                        txtUnitCostInRupee.Text == "" ? 0 : Math.Round(Convert.ToDouble(txtUnitCostInRupee.Text), 2), txtBatchNo.Text.Trim(), dtpExpiredDate.Value.ToShortDateString());
                        ClearForDataGrid();
                        CalculateAllTotal();
                    }
                }
                else //update
                {
                    int Check = CheckDuplicateProductIDInUpdate();
                    if (Check > 0)
                    {
                        MessageBox.Show("You Already Entered This Product.");
                    }
                    else
                    {
                        dgPurchase.Rows[GlobalVariable.RowNo].SetValues(cmbProductCategory.Text, cmbProductName.Text, txtPID.Text,
                        txtQuantity.Text == "" ? 0 : Math.Round((Convert.ToDouble(txtQuantity.Text)), 2),
                        txtUnitCost.Text == "" ? 0 : Math.Round(Convert.ToDouble(txtUnitCost.Text), 2),
                        txtAmount.Text, txtPersent.Text == "" ? 0 : (Math.Round(Convert.ToDouble(txtPersent.Text), 2)),
                        txtSalesPrice.Text == "" ? 0 : Math.Round(Convert.ToDouble(txtSalesPrice.Text), 2),
                        txtVat.Text == "" ? 0 : Math.Round(Convert.ToDouble(txtVat.Text), 2), cmbProductCategory.SelectedValue.ToString(),
                        txtUnitCostInRupee.Text == "" ? 0 : Math.Round(Convert.ToDouble(txtUnitCostInRupee.Text), 2), txtBatchNo.Text.Trim(), dtpExpiredDate.Value.ToShortDateString());
                        ClearForDataGrid();
                        CalculateAllTotal();
                    }
                }
            }
            else
            {
                if (cmbProductCategory.Text == "")
                {
                    MessageBox.Show("Please Select Product Category.");
                    cmbProductCategory.Focus();
                }
                else if (cmbProductName.Text == "")
                {
                    MessageBox.Show("Please Select Product Name.");
                    cmbProductName.Focus();
                }
                else if (txtPID.Text == "")
                {
                    MessageBox.Show("For PID Please Select a Product Name.");
                    cmbProductName.Focus();
                }
                else if (txtUnitCost.Text == "")
                {
                    MessageBox.Show("Please Enter Product Unit Cost.");
                    txtUnitCost.Focus();
                }
                else if (txtAmount.Text == "")
                {
                    MessageBox.Show("Please Enter Amount.");
                    txtAmount.Focus();
                }
                else if (txtSalesPrice.Text == "")
                {
                    MessageBox.Show("Please Enter Sales Price.");
                    txtSalesPrice.Focus();
                }
                else if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity.");
                    txtQuantity.Focus();
                }
                else if (txtBatchNo.Text == "")
                {
                    MessageBox.Show("Please Enter Batch No.");
                    txtBatchNo.Focus();
                }
                else if (dtpExpiredDate.Value <= dtpReceivedDate.Value)
                {
                    MessageBox.Show("Please Select Valid Expired Date.");
                    dtpExpiredDate.Focus();
                }
            }
        }


        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForInt(txtQuantity);
        }

        private void txtUnitCost_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtUnitCost);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtAmount);
        }

        private void txtSalesPrice_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtSalesPrice);
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtDiscount);
        }

        private void txtShipCharge_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtCarryingCost);
        }
        private void LoadAllProductNameAgainstSupplier()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                var query1 = from p in DB.tbl_Products from r in DB.tbl_DosagesDescriptions
                             where p.DosagesID == r.DosagesID && p.SupplierID == int.Parse(cmbSupplierName.SelectedValue.ToString())
                             orderby p.ProductName ascending
                             select new { name = p.ProductName + " " + r.DosagesDescription, id = p.ProductID };
                if (query1.Count() > 0)
                {
                    cmbProductName.DataSource = query1;
                    cmbProductName.DisplayMember = "name";
                    cmbProductName.ValueMember = "id";
                    cmbProductName.SelectedIndex = -1;
                    cmbProductCategory.SelectedIndex = -1;
                    //tbl_ProductCategory Cat = ClsProductCategory.GetProductCategorySingleInfo(Int64.Parse( ClsProduct.GetProductInfoByID(cmbProductName.SelectedValue.ToString()).CategoryID.ToString()));
                    //cmbProductCategory.Text = Cat.CategoryName;
                    cmbProductName.Text = "";
                    txtPID.Text = "";
                    txtUnitCost.Text = "";
                    txtSalesPrice.Text = "";
                }
                else
                {
                    cmbProductName.Text = "";
                    txtPID.Text = "";
                    cmbProductName.DataSource = null; ;
                    txtUnitCost.Text = "";
                    txtSalesPrice.Text = "";
                }
            }
            catch
            {
                cmbProductName.Text = "";
                txtPID.Text = "";
                cmbProductName.DataSource = null; ;
                txtUnitCost.Text = "";
                txtSalesPrice.Text = "";
            }
        }
        /*private void LoadAllProductName()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                var query1 = from p in DB.tbl_Products
                             orderby p.ProductName ascending
                             select new { name = p.ProductName + " " + p.DosageDescription, id = p.ProductID };
                if (query1.Count() > 0)
                {
                    cmbProductNameAll.DataSource = query1;
                    cmbProductNameAll.DisplayMember = "name";
                    cmbProductNameAll.ValueMember = "id";
                    cmbProductNameAll.SelectedIndex = -1;
                    cmbProductNameAll.SelectedIndex = -1;
                    //tbl_ProductCategory Cat = ClsProductCategory.GetProductCategorySingleInfo(Int64.Parse( ClsProduct.GetProductInfoByID(cmbProductName.SelectedValue.ToString()).CategoryID.ToString()));
                    //cmbProductCategory.Text = Cat.CategoryName;
                    cmbProductName.Text = "";
                    txtPID.Text = "";
                    txtUnitCost.Text = "";
                    txtSalesPrice.Text = "";
                }
                else
                {
                    cmbProductName.Text = "";
                    txtPID.Text = "";
                    cmbProductName.DataSource = null; ;
                    txtUnitCost.Text = "";
                    txtSalesPrice.Text = "";
                }
            }
            catch
            {
                cmbProductName.Text = "";
                txtPID.Text = "";
                cmbProductName.DataSource = null; ;
                txtUnitCost.Text = "";
                txtSalesPrice.Text = "";
            }
        }*/
        private void cmbSupplierName_Leave(object sender, EventArgs e)
        {
            if (cmbSupplierName.Text != "")
            {
                tbl_Supplier supplier = ClsSupplier.GetSupplierSingleInfo(int.Parse(cmbSupplierName.SelectedValue.ToString()));
                if (supplier != null)
                {
                    txtSupplierID.Text = supplier.SupplierID.ToString();
                    txtAddress.Text = supplier.Address;
                    txtContactName.Text = supplier.ContactPerson;
                    txtContactNo.Text = supplier.ContactNo;
                }
                else
                {
                    txtSupplierID.Text = "";
                    txtAddress.Text = "";
                    txtContactName.Text = "";
                    txtContactNo.Text = "";
                }
            }
        }
        private int CheckWrongInputBeforeSave()
        {
            int count = 0;
            for (int i = 0; i < dgPurchase.Rows.Count - 1; i++)
            {
                if (dgPurchase.Rows[i].Cells[0].Value != null)
                {
                    try
                    {
                        int.Parse(dgPurchase.Rows[i].Cells[3].Value.ToString());
                    }
                    catch
                    {
                        count += 1;
                        dgPurchase.Rows[i].Cells[3].Style.BackColor = Color.Red;
                    }
                    try
                    {
                        float.Parse(dgPurchase.Rows[i].Cells[4].Value.ToString());

                    }
                    catch
                    {
                        count += 1;
                        dgPurchase.Rows[i].Cells[4].Style.BackColor = Color.Red;
                    }
                    try
                    {
                        float.Parse(dgPurchase.Rows[i].Cells[5].Value.ToString());

                    }
                    catch
                    {
                        count += 1;
                        dgPurchase.Rows[i].Cells[5].Style.BackColor = Color.Red;
                    }
                    try
                    {
                        float.Parse(dgPurchase.Rows[i].Cells[6].Value.ToString());
                    }
                    catch
                    {
                        count += 1;
                        dgPurchase.Rows[i].Cells[6].Style.BackColor = Color.Red;
                    }
                    try
                    {
                        float.Parse(dgPurchase.Rows[i].Cells[7].Value.ToString());
                    }
                    catch
                    {
                        count += 1;
                        dgPurchase.Rows[i].Cells[7].Style.BackColor = Color.Red;
                    }
                    try
                    {
                        float.Parse(dgPurchase.Rows[i].Cells[8].Value.ToString());
                    }
                    catch
                    {
                        count += 1;
                        dgPurchase.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                }
            }
            return count;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSupplierName.Text != "" && txtSupplierID.Text != "" && txtInvoiceNo.Text != "" && txtShopName.Text != "" && dgPurchase.Rows.Count > 1)
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                if (CheckWrongInputBeforeSave() <= 0)
                {
                    if (btnSave.Text == "Save")
                    {
                        //Create New hidden Invoice No
                        createInvoiceNoHidden();
                        // Check Duplicate Invoice No

                        var query = from p in DB.tbl_PurchaseInvInfos
                                    where p.InvoiceNo == txtInvoiceNo.Text.Trim()
                                    select p;
                        if (query.Count() == 0)
                        {
                            tbl_PurchaseInvInfo info = new tbl_PurchaseInvInfo();
                            info.SupplierID = int.Parse(cmbSupplierName.SelectedValue.ToString());
                            info.InvoiceNo = txtInvoiceNo.Text.Trim();
                            info.InvoiceDate = dtpInvoiceDate.Value.Date;
                            info.ReceivedDate = dtpReceivedDate.Value.Date;
                            info.ShopID = GlobalVariable.ShopID;
                            info.SubTotal = txtSubTotal.Text != "" ? Math.Round(float.Parse(txtSubTotal.Text), 2) : 0;
                            info.CarryingCost = txtCarryingCost.Text != "" ? Math.Round(float.Parse(txtCarryingCost.Text), 2) : 0;
                            info.InvTotal = txtInvTotal.Text != "" ? Math.Round(float.Parse(txtInvTotal.Text), 2) : 0;
                            info.InvTotalInRupee = txtTotalRupee.Text != "" ? Math.Round(float.Parse(txtTotalRupee.Text), 2) : 0;
                            info.CurrencyExRate = txtER.Text != "" ? Math.Round(float.Parse(txtER.Text), 2) : 0;
                            info.LC = txtLC.Text != "" ? Math.Round(float.Parse(txtLC.Text), 2) : 0;
                            info.Discount = txtDiscount.Text != "" ? Math.Round(float.Parse(txtDiscount.Text), 2) : 0;
                            info.TotalVat = txtTotalVat.Text != "" ? Math.Round(float.Parse(txtTotalVat.Text), 2) : 0;
                            
                            List<tbl_PurchaseProductInfo> allProductList = new List<tbl_PurchaseProductInfo>();
                            List<tbl_StockDetail> allStockList = new List<tbl_StockDetail>();
                            for (int i = 0; i < dgPurchase.Rows.Count - 1; i++)
                            {
                                tbl_PurchaseProductInfo product = new tbl_PurchaseProductInfo();
                                product.SupplierID = int.Parse(cmbSupplierName.SelectedValue.ToString());
                                product.InvoiceNo = txtInvoiceNo.Text.Trim();
                                product.ShopID = GlobalVariable.ShopID;
                                product.InvoiceNoHidden = InvoiceNoHidden;
                                if (dgPurchase.Rows[i].Cells[0].Value != null)
                                {
                                    product.ProductCategoryID = int.Parse(dgPurchase.Rows[i].Cells[9].Value.ToString());
                                    product.UnitCostInRupee = float.Parse(dgPurchase.Rows[i].Cells[10].Value.ToString());
                                    product.ProductID = dgPurchase.Rows[i].Cells[2].Value.ToString();
                                    product.Qty = int.Parse(dgPurchase.Rows[i].Cells[3].Value.ToString());
                                    product.UnitCost = Math.Round(float.Parse(dgPurchase.Rows[i].Cells[4].Value.ToString()), 2);
                                    product.TotalAmount = Math.Round(float.Parse(dgPurchase.Rows[i].Cells[5].Value.ToString()), 2);
                                    product.SalesPrice = Math.Round(float.Parse(dgPurchase.Rows[i].Cells[7].Value.ToString()), 2);
                                    product.VatAmount = Math.Round(float.Parse(dgPurchase.Rows[i].Cells[8].Value.ToString()), 2);
                                    product.Discount = 0;
                                    product.BatchNo = dgPurchase.Rows[i].Cells[11].Value.ToString();
                                    product.ExpiredDate = Convert.ToDateTime( dgPurchase.Rows[i].Cells[12].Value.ToString());
                                    //adding  datagrid row item to product list
                                    allProductList.Add(product);

                                    tbl_StockDetail stock = new tbl_StockDetail();
                                    stock.ProductID = dgPurchase.Rows[i].Cells[2].Value.ToString();
                                    stock.PurchaseInvoiceNo = txtInvoiceNo.Text.Trim();
                                    stock.SupplierID = int.Parse(cmbSupplierName.SelectedValue.ToString());
                                    stock.AddQty = int.Parse(dgPurchase.Rows[i].Cells[3].Value.ToString());
                                    stock.AddCost = Math.Round(float.Parse(dgPurchase.Rows[i].Cells[5].Value.ToString()), 2);
                                    stock.CreateDate = dtpReceivedDate.Value.Date;
                                    stock.ShopID = GlobalVariable.ShopID;
                                    stock.SubCost = 0;
                                    stock.SubQty = 0;
                                    //adding  datagrid row item to product list
                                    allStockList.Add(stock);

                                }
                            }
                            using (TransactionScope trans = new TransactionScope())
                            {
                                try
                                {
                                    DB.tbl_PurchaseInvInfos.InsertOnSubmit(info);
                                    DB.SubmitChanges();
                                    DB.tbl_PurchaseProductInfos.InsertAllOnSubmit(allProductList);
                                    DB.SubmitChanges();
                                    DB.tbl_StockDetails.InsertAllOnSubmit(allStockList);
                                    DB.SubmitChanges();
                                    
                                    //insert ledger
                                    tbl_Ledger led = new tbl_Ledger();
                                    led.AccountName = cmbSupplierName.SelectedValue.ToString();
                                     
                                       tbl_LedgerHead Head= ClsLedgerHead.GetSingleLedgerHead(led.AccountName);
                                    led.AccountNo =Head.AccountNo;
                                    led.InAmount = 0;
                                    led.OutAmount = info.InvTotal;
                                    led.Particular = "Supplier Payment";
                                    led.ShopID = GlobalVariable.ShopID;
                                    led.Status = 2;
                                    led.SubGLID = Head.SubGLID;
                                    led.TransactionDate = dtpReceivedDate.Value;
                                    led.TransactionID = DateTime.Now.ToFileTimeUtc().ToString();
                                    led.VoucharNo = txtInvoiceNo.Text.Trim();

                                    DB.tbl_Ledgers.InsertOnSubmit(led);
                                    DB.SubmitChanges();

                                    foreach (var product in allProductList)
                                    {
                                        var q = from p in DB.tbl_RecentProductPrices
                                                where p.ProductID == product.ProductID
                                                select p;
                                        if (q.Count() > 0)
                                        {
                                            foreach (tbl_RecentProductPrice recentProduct in q)
                                            {
                                                recentProduct.UnitCost = product.UnitCost;
                                                recentProduct.SalePrice = product.SalesPrice;
                                                recentProduct.InvoiceNo = product.InvoiceNo;
                                            }
                                            DB.SubmitChanges();
                                        }
                                        else
                                        {
                                            tbl_RecentProductPrice recentProductPrice = new tbl_RecentProductPrice();
                                            recentProductPrice.ProductID = product.ProductID;
                                            recentProductPrice.UnitCost = product.UnitCost;
                                            recentProductPrice.SalePrice = product.SalesPrice;
                                            recentProductPrice.InvoiceNo = product.InvoiceNo;
                                            DB.tbl_RecentProductPrices.InsertOnSubmit(recentProductPrice);
                                            DB.SubmitChanges();
                                        }

                                        //For stock summary insert or update 
                                        var r = from p in DB.tbl_StockSummaries
                                                where p.ProductID == product.ProductID && p.ShopID == GlobalVariable.ShopID
                                                select p;
                                        if (r.Count() > 0)
                                        {
                                            foreach (tbl_StockSummary stockSummary in r)
                                            {
                                                stockSummary.CategoryID = int.Parse(product.ProductCategoryID.ToString());
                                                stockSummary.SupplierID = product.SupplierID;
                                                stockSummary.StockQty = stockSummary.StockQty + product.Qty;
                                            }
                                            DB.SubmitChanges();
                                        }
                                        else
                                        {
                                            tbl_StockSummary SummaryEntry = new tbl_StockSummary();
                                            SummaryEntry.ProductID = product.ProductID;
                                            SummaryEntry.ShopID = GlobalVariable.ShopID;
                                            SummaryEntry.CategoryID = int.Parse(product.ProductCategoryID.ToString());
                                            SummaryEntry.SupplierID = product.SupplierID;
                                            SummaryEntry.StockQty = product.Qty;
                                            DB.tbl_StockSummaries.InsertOnSubmit(SummaryEntry);
                                            DB.SubmitChanges();
                                        }

                                    }
                                    trans.Complete();

                                    MessageBox.Show("All product purchased successfully.");
                                    Clear();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Invoice Number Already Used.\n\n Try With Another Number.");
                            txtInvoiceNo.Focus();
                        }

                    }//save ends here

                }
                else
                {
                    MessageBox.Show("Please Check Wrong Input.");
                    dgPurchase.Focus();
                }

            }
            else
            {
                if (cmbSupplierName.Text == "")
                {
                    MessageBox.Show("Please Select Supplier Name.");
                    cmbSupplierName.Focus();
                }
                else if (txtSupplierID.Text == "")
                {
                    MessageBox.Show("Please Select a valid Supplier Name.");
                    cmbSupplierName.Focus();
                }
                else if (txtInvoiceNo.Text == "")
                {
                    MessageBox.Show("Please Select Invoice ID.");
                    txtInvoiceNo.Focus();
                }
                else if (dgPurchase.Rows.Count <= 1)
                {
                    MessageBox.Show("Please Add Product.");
                    cmbProductCategory.Focus();
                }
                else if (txtShopName.Text == "")
                {
                    MessageBox.Show("Please Select Shop Name.");
                    txtShopName.Focus();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CalculateAmount()
        {
            double Amount = 0, UnitCost = 0, Qty = 0;

            if (txtAmount.Text != "")
            {
                try
                {
                    float.Parse(txtAmount.Text);
                    Amount = Convert.ToDouble(txtAmount.Text);
                }
                catch
                {
                    Amount = 0;
                }
            }
            else
            {
                Amount = 0;
            }

            if (txtUnitCost.Text != "")
            {
                try
                {
                    float.Parse(txtUnitCost.Text);
                    UnitCost = Convert.ToDouble(txtUnitCost.Text);
                }
                catch
                {
                    UnitCost = 0;
                }
            }
            else
            {
                UnitCost = 0;
            }
            if (txtQuantity.Text != "")
            {
                try
                {
                    int.Parse(txtQuantity.Text);
                    Qty = Convert.ToDouble(txtQuantity.Text);
                }
                catch
                {
                    Qty = 0;
                }
            }
            else
            {
                Qty = 0;
            }

            try
            {
                Amount = Math.Round((UnitCost * Qty), 2);
                txtAmount.Text = Amount.ToString();
            }
            catch
            {
                txtAmount.Text = "0";
            }
        }

        private void CalculateSalesPrice()
        {
            double UnitPrice = 0, Percent = 0, TotalSalesPrice = 0;
            try
            {
                UnitPrice = Convert.ToDouble(txtUnitCost.Text.Trim());
                Percent = Convert.ToDouble(txtPersent.Text.Trim());

                TotalSalesPrice = Math.Round((UnitPrice + ((UnitPrice * Percent) / 100)), 2);
                txtSalesPrice.Text = TotalSalesPrice.ToString();
            }
            catch
            {

            }
        }

        private void CalculateSubTotal()
        {
            try
            {
                double SubTotal = 0, Increment = 0;
                for (int i = 0; i < dgPurchase.Rows.Count - 1; i++)
                {
                    if (dgPurchase.Rows[i].Cells[0].Value != null)
                    {
                        Increment = 0;
                        if (dgPurchase.Rows[i].Cells[5].Value != null)
                        {
                            Increment = Convert.ToDouble(dgPurchase.Rows[i].Cells[5].Value.ToString());
                        }
                        else
                        {
                            Increment = 0;
                        }
                        SubTotal += Increment;
                    }
                }
                SubTotal = Math.Round(SubTotal, 2);
                txtSubTotal.Text = SubTotal.ToString();
            }
            catch
            {

            }
        }
        private void CalculateTotalVat()
        {
            try
            {
                double Total = 0, Increment = 0;
                for (int i = 0; i < dgPurchase.Rows.Count - 1; i++)
                {
                    if (dgPurchase.Rows[i].Cells[0].Value != null)
                    {
                        Increment = 0;
                        if (dgPurchase.Rows[i].Cells[8].Value != null)
                        {
                            Increment = Convert.ToDouble(dgPurchase.Rows[i].Cells[8].Value.ToString());
                        }
                        else
                        {
                            Increment = 0;
                        }
                        Total += Increment;
                    }
                }
                Total = Math.Round(Total, 2);
                txtTotalVat.Text = Total.ToString();
            }
            catch
            {

            }
        }

        private void CalculateGrandTotal()
        {
            try
            {
                double SubTotal = 0, Vat = 0, Discount = 0, ShipCharge = 0, InvTotal = 0;

                if (txtDiscount.Text != "")
                {
                    Discount = Convert.ToDouble(txtDiscount.Text);
                }
                else
                {
                    Discount = 0;
                }
                if (txtSubTotal.Text != "")
                {
                    SubTotal = Convert.ToDouble(txtSubTotal.Text);
                }
                else
                {
                    SubTotal = 0;
                }
                if (txtTotalVat.Text != "")
                {
                    Vat = Convert.ToDouble(txtTotalVat.Text);
                }
                else
                {
                    Vat = 0;
                }

                if (txtCarryingCost.Text != "")
                {
                    ShipCharge = Convert.ToDouble(txtCarryingCost.Text);
                }
                else
                {
                    ShipCharge = 0;
                }

                InvTotal = Math.Round((SubTotal + Vat + ShipCharge - Discount), 2);

                txtInvTotal.Text = InvTotal.ToString();
            }
            catch
            {

            }
        }

        private void CalculateAllTotal()
        {
            CalculateSubTotal();
            CalculateTotalVat();
            CalculateGrandTotal();
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void txtUnitCost_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateSalesPrice();
        }

        private void dgPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgPurchase.SelectedRows[0].Cells[0].Value != null)
                {
                    GlobalVariable.RowNo = Convert.ToInt32(dgPurchase.CurrentCell.RowIndex);
                    cmbProductCategory.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[0].Value.ToString();
                    cmbProductName.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[1].Value.ToString();
                    txtPID.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[2].Value.ToString();
                    txtQuantity.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[3].Value.ToString();
                    txtUnitCost.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[4].Value.ToString();
                    txtAmount.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[5].Value.ToString();
                    txtPersent.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[6].Value.ToString();
                    txtSalesPrice.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[7].Value.ToString();
                    txtVat.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[8].Value.ToString();
                    txtBatchNo.Text = dgPurchase.Rows[GlobalVariable.RowNo].Cells[11].Value.ToString();
                    dtpExpiredDate.Value = Convert.ToDateTime(dgPurchase.Rows[GlobalVariable.RowNo].Cells[12].Value.ToString());
                    btnAdd.Text = "Update";
                    btnDelete.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dgPurchase.Rows.RemoveAt(GlobalVariable.RowNo);
                ClearForDataGrid();
                CalculateAllTotal();
            }
        }

        private void txtPersent_TextChanged(object sender, EventArgs e)
        {
            CalculateSalesPrice();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateGrandTotal();
        }

        private void txtShipCharge_TextChanged(object sender, EventArgs e)
        {
            CalculateGrandTotal();
        }

        private void txtPersent_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtPersent);
        }

        private void txtVat_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtVat);
        }

        private void cmbProductGroup_Leave(object sender, EventArgs e)
        {
            LoadProductNameInLeaveEvent();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (dgPurchase.Rows.Count > 1 && txtInvoiceNo.Text != "")
            {
                createInvoiceNoHidden();
                Barcode barcodeDetails = new Barcode();
                DataTable dataTable = barcodeDetails.tbl_Barcode;

                for (int k = 0; k < dgPurchase.Rows.Count; k++)
                {
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
                                    numberofLabel = Convert.ToInt64(dgPurchase.Rows[k].Cells[3].Value.ToString());
                                }
                                catch
                                {

                                }
                                for (int i = 0; i < numberofLabel; i++)
                                {
                                    DataRow drow = dataTable.NewRow();
                                    string ProductID = dgPurchase.Rows[k].Cells[2].Value.ToString();
                                    if (blank_labels <= i)
                                    {
                                        drow["Barcode"] = "*";
                                        drow["Barcode"] += ProductID;
                                        drow["Barcode"] += GlobalVariable.BarcodeCharacter;
                                        drow["Barcode"] += InvoiceNoHidden;
                                        drow["Barcode"] += "*";

                                        drow["ProductId"] = ProductID + GlobalVariable.BarcodeCharacter + InvoiceNoHidden;
                                        drow["ProductName"] = dgPurchase.Rows[k].Cells[1].Value.ToString();
                                        drow["SalesPrice"] = "Tk " + dgPurchase.Rows[k].Cells[7].Value.ToString() + "/-";
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
                    else //default barcode not printed
                    {
                        // check barcode print needed or not 
                        EasySaleDataContext DB = new EasySaleDataContext();
                        var q = from p in DB.tbl_Products
                                where p.ProductID == dgPurchase.Rows[k].Cells[2].Value.ToString() && p.BarcodeNeeded == 1
                                select p;
                        try
                        {
                            if (q.Count() == 1)
                            {
                                int blank_labels = 0;
                                Int64 numberofLabel = 0;
                                try
                                {
                                    numberofLabel = Convert.ToInt64(dgPurchase.Rows[k].Cells[3].Value.ToString());
                                }
                                catch
                                {

                                }
                                for (int i = 0; i < numberofLabel; i++)
                                {
                                    DataRow drow = dataTable.NewRow();
                                    string ProductID = dgPurchase.Rows[k].Cells[2].Value.ToString();
                                    if (blank_labels <= i)
                                    {
                                        drow["Barcode"] = "*";
                                        drow["Barcode"] += ProductID;
                                        drow["Barcode"] += GlobalVariable.BarcodeCharacter;
                                        drow["Barcode"] += InvoiceNoHidden;
                                        drow["Barcode"] += "*";

                                        drow["ProductId"] = ProductID + GlobalVariable.BarcodeCharacter + InvoiceNoHidden;
                                        drow["ProductName"] = dgPurchase.Rows[k].Cells[1].Value.ToString();
                                        drow["SalesPrice"] = "Tk " + dgPurchase.Rows[k].Cells[7].Value.ToString() + "/-";
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

                }
                GlobalVariable.DataTable = dataTable;
                // Report.Database.Tables["tbl_Barcode"].SetDataSource((DataTable)dataTable);
                // crystalReportViewer1.ReportSource = Report;
                CrvBarcode code = new CrvBarcode();
                code.Show();
            }
            else
            {
                if (txtInvoiceNo.Text == "")
                {
                    MessageBox.Show("Please Enter Invoice Number.");
                    txtInvoiceNo.Focus();
                }
                else
                {
                    MessageBox.Show("Please Add Product.");
                    cmbProductCategory.Focus();
                }
            }
        }

        private void cmbProductName_Leave(object sender, EventArgs e)
        {
            if (cmbProductName.Text != "")
            {
                try
                {
                    txtPID.Text = cmbProductName.SelectedValue.ToString();
                }
                catch
                {
                    txtPID.Text = "";
                }


            }
        }


        private void cmbProductGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }
        private void cmbProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }
        private void txtQtyRupee_TextChanged(object sender, EventArgs e)
        {
            CalculateRupee();
        }

        private void txtUnitCostInRupee_TextChanged(object sender, EventArgs e)
        {
            CalculateRupee();
        }

        private void txtUnitCostWithLC_TextChanged(object sender, EventArgs e)
        {
            CalculateRupee();
        }

        private void txtTotalRupee_TextChanged(object sender, EventArgs e)
        {
            CalculateRupee();
        }

        private void txtLC_TextChanged(object sender, EventArgs e)
        {
            CalculateRupee();
        }

        private void txtER_TextChanged(object sender, EventArgs e)
        {
            CalculateRupee();
        }

        private void txtTotalRupee_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtTotalRupee);
        }

        private void txtLC_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtLC);
        }

        private void txtER_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtER);
        }

        private void txtUnitCostInRupee_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtUnitCostInRupee);
        }

        private void txtQtyRupee_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForInt(txtQtyRupee);
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductName.Text != "")
            {
                try
                {
                    string ProductID = cmbProductName.SelectedValue.ToString();
                    txtPID.Text = ProductID;
                    tbl_ProductCategory Cat = ClsProductCategory.GetProductCategorySingleInfo(Int64.Parse(ClsProduct.GetProductInfoByID(ProductID).CategoryID.ToString()));
                    cmbProductCategory.Text = Cat.CategoryName;
                    tbl_RecentProductPrice price = ClsRecentProductPrice.GetProductInfoByID(ProductID);
                    if (price != null)
                    {
                        txtUnitCost.Text = price.UnitCost.ToString();
                        txtSalesPrice.Text = price.SalePrice.ToString();
                    }
                    else
                    {
                        txtUnitCost.Text = "";
                        txtSalesPrice.Text = "";
                    }
                }
                catch
                {

                }
            }
        }

        private void cmbProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadProductNameInLeaveEvent();
        }


        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            if (txtProductID.Text != "")
            {
                try
                {
                    string ProductID = txtProductID.Text.Trim();
                    if (ProductID.Contains(GlobalVariable.BarcodeCharacter))
                    {
                        string[] Info = ClsBarcodeLabel.GetProductIDandInvoiceNoFromBarcode(ProductID);
                        ProductID = Info[0];
                    }
                    else
                    {
                        ProductID = txtProductID.Text.Trim();
                    }
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var q = from p in DB.tbl_Products
                            where p.ProductID == ProductID
                            select p;
                    if (q.Count() > 0)
                    {
                        cmbProductCategory.Text = ClsProductCategory.GetProductCategorySingleInfo(int.Parse(q.Single().CategoryID.ToString())).CategoryName;
                        cmbProductName.Text = q.Single().ProductName;
                        tbl_RecentProductPrice price = ClsRecentProductPrice.GetProductInfoByID(ProductID);
                        if (price != null)
                        {
                            txtUnitCost.Text = price.UnitCost.ToString();
                            txtSalesPrice.Text = price.SalePrice.ToString();
                        }
                        else
                        {
                            txtUnitCost.Text = "";
                            txtSalesPrice.Text = "";
                        }
                        txtPID.Text = ProductID;
                    }
                    else
                    {
                        //MessageBox.Show("This Product is Not Added.\n Please add Product first then try again.");                        
                        cmbProductCategory.Text = "";
                        cmbProductName.Text = "";
                        txtPID.Text = "";
                        txtUnitCost.Text = "";
                        txtSalesPrice.Text = "";
                    }

                }
                catch
                {

                }
            }
        }

        private void txtProductID_MouseHover(object sender, EventArgs e)
        {
            txtProductID.Text = "";
        }

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllProductNameAgainstSupplier();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void frmPurchase_KeyDown(object sender, KeyEventArgs e)
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
