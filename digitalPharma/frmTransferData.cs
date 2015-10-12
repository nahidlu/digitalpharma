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
using System.Web;
using AppSecure;


namespace digitalPharma
{
    public partial class frmTransferData : Form
    {
        public frmTransferData()
        {
            InitializeComponent();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                var q = (from p in DB.tbl_Worksheets
                         select p.CompanyName).Distinct();
                int check = 0;
                //using (TransactionScope Trans = new TransactionScope())
                //{
                try
                {
                    List<tbl_Supplier> worksheetList = new List<tbl_Supplier>();
                    foreach (var CompanyName in q)
                    {
                        tbl_Supplier entry = new tbl_Supplier();
                        entry.SupplierName = CompanyName;
                        DB.tbl_Suppliers.InsertOnSubmit(entry);
                        DB.SubmitChanges();
                    }

                    //DB.tbl_Suppliers.InsertAllOnSubmit(worksheetList);
                    // Trans.Complete();
                    check = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                // }
                if (check > 0)
                {
                    MessageBox.Show("Successful.");
                }
                else
                {
                    MessageBox.Show("Error!");

                }
            }
        }

        private void Category_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                var q = (from p in DB.tbl_Worksheets
                         select p.GenericNameAndStrength).Distinct();
                int check = 0;
                //using (TransactionScope Trans = new TransactionScope())
                //{
                try
                {
                    //List<tbl_Supplier> worksheetList = new List<tbl_Supplier>();
                    foreach (var Name in q)
                    {
                        tbl_ProductCategory entry = new tbl_ProductCategory();
                        entry.CategoryName = Name;
                        DB.tbl_ProductCategories.InsertOnSubmit(entry);
                        DB.SubmitChanges();
                    }

                    //DB.tbl_Suppliers.InsertAllOnSubmit(worksheetList);
                    // Trans.Complete();
                    check = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                // }
                if (check > 0)
                {
                    MessageBox.Show("Successful.");
                }
                else
                {
                    MessageBox.Show("Error!");

                }
            }
        }

        private void Product_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                var q = (from p in DB.tbl_Worksheets
                         where p.ProductUse == "Human"
                         select p);
                int check = 0;
              
                try
                {
                    int count = 0;
                   
                    foreach (var Name in q)
                    {
                        tbl_Product entry = new tbl_Product();
                        //count += 1;
                        entry.BarcodeNeeded = 0;
                        entry.CategoryID = ClsProductCategory.GetProductCategorySingleInfoByName(Name.GenericNameAndStrength).CategoryID;
                       // **********************//Description replace with id******************************
                        //entry.DosagesDescription = Name.DosagesDescription;
                        entry.ProductID = Name.ProductID.ToString();
                        entry.ProductName = Name.MedicineName;
                        entry.ProductUse = Name.ProductUse;
                        entry.SupplierID = ClsSupplier.GetSupplierSingleInfoByName(Name.CompanyName).SupplierID;

                        DB.tbl_Products.InsertOnSubmit(entry);
                        DB.SubmitChanges();
                        
                    }
                    
                   
                    check = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
              
                if (check > 0)
                {
                    MessageBox.Show("Successful.");
                }
                else
                {
                    MessageBox.Show("Error!");

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                var q = (from p in DB.tbl_Worksheets
                         select p.DosagesDescription).Distinct();
                int check = 0;
                using (TransactionScope Trans = new TransactionScope())
                {
                    try
                    {
                        foreach (var CompanyName in q)
                        {
                            tbl_DosagesDescription entry = new tbl_DosagesDescription();
                            entry.DosagesDescription = CompanyName;
                            DB.tbl_DosagesDescriptions.InsertOnSubmit(entry);
                            DB.SubmitChanges();
                        }

                        // DB.tbl_Suppliers.InsertAllOnSubmit(worksheetList);
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
                    MessageBox.Show("Successful.");
                }
                else
                {
                    MessageBox.Show("Error!");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            if (MessageBox.Show("Confirm?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EasySaleDataContext DB = new EasySaleDataContext();

                var q = (from p in DB.tbl_DosagesDescriptions
                         select p);
                int check = 0;
                //using (TransactionScope Trans = new TransactionScope())
                //{
                    try
                    {
                        foreach (var product in q)
                        {
                            
                            var r = from p in DB.tbl_Products
                                    where p.DosagesDescription == product.DosagesDescription
                                    select p;
                            foreach (tbl_Product update in r)
                            {
                                //tbl_DosagesDescription entry = new tbl_DosagesDescription();
                                update.DosagesID = product.DosagesID;
                                DB.SubmitChanges();
                            }
                        }

                        // DB.tbl_Suppliers.InsertAllOnSubmit(worksheetList);
                        //Trans.Complete();
                        check = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                //}
                if (check > 0)
                {
                    MessageBox.Show("Successful.");
                }
                else
                {
                    MessageBox.Show("Error!");

                }
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int check = 0;
                //using (TransactionScope Trans = new TransactionScope())
                {
                    EasySaleDataContext DB = new EasySaleDataContext();
                    var q = from p in DB.tbl_Suppliers
                            select p;
                    int AccountNO = 1;
                    foreach (tbl_Supplier sup in q)
                    {
                        try
                        {
                            tbl_LedgerHead entry = new tbl_LedgerHead();
                            entry.GLID = 4000;
                            entry.SubGLID = 9;
                            entry.AccountName = sup.SupplierID.ToString();
                            entry.AccountNo = 4000 + AccountNO;
                            entry.Description = sup.SupplierName;
                            AccountNO += 1;
                            DB.tbl_LedgerHeads.InsertOnSubmit(entry);
                            DB.SubmitChanges();
                            //Trans.Complete();
                            check = 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            check = 0;
                        }
                    }
                }

                if (check > 0)
                {
                    MessageBox.Show("Saved Successfully.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HardwareId hi = new HardwareId();
            string data = (hi.getUniqueID("C"));
            string encodedData = String.Empty;
            try
            {
                byte[] data_byte = Encoding.UTF8.GetBytes(data);
                encodedData = HttpUtility.UrlEncode(Convert.ToBase64String(data_byte));
            }
            catch (Exception exception)
            {
                //Log exception
            }
            //return encodedData;
            textBox1.Text = encodedData;

        }

        private void frmTransferData_Load(object sender, EventArgs e)
        {

        }
    }
}
