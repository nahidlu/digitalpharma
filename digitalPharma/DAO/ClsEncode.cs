using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace digitalPharma.DAO
{
    class ClsEncode
    {
        public static string GetEncodedData(string ID)
        {
            string EncodedData = "";        
            try
            {
                byte[] data_byte = Encoding.UTF8.GetBytes(ID);
                EncodedData = HttpUtility.UrlEncode(Convert.ToBase64String(data_byte));
            }
            catch (Exception exception)
            {
                //Log exception
            }

            return EncodedData;
        }
    }
}
