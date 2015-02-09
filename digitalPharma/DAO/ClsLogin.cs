using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsLogin
    {
        public static tbl_login GetSingleRecord(string UserId, string Password)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_logins
                            where p.user_id == UserId &&
                                  p.password == Password
                            select p;
                if (query.Count() != 0)
                {
                    return query.Single();
                }
                else
                {
                    return null;
                }
            }
        }
        public static tbl_login CheckExistingID(string UserId)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_logins
                            where p.user_id == UserId
                            select p;
                if (query.Count() != 0)
                {
                    return query.Single();
                }
                else
                {
                    return null;
                }
            }
        }
        public static Int64 InsertAccountInfo(tbl_login entry)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                try
                {
                    fms.tbl_logins.InsertOnSubmit(entry);
                    fms.SubmitChanges();
                    return entry.EmployeeID;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static List<tbl_login> GetAllAccountInfo()
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                var query = from p in fms.tbl_logins
                            select p;
                if (query.Count() != 0)
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }

            }
        }
        public static tbl_login GetAccountSingelRecord(int autoID)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                var query = from p in fms.tbl_logins
                            where p.EmployeeID == autoID
                            select p;
                if (query.Count() != 0)
                {
                    return query.Single();
                }
                else
                {
                    return null;
                }
            }
        }
        public static Int64 updateAccountInfo(tbl_login entry)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                var query = from p in fms.tbl_logins
                            where p.EmployeeID == entry.EmployeeID
                            select p;
                foreach (tbl_login item in query)
                {
                    item.user_type = entry.user_type;
                    //item.user_id = entry.user_id;
                    item.password = entry.password;

                }
                try
                {
                    fms.SubmitChanges();
                    return entry.EmployeeID;
                }
                catch
                {
                    return 0;
                }

            }

        }
        public static int deleteAccountInfo(int autoTD)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                var query = from p in fms.tbl_logins
                            where p.EmployeeID == autoTD
                            select p;
                foreach (tbl_login SN in query)
                {
                    fms.tbl_logins.DeleteOnSubmit(SN);
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
