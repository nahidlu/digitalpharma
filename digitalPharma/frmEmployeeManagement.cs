using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Transactions;
using digitalPharma.DAO;

namespace digitalPharma
{
    public partial class frmEmployeeManagement : Form
    {
        Int64 EmployeeID = 0;
        public frmEmployeeManagement()
        {
            InitializeComponent();
        }
        private void Clear()
        {
            txtName.Text = "";
            txtEmployeeID.Text = "";
            txtContactNo.Text = "";
            txtAddress.Text = "";
            cmbEmployeeType.Text = "";
            txtUserId.Text = "";
            txtPassword.Text = "";
            LoadDgEmployee();
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            EmployeeID = 0;
            txtAdminTypeCheck.Text = "";
        }
        private void LoadEmployeeType()
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var r = from p in DB.tbl_EmployeeTypes
                    select p;
            if (r.Count() > 0)
            {
                cmbEmployeeType.Items.Clear();
                foreach (tbl_EmployeeType type in r)
                {
                    cmbEmployeeType.Items.Add(type.Type);
                }
            }
        }
        private void LoadDgEmployee()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var q = from p in DB.tbl_EmployeeInfos
                    from r in DB.tbl_logins
                    where p.EmployeeID == r.EmployeeID
                    select new { p.EmployeeID,p.Address,p.ContactNo,p.Name,p.ShopID,p.ProfilePicture,r.user_id,r.password,r.user_type};
            if (q.Count() > 0)
            {
                dgEmployee.Rows.Clear();

                foreach (var info in q)
                {
                    dgEmployee.Rows.Add( info.EmployeeID, info.user_type,  info.Name, info.ContactNo, info.Address,info.user_id,info.password);
                }
            }
            else
            {
                dgEmployee.Rows.Clear();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEmployeeType();
            LoadDgEmployee();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cmbEmployeeType.Text != "" && txtName.Text != "" && txtContactNo.Text != "")
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                if (btnSave.Text == "Save")
                {
                    //check Duplicate user id

                    var q = from p in DB.tbl_logins
                            where p.user_id == txtUserId.Text.Trim()
                            select p;

                    if (q.Count() > 0)
                    {
                        MessageBox.Show("This user id is already taken.\n Please try with another id.");
                        txtUserId.Focus();
                    }
                    else
                    {
                        //using (TransactionScope Trans = new TransactionScope())
                        {
                            try
                            {
                                tbl_EmployeeInfo entry = new tbl_EmployeeInfo();
                                entry.Name = txtName.Text.Trim();
                                entry.Address = txtAddress.Text.Trim();
                                entry.ContactNo = txtContactNo.Text.Trim();
                                entry.ShopID = GlobalVariable.ShopID;

                                Int64 check = ClsEmployeeInfo.InsertEmployeeInfo(entry);
                                if (check > 0)
                                {
                                    tbl_login login = new tbl_login();
                                    login.EmployeeID = check;
                                    login.user_type = cmbEmployeeType.Text.Trim();
                                    login.password = txtPassword.Text.Trim();
                                    login.user_id = txtUserId.Text.Trim();
                                    Int64 checkLogin = ClsLogin.InsertAccountInfo(login);
                                    if (checkLogin > 0)
                                    {
                                        MessageBox.Show("Saved Successfully.");
                                        Clear();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                else // update
                {
                    if (txtAdminTypeCheck.Text != "admin")
                    {
                        int check = 0;
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            try
                            {
                                var q = from p in DB.tbl_EmployeeInfos
                                        where p.EmployeeID == EmployeeID
                                        select p;
                                foreach (tbl_EmployeeInfo entry in q)
                                {
                                    entry.Name = txtName.Text.Trim();
                                    entry.Address = txtAddress.Text.Trim();
                                    entry.ContactNo = txtContactNo.Text.Trim();
                                }
                                DB.SubmitChanges();

                                var r = from p in DB.tbl_logins
                                        where p.EmployeeID == EmployeeID
                                        select p;
                                foreach (tbl_login login in r)
                                {
                                    login.user_type = cmbEmployeeType.Text.Trim();
                                    login.password = txtPassword.Text.Trim();
                                }
                                DB.SubmitChanges();
                                Trans.Complete();
                                check = 1;
                            }
                            catch
                            {
                                check = 0;
                            }
                        }
                        if (check > 0)
                        {
                            MessageBox.Show("Updated Successfully.");
                            Clear();
                        }
                    }
                    else // user id and admin type should not be updated
                    {
                        int check = 0;
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            try
                            {
                                var q = from p in DB.tbl_EmployeeInfos
                                        where p.EmployeeID == EmployeeID
                                        select p;
                                foreach (tbl_EmployeeInfo entry in q)
                                {
                                    entry.Name = txtName.Text.Trim();
                                    entry.Address = txtAddress.Text.Trim();
                                    entry.ContactNo = txtContactNo.Text.Trim();
                                }
                                DB.SubmitChanges();

                                var r = from p in DB.tbl_logins
                                        where p.EmployeeID == EmployeeID
                                        select p;
                                foreach (tbl_login login in r)
                                {
                                    login.password = txtPassword.Text.Trim();
                                }
                                DB.SubmitChanges();
                                Trans.Complete();
                                check = 1;
                            }
                            catch
                            {
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
            }
            else
            {
                if (cmbEmployeeType.Text == "")
                {
                    MessageBox.Show("Please select Employee Type.");
                    cmbEmployeeType.Focus();
                }

                else if (txtName.Text == "")
                {
                    MessageBox.Show("Please Enter Employee Name.");
                    txtName.Focus();
                }
                else if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please Enter Contact Number.");
                    txtContactNo.Focus();
                }

            }
        }

       
        private void dgEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null )
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgEmployee.SelectedRows[0].Cells[0].Value != null)
                {
                    EmployeeID = Int64.Parse((dgEmployee.SelectedRows[0].Cells[0].Value.ToString()));
                    cmbEmployeeType.Text = dgEmployee.SelectedRows[0].Cells[1].Value.ToString();
                    txtName.Text = dgEmployee.SelectedRows[0].Cells[2].Value.ToString();                    
                    txtContactNo.Text = dgEmployee.SelectedRows[0].Cells[3].Value.ToString();
                    txtAddress.Text = dgEmployee.SelectedRows[0].Cells[4].Value.ToString();
                    txtUserId.Text = dgEmployee.SelectedRows[0].Cells[5].Value.ToString();
                    txtAdminTypeCheck.Text = dgEmployee.SelectedRows[0].Cells[5].Value.ToString();
                    txtPassword.Text = dgEmployee.SelectedRows[0].Cells[6].Value.ToString();
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtAdminTypeCheck.Text != "admin")
            {
                if (MessageBox.Show("Are You Sure To Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    int check = 0;
                    using (TransactionScope Trans = new TransactionScope())
                    {
                        try
                        {
                            EasySaleDataContext DB = new EasySaleDataContext();
                            var q = from p in DB.tbl_EmployeeInfos
                                    where p.EmployeeID == EmployeeID
                                    select p;
                            foreach (tbl_EmployeeInfo info in q)
                            {
                                DB.tbl_EmployeeInfos.DeleteOnSubmit(info);
                            }
                            DB.SubmitChanges();

                            var r = from p in DB.tbl_logins
                                    where p.EmployeeID == EmployeeID
                                    select p;
                            foreach (tbl_login info in r)
                            {
                                DB.tbl_logins.DeleteOnSubmit(info);
                            }
                            DB.SubmitChanges();

                            Trans.Complete();
                            check = 1;
                        }
                        catch
                        {
                            check = 0;
                        }
                    }
                    if (check > 0)
                    {
                        MessageBox.Show("Deleted Successfully");
                        Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Sorry, You can not Delete admin.");
            }
        }

        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtContactNo);
        }

        private void frmEmployeeManagement_KeyDown(object sender, KeyEventArgs e)
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
