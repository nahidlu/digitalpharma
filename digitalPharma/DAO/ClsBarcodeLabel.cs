using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsBarcodeLabel
    {
        public static string[] GetProductIDandInvoiceNoFromBarcode(string BarcodeLabel)
        {
            string ProductID = "";
            string InvoiceNO = "";
            string[] All = new string[2];
            ProductID = BarcodeLabel.Substring(0, BarcodeLabel.IndexOf(GlobalVariable.BarcodeCharacter));
            InvoiceNO = BarcodeLabel.Substring(BarcodeLabel.IndexOf(GlobalVariable.BarcodeCharacter) + 1);
            All[0] = ProductID;
            All[1] = InvoiceNO;
            return All;
        }
    }
}
