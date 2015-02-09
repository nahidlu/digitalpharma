using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.IO;

namespace digitalPharma
{
    public partial class FrmDataBase : Form
    {
        string TDate;
        string day, month, year;
           
        public FrmDataBase()
        {
            InitializeComponent();
        }
       
         
        private void LoadName()
        {
           

            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@"d:\Pharmacy DB Backup"))
            {
                //TDate = DateTime.Today.Date.ToString().Substring(0, 8);
                day = DateTime.Now.Day.ToString();
                month = DateTime.Now.Month.ToString();
                year = DateTime.Now.Year.ToString();
                TDate = "-" + day + "-" + month + "-" + year;
                txtBshow.Text = ("Pharmacy" + TDate + ".bak").ToString();

            }
            else
            {
                Directory.CreateDirectory(@"d:\Pharmacy DB Backup");
                //TDate = DateTime.Today.Date.ToString().Substring(0, 8);
                day = DateTime.Now.Day.ToString();
                month = DateTime.Now.Month.ToString();
                year = DateTime.Now.Year.ToString();
                TDate = "-" + day + "-" + month + "-" + year;
                txtBshow.Text = ("Pharmacy" + TDate + ".bak").ToString();
            }
        }

        private void FrmDataBase_Load(object sender, EventArgs e)
        {
            loadfile();
            LoadName();

        }

        public void loadfile()
        {
            try
            {
                cmd1.Items.Clear();
                DirectoryInfo di = new DirectoryInfo("d:\\Pharmacy DB Backup\\");
                var directories = di.GetFiles("*", SearchOption.AllDirectories);

                foreach (FileInfo d in directories)
                {
                    cmd1.Items.Add(d);
                }
            }
            catch
            { 
               
            }
        }

        private void cmd1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (MessageBox.Show("Are You Sure To Restore Database? \nWarnning:  The System will be Restarted.", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cmd1.Text != "")
                    {
                        string SelectName = cmd1.Text;

                        if (File.Exists(@"d:\Pharmacy DB Backup\" + SelectName))
                        {
                            if (MessageBox.Show("Are you sure you restore?", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Connect SQL-----------

                                SqlConnection connect;
                                //string con = @"Data Source=.\SQLEXPRESS;Initial Catalog = master;Integrated Security = True;";
                                //@"Data Source=.\SQLEXPRESS;Initial Catalog=DB_Jewelry;Integrated Security=True";
                                connect = new SqlConnection(GlobalVariable.con);
                                connect.Open();
                                //-----------------------------------------------------------------------------------------

                                //Excute SQL----------------
                                SqlCommand command;

                                //for connection stop
                                command = new SqlCommand("ALTER DATABASE PharmacyDB SET Single_User WITH Rollback Immediate", connect);
                                command.ExecuteNonQuery();
                                ///
                                command = new SqlCommand("use master", connect);
                                command.ExecuteNonQuery();
                                command = new SqlCommand(@"restore database PharmacyDB from disk = 'd:\Pharmacy DB Backup\" + SelectName + "'With Replace", connect);
                                command.ExecuteNonQuery();
                                //--------------------------------------------------------------------------------------------------------
                                // For connection start
                                command = new SqlCommand("ALTER DATABASE PharmacyDB SET Multi_User WITH Rollback Immediate", connect);
                                command.ExecuteNonQuery();
                                connect.Close();

                                MessageBox.Show("Has been restored database", "Restoration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmd1.Text = "";
                                Application.Restart();
                            }
                        }
                        else
                            MessageBox.Show(@"Do not make any endorsement above (or is not in the correct path)", "Restoration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Select Backup File.");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            day = DateTime.Now.Day.ToString();
            month = DateTime.Now.Month.ToString();
            year = DateTime.Now.Year.ToString();
            TDate = "-" + day + "-" + month + "-" + year;

           
            bool bBackUpStatus = true;

            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@"d:\Pharmacy DB Backup"))
            {
               // TDate = DateTime.Today.Date.ToString().Substring(0, 8);
                //wcBackUp1
                if (File.Exists(@"d:\Pharmacy DB Backup\Pharmacy" + TDate + ".bak"))
                {
                    if (MessageBox.Show(@"Do you want to replace it?", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(@"d:\Pharmacy DB Backup\Pharmacy" + TDate + ".bak");
                    }
                    else
                        bBackUpStatus = false;
                }
            }
            else
                Directory.CreateDirectory(@"d:\Pharmacy DB Backup");

            if (bBackUpStatus)
            {
                //Connect to DB
                SqlConnection connect;
                //string con = @"Data Source=.\SQLEXPRESS;Initial Catalog=DB_Jewelry;Integrated Security=True";
                connect = new SqlConnection(GlobalVariable.con);
                connect.Open();
                //----------------------------------------------------------------------------------------------------

                //Execute SQL---------------
                SqlCommand command;
                string BName = "Pharmacy" + TDate + ".bak";           //d:\JewelryBackup\jewelry" + TDate + ".bak"
                command = new SqlCommand(@"backup database PharmacyDB to disk ='d:\Pharmacy DB Backup\" + BName + "' with init,stats=10", connect);
                command.ExecuteNonQuery();
                //-------------------------------------------------------------------------------------------------------------------------------

                connect.Close();

                MessageBox.Show("Database Backup has been successfull.", "Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadfile();
            }
        }

        private void txtBshow_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmDataBase_KeyDown(object sender, KeyEventArgs e)
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
