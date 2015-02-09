using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsEmployeeInfo
    {
        public static tbl_EmployeeInfo GetSingleRecord(Int64 UserId)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_EmployeeInfos
                            where p.EmployeeID == UserId 
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
        public static tbl_EmployeeInfo CheckExistingID(Int64 UserId)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_EmployeeInfos
                            where p.EmployeeID == UserId
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
        public static Int64 InsertEmployeeInfo(tbl_EmployeeInfo entry)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                try
                {
                    fms.tbl_EmployeeInfos.InsertOnSubmit(entry);
                    fms.SubmitChanges();
                    return entry.EmployeeID;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static List<tbl_EmployeeInfo> GetAllEmployeeInfo()
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                var query = from p in fms.tbl_EmployeeInfos
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
        public static tbl_EmployeeInfo GetEmployeeSingelRecord(int autoID)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                var query = from p in fms.tbl_EmployeeInfos
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
        public static Int64 updateEmployeeInfo(tbl_EmployeeInfo entry)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                var query = from p in fms.tbl_EmployeeInfos
                            where p.EmployeeID == entry.EmployeeID
                            select p;
                foreach (tbl_EmployeeInfo item in query)
                {
                    
                    item.Name = entry.Name;                    
                    item.Address = entry.Address;
                    item.ContactNo = entry.ContactNo;

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
        public static int deleteEmployeeInfo(Int64 autoTD)
        {
            using (EasySaleDataContext fms = new  EasySaleDataContext())
            {
                var query = from p in fms.tbl_EmployeeInfos
                            where p.EmployeeID == autoTD
                            select p;
                foreach (tbl_EmployeeInfo SN in query)
                {
                    fms.tbl_EmployeeInfos.DeleteOnSubmit(SN);
                }
                try
                {
                    fms.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }


    }
}
