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
    public partial class frmIncome : Form
    {
        //Int64 SN = 0;
        string VoucherNo = "";
        public frmIncome()
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
            LoadDGIncome();
            LoadIncomeAccountName();
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            //SN = 0;
            VoucherNo = "";
        }
        private void LoadIncomeAccountName()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_LedgerHeads
                        where (p.GLID == 1000 && p.AccountNo != GlobalVariable.CashInHandAccountNo ) || (p.GLID == 2000 && p.AccountNo != GlobalVariable.ProductSaleAccountNo)
                        select new { id = p.AccountNo, name = p.AccountName };
                if (q.Count() > 0)
                {
                    cmbAccountName.DataSource = q;
                    cmbAccountName.DisplayMember = "name";
                    cmbAccountName.ValueMember = "id";
                }
                else
                {
                    cmbAccountName.DataSource = null;
                }
            }
            catch
            { 
            
            }
        }

        private void LoadDGIncome()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_Ledgers
                        where (p.TransactionDate.Value.Date >= dtpFrom.Value.Date && p.TransactionDate.Value.Date <= dtpTo.Value.Date
                                && p.AccountNo.ToString().StartsWith("2") && p.AccountNo != GlobalVariable.ProductSaleAccountNo)

                                || (p.TransactionDate.Value.Date >= dtpFrom.Value.Date && p.TransactionDate.Value.Date <= dtpTo.Value.Date
                                && p.AccountNo.ToString().StartsWith("1") && p.AccountNo != GlobalVariable.CashInHandAccountNo)
                        select p;
                if (q.Count() > 0)
                {
                    dgIncome.Rows.Clear();
                    foreach (tbl_Ledger add in q)
                    {
                        dgIncome.Rows.Add(add.SN, add.TransactionDate.Value, add.VoucharNo, add.AccountName, add.InAmount, add.Particular, add.AccountNo, add.SubGLID);
                    }
                }
                else
                {
                    dgIncome.Rows.Clear();
                }
            }
            catch
            {
                dgIncome.Rows.Clear();
            }
        }

        private void frmIncome_Load(object sender, EventArgs e)
        {
            LoadIncomeAccountName();
            LoadDGIncome();
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
                            //insert Income
                            {
                                tbl_Ledger entry = new tbl_Ledger();
                                entry.VoucharNo = txtVoucherNO.Text.Trim();
                                entry.AccountName = cmbAccountName.Text.Trim();
                                entry.AccountNo = int.Parse(cmbAccountName.SelectedValue.ToString());
                                entry.InAmount = txtAmount.Text == "" ? 0 : Math.Round((float.Parse(txtAmount.Text.Trim())), 2);
                                entry.OutAmount = 0;
                                entry.Particular = txtParticular.Text.Trim();
                                entry.Status = 0;
                                entry.ShopID = GlobalVariable.ShopID;
                                entry.SubGLID = ClsLedgerHead.GetSubGLIDByAccountNo(int.Parse(cmbAccountName.SelectedValue.ToString()));
                                entry.TransactionDate = dtpDate.Value;
                                entry.TransactionID = txtVoucherNO.Text.Trim();
                                LedgerList.Add(entry);
                            }
                            // add cash in hand
                            //insert Income
                            {
                                tbl_Ledger entry = new tbl_Ledger();
                                entry.VoucharNo = txtVoucherNO.Text.Trim();
                                entry.AccountName = GlobalVariable.CashInHandAccountName;
                                entry.AccountNo = GlobalVariable.CashInHandAccountNo;
                                entry.InAmount = txtAmount.Text == "" ? 0 : Math.Round((float.Parse(txtAmount.Text.Trim())), 2);
                                entry.OutAmount = 0;
                                entry.Particular = txtParticular.Text.Trim();
                                entry.Status = 0;
                                entry.ShopID = GlobalVariable.ShopID;
                                entry.SubGLID = ClsLedgerHead.GetSubGLIDByAccountNo(GlobalVariable.CashInHandAccountNo);
                                entry.TransactionDate = dtpDate.Value;
                                entry.TransactionID = txtVoucherNO.Text.Trim();
                                LedgerList.Add(entry);
                            }

                            DB.tbl_Ledgers.InsertAllOnSubmit(LedgerList);
                            DB.SubmitChanges();

                            Trans.Complete();
                            check = 1;
                        }
                        catch(Exception ex)
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
                            //delete income and cash in hand with voucherNo
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
                        catch(Exception ex)
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

       

        private void dgLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GlobalVariable.userType != "Sales Man")
                {
                    if (dgIncome.SelectedRows[0].Cells[3].Value.ToString() == GlobalVariable.ProductSaleAccountName)
                    {
                        MessageBox.Show("You can not Update This Ledger Head.");
                    }
                    else
                    {
                        if (dgIncome.SelectedRows[0].Cells[0].Value != null)
                        {
                            //SN = Int64.Parse(dgIncome.SelectedRows[0].Cells[0].Value.ToString());
                            VoucherNo = dgIncome.SelectedRows[0].Cells[2].Value.ToString();
                            dtpDate.Value = Convert.ToDateTime(dgIncome.SelectedRows[0].Cells[1].Value.ToString());
                            cmbAccountName.Text = dgIncome.SelectedRows[0].Cells[3].Value.ToString();
                            txtVoucherNO.Text = dgIncome.SelectedRows[0].Cells[2].Value.ToString();
                            txtAmount.Text = dgIncome.SelectedRows[0].Cells[4].Value.ToString();
                            txtParticular.Text = dgIncome.SelectedRows[0].Cells[5].Value.ToString();
                            btnDelete.Enabled = true;
                            btnSave.Enabled = false;
                        }
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

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadDGIncome();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadDGIncome();
        }

        private void frmIncome_KeyDown(object sender, KeyEventArgs e)
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
