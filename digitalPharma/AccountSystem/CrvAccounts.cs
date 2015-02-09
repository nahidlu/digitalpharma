using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.AccountSystem.Reports;

namespace digitalPharma
{
    public partial class CrvAccounts : Form
    {
        string AccountName = "", ReportID= "";
        int AccountNo = 0;
        public CrvAccounts()
        {
            InitializeComponent();
        }
        public CrvAccounts(string ReportId, string Name, int AccNO)
        {
            InitializeComponent();
            AccountName = Name;
            AccountNo = AccNO;
            ReportID = ReportId; 
        }

        private void CrvAccounts_Load(object sender, EventArgs e)
        {
            if (ReportID == "HeadWiseExp")
            {
                try
                {
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var report = (from p in DB.tbl_Ledgers
                                  where p.AccountNo == AccountNo && p.TransactionDate.Value.Date >= GlobalVariable.FromDate.Date && p.TransactionDate.Value.Date <= GlobalVariable.ToDate.Date
                                  select new { p.VoucharNo, OutAmount = p.OutAmount.Value, p.Particular, TransactionDate = p.TransactionDate.Value }).ToList();


                    CrExpenseReportAccountWise ledger = new CrExpenseReportAccountWise();
                    ledger.Load(@"CrExpenseReportAccountWise");
                    ledger.SetDataSource(report);
                    ledger.SetParameterValue("FromDate", GlobalVariable.FromDate);
                    ledger.SetParameterValue("ToDate", GlobalVariable.ToDate);
                    ledger.SetParameterValue("ShopName", GlobalVariable.ShopName);
                    ledger.SetParameterValue("AccountName", AccountName);

                    crystalReportViewer1.ReportSource = ledger;

                    GlobalVariable.FromDate = DateTime.Today;
                    GlobalVariable.ToDate = DateTime.Today;
                    AccountName = "";
                    AccountNo = 0;
                    ReportID = "";
                }
                catch
                {

                }
            }
            else if (ReportID == "HeadWiseInc")
            {
                try
                {
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var report = (from p in DB.tbl_Ledgers
                                  where p.AccountNo == AccountNo && p.TransactionDate.Value.Date >= GlobalVariable.FromDate.Date && p.TransactionDate.Value.Date <= GlobalVariable.ToDate.Date
                                  select new { p.VoucharNo, InAmount = p.InAmount.Value, p.Particular, TransactionDate = p.TransactionDate.Value }).ToList();


                    CrIncomeReportAccountWise ledger = new CrIncomeReportAccountWise();
                    ledger.Load(@"CrIncomeReportAccountWise");
                    ledger.SetDataSource(report);
                    ledger.SetParameterValue("FromDate", GlobalVariable.FromDate);
                    ledger.SetParameterValue("ToDate", GlobalVariable.ToDate);
                    ledger.SetParameterValue("ShopName", GlobalVariable.ShopName);
                    ledger.SetParameterValue("AccountName", AccountName);

                    crystalReportViewer1.ReportSource = ledger;

                    GlobalVariable.FromDate = DateTime.Today;
                    GlobalVariable.ToDate = DateTime.Today;
                    AccountName = "";
                    AccountNo = 0;
                    ReportID = "";
                }
                catch
                { }
            }
            else if (ReportID == "DateWiseExp")
            {
                double Amount = 0;
                EasySaleDataContext DB = new EasySaleDataContext();
                //delete temp expense
                var q = from p in DB.tbl_TempExpenseReports
                        select p;
                foreach (tbl_TempExpenseReport exp in q)
                {
                    DB.tbl_TempExpenseReports.DeleteOnSubmit(exp);
                }
                try
                {
                    DB.SubmitChanges();
                }
                catch
                {

                }
                int SN = 0;
                List<tbl_TempExpenseReport> AllExpense = new List<tbl_TempExpenseReport>();
                var q1 = from p in DB.tbl_LedgerHeads
                         where p.AccountNo.ToString().StartsWith("3")
                         orderby p.AccountName ascending
                         select p;
                foreach (tbl_LedgerHead head in q1)
                {
                    tbl_TempExpenseReport entry = new tbl_TempExpenseReport();
                    Amount = 0;
                    var q2 = from p in DB.tbl_Ledgers
                             where p.AccountNo == head.AccountNo && p.TransactionDate.Value.Date >= GlobalVariable.FromDate.Date && p.TransactionDate.Value.Date <= GlobalVariable.ToDate.Date
                             select p.OutAmount.Value;
                    try
                    {
                        Amount = Convert.ToDouble(q2.Sum());
                    }
                    catch
                    {

                    }
                    entry.AccountName = head.AccountName;
                    entry.Amount = Amount;
                    entry.AccountNo = head.AccountNo;
                    SN += 1;
                    entry.SN = SN;
                    AllExpense.Add(entry);
                }
                DB.tbl_TempExpenseReports.InsertAllOnSubmit(AllExpense);
                DB.SubmitChanges();
                var b = (from p in DB.tbl_TempExpenseReports
                         select new { p.SN, p.AccountName, AccountNo = p.AccountNo.Value, Amount = p.Amount.Value }).ToList();


                CrExpenseReportDatewiseWise ledger = new CrExpenseReportDatewiseWise();
                ledger.Load(@"CrExpenseReportDatewiseWise");
                ledger.SetDataSource(b);
                ledger.SetParameterValue("FromDate", GlobalVariable.FromDate);
                ledger.SetParameterValue("ToDate", GlobalVariable.ToDate);
                ledger.SetParameterValue("ShopName", GlobalVariable.ShopName);

                crystalReportViewer1.ReportSource = ledger;

                GlobalVariable.FromDate = DateTime.Today;
                GlobalVariable.ToDate = DateTime.Today;
                AccountName = "";
                AccountNo = 0;
                ReportID = "";
            }
            else if (ReportID == "DateWiseInc")
            {
                double Amount = 0;
                EasySaleDataContext DB = new EasySaleDataContext();
                //delete temp expense
                var q = from p in DB.tbl_TempExpenseReports
                        select p;
                foreach (tbl_TempExpenseReport exp in q)
                {
                    DB.tbl_TempExpenseReports.DeleteOnSubmit(exp);
                }
                try
                {
                    DB.SubmitChanges();
                }
                catch
                {

                }
                int SN = 0;
                List<tbl_TempExpenseReport> AllExpense = new List<tbl_TempExpenseReport>();
                var q1 = from p in DB.tbl_LedgerHeads
                         where (p.AccountNo.ToString().StartsWith("1") && p.AccountNo != GlobalVariable.CashInHandAccountNo) || p.AccountNo.ToString().StartsWith("2")
                         orderby p.AccountName ascending
                         select p;
                foreach (tbl_LedgerHead head in q1)
                {
                    tbl_TempExpenseReport entry = new tbl_TempExpenseReport();
                    Amount = 0;
                    var q2 = from p in DB.tbl_Ledgers
                             where p.AccountNo == head.AccountNo && p.TransactionDate.Value.Date >= GlobalVariable.FromDate.Date && p.TransactionDate.Value.Date <= GlobalVariable.ToDate.Date
                             select p.InAmount.Value;
                    try
                    {
                        Amount = Convert.ToDouble(q2.Sum());
                    }
                    catch
                    {

                    }
                    entry.AccountName = head.AccountName;
                    entry.Amount = Amount;
                    entry.AccountNo = head.AccountNo;
                    SN += 1;
                    entry.SN = SN;
                    AllExpense.Add(entry);
                }
                DB.tbl_TempExpenseReports.InsertAllOnSubmit(AllExpense);
                DB.SubmitChanges();
                var b = (from p in DB.tbl_TempExpenseReports
                         select new { p.SN, p.AccountName, AccountNo = p.AccountNo.Value, Amount = p.Amount.Value }).ToList();


                CrIncomeReportDatewiseWise ledger = new CrIncomeReportDatewiseWise();
                ledger.Load(@"CrIncomeReportDatewiseWise");
                ledger.SetDataSource(b);
                ledger.SetParameterValue("FromDate", GlobalVariable.FromDate);
                ledger.SetParameterValue("ToDate", GlobalVariable.ToDate);
                ledger.SetParameterValue("ShopName", GlobalVariable.ShopName);

                crystalReportViewer1.ReportSource = ledger;

                GlobalVariable.FromDate = DateTime.Today;
                GlobalVariable.ToDate = DateTime.Today;
                AccountName = "";
                AccountNo = 0;
                ReportID = "";
            }
        }

       

       
       
    }
}
