using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace digitalPharma
{
    public partial class CrvSalesReceipt : Form
    {
        string InvoiceNo = "";
        public CrvSalesReceipt()
        {
            InitializeComponent();
        }
        public CrvSalesReceipt(string invoice)
        {
            InitializeComponent();
            InvoiceNo = invoice;
        }
        private void CrvSalesSingle_Load(object sender, EventArgs e)
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var report = (from p in DB.tbl_SalesInvInfos
                          where p.SalesInvoiceNo == InvoiceNo 
                          select new { DueAmount = p.DueAmount.Value, Discount = p.Discount.Value, CartTotal = p.CartTotal.Value, SalesDate = p.SalesDate.Value, p.SalesInvoiceNo, p.CounterNo, p.SalesBy, p.ShopID.Value, GrandTotal = p.GrandTotal.Value, Vat = p.Vat.Value }).ToList();

            CrSalesReceipt Sale = new CrSalesReceipt();
            Sale.Load(@"CrSalesReceipt");
            Sale.SetDataSource(report);
            Sale.SetParameterValue("ShopName", GlobalVariable.ShopName);
            Sale.SetParameterValue("Address1", GlobalVariable.Address1);
            Sale.SetParameterValue("Address2", GlobalVariable.Address2);
            Sale.SetParameterValue("Phone", GlobalVariable.Phone);
            Sale.SetParameterValue("Slogan", GlobalVariable.Slogan);
            crystalReportViewer1.ReportSource = Sale;
             PrinterSettings getprinterName = new PrinterSettings();
             Sale.PrintOptions.PrinterName = getprinterName.PrinterName;
             Sale.PrintToPrinter(1, true, 1, 1);

           /* ReportDocument rdoc = new ReportDocument();
            //rdoc.Load(Application.StartupPath + "\\" + @"Reports\CrSalesReceipt.rpt");
            //rdoc.Load(@"CrSalesReceipt");
            rdoc.SetDataSource(report);
            crystalReportViewer1.ReportSource = rdoc;

            PrinterSettings getprinterName = new PrinterSettings();
            rdoc.PrintOptions.PrinterName = getprinterName.PrinterName;
            rdoc.PrintToPrinter(1, true, 1, 1);*/

            InvoiceNo = "";
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
