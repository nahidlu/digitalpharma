using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace digitalPharma
{
    public partial class frmPrintReceipt : Form
    {
        public frmPrintReceipt()
        {
            InitializeComponent();
        }
        private void LoadSalesInvoiceNo()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var query = from p in DB.tbl_SalesInvInfos
                        where p.ShopID == GlobalVariable.ShopID && p.AdvanceStatus == 0
                        orderby p.SN descending
                        select p.SalesInvoiceNo;
            if (query.Count() != 0)
            {
                cmbInvoiceNoSales.DataSource = query;
            }
            else
            {
                cmbInvoiceNoSales.DataSource = null;
            }
        }
        private void frmPrintReceipt_Load(object sender, EventArgs e)
        {
            LoadSalesInvoiceNo();
        }

        private void btnReportSingle_Click(object sender, EventArgs e)
        {
            if (cmbInvoiceNoSales.Text != "")
            {
                CrvSalesReceipt sale = new CrvSalesReceipt(cmbInvoiceNoSales.Text.Trim());
                sale.Show();
            }
            else
            {
                MessageBox.Show("Please select Invoice No.");
                cmbInvoiceNoSales.Focus();
            }
        }
    }
}
