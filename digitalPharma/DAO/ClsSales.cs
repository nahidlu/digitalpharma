using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsSales
    {
        public static Int64 InsertSalesInfo(tbl_SalesInvInfo entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_SalesInvInfos.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return entry.SN;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static Int64 InsertSalesDetail(tbl_SalesProductInfo entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_SalesProductInfos.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return entry.SN;
                }
                catch
                {
                    return 0;
                }
            }
        }
       
    }
}
