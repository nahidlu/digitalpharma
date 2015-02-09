using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsCustomer
    {
        public static string[] GetCustomerNameAndMobileNoByCardID(string CardID)
        {
            string[] allInfo = new string[2];
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_Customers
                    where p.DiscountCardID == CardID
                    select p;
            if (q.Count() > 0)
            {
                allInfo[0] = q.Single().CustomerName;
                allInfo[1] = q.Single().MobileNo;
                return allInfo;
            }
            else
            {
                return null;
            }
        }

        public static Int64 GetCustomerIDByCardID(string CardID)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_Customers
                    where p.DiscountCardID == CardID
                    select p;
            if (q.Count() > 0)
            {
                Int64 CustomerID = q.Single().CustomerID;
                return CustomerID;
            }
            else
            {
                return 0;
            }
        }
    }
}
