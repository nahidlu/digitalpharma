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
    public partial class CrvLedger : Form
    {
        string ReportID = "";
        public CrvLedger()
        {
            InitializeComponent();
        }
        public CrvLedger(string reportid)
        {
            InitializeComponent();
            ReportID = reportid;
        }
        private void CrvLedger_Load(object sender, EventArgs e)
        {
            if (ReportID == "Ledger")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var a = from p in DB.tbl_Ledgers
                        where p.TransactionDate.Value.Date >= GlobalVariable.FromDate.Date && p.TransactionDate.Value.Date <= GlobalVariable.ToDate.Date && p.AccountNo != GlobalVariable.CashInHandAccountNo
                        select p.InAmount.Value;
                var b = from p in DB.tbl_Ledgers
                        where p.TransactionDate.Value.Date >= GlobalVariable.FromDate.Date && p.TransactionDate.Value.Date <= GlobalVariable.ToDate.Date && p.AccountNo != GlobalVariable.CashInHandAccountNo
                        select p.OutAmount.Value;
                double Income = 0;
                double Expense = 0;
                try
                {
                    Income = Convert.ToDouble(a.Sum());
                }
                catch
                {

                }
                try
                {
                    Expense = Convert.ToDouble(b.Sum());
                }
                catch
                {

                }
                double Profit = Income - Expense;

                CrLedgerReport ledger = new CrLedgerReport();
                ledger.SetParameterValue("Income", Income);
                ledger.SetParameterValue("Expense", Expense);
                ledger.SetParameterValue("Profit", Profit);
                ledger.SetParameterValue("FromDate", GlobalVariable.FromDate);
                ledger.SetParameterValue("ToDate", GlobalVariable.ToDate);
                ledger.SetParameterValue("ShopName", GlobalVariable.ShopName);

                crystalReportViewer1.ReportSource = ledger;

                GlobalVariable.FromDate = DateTime.Today;
                GlobalVariable.ToDate = DateTime.Today;
            }
            
        }
    }
}
