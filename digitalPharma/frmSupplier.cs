using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digitalPharma.DAO;
using System.Text.RegularExpressions;
using digitalPharma.AccountSystem.DAO;
using System.Transactions;

namespace digitalPharma
{
    public partial class frmSupplier : Form
    {

        public frmSupplier()
        {
            InitializeComponent();
        }
        

        //private void ClearAll()
        //{
        //    txtAddress.Text = "";
        //    txtContactName.Text = "";
        //    txtContactNo.Text = "";
        //    txtSupplierID.Text = "";
        //    txtSupplierName.Text = "";
        //    //dgSupplier.Rows.Clear();
        //    CreateSupplierID();
        //    LoadDgSupplier();
        //}

        private void Clear()
        {
            txtAddress.Text = "";
            txtContactName.Text = "";
            txtContactNo.Text = "";
            txtSupplierName.Text = "";
            LoadDgSupplier();
            btnDelete.Enabled = false;
            btnSave.Text = "Save";
            GlobalVariable.SupplierID = 0;
        }
        private void LoadDgSupplier()
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var query = from p in DB.tbl_Suppliers
                        orderby p.SupplierName ascending
                        select p;
            if (query.Count() != 0)
            {
                dgSupplier.DataSource = query;
                dgSupplier.Columns[0].Visible = false;
                dgSupplier.Columns[1].HeaderText = "Supplier Name";
                dgSupplier.Columns[2].HeaderText = "Address";
                dgSupplier.Columns[3].HeaderText = "Contact No";
                dgSupplier.Columns[4].HeaderText = "Contact Person";
            }
            else
            {
                dgSupplier.DataSource = null;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSupplierName.Text != "" && txtAddress.Text != "" && txtContactNo.Text != "")
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                if (btnSave.Text == "Save")
                {

                    var query = from p in DB.tbl_Suppliers
                                where p.SupplierName == txtSupplierName.Text.Trim()
                                select p;
                    if (query.Count() == 0)
                    {
                        tbl_Supplier supplier = new tbl_Supplier();
                        supplier.SupplierName = txtSupplierName.Text.Trim();
                        supplier.ContactNo = txtContactNo.Text.Trim();
                        supplier.ContactPerson = txtContactName.Text.Trim();
                        supplier.Address = txtAddress.Text.Trim();
                        Int64 check = ClsSupplier.InsertSupplier(supplier);

                        if (check > 0)
                        {
                            //insert on Leadger Head
                            //check duplicate entry
                            var q = from p in DB.tbl_LedgerHeads
                                    where p.AccountName == txtSupplierName.Text.Trim() && p.SubGLID == ClsSubHead.GetSubHeadSingleInfoByName("Suppliers").SubGLID
                                    select p;
                            if (q.Count() == 0)
                            {

                                tbl_LedgerHead entry = new tbl_LedgerHead();
                                entry.GLID = 4000;
                                entry.SubGLID = ClsSubHead.GetSubHeadSingleInfoByName(GlobalVariable.SupplierSubHeadName).SubGLID;
                                entry.AccountName = check.ToString();
                                entry.AccountNo = frmHeadEntry.CreateAccountNo("4");
                                entry.Description = txtSupplierName.Text.Trim();

                                DB.tbl_LedgerHeads.InsertOnSubmit(entry);
                                DB.SubmitChanges();
                                check = 1;
                            }
                        }

                        if (check > 0)
                        {
                            MessageBox.Show("Saved Successfully.");
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Not Saved. Please Try Again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Supplier Name already Exists. \n Please Try with other names.");
                        txtSupplierName.Focus();
                    }
                }
                else // Update
                {
                    //Check Dupplicate name

                    tbl_Supplier CheckDupplicate = ClsSupplier.GetSupplierSingleInfoByName(txtSupplierName.Text.Trim());
                    var query = from p in DB.tbl_Suppliers
                                where p.SupplierName == txtSupplierName.Text.Trim() && p.SupplierID != GlobalVariable.SupplierID
                                select p;
                    if (query.Count() == 0)
                    {
                        tbl_Supplier supplier = new tbl_Supplier();
                        supplier.SupplierName = txtSupplierName.Text.Trim();
                        supplier.SupplierID = int.Parse(txtSupplierID.Text.Trim());
                        supplier.ContactNo = txtContactNo.Text.Trim();
                        supplier.ContactPerson = txtContactName.Text.Trim();
                        supplier.Address = txtAddress.Text.Trim();

                        Int64 check = ClsSupplier.UpdateSupplier(supplier);
                        if (check > 0)
                        {
                            MessageBox.Show("Updated Successfully.");
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Supplier Name already Exists. \n Please Try with other names.");
                        txtSupplierName.Focus();
                    }

                }
                
            }
            else
            {
                if (txtSupplierName.Text == "")
                {
                    MessageBox.Show("Please Enter Supplier Name.");
                    txtSupplierName.Focus();
                }                
                else if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please Enter Address.");
                    txtAddress.Focus();
                }
                else if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please Enter Contact Number.");
                    txtContactNo.Focus();
                }
            }
        }
        
        private void frmSupplier_Load(object sender, EventArgs e)
        {          
            LoadDgSupplier();
        }

        private void dgSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgSupplier.SelectedRows[0].Cells[0].Value != null)
                {
                    GlobalVariable.SupplierID = int.Parse(dgSupplier.SelectedRows[0].Cells[0].Value.ToString());

                    tbl_Supplier Supplier = ClsSupplier.GetSupplierSingleInfo(GlobalVariable.SupplierID);

                    if (Supplier != null)
                    {
                        txtSupplierName.Text = Supplier.SupplierName;
                        txtSupplierID.Text = Supplier.SupplierID.ToString();
                        txtAddress.Text = Supplier.Address;
                        txtContactNo.Text = Supplier.ContactNo;
                        txtContactName.Text = Supplier.ContactPerson;
                        btnSave.Text = "Update";
                        btnDelete.Enabled = true;
                    }

                }
            }
            catch
            { 
            
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.userType == "Admin")
            {
                if (MessageBox.Show("If You Delete This Supplier, \n All Debit Credit Information of this Supplier Will Be Deleted.\n Are You Sure To Delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Int64 check = 0;
                    using (TransactionScope Trans = new TransactionScope())
                    {
                        try
                        {
                            check = ClsSupplier.DeleteSupplier(GlobalVariable.SupplierID);

                            //delete Accounts info of this supplier
                            //// delete ledger head
                            EasySaleDataContext DB = new EasySaleDataContext();
                            var q = from p in DB.tbl_LedgerHeads
                                    where p.AccountName == GlobalVariable.SupplierID.ToString()
                                    select p;
                            foreach (tbl_LedgerHead head in q)
                            {
                                DB.tbl_LedgerHeads.DeleteOnSubmit(head);
                            }
                            DB.SubmitChanges();
                            //delete ledger
                            var r = from p in DB.tbl_Ledgers
                                    where p.AccountName == GlobalVariable.SupplierID.ToString()
                                    select p;
                            foreach (tbl_Ledger head in r)
                            {
                                DB.tbl_Ledgers.DeleteOnSubmit(head);
                            }

                            DB.SubmitChanges();
                            Trans.Complete();
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
                MessageBox.Show("You Have No Permission.");
            }

        }

        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            ClsGlobalClass.CheckTypeInLeaveForFloat(txtContactNo);
        }

        private void frmSupplier_KeyDown(object sender, KeyEventArgs e)
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
