using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.DAO;
using digitalPharma.AccountSystem.DAO;

namespace digitalPharma
{
    public partial class frmReportAll : Form
    {
        public frmReportAll()
        {
            InitializeComponent();
        }

        
        private void LoadSalesInvoiceNo()
        {
        EasySaleDataContext DB = new EasySaleDataContext();

            var query = from p in DB.tbl_SalesInvInfos
                        where p.ShopID == GlobalVariable.ShopID && p.AdvanceStatus == 0
                        orderby p.SN descending
                        select p.SalesInvoiceNo;
            if (query.Count() != 0)
            {
                cmbInvoiceNoSales.DataSource = query;
            }
            else
            {
                cmbInvoiceNoSales.DataSource = null;
            }
        }

        private void LoadInvoiceNoPurchase()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var query = from p in DB.tbl_PurchaseInvInfos
                        where p.ShopID == GlobalVariable.ShopID
                        select p.InvoiceNo;
            if (query.Count() != 0)
            {
                cmbInvoiceNoPurchase.DataSource = query;
            }
            else
            {
                cmbInvoiceNoPurchase.DataSource = null;
            }
        }
        public void LoadExpenseHeadName()
        {
            try
            {
                DataTable dt = ClsEpense.GetExpenseHeadNameDataSource();
                cmbHeaderName.DataSource = dt;
                cmbHeaderName.DisplayMember = "name";
                cmbHeaderName.ValueMember = "id";
            }
            catch
            {
                cmbHeaderName.DataSource = null;
            }
        }
        public void LoadIncomeHeadName()
        {
            try
            {
                DataTable dt =ClsIncome.GetIncomeHeadNameDataSource();
                cmbIncomeHeadname.DataSource = dt;
                cmbIncomeHeadname.DisplayMember = "name";
                cmbIncomeHeadname.ValueMember = "id";
            }
            catch
            {
                cmbIncomeHeadname.DataSource = null;
            }
        }
        public void LoadSupplier()
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var Query = from p in DB.tbl_Suppliers
                        orderby p.SupplierName ascending
                        select p;// new { name = p.SupplierName, id = p.SupplierID };
            if (Query.Count() != 0)
            {
                try
                {
                    cmbSuppler.DataSource = Query;
                    cmbSuppler.DisplayMember = "SupplierName";
                    cmbSuppler.ValueMember = "SupplierID";
                }
                catch 
                {
                    cmbSuppler.DataSource = null;
                }
            }
            else
            {
                cmbSuppler.DataSource = null;
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

                cmbProductCategory.DataSource = null;
                cmbProductCategory.DataSource = q;

                cmbProductCategory.ValueMember = "CategoryID";
                cmbProductCategory.DisplayMember = "CategoryName";

            }
            else
            {
                cmbProductCategory.DataSource = null;
            }
            cmbProductCategory.Text = "";
        }
        private void frmReportDateWiseReport_Load(object sender, EventArgs e)
        {
            LoadSalesInvoiceNo();
            LoadInvoiceNoPurchase();
            LoadExpenseHeadName();
            LoadSupplier();
            LoadProductCategory();
            LoadIncomeHeadName();
            if (GlobalVariable.userType == "Sales Man")
            {
                gbExpense.Visible = false;
                gbIncome.Visible = false;
                gbProfit.Visible = false;
                gbSale.Visible = false;
                gbSaleDate.Visible = false;
                gbPurchsaseDate.Visible = false;
                gbPurchase.Visible = false;
                gbReturn.Visible = false;
                gbSupplierwise.Visible = false;
                gbCategoryWise.Visible = false;
                gbStock.Visible = false;
                gbPopular.Visible = false;
            }
        }

        private void btnReportSingle_Click(object sender, EventArgs e)
        {
            if (cmbInvoiceNoSales.Text != "")
            {
                GlobalVariable.InvoiceNo = cmbInvoiceNoSales.Text.ToString();
                CrvSales sale = new CrvSales("SalesSingle", cmbInvoiceNoSales.Text.ToString());
                sale.Show();
            }
            else
            {
                MessageBox.Show("Please Select a Invoice ID.");
                cmbInvoiceNoSales.Focus();
            }
        }

        private void btnReportDateWise_Click(object sender, EventArgs e)
        {
            GlobalVariable.FromDate = dtpFrom.Value.Date;
            GlobalVariable.ToDate = dtpTo.Value.Date;
            CrvSales rep = new CrvSales("DateWise","");
            rep.Show();
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            GlobalVariable.SaleReport = "Counter Wise";
            GlobalVariable.FromDate = dtpFrom.Value.Date;
            GlobalVariable.ToDate = dtpTo.Value.Date;
            CrvCounterWiseSaleReport rep = new CrvCounterWiseSaleReport();
            rep.Show();
        }

        private void btnPurchaseSingle_Click(object sender, EventArgs e)
        {
            if (cmbInvoiceNoPurchase.Text != "")
            {
                GlobalVariable.InvoiceNo = cmbInvoiceNoPurchase.Text.ToString();
                CrvPurchse purchase = new CrvPurchse("PurchaseSingle");
                purchase.Show();
            }
            else
            {
                MessageBox.Show("Please Select a Invoice ID.");
                cmbInvoiceNoPurchase.Focus();
            }
        }

        private void btnPurchaseDatewise_Click(object sender, EventArgs e)
        {
            GlobalVariable.FromDate = dtpFrom.Value.Date;
            GlobalVariable.ToDate = dtpTo.Value.Date;
            CrvPurchse purchase = new CrvPurchse("PurchaseDateWise");
            purchase.Show();
            
        }
        
        private void cmbProductGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbSuppler_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbHeaderName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        
        CrvStock stock;
        private void btnStockSummery_Click(object sender, EventArgs e)
        {
            if (stock == null)
            {
                stock = new CrvStock("Summary", 0,0,"");
                //stock.MdiParent = this.MdiParent;
                stock.FormClosed += new FormClosedEventHandler(stock_FormClosed);
                stock.Show();
                stock.WindowState = FormWindowState.Maximized;
            }
            else
            {
                stock.Activate();
            }
        }

        void stock_FormClosed(object sender, FormClosedEventArgs e)
        {
            stock = null;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSalesInvoiceNo();
            LoadInvoiceNoPurchase();
            LoadExpenseHeadName();
            LoadSupplier();
            LoadProductCategory();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            if (cmbSuppler.Text != "")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_StockSummaries
                        from r in DB.tbl_Products
                        where p.ProductID == r.ProductID && p.SupplierID == int.Parse(cmbSuppler.SelectedValue.ToString()) && p.ShopID == GlobalVariable.ShopID
                        orderby r.ProductName ascending
                        select p;
                if (q.Count() > 0)
                {
                    GlobalVariable.SupplierName = cmbSuppler.Text.Trim();
                    CrvStock sto = new CrvStock("SupplierWise", int.Parse(cmbSuppler.SelectedValue.ToString()), 0, "");
                    sto.Show();
                }
                else
                {
                    MessageBox.Show("Report Not available For This Supplier. ");
                }
            }
            else
            {
                MessageBox.Show("Please select Supplier Name.");
                cmbSuppler.Focus();
            }
        }

        private void btnLeadger_Click(object sender, EventArgs e)
        {
            GlobalVariable.FromDate = dtpFrom.Value;
            GlobalVariable.ToDate = dtpTo.Value;
            CrvLedger led = new CrvLedger("Ledger");
            led.Show();
        }

        private void btnHead_Click(object sender, EventArgs e)
        {
            GlobalVariable.FromDate = dtpFrom.Value;
            GlobalVariable.ToDate = dtpTo.Value;
            CrvAccounts exp = new CrvAccounts("HeadWiseExp" , cmbHeaderName.Text.Trim(), int.Parse(cmbHeaderName.SelectedValue.ToString()));
            exp.Show();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            GlobalVariable.FromDate = dtpFrom.Value;
            GlobalVariable.ToDate = dtpTo.Value;
            CrvAccounts exp = new CrvAccounts("DateWiseExp", "", 0);
            exp.Show();
        }

        private void btnProductCategory_Click(object sender, EventArgs e)
        {
            if (cmbProductCategory.Text != "")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_StockSummaries
                        from r in DB.tbl_Products
                        where p.ProductID == r.ProductID && p.CategoryID == int.Parse(cmbProductCategory.SelectedValue.ToString()) && p.ShopID == GlobalVariable.ShopID
                        orderby r.ProductName ascending
                        select p;
                if (q.Count() > 0)
                {
                    GlobalVariable.SupplierName = cmbSuppler.Text.Trim();
                    CrvStock sto = new CrvStock("ProductCategory", 0, Int64.Parse(cmbProductCategory.SelectedValue.ToString()), cmbProductCategory.Text.Trim());
                    sto.Show();
                }
                else
                {
                    MessageBox.Show("Report Not available For This Category. ");
                }
            }
            else
            {
                MessageBox.Show("Please select Product Category.");
                cmbProductCategory.Focus();
            }
        }

        private void btnPopularProductList_Click(object sender, EventArgs e)
        {
            GlobalVariable.FromDate = dtpFrom.Value.Date;
            GlobalVariable.ToDate = dtpTo.Value.Date;

            CrvSales sale = new CrvSales("Popular","");
            sale.Show();
        }

        private void btnHeadIncome_Click(object sender, EventArgs e)
        {
            GlobalVariable.FromDate = dtpFrom.Value;
            GlobalVariable.ToDate = dtpTo.Value;
            CrvAccounts exp = new CrvAccounts("HeadWiseInc", cmbIncomeHeadname.Text.Trim(), int.Parse(cmbIncomeHeadname.SelectedValue.ToString()));
            exp.Show();
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            GlobalVariable.FromDate = dtpFrom.Value;
            GlobalVariable.ToDate = dtpTo.Value;
            CrvAccounts exp = new CrvAccounts("DateWiseInc", "", 0);
            exp.Show();
        }

        private void btnReturnProduct_Click(object sender, EventArgs e)
        {
            GlobalVariable.FromDate = dtpFrom.Value.Date;
            GlobalVariable.ToDate = dtpTo.Value.Date;

            CrvReturnProductDateWise purchse = new CrvReturnProductDateWise();
            purchse.Show();
        }

        private void btnExpired_Click(object sender, EventArgs e)
        {
            if (txtExpiredDays.Text != "")
            {
                GlobalVariable.FromDate = dtpExpired.Value.Date;
                GlobalVariable.Days = int.Parse(txtExpiredDays.Text.Trim());
                CrvPurchse purchase = new CrvPurchse("Expired");
                purchase.Show();
            }
            else
            {
                MessageBox.Show("Please Enter Days.");
                txtExpiredDays.Focus();
            }
        }

        private void txtExpiredDays_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForInt(txtExpiredDays);
        }

        private void frmReportAll_KeyDown(object sender, KeyEventArgs e)
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
