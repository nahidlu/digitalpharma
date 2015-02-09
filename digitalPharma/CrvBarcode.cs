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
    public partial class CrvBarcode : Form
    {
        public CrvBarcode()
        {
            InitializeComponent();
        }

        private void CrvBarcode_Load(object sender, EventArgs e)
        {
           
            CrBarcodeReport Report = new CrBarcodeReport();
            Report.SetDataSource(GlobalVariable.DataTable);
            crystalReportViewer1.ReportSource = Report;
        }
    }
}
