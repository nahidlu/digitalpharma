using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace digitalPharma.DAO
{
    class ClsGlobalClass
    {
        public static void CheckTypeInLeaveForFloat(TextBox Box)
        {
            if (Box.Text != "")
                try
                {
                    Box.ForeColor = Color.Black;
                    float.Parse(Box.Text);
                }
                catch
                {
                    MessageBox.Show("Wrong Input.");
                    Box.Focus();
                    Box.ForeColor = Color.Red;
                }
        }

        public static void CheckTypeInLeaveForInt(TextBox Box)
        {
            if (Box.Text != "")
                try
                {
                    Box.ForeColor = Color.Black;
                    int.Parse(Box.Text);

                }
                catch
                {
                    MessageBox.Show("Wrong Input.");
                    Box.Focus();
                    Box.ForeColor = Color.Red;
                }
        }
    }
}
