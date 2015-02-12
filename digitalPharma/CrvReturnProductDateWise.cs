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
    public partial class CrvReturnProductDateWise : Form
    {
        public CrvReturnProductDateWise()
        {
            InitializeComponent();
        }

        private void CrvReturnProductDateWise_Load(object sender, EventArgs e)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            CrReturnProductDateWise purchase = new CrReturnProductDateWise();

            var report = (from p in DB.tbl_ProductReturns
                          where p.Date.Value.Date >= GlobalVariable.FromDate.Date && p.Date.Value.Date <= GlobalVariable.ToDate.Date && p.ShopID == GlobalVariable.ShopID
                          select new { SupplierID = p.SupplierID.Value }).ToList(); // , Date = p.Date.Value == null ? DateTime.Now : p.Date.Value, p.ProductID, ReturnQty = p.ReturnQty == null ? 0 : p.ReturnQty.Value }).ToList();
                       
            //var report = (from p in DB.tbl_ProductReturns
            //              where p.Date.Value.Date >= GlobalVariable.FromDate.Date && p.Date.Value.Date <= GlobalVariable.ToDate.Date && p.ShopName == GlobalVariable.Shop
            //              select new {  p.SupplierID}).Distinct(); //Date = p.Date.Value == null ? DateTime.Now : p.Date.Value, p.ProductID, ReturnQty = p.ReturnQty == null ? 0 : p.ReturnQty.Value }).ToList();
            //              //select p).ToList();
            //purchase.SetDataSource(report);
            //if (report.Count() != 0)
            //{
            //     var sup = from p in DB.tbl_ProductReturns
            //              where p.Date.Value.Date >= GlobalVariable.FromDate.Date && p.Date.Value.Date <= GlobalVariable.ToDate.Date
            //              select p.SupplierID;
                       
            //    foreach (string ret in sup.Distinct())
            //    {
            //        var query = from p in DB.tbl_ProductReturns
            //                    where p.SupplierID == ret
            //                    select p;
            //        if (query.Count() != 0)
            //        {                        
            //            var report1 = (from p in DB.tbl_ProductReturns
            //                           where p.Date.Value.Date >= GlobalVariable.FromDate.Date && p.Date.Value.Date <= GlobalVariable.ToDate.Date
            //                           select new { p.SupplierID, Date = p.Date.Value == null ? DateTime.Now : p.Date.Value, p.ProductID, ReturnQty = p.ReturnQty == null ? 0 : p.ReturnQty.Value }).ToList();
            //            // select new { p.SupplierID }).Distinct().ToList();
                        
            //            purchase.Subreports[0].SetDataSource(report1);
            //        }
            //    }
            //}
            purchase.Subreports[0].SetDataSource(report);
            purchase.SetParameterValue("From", GlobalVariable.FromDate);
            purchase.SetParameterValue("To", GlobalVariable.ToDate);
           
            crystalReportViewer1.ReportSource = purchase;
           
            

            GlobalVariable.FromDate = DateTime.Now;
            GlobalVariable.ToDate = DateTime.Now;
        }
    }
}
