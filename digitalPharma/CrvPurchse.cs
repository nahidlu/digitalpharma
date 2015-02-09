using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.Reports;

namespace digitalPharma
{
    public partial class CrvPurchse : Form
    {
        public CrvPurchse()
        {
            InitializeComponent();
        }
        string ReportID = "";
        public CrvPurchse(string Reportid)
        {
            InitializeComponent();
            ReportID = Reportid;
        }
        private void CrvPurchseSingle_Load(object sender, EventArgs e)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            if (ReportID == "PurchaseSingle")
            {
                var report = (from p in DB.tbl_PurchaseInvInfos
                              where p.InvoiceNo == GlobalVariable.InvoiceNo
                              select new { Discount = p.Discount.Value, GrandTotal = p.InvTotal.Value, InvoiceDate = p.InvoiceDate.Value, ReceivedDate = p.ReceivedDate.Value, p.InvoiceNo, p.SupplierID.Value, CarryingCost = p.CarryingCost.Value, SubTotal = p.SubTotal.Value, TotalVat = p.TotalVat.Value, CurrencyExRate = p.CurrencyExRate.Value, InvTotalInRupee = p.InvTotalInRupee.Value, LC = p.LC.Value }).ToList();

                CrPurchaseSingle purchase = new CrPurchaseSingle();
                purchase.Load(@"CrPurchaseSingle");
                purchase.SetDataSource(report);
                purchase.SetParameterValue("ShopName", GlobalVariable.ShopName);
                crystalReportViewer1.ReportSource = purchase;

                GlobalVariable.InvoiceNo = "";
                ReportID = "";
            }
            else if(ReportID == "PurchaseDateWise")
            {
            var report = (from p in DB.View_SupplierAndPurchaseInvInfos
                          where p.ReceivedDate.Value.Date >= GlobalVariable.FromDate.Date && p.ReceivedDate.Value.Date <= GlobalVariable.ToDate.Date && p.ShopID==GlobalVariable.ShopID
                          select new { Discount = p.Discount.Value, InvTotal = p.InvTotal.Value, InvoiceDate = p.InvoiceDate.Value, ReceivedDate = p.ReceivedDate.Value, p.InvoiceNo, p.SupplierID.Value, CarryingCost = p.CarryingCost.Value, SubTotal = p.SubTotal.Value, TotalVat = p.TotalVat.Value, CurrencyExRate = p.CurrencyExRate.Value, InvTotalInRupee = p.InvTotalInRupee.Value, LC = p.LC.Value, p.SupplierName }).ToList();

            CrPurchaseDateWise purchase = new CrPurchaseDateWise();
            purchase.Load(@"CrPurchaseDateWise");
            purchase.SetDataSource(report);
            purchase.SetParameterValue("ShopName", GlobalVariable.ShopName);
            purchase.SetParameterValue("From", GlobalVariable.FromDate);
            purchase.SetParameterValue("To", GlobalVariable.ToDate);
            crystalReportViewer1.ReportSource = purchase;

            GlobalVariable.FromDate = DateTime.Now;
            GlobalVariable.ToDate = DateTime.Now;
            ReportID = "";
            }
            else if (ReportID == "Expired")
            {
               // MessageBox.Show(Convert.ToDateTime(GlobalVariable.FromDate.AddDays(GlobalVariable.Days)).ToString());
                
                var report = (from p in DB.View_PurchaseProductAndProductAndSupplierAndCategories
                              where p.ExpiredDate.Value.Date == Convert.ToDateTime(GlobalVariable.FromDate.AddDays(GlobalVariable.Days)) && p.ShopID == GlobalVariable.ShopID
                              orderby p.ProductName ascending
                              select new {p.ProductName,p.CategoryName,p.SupplierName, ExpiredDate=p.ExpiredDate.Value, p.BatchNo }).ToList();
                if (report.Count() > 0)
                {
                    CrExpiredProductList purchase = new CrExpiredProductList();
                    purchase.Load(@"CrExpiredProductList");
                    purchase.SetDataSource(report);
                    purchase.SetParameterValue("ShopName", GlobalVariable.ShopName);
                    purchase.SetParameterValue("FromDate", GlobalVariable.FromDate);
                    purchase.SetParameterValue("Days", GlobalVariable.Days);
                    crystalReportViewer1.ReportSource = purchase;

                    GlobalVariable.FromDate = DateTime.Now;
                    GlobalVariable.Days = 0;
                    ReportID = "";
                }
                else
                {
                    MessageBox.Show("No Expired Product.");
                }
                
            }
        }
    }
}
