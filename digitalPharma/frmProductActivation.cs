using System;
using System.Collections.Generic;
using System.Management; //Need to manually add to the References
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using AppSecure;

namespace digitalPharma
{
    public partial class frmProductActivation : Form
    {
        public frmProductActivation()
        {
            InitializeComponent();
        }
        string getpassword;
        string regPath;
        public frmProductActivation(String passname, String path)
        {
            InitializeComponent();
            getpassword = passname;
            regPath = path;
        }

        public bool passwordEntry(String originalPass, String pass)
        {
            HardwareId hid = new HardwareId();
           string hardid = hid.getUniqueID("C");
           // MessageBox.Show(pass);
           // if (hid.getUniqueID("C") == pass)
           if (originalPass == hardid && hid.getUniqueID("C") == pass)
            {
                RegistryKey regkey = Registry.CurrentUser;
                regkey = regkey.CreateSubKey(regPath); //path

                if (regkey != null)
                {
                    regkey.SetValue("Password", pass); //Value Name,Value Data
                }
                return true;
            }
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if password true then send true			
            bool value = passwordEntry(getpassword,textBox1.Text);
            if (value ==true)
            {
                MessageBox.Show("Thank you for activation!","Activate",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Product Key is not valid! Please Enter a valid Product Key! or Contact Arrowsoft","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			//----------------------------------------------		
		
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //--------------activation
        //private string getUniqueID(string drive)
        //{
        //    if (drive == string.Empty)
        //    {
        //        //Find first drive
        //        foreach (DriveInfo compDrive in DriveInfo.GetDrives())
        //        {
        //            if (compDrive.IsReady)
        //            {
        //                drive = compDrive.RootDirectory.ToString();
        //                break;
        //            }
        //        }
        //    }

        //    if (drive.EndsWith(":\\"))
        //    {
        //        //C:\ -> C
        //        drive = drive.Substring(0, drive.Length - 2);
        //    }

        //    string volumeSerial = getVolumeSerial(drive);
        //    string cpuID = getCPUID();

        //    //Mix them up and remove some useless 0's
        //    return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        //}

        //private string getVolumeSerial(string drive)
        //{
        //    ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
        //    disk.Get();

        //    string volumeSerial = disk["VolumeSerialNumber"].ToString();
        //    disk.Dispose();

        //    return volumeSerial;
        //}

        //private string getCPUID()
        //{
        //    string cpuInfo = "";
        //    ManagementClass managClass = new ManagementClass("win32_processor");
        //    ManagementObjectCollection managCollec = managClass.GetInstances();

        //    foreach (ManagementObject managObj in managCollec)
        //    {
        //        if (cpuInfo == "")
        //        {
        //            //Get only the first CPU's ID
        //            cpuInfo = managObj.Properties["processorID"].Value.ToString();
        //            break;
        //        }
        //    }

        //    return cpuInfo;
        //}
        //---------
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
