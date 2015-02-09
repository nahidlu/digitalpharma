using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsLoginHistory
    {
       
        
        public static Int64 InsertLoginHistry(tbl_LoginHistory entry)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                try
                {
                    fms.tbl_LoginHistories.InsertOnSubmit(entry);
                    fms.SubmitChanges();
                    return entry.SN;
                }
                catch
                {
                    return 0;
                }
            }
        }
        
        public static int deleteLoginHistry(int autoTD)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                var query = from p in fms.tbl_LoginHistories
                            where p.SN == autoTD
                            select p;
                foreach (tbl_LoginHistory SN in query)
                {
                    fms.tbl_LoginHistories.DeleteOnSubmit(SN);
                }
                try
                {
                    fms.SubmitChanges();
                    return autoTD;
                }
                catch
                {
                    return 0;
                }
            }
        }


    }
}
