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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void SaveLoginHistory()
        {
            
        }
        private void login()
        {
            if (txtUserId.Text != "" && TxtPassword.Text != "" && cmbShop.Text != "" && cmbCounterNo.Text != "")
            {
                tbl_login SingleRecord = ClsLogin.GetSingleRecord(txtUserId.Text.Trim(), TxtPassword.Text.Trim());
                if (SingleRecord != null)
                {
                    GlobalVariable.userID = txtUserId.Text.Trim();
                    GlobalVariable.ShopName = cmbShop.Text.Trim();
                    GlobalVariable.ShopID = int.Parse(cmbShop.SelectedValue.ToString());
                    GlobalVariable.CounterNo = cmbCounterNo.Text.Trim();
                    tbl_Shop ShopInfo = ClsShop.GetShopInfo(GlobalVariable.ShopID);
                    GlobalVariable.Address1 = ShopInfo.Address1;
                    GlobalVariable.Address2 = ShopInfo.Address2;
                    GlobalVariable.Phone = ShopInfo.ContactNo;
                    GlobalVariable.Slogan = ShopInfo.Slogan;
                    EasySaleDataContext fms = new EasySaleDataContext();
                    var query = from user in fms.tbl_logins
                                where user.user_id == txtUserId.Text.Trim()
                                select user;
                    foreach (tbl_login item in query)
                    {
                        GlobalVariable.userType = item.user_type;
                    }

                    tbl_LoginHistory entry = new tbl_LoginHistory();
                    entry.StartTime = DateTime.Now;
                    entry.EmployeeID = SingleRecord.EmployeeID;// Int64.Parse(SingleRecord.EmployeeID);
                    Int64 check = ClsLoginHistory.InsertLoginHistry(entry);

                    if (check > 0)
                    {
                        frmMain obj = new frmMain();
                        obj.Show();
                        this.Hide();
                        if (GlobalVariable.userType == "Sales Man")
                        {
                            frmSubMenuForSalesMan sub = new frmSubMenuForSalesMan();
                            sub.MdiParent = obj;
                            sub.Show();
                        }
                        else
                        {
                            frmSubMenu sub = new frmSubMenu();
                            sub.MdiParent = obj;
                            sub.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password.");
                }
            }
            else
            {
                if (cmbShop.Text == "")
                {
                    MessageBox.Show("Please Select Shop.");
                    cmbShop.Focus();
                }
                else if (cmbCounterNo.Text == "")
                {
                    MessageBox.Show("Please Select Counter No.");
                    cmbCounterNo.Focus();
                }
                else if (txtUserId.Text == "")
                {
                    MessageBox.Show("Please Enter User ID.");
                    txtUserId.Focus();
                }
                else if (TxtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Password.");
                    TxtPassword.Focus();
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void LoadCounterNO()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var q = from p in DB.tbl_CounterNos
                    select p;
            if (q.Count() > 0)
            {
                cmbCounterNo.Items.Clear();
                foreach (tbl_CounterNo no in q)
                {
                    cmbCounterNo.Items.Add(no.CounterNo);
                }
                cmbCounterNo.SelectedIndex = 0;
            }
            else
            {
                cmbCounterNo.Items.Clear();
            }
        }

        private void LoadShop()
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var q = from p in DB.tbl_Shops
                    select new { name = p.ShopName, id = p.ShopID };
            if (q.Count() > 0)
            {

                 cmbShop.DataSource = null;
                 cmbShop.DataSource = q;

                 cmbShop.ValueMember = "id";
                 cmbShop.DisplayMember = "name";
                 cmbShop.SelectedIndex = 0;  
            }
            else
            {
                cmbShop.DataSource = null;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {            
            LoadCounterNO();
            LoadShop();
            lblShopName.Text = cmbShop.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbShop_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void cmbCounterNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

    }
}
