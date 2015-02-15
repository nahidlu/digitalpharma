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

namespace digitalPharma
{
    public partial class frmHeadEntry : Form
    {
        int SubGLID = 0, AccountNumber = 0;

        public frmHeadEntry()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            cmbGL.Text = "";
            txtSubHeadName.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            LoadDgSubHead();
            LoadGL2();
            SubGLID = 0;
            
        }
        private void ClearLeadgerHead()
        {
            cmbGL2.Text = "";
            cmbSubHeadName.Text = "";
            btnSaveLHead.Text = "Save";
            btnDeleteLHead.Enabled = false;
            txtAccountName.Text = "";
            txtDescription.Text = "";
            LoadDgLedgerHead();
            AccountNumber = 0;
        }
        public static int CreateAccountNo(string no)
        {
            int AccountNO = 0;
            try
            {                
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = (from p in DB.tbl_LedgerHeads
                        where p.AccountNo.ToString().StartsWith(no)
                        orderby p.SN ascending
                        select p.AccountNo).ToList();
                if (q.Count() > 0)
                {
                    AccountNO = q.Max() + 1;
                }
                else
                {
                    string First = no + "001";
                    AccountNO = Convert.ToInt16(First);
                }
            }
            catch
            {

            }
            return AccountNO;

        }
        private void LoadDgSubHead()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_SubHeads
                        where p.GLID == int.Parse(cmbGL.SelectedValue.ToString())
                        select p;
                if (q.Count() > 0)
                {
                    dgSubHead.Rows.Clear();
                    foreach (tbl_SubHead head in q)
                    {
                        dgSubHead.Rows.Add(head.SubGLID, ClsHead.GetGLName(int.Parse(head.GLID.ToString())), head.SubHeadName);
                    }
                }
                else
                {
                    dgSubHead.Rows.Clear();
                }
            }
            catch
            {
                dgSubHead.Rows.Clear();
            }
        }
        private void LoadDgLedgerHead()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_LedgerHeads
                        where p.GLID == int.Parse(cmbGL2.SelectedValue.ToString()) && p.SubGLID == int.Parse(cmbSubHeadName.SelectedValue.ToString())
                        select p;
                if (q.Count() > 0)
                {
                   dgLedgerHead.Rows.Clear();
                    foreach (tbl_LedgerHead head in q)
                    {
                        dgLedgerHead.Rows.Add(head.SN, ClsHead.GetGLName(int.Parse(head.GLID.ToString())), ClsSubHead.GetSubHeadName(int.Parse(head.SubGLID.ToString())), head.AccountName, head.Description, head.AccountNo);
                    }
                }
                else
                {
                    dgLedgerHead.Rows.Clear();
                }
            }
            catch
            {
                dgLedgerHead.Rows.Clear();
            }
        }
        private void LoadGL()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_Heads
                        select p;
                if (q != null)
                {
                    cmbGL.DataSource = q;
                    cmbGL.DisplayMember = "GLName";
                    cmbGL.ValueMember = "GLID";
                }
                else
                {
                    cmbGL.DataSource = null;
                }
            }
            catch
            {
                cmbGL.DataSource = null;
            }
        }
        private void LoadGL2()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_Heads
                        select p;// new { ID = p.GLID, Name = p.GLName };
                if (q != null)
                {
                    cmbGL2.DataSource = q;
                    cmbGL2.DisplayMember = "GLName";
                    cmbGL2.ValueMember = "GLID";
                }
                else
                {
                    cmbGL2.DataSource = null;                    
                }
            }
            catch
            {
                cmbGL2.DataSource = null;
            }
        }
        private void LoadSubHead()
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_SubHeads
                        where p.GLID == int.Parse(cmbGL2.SelectedValue.ToString()) && p.SubHeadName != GlobalVariable.SupplierSubHeadName
                        select p;// new { ID = p.SubGLID, Name = p.SubHeadName };
                if (q != null)
                {
                    cmbSubHeadName.DataSource = q;
                    cmbSubHeadName.DisplayMember = "SubHeadName";
                    cmbSubHeadName.ValueMember = "SubGLID";
                }
                else
                {
                    cmbSubHeadName.DataSource = null;
                }
            }
            catch
            {
                cmbSubHeadName.DataSource = null;
            }
        }

        private void frmSubHead_Load(object sender, EventArgs e)
        {
            LoadGL();
            LoadGL2();
            LoadDgSubHead();
            cmbGL2.Text = "Income";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbGL.Text != "" && txtSubHeadName.Text != "")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                int check = 0;
                if (btnSave.Text == "Save")
                {
                    var q = from p in DB.tbl_SubHeads
                            where p.SubHeadName == txtSubHeadName.Text.Trim() && p.GLID == int.Parse(cmbGL.SelectedValue.ToString())
                            select p;
                    if (q.Count() == 0)
                    {                        
                        using (TransactionScope trans = new TransactionScope())
                        {
                            try
                            {
                                tbl_SubHead entry = new tbl_SubHead();
                                entry.GLID = int.Parse(cmbGL.SelectedValue.ToString());
                                entry.SubHeadName = txtSubHeadName.Text.Trim();
                                DB.tbl_SubHeads.InsertOnSubmit(entry);
                                DB.SubmitChanges();

                                trans.Complete();
                                check = 1;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                check = 0;
                            }
                        }
                        if (check > 0)
                        {
                            MessageBox.Show("Saved Successfully.");
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Name Already used.\n Please Try with other Name");
                        txtSubHeadName.Focus();
                    }
                }
                else //Update here
                {

                    using (TransactionScope trans = new TransactionScope())
                        {
                            try
                            {
                                var r = from p in DB.tbl_SubHeads
                                        where p.SubHeadName == txtSubHeadName.Text.Trim() && p.SubGLID != SubGLID && p.GLID == int.Parse(cmbGL.SelectedValue.ToString())
                                        select p;
                                if (r.Count() == 0)
                                {
                                    var q = from p in DB.tbl_SubHeads
                                            where p.SubGLID == SubGLID
                                            select p;
                                    foreach (tbl_SubHead entry in q)
                                    {
                                        entry.GLID = int.Parse(cmbGL.SelectedValue.ToString());
                                        entry.SubHeadName = txtSubHeadName.Text.Trim();
                                    }
                                    DB.SubmitChanges();

                                    trans.Complete();
                                    check = 1;
                                }
                                else
                                {
                                    MessageBox.Show("This Name Already used.\n Please Try with other Name");
                                    txtSubHeadName.Focus();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                check = 0;
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
                if (cmbGL.Text == "")
                {
                    MessageBox.Show("Please select a GL");
                    cmbGL.Focus();
                }
                else
                {
                    MessageBox.Show("Please enter Sub Head Name");
                    txtSubHeadName.Focus();
                }
            }
        }

        private void dgSubHead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GlobalVariable.userType != "Sales Man")
                {
                    if (dgSubHead.SelectedRows[0].Cells[2].Value.ToString() == "Sales" || dgSubHead.SelectedRows[0].Cells[2].Value.ToString() == GlobalVariable.CashInHandAccountName)
                    {
                        MessageBox.Show("You can not Update This Sub Head Name.");
                    }
                    else
                    {
                        if (dgSubHead.SelectedRows[0].Cells[0].Value != null)
                        {
                            SubGLID = int.Parse((dgSubHead.SelectedRows[0].Cells[0].Value.ToString()));
                            cmbGL.Text = dgSubHead.SelectedRows[0].Cells[1].Value.ToString();
                            txtSubHeadName.Text = dgSubHead.SelectedRows[0].Cells[2].Value.ToString();
                            btnSave.Text = "Update";
                            btnDelete.Enabled = true;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgSubHead.SelectedRows[0].Cells[2].Value.ToString() == "Sales" || dgSubHead.SelectedRows[0].Cells[2].Value.ToString() == GlobalVariable.CashInHandAccountName)
            {
                MessageBox.Show("You can not Delete This Sub Head Name.");
            }
            else
            {
                if (MessageBox.Show("If you delete this, All Ledger Head under this sub head will be deleted. \n Are You Sure to Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    int check = 0;
                    using (TransactionScope Trans = new TransactionScope())
                    {
                        try
                        {
                            EasySaleDataContext DB = new EasySaleDataContext();
                            var q = from p in DB.tbl_SubHeads
                                    where p.SubGLID == SubGLID
                                    select p;
                            foreach (tbl_SubHead head in q)
                            {
                                DB.tbl_SubHeads.DeleteOnSubmit(head);
                            }

                            DB.SubmitChanges();
                            Trans.Complete();
                            check = 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            check = 0;
                        }
                    }
                    if (check > 0)
                    {
                        MessageBox.Show("Deleted Successfully.");
                        Clear();
                    }
                }
            }
        }

        private void cmbGL2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubHead();
        }
        

        private void dgLedgerHead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GlobalVariable.userType != "Sales Man")
                {
                    if ((dgLedgerHead.SelectedRows[0].Cells[2].Value.ToString() == "Sales" && dgLedgerHead.SelectedRows[0].Cells[3].Value.ToString() == GlobalVariable.ProductSaleAccountName) || (dgLedgerHead.SelectedRows[0].Cells[2].Value.ToString() == GlobalVariable.CashInHandAccountName && dgLedgerHead.SelectedRows[0].Cells[3].Value.ToString() == GlobalVariable.CashInHandAccountName))
                    {
                        MessageBox.Show("You can not Update This Ledger Head.");
                    }
                    else
                    {
                        if (dgLedgerHead.SelectedRows[0].Cells[0].Value != null)
                        {
                            AccountNumber = int.Parse((dgLedgerHead.SelectedRows[0].Cells[5].Value.ToString()));
                            cmbGL2.Text = dgLedgerHead.SelectedRows[0].Cells[1].Value.ToString();
                            cmbSubHeadName.Text = dgLedgerHead.SelectedRows[0].Cells[2].Value.ToString();
                            txtAccountName.Text = dgLedgerHead.SelectedRows[0].Cells[3].Value.ToString();
                            txtDescription.Text = dgLedgerHead.SelectedRows[0].Cells[4].Value.ToString();
                            btnSaveLHead.Text = "Update";
                            btnDeleteLHead.Enabled = true;
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

        private void cmbSubHeadName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgLedgerHead();
        }

        private void btnDeleteLHead_Click(object sender, EventArgs e)
        {
            if ((dgLedgerHead.SelectedRows[0].Cells[2].Value.ToString() == "Sales" && dgLedgerHead.SelectedRows[0].Cells[3].Value.ToString() == GlobalVariable.ProductSaleAccountName) || (dgLedgerHead.SelectedRows[0].Cells[2].Value.ToString() == GlobalVariable.CashInHandAccountName && dgLedgerHead.SelectedRows[0].Cells[3].Value.ToString() == GlobalVariable.CashInHandAccountName))
            {
                MessageBox.Show("You can not Delete This Ledger Head.");
            }
            else
            {
                if (MessageBox.Show("If You Delete This Account Name, \nAll The Leadger History Using This Account Name Will Be Deleted.\n Are You Sure to Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    int check = 0;
                    using (TransactionScope Trans = new TransactionScope())
                    {
                        try
                        {
                            EasySaleDataContext DB = new EasySaleDataContext();
                            var q = from p in DB.tbl_LedgerHeads
                                    where p.AccountNo == AccountNumber
                                    select p;
                            foreach (tbl_LedgerHead head in q)
                            {
                                DB.tbl_LedgerHeads.DeleteOnSubmit(head);
                            }
                            DB.SubmitChanges();
                            Trans.Complete();
                            check = 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            check = 0;
                        }
                    }
                    if (check > 0)
                    {
                        MessageBox.Show("Deleted Successfully.");
                        ClearLeadgerHead();
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClearLHead_Click(object sender, EventArgs e)
        {
            ClearLeadgerHead();
        }

        private void cmbGL_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgSubHead();
        }

        private void btnSaveLHead_Click(object sender, EventArgs e)
        {            
            if (cmbGL2.Text != "" && cmbSubHeadName.Text != "" && txtAccountName.Text != "")
            {
                int check = 0;
                EasySaleDataContext DB = new EasySaleDataContext();
                if (btnSaveLHead.Text == "Save")
                {
                    //check duplicate entry
                    var q = from p in DB.tbl_LedgerHeads
                            where p.AccountName == txtAccountName.Text.Trim() && p.SubGLID == int.Parse(cmbSubHeadName.SelectedValue.ToString())
                            select p;
                    if (q.Count() == 0)
                    {
                        //using (TransactionScope Trans = new TransactionScope())
                        {
                            //try
                            //{
                            tbl_LedgerHead entry = new tbl_LedgerHead();
                            entry.GLID = int.Parse(cmbGL2.SelectedValue.ToString());
                            entry.SubGLID = int.Parse(cmbSubHeadName.SelectedValue.ToString());
                            entry.AccountName = txtAccountName.Text.Trim();
                            entry.AccountNo = CreateAccountNo(cmbGL2.SelectedValue.ToString().Substring(0, 1));
                            entry.Description = txtDescription.Text.Trim();

                            DB.tbl_LedgerHeads.InsertOnSubmit(entry);
                           DB.SubmitChanges();
                            //Trans.Complete();
                            check = 1;
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.ToString());
                            //    check = 0;
                            //}
                        }

                        if (check > 0)
                        {
                            MessageBox.Show("Saved Successfully.");
                            ClearLeadgerHead();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Account Name Already Used.\n Please Try With Other Name");
                    }
                }
                else // Update here
                {
                    //check duplicate entry
                    var q = from p in DB.tbl_LedgerHeads
                            where p.AccountName == txtAccountName.Text.Trim() && p.SubGLID == int.Parse(cmbSubHeadName.SelectedValue.ToString()) && p.AccountNo != AccountNumber
                            select p;
                    if (q.Count() == 0)
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            try
                            {
                                var r = from p in DB.tbl_LedgerHeads
                                        where p.AccountNo == AccountNumber
                                        select p;
                                foreach (tbl_LedgerHead entry in r)
                                {
                                    entry.GLID = int.Parse(cmbGL2.SelectedValue.ToString());
                                    entry.SubGLID = int.Parse(cmbSubHeadName.SelectedValue.ToString());
                                    entry.AccountName = txtAccountName.Text.Trim();
                                    entry.Description = txtDescription.Text.Trim();
                                }
                                DB.SubmitChanges();
                                Trans.Complete();
                                check = 1;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                check = 0;
                            }
                        }

                        if (check > 0)
                        {
                            MessageBox.Show("Updated Successfully.");
                            ClearLeadgerHead();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Account Name Already Used.\n Please Try With Other Name");
                    }
                }
            }
            else
            {
                if (cmbGL2.Text == "")
                {
                    MessageBox.Show("Please select a GL");
                    cmbGL2.Focus();
                }
                else if (cmbSubHeadName.Text == "")
                {
                    MessageBox.Show("Please Select Sub Head Name");
                    cmbSubHeadName.Focus();
                }
                else if (txtAccountName.Text == "")
                {
                    MessageBox.Show("Please Enter Account Name");
                    txtAccountName.Focus();
                }

            }
        }

        private void frmHeadEntry_KeyDown(object sender, KeyEventArgs e)
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
