using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.Reports;
using digitalPharma.DAO;

namespace digitalPharma
{
    public partial class CrvSales : Form
    {
        public CrvSales()
        {
            InitializeComponent();
        }
        string ReportID = "", InvoiceNo="";
        public CrvSales(string reportID,string invoiceNo)
        {
            InitializeComponent();
            ReportID = reportID;
            InvoiceNo = invoiceNo;
        }
        private void CrvSalesSingle_Load(object sender, EventArgs e)
        {
            if (ReportID == "SalesSingle")
            {
                EasySaleDataContext DB = new EasySaleDataContext();


                var report = (from p in DB.tbl_SalesInvInfos
                              where p.SalesInvoiceNo == InvoiceNo && p.AdvanceStatus == 0
                              select new { DueAmount = p.DueAmount == null ? 0 : p.DueAmount.Value, Discount = p.Discount == null ? 0 : p.Discount.Value, CartTotal = p.CartTotal == null ? 0 : p.CartTotal.Value, SalesDate = p.SalesDate == null ? DateTime.Now : p.SalesDate.Value, p.SalesInvoiceNo, p.CounterNo, p.SalesBy, p.ShopID.Value, p.PaymentMode, GrandTotal = p.GrandTotal == null ? 0 : p.GrandTotal.Value, Vat = p.Vat == null ? 0 : p.Vat.Value }).ToList();

                CrSalesSingle Sale = new CrSalesSingle();
                Sale.Load(@"CrSalesSingle");
                Sale.SetDataSource(report);
                Sale.SetParameterValue("ShopName", GlobalVariable.ShopName);
                crystalReportViewer1.ReportSource = Sale;
                InvoiceNo = "";
                ReportID = "";
            }
            else if (ReportID == "DateWise")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var a = from p in DB.tbl_Ledgers
                        where p.TransactionDate.Value.Date >= GlobalVariable.FromDate.Date && p.TransactionDate.Value.Date <= GlobalVariable.ToDate.Date && p.AccountNo == GlobalVariable.CashInHandAccountNo
                        select p.InAmount.Value;
                var b = from p in DB.tbl_Ledgers
                        where p.TransactionDate.Value.Date >= GlobalVariable.FromDate.Date && p.TransactionDate.Value.Date <= GlobalVariable.ToDate.Date && p.AccountNo == GlobalVariable.CashInHandAccountNo
                        select p.OutAmount.Value;
                double CashIn = 0;
                double CashOut = 0;
                try
                {
                    CashIn = Convert.ToDouble(a.Sum());
                }
                catch
                {

                }
                try
                {
                    CashOut = Convert.ToDouble(b.Sum());
                }
                catch
                {

                }
                double CashInHand = CashIn - CashOut;
                if (GlobalVariable.userType == "Admin")
                {
                    var c1 = (from p in DB.tbl_SalesInvInfos
                              where p.AdvanceStatus == 0 && p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date && p.ShopID == GlobalVariable.ShopID
                              orderby p.SalesDate ascending
                              select new
                              {
                                  p.CounterNo,
                                  Discount = p.Discount.Value,
                                  DueAmount = p.DueAmount.Value,
                                  p.PaymentMode,
                                  p.SalesInvoiceNo,
                                  p.SalesBy,
                                  SalesDate = p.SalesDate.Value,
                                  CartTotal = p.CartTotal.Value,
                                  GrandTotal = p.GrandTotal.Value,
                                  Vat = p.Vat.Value,
                                  DiscountCardAmount = p.DiscountCardAmount.Value,
                                  p.DiscountCardNo,
                                  Profit = p.Profit.Value
                              }).ToList();
                    CrSalesReportDateWise rep = new CrSalesReportDateWise();
                    rep.SetDataSource(c1);
                    rep.SetParameterValue("FromDate", GlobalVariable.FromDate);
                    rep.SetParameterValue("ToDate", GlobalVariable.ToDate);
                    rep.SetParameterValue("ShopName", GlobalVariable.ShopName);
                    rep.SetParameterValue("CashInHand", CashInHand);
                    crystalReportViewer1.ReportSource = rep;                    
                }
                else
                {
                    var c1 = (from p in DB.tbl_SalesInvInfos
                              where p.AdvanceStatus == 0 && p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date && p.ShopID == GlobalVariable.ShopID
                              orderby p.SalesDate ascending
                              select new
                              {
                                  p.CounterNo,
                                  Discount = p.Discount.Value,
                                  DueAmount = p.DueAmount.Value,
                                  p.PaymentMode,
                                  p.SalesInvoiceNo,
                                  p.SalesBy,
                                  SalesDate = p.SalesDate.Value,
                                  CartTotal = p.CartTotal.Value,
                                  GrandTotal = p.GrandTotal.Value,
                                  Vat = p.Vat.Value,
                                  DiscountCardAmount = p.DiscountCardAmount.Value,
                                  p.DiscountCardNo,
                              }).ToList();
                    CrSalesReportDateWise rep = new CrSalesReportDateWise();
                    rep.SetDataSource(c1);
                    rep.SetParameterValue("FromDate", GlobalVariable.FromDate);
                    rep.SetParameterValue("ToDate", GlobalVariable.ToDate);
                    rep.SetParameterValue("ShopName", GlobalVariable.ShopName);
                    rep.SetParameterValue("CashInHand", CashInHand);
                    crystalReportViewer1.ReportSource = rep;
                }
                ReportID = "";
            }
            else if (ReportID == "Popular")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                CrMostSellingProductList purchase = new CrMostSellingProductList();

