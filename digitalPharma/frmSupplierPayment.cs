using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.AccountSystem.DAO;
using digitalPharma.DAO;
using System.Transactions;

namespace digitalPharma
{
    public partial class frmSupplierPayment : Form
    {
        public frmSupplierPayment()
        {
            InitializeComponent();
        }
        string TransactionID = "";
        private void Clear()
        {
            //cmbSupplierName.SelectedIndex = -1;
            dtpPaymentDate.Value = DateTime.Today;
            txtAmount.Text = "";
            txtParticular.Text = "";
            btnSave.Text = "Save";
            TransactionID = "";
            LoadDGSupplier();
            ShowBalance();
        }
        private void LoadDGSupplier()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = (from p in DB.tbl_Ledgers
                        where (p.AccountName == cmbSupplierName.SelectedValue.ToString() && p.Status == 2 && p.InAmount != 0)
                        orderby p.SN descending
                        select p).Take(10);
                if (q.Count() > 0)
                {
                    dgSupplier.Rows.Clear();
                    foreach (tbl_Ledger add in q)
                    {
                        dgSupplier.Rows.Add(add.SN, add.TransactionDate.Value.ToShortDateString(),add.TransactionID, add.AccountName, add.InAmount, add.Particular, add.AccountNo, add.SubGLID);
                    }
                }
                else
                {
                    dgSupplier.Rows.Clear();
                }
            }
            catch
            {
                dgSupplier.Rows.Clear();
            }
        }
        private void ShowBalance()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = (from p in DB.tbl_Ledgers
                         where p.AccountName == cmbSupplierName.SelectedValue.ToString()
                         select p.InAmount).Sum();
                var r = (from p in DB.tbl_Ledgers
                         where p.AccountName == cmbSupplierName.SelectedValue.ToString()
                         select p.OutAmount).Sum();
                double InAmount = 0, OutAmount = 0;
                InAmount = q.Value;
                OutAmount = r.Value;
                double Balance = InAmount - OutAmount;
                lblBalance.Text = Balance.ToString() + " Tk";
            }
            catch
            {
                lblBalance.Text = "0.00 Tk";
            }
                    
        }
        private void frmSupplierPayment_Load(object sender, EventArgs e)
        {
            frmPurchase.LoadSupplierName(cmbSupplierName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSupplierName.Text != "" && txtAmount.Text != "")
            {
                if (btnSave.Text == "Save")
                {
                    string ID = DateTime.Now.ToFileTime().ToString();
                    tbl_LedgerHead info = ClsLedgerHead.GetSingleLedgerHead(cmbSupplierName.SelectedValue.ToString());
                    tbl_Ledger sup = new tbl_Ledger();
                    //tbl_Ledger cash = new tbl_Ledger();
                    EasySaleDataContext DB = new EasySaleDataContext();
                    sup.AccountName = cmbSupplierName.SelectedValue.ToString();
                    sup.AccountNo = info.AccountNo;
                    sup.InAmount = txtAmount.Text == "" ? 0 : Math.Round((float.Parse(txtAmount.Text.Trim())), 2);
                    sup.OutAmount = 0;
                    sup.Particular = txtParticular.Text.Trim();
                    sup.ShopID = GlobalVariable.ShopID;
                    sup.Status = 2;
                    sup.SubGLID = info.SubGLID;
                    sup.TransactionDate = dtpPaymentDate.Value;
                    sup.TransactionID = ID;
                    sup.VoucharNo = ID;
                    /*
                    //insert cash in hand
                    cash.AccountName = GlobalVariable.CashInHandAccountName;
                    cash.AccountNo = GlobalVariable.CashInHandAccountNo;
                    cash.InAmount = 0;
                    cash.OutAmount = txtAmount.Text == "" ? 0 : Math.Round((float.Parse(txtAmount.Text.Trim())), 2);
                    cash.Particular = txtParticular.Text.Trim();
                    cash.ShopID = GlobalVariable.ShopID;
                    cash.Status = 0;
                    cash.SubGLID = ClsLedgerHead.GetSubGLIDByAccountNo(GlobalVariable.CashInHandAccountNo);
                    cash.TransactionDate = dtpPaymentDate.Value;
                    cash.TransactionID = ID;
                    cash.VoucharNo = ID;
                     */
                     
                    int check = 0;
                      
                    using (TransactionScope Trans = new TransactionScope())
                    {
                        try
                        {
                            DB.tbl_Ledgers.InsertOnSubmit(sup);
                            DB.SubmitChanges();

                            //DB.tbl_Ledgers.InsertOnSubmit(cash);
                            //DB.SubmitChanges();

                            Trans.Complete();
                            check = 1;
                        }
                        catch
                        {

                        }
                    }
                    if (check > 0)
                    {
                        MessageBox.Show("Saved Successfully.");
                        Clear();
                    }
                }
                else // Update here
                {
                   
                    tbl_LedgerHead info = ClsLedgerHead.GetSingleLedgerHead(cmbSupplierName.SelectedValue.ToString());
                   // tbl_Ledger sup = new tbl_Ledger();
                    //tbl_Ledger cash = new tbl_Ledger();
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var q = from p in DB.tbl_Ledgers
                            where p.TransactionID == TransactionID
                            select p;
                    foreach (tbl_Ledger sup in q)
                    {
                        sup.AccountName = cmbSupplierName.SelectedValue.ToString();
                        sup.AccountNo = info.AccountNo;
                        sup.InAmount = txtAmount.Text == "" ? 0 : Math.Round((float.Parse(txtAmount.Text.Trim())), 2);
                        sup.OutAmount = 0;
                        sup.Particular = txtParticular.Text.Trim();
                        sup.ShopID = GlobalVariable.ShopID;
                        sup.Status = 2;
                        sup.SubGLID = info.SubGLID;
                        sup.TransactionDate = dtpPaymentDate.Value;
                    }
                    /*
                    //insert cash in hand
                    cash.AccountName = GlobalVariable.CashInHandAccountName;
                    cash.AccountNo = GlobalVariable.CashInHandAccountNo;
                    cash.InAmount = 0;
                    cash.OutAmount = txtAmount.Text == "" ? 0 : Math.Round((float.Parse(txtAmount.Text.Trim())), 2);
                    cash.Particular = txtParticular.Text.Trim();
                    cash.ShopID = GlobalVariable.ShopID;
                    cash.Status = 0;
                    cash.SubGLID = ClsLedgerHead.GetSubGLIDByAccountNo(GlobalVariable.CashInHandAccountNo);
                    cash.TransactionDate = dtpPaymentDate.Value;
                    cash.TransactionID = ID;
                    cash.VoucharNo = ID;
                     */

                    int check = 0;

                    using (TransactionScope Trans = new TransactionScope())
                    {
                        try
                        {
                            DB.SubmitChanges();

                            //DB.tbl_Ledgers.InsertOnSubmit(cash);
                            //DB.SubmitChanges();

                            Trans.Complete();
                            check = 1;
                        }
                        catch
                        {

                        }
                    }
                    if (check > 0)
                    {
                        MessageBox.Show("Updated Successfully.");
                        Clear();
                    }
                }

            }
            else
            {
                if (cmbSupplierName.Text == "")
                {
                    MessageBox.Show("Please Select Supplier Name.");
                    cmbSupplierName.Focus();
                }
                else
                {
                    MessageBox.Show("Please Enter Amount.");
                    txtAmount.Focus();
                }
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtAmount);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDGSupplier();
            ShowBalance();
        }

        private void dgSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSupplier.SelectedRows[0].Cells[0].Value != null)
            {
                //SN = Int64.Parse(dgIncome.SelectedRows[0].Cells[0].Value.ToString());
                TransactionID = dgSupplier.SelectedRows[0].Cells[2].Value.ToString();
                dtpPaymentDate.Value = Convert.ToDateTime(dgSupplier.SelectedRows[0].Cells[1].Value.ToString());
                txtAmount.Text = dgSupplier.SelectedRows[0].Cells[4].Value.ToString();
                txtParticular.Text = dgSupplier.SelectedRows[0].Cells[5].Value.ToString();
                btnSave.Text = "Update";
            }
        }

        private void frmSupplierPayment_KeyDown(object sender, KeyEventArgs e)
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
