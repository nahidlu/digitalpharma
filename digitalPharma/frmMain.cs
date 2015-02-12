using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.AccountSystem;

namespace digitalPharma
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are You Sure To Exit?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmEmployeeManagement))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmEmployeeManagement();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }

        private void productGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmProductCategory))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmProductCategory();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }

        private void supplierFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmSupplier))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmSupplier();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }


        private void purchaseFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmPurchase))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmPurchase();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }

        private void salesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*  foreach (Form form in Application.OpenForms)
              {
                  if (form.GetType() == typeof(frmSale))
                  {
                      form.Activate();
                      return;
                  }
              }*/

            Form newForm = new frmSale();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }

        private void allReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmReportAll))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmReportAll();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FrmDataBase))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new FrmDataBase();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    client.BackColor = this.BackColor;
                    client.BackgroundImage = Properties.Resources.PharmacyPNG;
                    //client.BackgroundImageLayout= System.Windows.Forms.ImageLayout.Center;
                    this.BackgroundImageLayout = ImageLayout.Center;
                    // 4#
                    break;
                }
            }
            if (GlobalVariable.userType == "Admin")
            {
                menuStrip1.Visible = true;
            }
            else
            {
                menuStrip1.Visible = false;
            }
        }
        private void expenseHeadEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmHeadEntry))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmHeadEntry();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }


        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmIncome))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmIncome();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }


        private void expenseEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmExpense))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmExpense();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }

        private void stockManagementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmStockManagement))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmStockManagement();
            newForm.MdiParent = this;
            frmSubMenu sub = new frmSubMenu();
            newForm.Location = new Point(sub.Width, 50);
            newForm.Show();
        }

        private void setToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmSet))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmSet();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void supplierPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmSupplierPayment))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new frmSupplierPayment();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                if (MessageBox.Show("Are You Sure To Exit?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.SuppressKeyPress = true;
                }

            }
        }
    }
}
