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
    public partial class frmSet : Form
    {
        public frmSet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPercentAmount.Text != "")
            {
                if (MessageBox.Show("Confirm Update?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var q = from p in DB.tbl_DiscountPercents
                            select p;
                    foreach (tbl_DiscountPercent update in q)
                    {
                        update.PercentAmount = float.Parse(txtPercentAmount.Text.Trim());
                    }
                    try
                    {
                        DB.SubmitChanges();
                        MessageBox.Show("Successfully Updated.");
                    }
                    catch
                    {
                        MessageBox.Show("Error!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Percent Amount.");
                txtPercentAmount.Focus();
            }
        }
       

        private void frmSet_Load(object sender, EventArgs e)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_DiscountPercents
                    select p;
            if (q.Count() > 0)
            {
                txtPercentAmount.Text = q.Single().PercentAmount.ToString();
            }
            else
            {
                txtPercentAmount.Text = "0";
            }
        }

        private void frmSet_KeyDown(object sender, KeyEventArgs e)
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

        private void txtPercentAmount_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtPercentAmount);
        }
    }
}
