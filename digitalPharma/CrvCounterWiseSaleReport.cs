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
    public partial class CrvCounterWiseSaleReport : Form
    {
        public CrvCounterWiseSaleReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void CrvCounterWiseSaleReport_Load(object sender, EventArgs e)
        {
            if (GlobalVariable.SaleReport == "Counter Wise")
            {
            
             EasySaleDataContext DB = new EasySaleDataContext();
                var c1 = (from p in DB.tbl_SalesInvInfos
                          where p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date && p.ShopID == GlobalVariable.ShopID && p.CounterNo == "COUNTER 1"
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
                             Vat = p.Vat.Value
                         }).ToList();

            var c2 = (from p in DB.tbl_SalesInvInfos
                      where p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date && p.ShopID == GlobalVariable.ShopID && p.CounterNo == "COUNTER 2"
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
                             Vat = p.Vat.Value
                         }).ToList();

             var c3 = (from p in DB.tbl_SalesInvInfos
                       where p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date && p.ShopID == GlobalVariable.ShopID && p.CounterNo == "COUNTER 3"
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
                             Vat = p.Vat.Value
                         }).ToList();

                

                 var a1 = from p in DB.tbl_SalesInvInfos
                            where p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date
                            && (p.CounterNo == "COUNTER 1" || p.CounterNo == "COUNTER 2" || p.CounterNo == "COUNTER 3")
                            select  p.CartTotal; 

                 double SubTotal = Convert.ToDouble(a1.Sum());

                 var a2 = from p in DB.tbl_SalesInvInfos
                          where p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date
                          && (p.CounterNo == "COUNTER 1" || p.CounterNo == "COUNTER 2" || p.CounterNo == "COUNTER 3")
                          select p.Vat; 

                 double Vat = Convert.ToDouble(a2.Sum());

                 

                 var a5 = from p in DB.tbl_SalesInvInfos
                          where p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date
                          && (p.CounterNo == "COUNTER 1" || p.CounterNo == "COUNTER 2" || p.CounterNo == "COUNTER 3")
                          select p.DueAmount; 

                 double Due = Convert.ToDouble(a5.Sum());

                 var a6 = from p in DB.tbl_SalesInvInfos
                          where p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date
                          && (p.CounterNo == "COUNTER 1" || p.CounterNo == "COUNTER 2" || p.CounterNo == "COUNTER 3")
                          select p.Discount;

                 double Discount = Convert.ToDouble(a6.Sum());

                var a7 = from p in DB.tbl_SalesInvInfos
                          where p.SalesDate.Value.Date >= GlobalVariable.FromDate.Date && p.SalesDate <= GlobalVariable.ToDate.Date
                          && (p.CounterNo == "COUNTER 1" || p.CounterNo == "COUNTER 2" || p.CounterNo == "COUNTER 3")
                          select p.GrandTotal;

                 double Total = Convert.ToDouble(a7.Sum());

                CrSalesReportCounterWise rep = new CrSalesReportCounterWise();
                rep.Subreports[0].SetDataSource(c1);
                rep.Subreports[1].SetDataSource(c2);
                rep.Subreports[2].SetDataSource(c3);
                rep.SetParameterValue("FromDate", GlobalVariable.FromDate);
                rep.SetParameterValue("ToDate", GlobalVariable.ToDate);
                rep.SetParameterValue("CounterNo","COUNTER 1", "CrSubSalesReportCounterWise1.rpt" );
                rep.SetParameterValue("CounterNo","COUNTER 2", "CrSubSalesReportCounterWise2.rpt");
                rep.SetParameterValue("CounterNo", "COUNTER 3", "CrSubSalesReportCounterWise3.rpt");
                rep.SetParameterValue("SubTotal", SubTotal);
                rep.SetParameterValue("Vat", Vat);
                rep.SetParameterValue("Due", Due);
                rep.SetParameterValue("Discount", Discount);
                rep.SetParameterValue("Total", Total);
                rep.SetParameterValue("ShopName", GlobalVariable.ShopName);
                crystalReportViewer1.ReportSource = rep;

                
                GlobalVariable.SaleReport = "";
                GlobalVariable.FromDate = DateTime.Now;
                GlobalVariable.ToDate = DateTime.Now;

               
            }
            
        }
    }
}
