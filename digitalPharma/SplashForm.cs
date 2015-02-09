using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace digitalPharma
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            lblShopName.Text = ConfigurationManager.AppSettings["ShopName"];
            //lblShopName.Location =;
        }
    }
}
