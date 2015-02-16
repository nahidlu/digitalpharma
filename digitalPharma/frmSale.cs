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
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using System.Transactions;
using System.Text.RegularExpressions;
using digitalPharma.AccountSystem.DAO;

namespace digitalPharma
{
    public partial class frmSale : Form
    {
        public frmSale()
        {
            InitializeComponent();
        }
        double AdvanceTkGlobal = 0;
        private void Clear()
        {
            AdvanceTkGlobal = 0;
            dtpSaleDate.Value = DateTime.Today;
            txtAvailableQty.Text = "";
            txtDiscount.Text = "";
            txtDue.Text = "";
            txtPaid.Text = "";
            txtProductID.Text = "";
            txtReturn.Text = "";
            //txtSalesBy.Text = "";
            txtCartTotal.Text = "";
            txtTotal.Text = "";
            txtVat.Text = "";
            dgSale.Rows.Clear();
            cmbPaymentMode.Text = "Cash";
            lblTotal.Text = "0.00" + " " + "TK";
            txtProductRemove.Text = "";
            GlobalVariable.BookingID = "";
            GlobalVariable.Paid = 0;
            lblAdTk.Visible = false;
            lblAdvance.Visible = false;
            lblAdTk.Text = AdvanceTkGlobal.ToString();
            txtDiscountCardNo.Text = "";
            txtMobileNO.Text = "";
            txtCustomerName.Text = "";
            cbAdvance.Checked = false;
            cmbBookingID.Text = "";
            btnSave.Text = "Save";
            createInvoiceNo();
            LoadAdvanceBookingInvoice();
            cmbCounterNo.Text = GlobalVariable.CounterNo;
            txtProductID.Focus();
            txtQty.Text = "";
        }
        private void LoadAdvanceBookingInfo()
        {
            String InvoiceNO = cmbBookingID.Text.Trim();
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = (from p in DB.tbl_SalesInvInfos
                     where p.SalesInvoiceNo == InvoiceNO && p.AdvanceStatus == 1
                     select p).Single();
            if (q != null)
            {
                btnSave.Text = "Advance Sale";
                txtInvoiceNo.Text = InvoiceNO;
                cmbCounterNo.Text = q.CounterNo;
                dtpSaleDate.Value = q.SalesDate.Value;
                cmbPaymentMode.Text = q.PaymentMode;
                txtCartTotal.Text = q.CartTotal.ToString();
                txtDue.Text = q.DueAmount.ToString();
                txtDiscount.Text = q.Discount.ToString();
                txtVat.Text = q.Vat.ToString();
                lblAdTk.Visible = true;
                lblAdvance.Visible = true;
                AdvanceTkGlobal = q.GrandTotal.Value - q.DueAmount.Value;
                lblAdTk.Text = AdvanceTkGlobal.ToString();
                txtTotal.Text = (q.GrandTotal - AdvanceTkGlobal).ToString();
                if (q.AdvanceStatus == 1)
                {
                    cbAdvance.Checked = true;
                }
                else
                {
                    cbAdvance.Checked = false;
                }
                var r = from p in DB.tbl_SalesProductInfos
                        where p.SalesInvoiceNo == InvoiceNO
                        select p;
                if (r.Count() > 0)
                {
                    dgSale.Rows.Clear();
                    tbl_PurchaseProductInfo singleInfo = new tbl_PurchaseProductInfo();

                    foreach (var add in r)
                    {
                        if (add.PurchaseInvNo != "")
                        {
                            singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNo(add.ProductID, add.PurchaseInvNo);
                        }
                        else
                            singleInfo = ClsPurchase.GetLastPurchaseProductInfo(add.ProductID);

                        dgSale.Rows.Add(add.ProductID, ClsProductCategory.GetProductCategorySingleInfo(Int64.Parse(add.ProductCategoryID.ToString())).CategoryName, ClsProduct.GetProductInfoByID(add.ProductID).ProductName, add.SalesPrice, add.Qty, add.TotalAmount, add.VatAmount, add.Discount, singleInfo.UnitCost, add.PurchaseInvNo, add.ProductCategoryID, singleInfo.SupplierID, add.Qty);
                    }
                }
                CalculateSubTotal();
                CalculateFinalTotal();
            }
        }
        private void LoadAdvanceBookingInvoice()
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_SalesInvInfos
                    where p.AdvanceStatus == 1
                    select p;
            if (q.Count() > 0)
            {
                cmbBookingID.Items.Clear();
                foreach (var r in q)
                {
                    cmbBookingID.Items.Add(r.SalesInvoiceNo);
                }
            }
            else
            {
                cmbBookingID.Items.Clear();
                cmbBookingID.Text = "";
            }
        }
        private int[] CheckExistingProductIDInDgSale(string ProductID)
        {
            int Number = 0, RowNO = 0;
            int[] ROWInfo = new int[2];
            for (int i = 0; i <= dgSale.Rows.Count - 1; i++)
            {
                try
                {
                    if (dgSale.Rows[i].Cells[0].Value.ToString() == ProductID)
                    {
                        Number += 1;
                        RowNO = i;
                        ROWInfo[0] = Number;
                        ROWInfo[1] = RowNO;
                    }
                }
                catch
                {

                }
            }
            return ROWInfo;
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
                txtAvailableQty.Text = ClsStockSummary.GetStockQuantityByProductID(ProductID).ToString();
                //get product Name and Category name
                ProductInfo = ClsProduct.GetProductNameAndCategoryNameByID(ProductID);
                ProductName = ProductInfo[0];
                CategoryName = ProductInfo[1];
                //check Existing ProductID for update Qty or new entry
                int[] NumberInfo = CheckExistingProductIDInDgSale(ProductID);
                int Number = NumberInfo[0];
                int RowNO = NumberInfo[1];

                //calculate stock
                double CurrentStock = 0;
                CurrentStock = Convert.ToDouble(txtAvailableQty.Text.Trim());
                if (Number <= 0)
                {
                    if (CurrentStock >= 1)
                    {
                        if (singleInfo != null)
                        {
                            double SalesPrice = 0;

                            SalesPrice = singleInfo.SalesPrice.Value;// -(singleInfo.SalesPrice.Value * singleInfo.Discount.Value) / 100;

                            dgSale.Rows.Add(singleInfo.ProductID, CategoryName, ProductName, Math.Round(SalesPrice, 2), 1, Math.Round(SalesPrice, 2), singleInfo.VatAmount == null ? 0 : singleInfo.VatAmount, singleInfo.Discount == null ? 0 : singleInfo.Discount, singleInfo.UnitCost == null ? 0 : singleInfo.UnitCost, singleInfo.InvoiceNo, singleInfo.ProductCategoryID, singleInfo.SupplierID);
                        }
                        CalculateSubTotal();
                        CalculateFinalTotal();
                    }
                    else
                    {
                    }
                }
                else
                {
                    if (CurrentStock > Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()))
                    {
                        //MessageBox.Show("This Product is in the List. Please Change Quantity.");
                        if (Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) == -1)
                        {
                            dgSale.Rows.RemoveAt(dgSale.Rows[RowNO].Cells[4].RowIndex);
                            CalculateSubTotal();
                            CalculateFinalTotal();
                        }
                        else
                        {
                            dgSale.Rows[RowNO].Cells[4].Value = Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) + 1;
                            CalculateSubTotal();
                            CalculateFinalTotal();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Check Available Stock Quantity.");
                        txtAvailableQty.Focus();
                    }
                }
                txtProductID.Text = "";
            }
            catch
            {

            }
        }

        private void CalculateSubTotal()
        {
            try
            {
                double SubTotal = 0, Increment = 0, Quantity = 0, SalesPrice = 0, UnitCost = 0, SingleVat = 0, Discount = 0, TotalDiscount = 0;
                for (int i = 0; i < dgSale.Rows.Count - 1; i++)
                {
                    if (dgSale.Rows[i].Cells[0].Value != null)
                    {
                        //calculate Total amount
                        Increment = 0;
                        //quantity
                        if (dgSale.Rows[i].Cells[4].Value != null)
                        {
                            Quantity = Convert.ToDouble(dgSale.Rows[i].Cells[4].Value.ToString());
                        }
                        else
                        {
                            Quantity = 0;
                        }
                        //sales price
                        if (dgSale.Rows[i].Cells[3].Value != null)
                        {
                            SalesPrice = Convert.ToDouble(dgSale.Rows[i].Cells[3].Value.ToString());
                        }
                        else
                        {
                            SalesPrice = 0;
                        }
                        Increment = SalesPrice * Quantity;
                        SubTotal += Increment;
                        dgSale.Rows[i].Cells[5].Value = Increment;

                        //calculate total vat
                        //get single vat amount and calculate Vat Amount
                        Increment = 0;
                        tbl_PurchaseProductInfo singleInfo = new tbl_PurchaseProductInfo();
                        if (dgSale.Rows[i].Cells[9].Value.ToString() != "")
                        {
                            singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNo(dgSale.Rows[i].Cells[0].Value.ToString(), dgSale.Rows[i].Cells[9].Value.ToString());
                        }
                        else
                            singleInfo = ClsPurchase.GetLastPurchaseProductInfo(dgSale.Rows[i].Cells[0].Value.ToString());

                        SingleVat = singleInfo.VatAmount == null ? 0 : Convert.ToDouble(singleInfo.VatAmount);
                        Increment = Math.Round(SingleVat * Quantity, 2);
                        dgSale.Rows[i].Cells[6].Value = Increment;
                        SubTotal += Increment;
                        Increment = 0;

                        //unit price
                        UnitCost = singleInfo.UnitCost == null ? 0 : Convert.ToDouble(singleInfo.UnitCost);
                        Increment = Math.Round(UnitCost * Quantity, 2);
                        dgSale.Rows[i].Cells[8].Value = Increment;
                        Increment = 0;
                        //calculate total Discount
                        //get single vat amount and calculate Vat Amount
                        Discount = singleInfo.Discount == null ? 0 : Convert.ToDouble(singleInfo.Discount);
                        double TotDiscount = Math.Round(Discount * Quantity, 2);
                        dgSale.Rows[i].Cells[7].Value = TotDiscount;
                        TotalDiscount += TotDiscount;
                        TotDiscount = 0;
                    }
                }
                SubTotal = Math.Round(SubTotal, 0, MidpointRounding.AwayFromZero);
                txtCartTotal.Text = SubTotal.ToString();
                //Total discount = general discount + card discount
                TotalDiscount = TotalDiscount + ClsDiscountCard.GetDiscountAmount(txtDiscountCardNo.Text.Trim(), SubTotal);
                txtDiscount.Text = Math.Round(TotalDiscount, 0, MidpointRounding.AwayFromZero).ToString();
            }
            catch
            {

            }
        }
        private void CalculateFinalTotal()
        {
            try
            {
                double SubTotal = 0, Discount = 0, DiscountPercent = 0, Vat = 0, Total = 0, Paid = 0, Due = 0, Advance = 0;
                SubTotal = txtCartTotal.Text == "" ? 0 : Convert.ToDouble(txtCartTotal.Text.Trim());
                DiscountPercent = txtDiscountPercent.Text == "" ? 0 : (Convert.ToDouble(txtDiscountPercent.Text.Trim()) * SubTotal) / 100;
                txtDiscount.Text = Math.Round( DiscountPercent,0,MidpointRounding.AwayFromZero).ToString();
                Discount = txtDiscount.Text == "" ? 0 : Convert.ToDouble(txtDiscount.Text.Trim());
                Vat = txtVat.Text == "" ? 0 : Math.Round(((Convert.ToDouble(txtVat.Text.Trim()) * SubTotal) / 100),0,MidpointRounding.AwayFromZero);
                Advance = AdvanceTkGlobal;
                Paid = txtPaid.Text == "" ? 0 : Convert.ToDouble(txtPaid.Text.Trim());
                Total = SubTotal + Vat - Discount - Advance;
                Due = Total - Paid;
                txtTotal.Text = Math.Round(Total, 0, MidpointRounding.AwayFromZero).ToString();
                lblTotal.Text = txtTotal.Text + " " + "TK";
                CalculateReturnAndDue();
            }
            catch
            {

            }
        }
        private void CalculateReturnAndDue()
        {
            double Total = 0, Paid = 0;
            try
            {
                Total = Convert.ToDouble(txtTotal.Text.Trim());
            }
            catch
            {

            }
            try
            {
                Paid = Convert.ToDouble(txtPaid.Text.Trim());
            }
            catch
            {

            }
            if (Paid >= Total)
            {
                txtReturn.Text = Math.Round(Paid - Total, 0, MidpointRounding.AwayFromZero).ToString();
                txtDue.Text = "0";
            }
            else
            {
                txtDue.Text = Math.Round(Total - Paid, 0, MidpointRounding.AwayFromZero).ToString();
                txtReturn.Text = "0";
            }
        }       
       

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalTotal();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalTotal();
        }

        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalTotal();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalTotal();
            txtPaid.Text = txtTotal.Text;
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalTotal();
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtDiscount);
        }

        private void txtVat_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtVat);
        }

        private void txtPaid_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtPaid);
        }
        private void dgSale_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateSubTotal();
            CalculateFinalTotal();
        }
        private void PrintSaleReceipt()
        {
            EasySaleDataContext DBX = new EasySaleDataContext();
            var report = (from p in DBX.tbl_SalesInvInfos
                          where p.SalesInvoiceNo == txtInvoiceNo.Text.Trim()
                          select new { DueAmount = p.DueAmount == null ? 0 : p.DueAmount.Value, Discount = p.Discount == null ? 0 : p.Discount.Value, CartTotal = p.CartTotal == null ? 0 : p.CartTotal.Value, SalesDate = p.SalesDate == null ? DateTime.Now : p.SalesDate.Value, p.SalesInvoiceNo, p.CounterNo, p.SalesBy, p.ShopID.Value, p.PaymentMode, Total = p.GrandTotal == null ? 0 : p.GrandTotal.Value, Vat = p.Vat == null ? 0 : p.Vat.Value }).ToList();
            try
            {
                CrSalesReceipt Sale = new CrSalesReceipt();
                Sale.Load(@"CrSalesReceipt");
                Sale.SetDataSource(report);
                Sale.SetParameterValue("ShopName", GlobalVariable.ShopName);
                Sale.SetParameterValue("Address1", GlobalVariable.Address1);
                Sale.SetParameterValue("Address2", GlobalVariable.Address2);
                Sale.SetParameterValue("Phone", GlobalVariable.Phone);
                Sale.SetParameterValue("Slogan", GlobalVariable.Slogan);
                //CrvSalesReceipt sal = new CrvSalesReceipt();
                //sal.Show();
                PrinterSettings getprinterName = new PrinterSettings();
                Sale.PrintOptions.PrinterName = getprinterName.PrinterName;
                Sale.PrintToPrinter(1, true, 1, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int CheckStockBeforeSave()
        {
            int count = 0;
            for (int i = 0; i < dgSale.Rows.Count - 1; i++)
            {
                if (dgSale.Rows[i].Cells[0].Value != null)
                {
                    int StockQty = 0;
                    StockQty = ClsStockSummary.GetStockQuantityByProductID(dgSale.Rows[i].Cells[0].Value.ToString());
                    if (StockQty < int.Parse(dgSale.Rows[i].Cells[4].Value.ToString()))
                    {
                        count += 1;
                        dgSale.Rows[i].Cells[4].Style.BackColor = Color.Red;
                    }
                }
            }
            return count;
        }
        private float GetProfitAmount()
        {
            //Total sales price - total purchase price
            float Profit = 0;
            try
            {
                for (int i = 0; i <= dgSale.Rows.Count - 1; i++)
                {
                    if (dgSale.Rows[i].Cells[0].Value != null)
                    {
                        Profit += (float.Parse(dgSale.Rows[i].Cells[5].Value.ToString()) - float.Parse(dgSale.Rows[i].Cells[8].Value.ToString()));
                    }
                }
            }
            catch
            {

            }
            return Profit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text != "" && cmbCounterNo.Text != "" && dgSale.Rows.Count > 1 && cmbPaymentMode.Text != "")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                int Chk = 0;
                double ProfitAmount = GetProfitAmount();
                if (btnSave.Text == "Save")
                {
                    var query = from p in DB.tbl_SalesInvInfos
                                where p.SalesInvoiceNo == txtInvoiceNo.Text.Trim()
                                select p;
                    if (query.Count() == 0)
                    {
                        int check = CheckStockBeforeSave();
                        if (check <= 0)
                        {
                            using (TransactionScope trans = new TransactionScope())
                            {
                                try
                                {
                                    tbl_SalesInvInfo info = new tbl_SalesInvInfo();
                                    info.CounterNo = cmbCounterNo.Text.Trim();
                                    info.PaymentMode = cmbPaymentMode.Text.Trim();
                                    info.SalesBy = txtSalesBy.Text.Trim();
                                    info.SalesDate = dtpSaleDate.Value.Date;
                                    info.SalesInvoiceNo = txtInvoiceNo.Text.Trim();
                                    info.ShopID = GlobalVariable.ShopID;
                                    info.CartTotal = txtCartTotal.Text == "" ? 0 : float.Parse(txtCartTotal.Text.Trim());
                                    info.Discount = txtDiscount.Text == "" ? 0 : float.Parse(txtDiscount.Text.Trim());
                                    info.DiscountPercent = txtDiscountPercent.Text == "" ? 0 : float.Parse(txtDiscountPercent.Text.Trim());
                                    info.Vat = txtVat.Text == "" ? 0 : float.Parse(txtVat.Text.Trim());
                                    info.GrandTotal = txtTotal.Text == "" ? 0 : float.Parse(txtTotal.Text.Trim()) + AdvanceTkGlobal;
                                    info.DueAmount = txtDue.Text == "" ? 0 : float.Parse(txtDue.Text.Trim());
                                    info.CustomerMobileNo = txtMobileNO.Text.Trim();
                                    info.DiscountCardNo = txtDiscountCardNo.Text.Trim();
                                    if (txtDiscountCardNo.Text != "")
                                    {
                                        info.DiscountCardAmount = ClsDiscountCard.GetDiscountAmount(txtDiscountCardNo.Text.Trim(), txtCartTotal.Text.Trim() == null ? 0 : Convert.ToDouble(txtCartTotal.Text.Trim()));
                                        info.CustomerID = ClsCustomer.GetCustomerIDByCardID(txtDiscountCardNo.Text.Trim());
                                    }
                                    else
                                    {
                                        info.DiscountCardAmount = 0;
                                        info.CustomerID = 0;
                                    }
                                    if (cbAdvance.Checked == true)
                                        info.AdvanceStatus = 1;
                                    else
                                        info.AdvanceStatus = 0;
                                    info.Profit = ProfitAmount;
                                    
                                    List<tbl_SalesProductInfo> allProductList = new List<tbl_SalesProductInfo>();
                                    List<tbl_StockDetail> allStockList = new List<tbl_StockDetail>();

                                    for (int i = 0; i <= dgSale.Rows.Count - 1; i++)
                                    {
                                        tbl_SalesProductInfo detail = new tbl_SalesProductInfo();
                                        if (dgSale.Rows[i].Cells[0].Value != null)
                                        {
                                            detail.SalesInvoiceNo = txtInvoiceNo.Text.Trim();
                                            detail.ProductID = dgSale.Rows[i].Cells[0].Value.ToString();
                                            detail.ProductCategoryID = Int64.Parse(dgSale.Rows[i].Cells[10].Value.ToString());
                                            detail.SalesDate = dtpSaleDate.Value.Date;
                                            detail.SalesPrice = float.Parse(dgSale.Rows[i].Cells[3].Value.ToString());
                                            detail.Qty = int.Parse(dgSale.Rows[i].Cells[4].Value.ToString());
                                            detail.TotalAmount = float.Parse(dgSale.Rows[i].Cells[5].Value.ToString());
                                            detail.VatAmount = float.Parse(dgSale.Rows[i].Cells[6].Value.ToString());
                                            detail.Discount = float.Parse(dgSale.Rows[i].Cells[7].Value.ToString());
                                            detail.PurchaseInvNo = dgSale.Rows[i].Cells[9].Value.ToString();

                                            allProductList.Add(detail);
                                            //insert stock

                                            tbl_StockDetail stock = new tbl_StockDetail();
                                            stock.ProductID = dgSale.Rows[i].Cells[0].Value.ToString();
                                            stock.SupplierID = int.Parse(dgSale.Rows[i].Cells[11].Value.ToString());
                                            stock.CreateDate = dtpSaleDate.Value.Date;
                                            stock.AddCost = 0;
                                            stock.AddQty = 0;
                                            stock.ShopID = GlobalVariable.ShopID;
                                            stock.SalesInvoiceNo = txtInvoiceNo.Text.Trim();
                                            stock.PurchaseInvoiceNo = dgSale.Rows[i].Cells[9].Value.ToString();
                                            stock.SubQty = dgSale.Rows[i].Cells[4].Value.ToString() == "" ? 0 : int.Parse(dgSale.Rows[i].Cells[4].Value.ToString());
                                            stock.SubCost = dgSale.Rows[i].Cells[5].Value.ToString() == "" ? 0 : float.Parse(dgSale.Rows[i].Cells[5].Value.ToString());

                                            allStockList.Add(stock);

                                        }
                                    }

                                    DB.tbl_SalesInvInfos.InsertOnSubmit(info);
                                    DB.SubmitChanges();

                                    DB.tbl_SalesProductInfos.InsertAllOnSubmit(allProductList);
                                    DB.SubmitChanges();

                                    DB.tbl_StockDetails.InsertAllOnSubmit(allStockList);
                                    DB.SubmitChanges();

                                    //update stock summary
                                    for (int i = 0; i <= dgSale.Rows.Count - 1; i++)
                                    {
                                        if (dgSale.Rows[i].Cells[0].Value != null)
                                        {
                                            var summary = from p in DB.tbl_StockSummaries
                                                          where p.ProductID == dgSale.Rows[i].Cells[0].Value.ToString() && p.ShopID == GlobalVariable.ShopID
                                                          select p;
                                            foreach (tbl_StockSummary SS in summary)
                                            {
                                                SS.StockQty = SS.StockQty - (dgSale.Rows[i].Cells[4].Value.ToString() == "" ? 0 : int.Parse(dgSale.Rows[i].Cells[4].Value.ToString()));
                                            }
                                            DB.SubmitChanges();
                                        }
                                    }

                                    //insert customer info
                                    if (txtMobileNO.Text != "")
                                    {
                                        var q = from p in DB.tbl_Customers
                                                where p.MobileNo == txtMobileNO.Text.Trim()
                                                select p;
                                        if (q.Count() == 0)
                                        {
                                            tbl_Customer Customer = new tbl_Customer();
                                            Customer.CustomerName = txtCustomerName.Text.Trim();
                                            Customer.MobileNo = txtMobileNO.Text.Trim();
                                            DB.tbl_Customers.InsertOnSubmit(Customer);
                                            DB.SubmitChanges();
                                        }
                                    }

                                    List<tbl_Ledger> AllLedgerList = new List<tbl_Ledger>();

                                    //insert ledger table
                                    tbl_Ledger ledger = new tbl_Ledger();
                                    ledger.AccountNo = GlobalVariable.ProductSaleAccountNo;
                                    ledger.InAmount = ProfitAmount;
                                    //ledger.InAmount = txtTotal.Text == "" ? 0 : float.Parse(txtTotal.Text.Trim()) + AdvanceTkGlobal;
                                    ledger.OutAmount = 0;
                                    ledger.Status = 0;
                                    ledger.SubGLID = ClsLedgerHead.GetSubGLIDByAccountNo(GlobalVariable.ProductSaleAccountNo);
                                    ledger.TransactionDate = dtpSaleDate.Value;
                                    ledger.TransactionID = txtInvoiceNo.Text.Trim();
                                    ledger.VoucharNo = txtInvoiceNo.Text.Trim();
                                    ledger.AccountName = GlobalVariable.ProductSaleAccountName;
                                    ledger.Particular = GlobalVariable.ProductSaleAccountName;
                                    ledger.ShopID = GlobalVariable.ShopID;
                                    AllLedgerList.Add(ledger);

                                    //Insert for cash in hand
                                    tbl_Ledger ledgerForCash = new tbl_Ledger();
                                    ledgerForCash.AccountNo = GlobalVariable.CashInHandAccountNo;
                                    //ledgerForCash.InAmount = ProfitAmount;
                                    ledgerForCash.InAmount = txtTotal.Text == "" ? 0 : float.Parse(txtTotal.Text.Trim()) + AdvanceTkGlobal;
                                    ledgerForCash.OutAmount = 0;
                                    ledgerForCash.Status = 0;
                                    ledgerForCash.SubGLID = ClsLedgerHead.GetSubGLIDByAccountNo(GlobalVariable.CashInHandAccountNo);
                                    ledgerForCash.TransactionDate = dtpSaleDate.Value;
                                    ledgerForCash.TransactionID = txtInvoiceNo.Text.Trim();
                                    ledgerForCash.VoucharNo = txtInvoiceNo.Text.Trim();
                                    ledgerForCash.AccountName = GlobalVariable.CashInHandAccountName;
                                    ledgerForCash.Particular = GlobalVariable.CashInHandAccountName;
                                    ledgerForCash.ShopID = GlobalVariable.ShopID;
                                    AllLedgerList.Add(ledgerForCash);

                                    DB.tbl_Ledgers.InsertAllOnSubmit(AllLedgerList);
                                    DB.SubmitChanges();
                                    
                                    trans.Complete();
                                    Chk = 1;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                    Chk = 0;
                                }
                            }
                            if (Chk > 0)
                            {
                               // MessageBox.Show("Saved Successfully.");
                                CrvSalesReceipt sale = new CrvSalesReceipt(txtInvoiceNo.Text.Trim());
                                sale.Show();

                               // PrintSaleReceipt();
                                Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please check stock Quantity.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Invoice Number is Used. \n Please Try with New Invoice Number.");
                    }
                }
                else //Advance Sales here
                {
                    if (cmbBookingID.Text != "" && (cmbBookingID.Text.Trim() == txtInvoiceNo.Text.Trim()))
                    {
                        int check = CheckStockBeforeSave();
                        if (check <= 0)
                        {
                            using (TransactionScope Trans = new TransactionScope())
                            {
                                try
                                {
                                    string InvoiceNO = txtInvoiceNo.Text.Trim();
                                    var q = from p in DB.tbl_SalesInvInfos
                                            where p.SalesInvoiceNo == InvoiceNO && p.AdvanceStatus == 1
                                            select p;
                                    foreach (tbl_SalesInvInfo info in q)
                                    {
                                        info.CounterNo = cmbCounterNo.Text.Trim();
                                        info.PaymentMode = cmbPaymentMode.Text.Trim();
                                        info.SalesBy = txtSalesBy.Text.Trim();
                                        info.SalesDate = dtpSaleDate.Value.Date;
                                        info.SalesInvoiceNo = txtInvoiceNo.Text.Trim();
                                        info.ShopID = GlobalVariable.ShopID;
                                        info.CartTotal = txtCartTotal.Text == "" ? 0 : float.Parse(txtCartTotal.Text.Trim());
                                        info.Discount = txtDiscount.Text == "" ? 0 : float.Parse(txtDiscount.Text.Trim());
                                        info.Vat = txtVat.Text == "" ? 0 : float.Parse(txtVat.Text.Trim());
                                        info.GrandTotal = txtTotal.Text == "" ? 0 : float.Parse(txtTotal.Text.Trim()) + AdvanceTkGlobal;
                                        info.DueAmount = txtDue.Text == "" ? 0 : float.Parse(txtDue.Text.Trim());
                                        info.CustomerMobileNo = txtMobileNO.Text.Trim();
                                        info.DiscountCardNo = txtDue.Text.Trim();
                                        if (txtDiscountCardNo.Text != "")
                                        {
                                            info.DiscountCardAmount = ClsDiscountCard.GetDiscountAmount(txtDiscountCardNo.Text.Trim(), txtCartTotal.Text.Trim() == null ? 0 : Convert.ToDouble(txtCartTotal.Text.Trim()));
                                            info.CustomerID = ClsCustomer.GetCustomerIDByCardID(txtDiscountCardNo.Text.Trim());
                                        }
                                        else
                                        {
                                            info.DiscountCardAmount = 0;
                                            info.CustomerID = 0;
                                        }
                                        info.AdvanceStatus = 0;
                                        info.Profit = ProfitAmount;
                                    }
                                    DB.SubmitChanges();

                                    for (int i = 0; i <= dgSale.Rows.Count - 1; i++)
                                    {
                                        if (dgSale.Rows[i].Cells[0].Value != null)
                                        {
                                            string ProductID = dgSale.Rows[i].Cells[0].Value.ToString();
                                            var q1 = from p in DB.tbl_SalesProductInfos
                                                     where p.SalesInvoiceNo == InvoiceNO && p.ProductID == ProductID
                                                     select p;
                                            if (q1.Count() > 0) //update previous product info
                                            {
                                                foreach (tbl_SalesProductInfo detail in q1)
                                                {
                                                    detail.SalesDate = dtpSaleDate.Value.Date;
                                                    detail.SalesPrice = float.Parse(dgSale.Rows[i].Cells[3].Value.ToString());
                                                    detail.Qty = int.Parse(dgSale.Rows[i].Cells[4].Value.ToString());
                                                    detail.TotalAmount = float.Parse(dgSale.Rows[i].Cells[5].Value.ToString());
                                                    detail.VatAmount = float.Parse(dgSale.Rows[i].Cells[6].Value.ToString());
                                                    detail.Discount = float.Parse(dgSale.Rows[i].Cells[7].Value.ToString());
                                                }
                                                DB.SubmitChanges();
                                            }
                                            else // insert  product info
                                            {
                                                tbl_SalesProductInfo detail = new tbl_SalesProductInfo();
                                                detail.SalesInvoiceNo = txtInvoiceNo.Text.Trim();
                                                detail.ProductID = dgSale.Rows[i].Cells[0].Value.ToString();
                                                detail.ProductCategoryID = Int64.Parse(dgSale.Rows[i].Cells[10].Value.ToString());
                                                detail.SalesDate = dtpSaleDate.Value.Date;
                                                detail.SalesPrice = float.Parse(dgSale.Rows[i].Cells[3].Value.ToString());
                                                detail.Qty = int.Parse(dgSale.Rows[i].Cells[4].Value.ToString());
                                                detail.TotalAmount = float.Parse(dgSale.Rows[i].Cells[5].Value.ToString());
                                                detail.VatAmount = float.Parse(dgSale.Rows[i].Cells[6].Value.ToString());
                                                detail.Discount = float.Parse(dgSale.Rows[i].Cells[7].Value.ToString());
                                                detail.PurchaseInvNo = dgSale.Rows[i].Cells[9].Value.ToString();

                                                DB.tbl_SalesProductInfos.InsertOnSubmit(detail);
                                                DB.SubmitChanges();
                                            }
                                            var q2 = from p in DB.tbl_StockDetails
                                                     where p.SalesInvoiceNo == InvoiceNO && p.ProductID == ProductID
                                                     select p;
                                            if (q2.Count() > 0) //update previous stock
                                            {
                                                foreach (tbl_StockDetail stock in q2)
                                                {
                                                    stock.CreateDate = dtpSaleDate.Value.Date;
                                                    stock.AddCost = 0;
                                                    stock.AddQty = 0;
                                                    stock.ShopID = GlobalVariable.ShopID;
                                                    stock.SalesInvoiceNo = txtInvoiceNo.Text.Trim();
                                                    stock.PurchaseInvoiceNo = dgSale.Rows[i].Cells[9].Value.ToString();
                                                    stock.SubQty = dgSale.Rows[i].Cells[4].Value.ToString() == "" ? 0 : int.Parse(dgSale.Rows[i].Cells[4].Value.ToString());
                                                    stock.SubCost = dgSale.Rows[i].Cells[5].Value.ToString() == "" ? 0 : float.Parse(dgSale.Rows[i].Cells[5].Value.ToString());
                                                }
                                                DB.SubmitChanges();
                                            }
                                            else
                                            {
                                                tbl_StockDetail stock = new tbl_StockDetail();
                                                stock.ProductID = dgSale.Rows[i].Cells[0].Value.ToString();
                                                stock.SupplierID = int.Parse(dgSale.Rows[i].Cells[11].Value.ToString());
                                                stock.CreateDate = dtpSaleDate.Value.Date;
                                                stock.AddCost = 0;
                                                stock.AddQty = 0;
                                                stock.ShopID = GlobalVariable.ShopID;
                                                stock.SalesInvoiceNo = txtInvoiceNo.Text.Trim();
                                                stock.PurchaseInvoiceNo = dgSale.Rows[i].Cells[9].Value.ToString();
                                                stock.SubQty = dgSale.Rows[i].Cells[4].Value.ToString() == "" ? 0 : int.Parse(dgSale.Rows[i].Cells[4].Value.ToString());
                                                stock.SubCost = dgSale.Rows[i].Cells[5].Value.ToString() == "" ? 0 : float.Parse(dgSale.Rows[i].Cells[5].Value.ToString());
                                                DB.tbl_StockDetails.InsertOnSubmit(stock);
                                                DB.SubmitChanges();
                                            }

                                            //update stock summary
                                            var summary = from p in DB.tbl_StockSummaries
                                                          where p.ProductID == ProductID && p.ShopID == GlobalVariable.ShopID
                                                          select p;
                                            foreach (tbl_StockSummary SS in summary)
                                            {
                                                SS.StockQty = SS.StockQty - (int.Parse(dgSale.Rows[i].Cells[4].Value.ToString()) - (dgSale.Rows[i].Cells[12].Value == null ? 0 : int.Parse(dgSale.Rows[i].Cells[12].Value.ToString())));
                                            }
                                            DB.SubmitChanges();
                                        }
                                    }

                                    //insert customer info
                                    if (txtMobileNO.Text != "")
                                    {
                                        var q3 = from p in DB.tbl_Customers
                                                 where p.MobileNo == txtMobileNO.Text.Trim()
                                                 select p;
                                        if (q3.Count() == 0)
                                        {
                                            tbl_Customer Customer = new tbl_Customer();
                                            Customer.CustomerName = txtCustomerName.Text.Trim();
                                            Customer.MobileNo = txtMobileNO.Text.Trim();
                                            DB.tbl_Customers.InsertOnSubmit(Customer);
                                            DB.SubmitChanges();
                                        }
                                    }
                                    
                                    //update ledger table
                                    var led = from p in DB.tbl_Ledgers
                                              where p.TransactionID == InvoiceNO
                                              select p;
                                    foreach (tbl_Ledger ledger in led)
                                    {
                                        ledger.InAmount = GetProfitAmount();
                                        ledger.TransactionDate = dtpSaleDate.Value;
                                    }
                                    DB.SubmitChanges();
                                    
                                    Trans.Complete();
                                    Chk = 1;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                    Chk = 0;
                                }
                            }
                            if (Chk > 0)
                            {
                                //MessageBox.Show("Saved Successfully.");
                                //PrintSaleReceipt();
                                //CrvSalesReceipt sale = new CrvSalesReceipt();
                                //sale.Show();
                                Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please check stock Quantity.");
                        }

                    }
                    else
                    {
                        if (cmbBookingID.Text == "")
                        {
                            MessageBox.Show("Please Select a Invoice No from Advance Booking.");
                            cmbBookingID.Focus();
                        }
                        else if (cmbBookingID.Text.Trim() != txtInvoiceNo.Text.Trim())
                        {
                            MessageBox.Show("Invoice Number not Match. Please Select a valid Invoice Number from Advance Booking.");
                            cmbBookingID.Focus();
                        }
                    }
                }

            }
            else
            {
                if (txtInvoiceNo.Text == "")
                {
                    MessageBox.Show("Please Enter Invoice Number.");
                    txtInvoiceNo.Focus();
                }
                else if (cmbCounterNo.Text == "")
                {
                    MessageBox.Show("Please Select Counter Number.");
                    cmbCounterNo.Focus();
                }
                else if (dgSale.Rows.Count <= 1)
                {
                    MessageBox.Show("Please Enter Product For Sale.");
                    txtProductID.Focus();
                }
                else if (cmbPaymentMode.Text == "")
                {
                    MessageBox.Show("Please Select Payment Mode.");
                    cmbPaymentMode.Focus();
                }
            }
        }
        private void AdvanceSale()
        {

        }
        

        private void LoadCounterNO()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var q = from p in DB.tbl_CounterNos
                    select p;
            if (q.Count() > 0)
            {
                cmbCounterNo.Items.Clear();
                foreach (tbl_CounterNo no in q)
                {
                    cmbCounterNo.Items.Add(no.CounterNo);
                }
            }
            else
            {
                cmbCounterNo.Items.Clear();
            }
        }
        private void LoadAllProductName()
        {
            try
            {
                //EasySaleDataContext DB = new EasySaleDataContext();

                //var query1 = from p in DB.tbl_Products from r in DB.tbl_DosagesDescriptions
                //             where p.DosagesID == r.DosagesID
                //             orderby p.ProductName ascending
                //             select new { name = p.ProductName + " " + r.DosagesDescription, id = p.ProductID };
                //if (query1.Count() > 0)
                {
                    cmbProductName.DisplayMember = "name";
                    cmbProductName.ValueMember = "id";
                    cmbProductName.DataSource = GlobalVariable.AllProductName;
                   // cmbProductName.DataSource = query1;
                    
                    cmbProductName.SelectedIndex = -1;
                    
                }
                
            }
            catch
            {
                
            }
        }
        private void LoadDiscountPercent()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_DiscountPercents
                        select p;
                if (q.Count() > 0)
                {
                    txtDiscountPercent.Text = q.Single().PercentAmount.ToString();
                }
                else
                {
                    txtDiscountPercent.Text = "0";
                }
            }
            catch
            { 
            
            }
        }
        private void frmSale_Load(object sender, EventArgs e)
        {
            txtSalesBy.Text = GlobalVariable.userID;
            createInvoiceNo();
            LoadCounterNO();
            LoadAllProductName();
            LoadAdvanceBookingInvoice();
            LoadDiscountPercent();
            cmbCounterNo.Text = GlobalVariable.CounterNo;            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void createInvoiceNo()
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
                var q = (from p in DB.tbl_SalesInvInfos
                         orderby p.SN ascending
                         where p.SalesInvoiceNo.StartsWith(FirstString)
                         select p.SalesInvoiceNo).ToList();
                if (q.Count() > 0)
                {
                    string invoiceNO = q.LastOrDefault().ToString();
                    string LastNo = invoiceNO.Substring(6);
                    txtInvoiceNo.Text = FirstString + (Convert.ToDouble(LastNo) + 1).ToString();
                }
                else
                {
                    txtInvoiceNo.Text = FirstString + "1";
                }
            }
            catch
            {
            }
        }

        private void btnNewInvoiceNO_Click(object sender, EventArgs e)
        {
            createInvoiceNo();
        }

        private void btnRowRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(dgSale.SelectedRows[0].Cells[4].Value.ToString()) == 1 || Convert.ToDouble(dgSale.SelectedRows[0].Cells[4].Value.ToString()) == -1)
                {
                    dgSale.Rows.RemoveAt(dgSale.SelectedRows[0].Cells[4].RowIndex);
                    CalculateSubTotal();
                    CalculateFinalTotal();
                }

                else //if (Convert.ToDouble(dgSale.SelectedRows[0].Cells[4].Value.ToString()) > 1)
                {
                    dgSale.SelectedRows[0].Cells[4].Value = Convert.ToDouble(dgSale.SelectedRows[0].Cells[4].Value.ToString()) - 1;
                    CalculateSubTotal();
                    CalculateFinalTotal();
                }

            }
            catch
            {
                MessageBox.Show("Please select a Rows or check Quantity.");
            }
        }

        private void txtProductRemove_TextChanged(object sender, EventArgs e)
        {
            string BarcodeText = txtProductRemove.Text.Trim();
            string ProductID = "";
            string InvoiceNo = "";

            //check Barcode label with invoce no or not
            if (BarcodeText.Contains(GlobalVariable.BarcodeCharacter))
            {
                //with barcode label   
                string[] Info = ClsBarcodeLabel.GetProductIDandInvoiceNoFromBarcode(BarcodeText);
                ProductID = Info[0];
                InvoiceNo = Info[1];
            }
            else
            {
                ProductID = BarcodeText;
            }
            int[] NumberInfo = CheckExistingProductIDInDgSale(ProductID);
            int Number = NumberInfo[0];
            int RowNO = NumberInfo[1];
            if (Number > 0)
            {
                try
                {
                    if (Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) == 1 || Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) == -1)
                    {
                        dgSale.Rows.RemoveAt(dgSale.Rows[RowNO].Cells[4].RowIndex);
                        CalculateSubTotal();
                    }

                    else //if (Convert.ToDouble(dgSale.SelectedRows[0].Cells[4].Value.ToString()) > 1)
                    {
                        dgSale.Rows[RowNO].Cells[4].Value = Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) - 1;
                        CalculateSubTotal();
                    }
                    txtProductRemove.Text = "";
                }
                catch
                {

                }
            }
        }

        private void txtProductID_MouseEnter(object sender, EventArgs e)
        {
            txtProductID.Text = "";
        }

        private void txtProductRemove_MouseEnter(object sender, EventArgs e)
        {
            txtProductRemove.Text = "";
        }

        private void txtDiscountManually_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalTotal();
        }

        private void txtReturnProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbl_PurchaseProductInfo singleInfo = new tbl_PurchaseProductInfo();
                string BarcodeText = txtReturnProduct.Text.Trim();
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
                    //GetSingleInfo(ProductID);                   
                    singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNo(ProductID, ClsRecentProductPrice.GetProductInfoByID(ProductID).InvoiceNo);
                }

                //txtAvailableQty.Text = ClsStockSummary.GetStockQuantityByProductID(ProductID).ToString();
                //get product Name and Category name
                ProductInfo = ClsProduct.GetProductNameAndCategoryNameByID(ProductID);
                ProductName = ProductInfo[0];
                CategoryName = ProductInfo[1];
                //check Existing ProductID for update Qty or new entry
                int[] NumberInfo = CheckExistingProductIDInDgSale(ProductID);
                int Number = NumberInfo[0];
                int RowNO = NumberInfo[1];
                if (Number <= 0)
                {
                    if (singleInfo != null)
                    {
                        double SalesPrice = 0;
                        try
                        {
                            SalesPrice = singleInfo.SalesPrice.Value;
                        }
                        catch
                        {

                        }
                        dgSale.Rows.Add(singleInfo.ProductID, CategoryName, ProductName, Math.Round(SalesPrice, 2), -1, Math.Round(SalesPrice, 2), singleInfo.VatAmount == null ? 0 : singleInfo.VatAmount, singleInfo.Discount == null ? 0 : singleInfo.Discount, singleInfo.UnitCost == null ? 0 : singleInfo.UnitCost, singleInfo.InvoiceNo, singleInfo.ProductCategoryID, singleInfo.SupplierID);
                    }
                    CalculateSubTotal();
                    CalculateFinalTotal();
                }
                else
                {
                    try
                    {
                        if (Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) == 1)
                        {
                            dgSale.Rows.RemoveAt(dgSale.Rows[RowNO].Cells[4].RowIndex);
                            CalculateSubTotal();
                            CalculateFinalTotal();
                        }

                        else //if (Convert.ToDouble(dgSale.SelectedRows[0].Cells[4].Value.ToString()) > 1)
                        {
                            dgSale.Rows[RowNO].Cells[4].Value = Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) - 1;
                            CalculateSubTotal();
                            CalculateFinalTotal();
                        }
                    }
                    catch
                    {

                    }
                }
                txtReturnProduct.Text = "";
            }
            catch
            {

            }
        }

        private void cmbSalesMan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LoadSaleManCommission();
        }



        private void lblAdvance_Click(object sender, EventArgs e)
        {

        }

        private void txtReturnProduct_MouseEnter(object sender, EventArgs e)
        {
            txtReturnProduct.Text = "";
        }

        private void cmbCounterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnQuantityPlus_Click(object sender, EventArgs e)
        {
            try
            {
                double stockQty = ClsStockSummary.GetStockQuantityByProductID(dgSale.SelectedRows[0].Cells[0].Value.ToString());
                if (stockQty > Convert.ToDouble(dgSale.SelectedRows[0].Cells[4].Value.ToString()) - Convert.ToDouble(dgSale.SelectedRows[0].Cells[12].Value))
                {
                    //MessageBox.Show("This Product is in the List. Please Change Quantity.");

                    if (Convert.ToDouble(dgSale.SelectedRows[0].Cells[4].Value.ToString()) == -1)
                    {
                        dgSale.Rows.RemoveAt(dgSale.SelectedRows[0].Cells[4].RowIndex);
                        CalculateSubTotal();
                        CalculateFinalTotal();
                    }
                    else
                    {
                        dgSale.SelectedRows[0].Cells[4].Value = Convert.ToDouble(dgSale.SelectedRows[0].Cells[4].Value.ToString()) + 1;
                        CalculateSubTotal();
                        CalculateFinalTotal();
                    }

                }
                else
                {
                    MessageBox.Show("Please select a Row or check available Quantity.");

                }
            }
            catch
            {
                MessageBox.Show("Please select a Row or check available Quantity.");
            }
        }

        private void txtDiscountCardNo_TextChanged(object sender, EventArgs e)
        {
            string[] NameAndMobile = ClsCustomer.GetCustomerNameAndMobileNoByCardID(txtDiscountCardNo.Text.Trim());
            if (NameAndMobile != null)
            {
                txtCustomerName.Text = NameAndMobile[0];
                txtMobileNO.Text = NameAndMobile[1];
            }
            else
            {
                txtMobileNO.Text = "";
                txtCustomerName.Text = "";
            }
            CalculateSubTotal();
            CalculateFinalTotal();
        }

        private void cmbBookingID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAdvanceBookingInfo();
        }

        private void cmbPaymentMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtMobileNO_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtMobileNO);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProductName.Text != "" && txtQty.Text != "")
            {
                try
                {
                    tbl_PurchaseProductInfo singleInfo = new tbl_PurchaseProductInfo();
                    //string BarcodeText = txtProductID.Text.Trim();
                    string BarcodeText = cmbProductName.SelectedValue.ToString();
                    int Qty = 0;
                    try
                    {
                        Qty = int.Parse(txtQty.Text.Trim());
                    }
                    catch
                    { 
                    
                    }
                    string ProductID = "";
                   // string InvoiceNoHidden = "";
                    string ProductName = "";
                    string CategoryName = "";
                    string[] ProductInfo = new string[2];
                    /*
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
                     * */
                    {
                        ProductID = BarcodeText;
                        singleInfo = ClsPurchase.GetPurchaseProductInfoByProductIdAndInvoiceNo(ProductID, ClsRecentProductPrice.GetProductInfoByID(ProductID).InvoiceNo);
                    }
                    //txtAvailableQty.Text = ClsStockSummary.GetStockQuantityByProductID(ProductID).ToString();
                    //get product Name and Category name
                    ProductInfo = ClsProduct.GetProductNameAndCategoryNameByID(ProductID);
                    ProductName = ProductInfo[0];
                    CategoryName = ProductInfo[1];
                    //check Existing ProductID for update Qty or new entry
                    int[] NumberInfo = CheckExistingProductIDInDgSale(ProductID);
                    int Number = NumberInfo[0];
                    int RowNO = NumberInfo[1];
                    
                    //calculate stock
                    double CurrentStock = 0;
                    CurrentStock = Convert.ToDouble(txtAvailableQty.Text.Trim());
                    
                    //For Return Product
                    if (cbReturnProduct.Checked==true)
                    {
                        if (Number <= 0)
                        {
                            //if (CurrentStock >= Qty)
                            {
                                if (singleInfo != null)
                                {
                                    double SalesPrice = 0;

                                    SalesPrice = singleInfo.SalesPrice.Value;// -(singleInfo.SalesPrice.Value * singleInfo.Discount.Value) / 100;

                                    dgSale.Rows.Add(singleInfo.ProductID, CategoryName, ProductName, Math.Round(SalesPrice, 2), -Qty, Math.Round(SalesPrice, 2), singleInfo.VatAmount == null ? 0 : singleInfo.VatAmount, singleInfo.Discount == null ? 0 : singleInfo.Discount, singleInfo.UnitCost == null ? 0 : singleInfo.UnitCost, singleInfo.InvoiceNo, singleInfo.ProductCategoryID, singleInfo.SupplierID);
                                }
                                CalculateSubTotal();
                                CalculateFinalTotal();
                            }
                           
                        }
                        else
                        {
                           // MessageBox.Show("This Product is already in the List.\n Please Update Qunatity.");
                            
                           // if (CurrentStock > Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()))
                            {
                                //MessageBox.Show("This Product is in the List. Please Change Quantity.");
                                if (Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) - Qty == 0)
                                {
                                    dgSale.Rows.RemoveAt(RowNO);
                                }
                                else
                                {
                                    dgSale.Rows[RowNO].Cells[4].Value = Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) - Qty;
                                    CalculateSubTotal();
                                    CalculateFinalTotal();
                                }
                            }
                            //else
                            //{
                            //    MessageBox.Show("Please Check Available Stock Quantity.");
                            //    txtAvailableQty.Focus();
                            //}
                        }
                    }
                    else
                    {
                        if (Number <= 0)
                        {
                            if (CurrentStock >= Qty)
                            {
                                if (singleInfo != null)
                                {
                                    double SalesPrice = 0;

                                    SalesPrice = singleInfo.SalesPrice.Value;// -(singleInfo.SalesPrice.Value * singleInfo.Discount.Value) / 100;

                                    dgSale.Rows.Add(singleInfo.ProductID, CategoryName, ProductName, Math.Round(SalesPrice, 2), Qty, Math.Round(SalesPrice, 2), singleInfo.VatAmount == null ? 0 : singleInfo.VatAmount, singleInfo.Discount == null ? 0 : singleInfo.Discount, singleInfo.UnitCost == null ? 0 : singleInfo.UnitCost, singleInfo.InvoiceNo, singleInfo.ProductCategoryID, singleInfo.SupplierID);
                                }
                                CalculateSubTotal();
                                CalculateFinalTotal();
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Product is already in the List.\n Please Update Qunatity.");
                            /*
                            if (CurrentStock > Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()))
                            {
                                //MessageBox.Show("This Product is in the List. Please Change Quantity.");
                                if (Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) == -1)
                                {
                                    dgSale.Rows.RemoveAt(dgSale.Rows[RowNO].Cells[4].RowIndex);
                                    CalculateSubTotal();
                                    CalculateFinalTotal();
                                }
                                else
                                {
                                    dgSale.Rows[RowNO].Cells[4].Value = Convert.ToDouble(dgSale.Rows[RowNO].Cells[4].Value.ToString()) + 1;
                                    CalculateSubTotal();
                                    CalculateFinalTotal();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Check Available Stock Quantity.");
                                txtAvailableQty.Focus();
                            }*/
                        }
                    }
                    txtProductID.Text = "";
                    txtQty.Text = "";
                    cmbProductName.SelectedIndex = -1;
                    cmbProductName.Focus();
                }
                catch
                {
                    MessageBox.Show("Please Check Available Quantity");
                }
            }
            else
            {
                if (cmbProductName.Text == "")
                {
                    MessageBox.Show("Please Enter Product Name.");
                    cmbProductName.Focus();
                }
                else
                {
                    MessageBox.Show("Please Enter Quantity");
                    txtQty.Focus();
                }
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForInt(txtQty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure To Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                { 
                        dgSale.Rows.RemoveAt(dgSale.SelectedRows[0].Cells[4].RowIndex);
                        CalculateSubTotal();
                        CalculateFinalTotal();
                }
                catch
                {
                    MessageBox.Show("Please select a Rows To Delete.");
                }
            }
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtAvailableQty.Text = ClsStockSummary.GetStockQuantityByProductID(cmbProductName.SelectedValue.ToString()).ToString();
            }
            catch
            { 
            
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txtDiscountPercent_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtDiscountPercent);
        }

        private void txtDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalTotal();
        }

        private void frmSale_KeyDown(object sender, KeyEventArgs e)
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

        private void lblAdTk_Click(object sender, EventArgs e)
        {

        }

        private void frmSale_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are You Sure To Exit?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmSale sale = new frmSale();
                    sale.Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

    }
}
