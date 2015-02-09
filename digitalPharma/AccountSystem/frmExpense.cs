using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using digitalPharma.AccountSystem.DAO;
using digitalPharma.DAO;

namespace digitalPharma.AccountSystem
{
    public partial class frmExpense : Form
    {
        //Int64 SN = 0;
        string VoucherNo = "";
        public frmExpense()
        {
            InitializeComponent();
        }
        private void Clear()
        {
            dtpDate.Value = DateTime.Today;
            cmbAccountName.Text = "";
            txtAmount.Text = "";
            txtParticular.Text = "";
            txtVoucherNO.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            LoadDGExpense();
            LoadExpenseAccountName();
           // SN = 0;
            VoucherNo = "";
        }
        private void LoadExpenseAccountName()
        {
            try
            {
                DataTable dt = ClsEpense.GetExpenseHeadNameDataSource();
                cmbAccountName.DataSource = dt;
                cmbAccountName.DisplayMember = "name";
                cmbAccountName.ValueMember = "id";
            }
            catch
            {
                cmbAccountName.DataSource = null;
            }            
        }

        private void LoadDGExpense()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_Ledgers
                        where p.TransactionDate.Value.Date >= dtpFrom.Value.Date && p.TransactionDate.Value.Date <= dtpTo.Value.Date
                              && p.AccountNo.ToString().StartsWith("3") 
                        select p;
                if (q.Count() > 0)
                {
                    dgExpense.Rows.Clear();
                    foreach (tbl_Ledger add in q)
                    {
                        dgExpense.Rows.Add(add.SN, add.TransactionDate.Value, add.VoucharNo, add.AccountName, add.OutAmount, add.Particular, add.AccountNo, add.SubGLID);
                    }
                }
                else
                {
                    dgExpense.Rows.Clear();
                }
            }
            catch
            { 
            
            }
        }

        private void frmIncome_Load(object sender, EventArgs e)
        {
            LoadExpenseAccountName();
            LoadDGExpense();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbAccountName.Text != "" && txtAmount.Text != "" && txtVoucherNO.Text != "" )
            {
                int check = 0;
                EasySaleDataContext DB = new EasySaleDataContext();

                var q = from p in DB.tbl_Ledgers
                        where p.VoucharNo == txtVoucherNO.Text.Trim()
                        select p;
                if (q.Count() == 0)
                {
                    using (TransactionScope Trans = new TransactionScope())
                    {
                        try
                        {
                            List<tbl_Ledger> LedgerList = new List<tbl_Ledger>();
                            // epense entry
                            {
                                tbl_Ledger entry = new tbl_Ledger();
                                entry.VoucharNo = txtVoucherNO.Text.Trim();
                                entry.AccountName = cmbAccountName.Text.Trim();
                                entry.AccountNo = int.Parse(cmbAccountName.SelectedValue.ToString());
                                entry.OutAmount = txtAmount.Text == "" ? 0 : Math.Round((float.Parse(txtAmount.Text.Trim())), 2);
                                entry.InAmount = 0;
                                entry.Particular = txtParticular.Text.Trim();
                                entry.Status = 0;
                                entry.SubGLID = ClsLedgerHead.GetSubGLIDByAccountNo(int.Parse(cmbAccountName.SelectedValue.ToString()));
                                entry.TransactionDate = dtpDate.Value;
                                entry.TransactionID = txtVoucherNO.Text.Trim();
                                entry.ShopID = GlobalVariable.ShopID;
                                LedgerList.Add(entry);
                            }

                            //Subtract from cash in hand
                            {
                                tbl_Ledger entry = new tbl_Ledger();
                                entry.VoucharNo = txtVoucherNO.Text.Trim();
                                entry.AccountName = GlobalVariable.CashInHandAccountName;
                                entry.AccountNo =GlobalVariable.CashInHandAccountNo;
                                entry.OutAmount = txtAmount.Text == "" ? 0 : Math.Round((float.Parse(txtAmount.Text.Trim())), 2);
                                entry.InAmount = 0;
                                entry.Particular = txtParticular.Text.Trim();
                                entry.Status = 0;
                                entry.SubGLID = ClsLedgerHead.GetSubGLIDByAccountNo(GlobalVariable.CashInHandAccountNo);
                                entry.TransactionDate = dtpDate.Value;
                                entry.TransactionID = txtVoucherNO.Text.Trim();
                                entry.ShopID = GlobalVariable.ShopID;
                                LedgerList.Add(entry);
                            }

                            DB.tbl_Ledgers.InsertAllOnSubmit(LedgerList);
                            DB.SubmitChanges();

                            Trans.Complete();
                            check = 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                    if (check == 1)
                    {
                        MessageBox.Show("Saved Successfully.");
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show("This voucher Number already used.\nPlease Try with another Number.");
                    txtVoucherNO.Focus();
                }

            }
            else
            {
                if (cmbAccountName.Text == "")
                {
                    MessageBox.Show("Please Select Account Name.");
                    cmbAccountName.Focus();
                }
                else if (txtVoucherNO.Text == "")
                {
                    MessageBox.Show("Please Enter Voucher No.");
                    txtVoucherNO.Focus();
                }
                else if (txtAmount.Text == "")
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.userType == "Admin")
            {
                if (MessageBox.Show("Are You Sure To Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    int check = 0;
                    using (TransactionScope Trans = new TransactionScope())
                    {
                        try
                        {
                            EasySaleDataContext DB = new EasySaleDataContext();

                            var q = from p in DB.tbl_Ledgers
                                    where p.VoucharNo == VoucherNo
                                    select p;
                            foreach (tbl_Ledger del in q)
                            {
                                DB.tbl_Ledgers.DeleteOnSubmit(del);
                            }
                            DB.SubmitChanges();
                            Trans.Complete();
                            check = 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    if (check > 0)
                    {
                        MessageBox.Show("Deleted Successfully.");
                        Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("You Have No Rights To Do This Action.");
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadDGExpense();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadDGExpense();
        }

        private void dgLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GlobalVariable.userType != "Sales Man")
                {
                    if (dgExpense.SelectedRows[0].Cells[0].Value != null)
                    {
                        VoucherNo = dgExpense.SelectedRows[0].Cells[2].Value.ToString();
                        dtpDate.Value = Convert.ToDateTime(dgExpense.SelectedRows[0].Cells[1].Value.ToString());
                        cmbAccountName.Text = dgExpense.SelectedRows[0].Cells[3].Value.ToString();
                        txtVoucherNO.Text = dgExpense.SelectedRows[0].Cells[2].Value.ToString();
                        txtAmount.Text = dgExpense.SelectedRows[0].Cells[4].Value.ToString();
                        txtParticular.Text = dgExpense.SelectedRows[0].Cells[5].Value.ToString();
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("You have no permission.");
                }
            }
            catch
            { 
            
            }
        }

        private void frmExpense_KeyDown(object sender, KeyEventArgs e)
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
