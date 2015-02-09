using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.DAO;

namespace digitalPharma
{
    public partial class frmReportExpiredProductList : Form
    {
        public frmReportExpiredProductList()
        {
            InitializeComponent();
        }

        private void btnExpired_Click(object sender, EventArgs e)
        {
            if (txtExpiredDays.Text != "")
            {
                GlobalVariable.FromDate = dtpExpired.Value.Date;
                GlobalVariable.Days = int.Parse(txtExpiredDays.Text.Trim());
                CrvPurchse purchase = new CrvPurchse("Expired");
                purchase.Show();
            }
            else
            {
                MessageBox.Show("Please Enter Days.");
                txtExpiredDays.Focus();
            }
        }

        private void txtExpiredDays_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForInt(txtExpiredDays);
        }

        private void frmReportExpiredProductList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                if (MessageBox.Show("Are You Sure To Exit?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    e.SuppressKeyPress = true;
                }

            }
        }
    }
}
