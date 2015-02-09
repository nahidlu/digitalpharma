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
    public partial class CrvStock : Form
    {
        public CrvStock()
        {
            InitializeComponent();
        }
        string ReportID = "", CategoryName = "";
        int SupplierID = 0;
        Int64 ProductCategoryID = 0;
        public CrvStock(string ReportId, int SupplierId, Int64 CategoryID, string Categoryname)
        {
            InitializeComponent();
            ReportID = ReportId;
            SupplierID = SupplierId;
            ProductCategoryID = CategoryID;
            CategoryName = Categoryname;
        }
        private void CrvStock_Load(object sender, EventArgs e)
        {
            if (ReportID == "SupplierWise")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                try
                {
                string ContactNo = "";
                ContactNo = ClsSupplier.GetSupplierSingleInfo(SupplierID).ContactNo;
                if (ContactNo == null)
                {
                    ContactNo = "";
                }
                    var q = (from p in DB.tbl_StockSummaries
                             from r in DB.tbl_Products
                             where p.ProductID == r.ProductID && p.SupplierID == SupplierID && p.ShopID == GlobalVariable.ShopID
                             orderby r.ProductName ascending
                             select new
                             {
                                 p.ProductID,
                                 StockQty = p.StockQty.Value
                             }).ToList();
                    if (q.Count() > 0)
                    {
                        CrStockReportSupplierWise stock = new CrStockReportSupplierWise();
                        stock.SetDataSource(q);
                        stock.SetParameterValue("ShopName", GlobalVariable.ShopName);
                        stock.SetParameterValue("SupplierName", GlobalVariable.SupplierName);
                        stock.SetParameterValue("ContactNo", ContactNo);
                        crystalReportViewer1.ReportSource = stock;

                        ReportID = "";
                        SupplierID = 0;
                    }
                    else
                    {
                        MessageBox.Show("Report Not available For This Supplier. ");
                    }
                }
                catch
                {

                }
            }
            else if (ReportID == "ProductCategory")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                try
                {
                    var q = (from p in DB.tbl_StockSummaries
                             from r in DB.tbl_Products
                             where p.ProductID == r.ProductID && p.CategoryID == ProductCategoryID && p.ShopID == GlobalVariable.ShopID
                             orderby r.ProductName ascending
                             select new
                             {
                                 p.ProductID,
                                 StockQty = p.StockQty.Value
                             }).ToList();
                    if (q.Count() > 0)
                    {
                        CrStockReportProductCategoryWise stock = new CrStockReportProductCategoryWise();
                        stock.SetDataSource(q);
                        stock.SetParameterValue("ShopName", GlobalVariable.ShopName);
                        stock.SetParameterValue("ProductCategory", CategoryName);
                        crystalReportViewer1.ReportSource = stock;

                        ReportID = "";
                        ProductCategoryID = 0;
                    }
                    else
                    {
                        MessageBox.Show("Report Not available For This Category. ");
                    }
                }
                catch
                {

                }
            }
            else if (ReportID == "Summary")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                //try
                //{
                    var q = (from p in DB.tbl_StockSummaries
                             from r in DB.tbl_Products 
                             where p.ProductID == r.ProductID && p.ShopID == GlobalVariable.ShopID  
                             orderby r.ProductName  ascending
                             //select r);

                             select new
                             {
                                     r.ProductID,
                                 StockQty = p.StockQty.Value,
                                 r.ProductName

                             }).ToList();
                    

                    CrStockSummaryReport stock = new CrStockSummaryReport();
                    stock.SetDataSource(q);
                    stock.SetParameterValue("ShopName", GlobalVariable.ShopName);
                    crystalReportViewer1.ReportSource = stock;

                    ReportID = ""; 
                    SupplierID = 0;
                //}
                //catch
                //{

                //}
            }
            else if (GlobalVariable.ReportID == "Minimum")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                try
                {
                    var q = (from p in DB.tbl_TempStockReports
                             orderby p.ProductName ascending
                             select new
                             {
                                 AdvanceQty = p.AdvanceQty == null ? 0 : p.AdvanceQty.Value,
                                 AvailableQty = p.AvailableQty == null ? 0 : p.AvailableQty.Value,
                                 PurchaseQty = p.PurchaseQty == null ? 0 : p.PurchaseQty.Value,
                                 SaleQty = p.SaleQty == null ? 0 : p.SaleQty.Value,
                                 SalesPrice = p.SalesPrice == null ? 0 : p.SalesPrice.Value,
                                 TotalAvailablePrice = p.TotalAvailablePrice == null ? 0 : p.TotalAvailablePrice.Value,
                                 TotalPurchasePrice = p.TotalPurchasePrice == null ? 0 : p.TotalPurchasePrice.Value,
                                 TotalSalePrice = p.TotalSalePrice == null ? 0 : p.TotalSalePrice.Value,
                                 UnitPrice = p.UnitPrice == null ? 0 : p.UnitPrice.Value,
                                 p.ProductGroup,
                                 p.ProductID,
                                 p.ProductName
                             }).ToList();

                    //CrMinimumStockQty stock = new CrMinimumStockQty();
                    //stock.SetDataSource(q);
                    //crystalReportViewer1.ReportSource = stock;

                    GlobalVariable.ReportID = "";
                }
                catch
                {

                }
            }
        }
    }
}