                //delete tbl_TempMostSellingProducts

                var q = from p in DB.tbl_TempMostSellingProducts
                        select p;

                foreach (tbl_TempMostSellingProduct sell in q)
                {
                    DB.tbl_TempMostSellingProducts.DeleteOnSubmit(sell);
                }
                try
                {
                    DB.SubmitChanges();
                }
                catch
                {

                }


                int SN = 0;
                var r = (from p in DB.tbl_SalesProductInfos
                         where p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate.Value.Date <= GlobalVariable.ToDate.Date
                         select p.ProductID).Distinct();

                List<tbl_TempMostSellingProduct> AllProduct = new List<tbl_TempMostSellingProduct>();
                foreach (var ProductID in r)
                {
                    tbl_TempMostSellingProduct entry = new tbl_TempMostSellingProduct();
                    try
                    {
                        var PCategory = (from p in DB.tbl_Products
                                         where p.ProductID == ProductID
                                         select p).Single();

                        var qty = from p in DB.tbl_SalesProductInfos
                                  where p.ProductID == ProductID && p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate.Value.Date <= GlobalVariable.ToDate.Date
                                  select p.Qty;

                        Int16 TotalQty = 0;
                        try
                        {
                            TotalQty = Convert.ToInt16(qty.Sum());
                        }
                        catch
                        {

                        }
                        try
                        {
                            entry.ProductCategory = ClsProductCategory.GetProductCategorySingleInfo(Int64.Parse(PCategory.CategoryID.ToString())).CategoryName;
                        }
                        catch
                        {
                            entry.ProductCategory = "";
                        }
                        entry.ProductName = PCategory.ProductName + " " + ClsDosageDescription.GetDosagesDescriptionSingleInfo(int.Parse(PCategory.DosagesID.ToString())).DosagesDescription;
                        entry.ProductID = ProductID;
                        entry.TotalSaleQty = TotalQty;
                        SN += 1;
                        entry.SN = SN;
                        AllProduct.Add(entry);

                    }
                    catch
                    {

                    }
                }

                DB.tbl_TempMostSellingProducts.InsertAllOnSubmit(AllProduct);
                DB.SubmitChanges();

                var report = (from p in DB.tbl_TempMostSellingProducts
                              orderby p.TotalSaleQty descending
                              select new {p.ProductID, p.ProductCategory, p.ProductName, TotalSaleQty = p.TotalSaleQty == null ? 0 : p.TotalSaleQty.Value }).ToList();

                purchase.SetDataSource(report);
                purchase.SetParameterValue("From", GlobalVariable.FromDate);
                purchase.SetParameterValue("To", GlobalVariable.ToDate);
                purchase.SetParameterValue("ShopName", GlobalVariable.ShopName);

                crystalReportViewer1.ReportSource = purchase;
                GlobalVariable.FromDate = DateTime.Now;
                GlobalVariable.ToDate = DateTime.Now;
                ReportID = "";
            }
        }
    }
}
