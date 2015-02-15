using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Configuration;
using System.ComponentModel;

namespace digitalPharma
{
    static public class GlobalVariable
    {
        public static string userID;
        public static string SuperAdmin = "arrowsoft";
        public static int ShopID = 1;
        public static string BarcodeCharacter = "$";
        public static string ShopName = "Arrowsoft";
        public static Int32 ProductSaleAccountNo = 2001;
        public static string ProductSaleAccountName = "Product Sale";
        public static Int32 CashInHandAccountNo = 1001;
        public static string CashInHandAccountName = "Cash In Hand";
        public static string SupplierSubHeadName = "Suppliers";
        public static string CounterNo = "COUNTER 1";
        public static string Address1 = "";
        public static string Address2 = "";
        public static string Phone = "";
        public static string Slogan = "";
        public static string BookingID;
        public static string ReportID;
        public static string SupplierName;
        public static string ContactNo;
        public static string InvoiceNo;
        public static string userType;
        public static string SaleReport;
        public static IQueryable AllProductName;
        public static DateTime FromDate;
        public static DateTime ToDate;
        public static Int64 CategoryID = 0;
        public static Int64 SN = 0;
        public static Int32 RowNo = 0;
        public static int SupplierID = 0;
        public static int Days = 0;
        public static DataTable DataTable;
        public static double Paid = 0;
        public static double Vat = 0;
        public static string con = ConfigurationManager.ConnectionStrings["PharmacyeDBConnectionString"].ConnectionString;
        public static string BarcodePrintNeededForOldProductID = ConfigurationManager.AppSettings["BarcodePrintNeededForOldProductID"];



    }
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string reg_path = @"Software\Arrowsoft\Protection";
            Secure scr = new Secure();


            try
            {
            EasySaleDataContext DB = new EasySaleDataContext();
            IQueryable q = from p in DB.tbl_Products
                           from r in DB.tbl_DosagesDescriptions
                           where p.DosagesID == r.DosagesID
                           orderby p.ProductName ascending
                           select new { name = p.ProductName + " " + r.DosagesDescription, id = p.ProductID };
            GlobalVariable.AllProductName = q;
            }
            catch
            {

            }                             
            bool logic = scr.Algorithm("6A7FEBF6A50E3F1FBFF", reg_path);
            //bool logic = scr.Algorithm("F41FEBFC4E8FD27FBFF", reg_path);//super market
            //bool logic = scr.Algorithm("F34FEBF0C4A984DFBFF", reg_path);

            //Application.Run(new frmTransferData());
            if (logic == true)
            //new SplashScreenApp().Run(args);

            Application.Run(new frmLogin());
            //Application.Run(new frmTransferData());
        }


        public class SplashScreenApp : WindowsFormsApplicationBase
        {
            protected override void OnCreateSplashScreen()
            {
                this.SplashScreen = new SplashForm();
                this.SplashScreen.ShowInTaskbar = false;
                this.SplashScreen.Cursor = Cursors.AppStarting;
            }

            protected override void OnCreateMainForm()
            {
                //Perform any tasks you want before your application starts

                //FOR TESTING PURPOSES ONLY (remove once you've added your code)
                System.Threading.Thread.Sleep(1000);

                //Set the main form to a new instance of your form
                //(this will automatically close the splash screen)
                this.MainForm = new frmLogin();
            }
        }
    }
}
