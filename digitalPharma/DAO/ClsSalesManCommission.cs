using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsSalesManCommission
    {
        public static Int64 InsertSalesManCommission(tbl_SalesManCommission entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_SalesManCommissions.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return entry.SN;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static Int64 UpdateSalesManCommission(tbl_SalesManCommission entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_SalesManCommissions
                            where p.SN == entry.SN
                            select p;
                foreach (tbl_SalesManCommission supplier in query)
                {
                    supplier.SalesDate = entry.SalesDate;
                    supplier.InvoiceNo = entry.InvoiceNo;
                    supplier.EmployeeID = entry.EmployeeID;
                    supplier.Amount = entry.Amount;
                }
                try
                {
                    DB.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static Int64 DeleteSalesManCommission(Int64  sn)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_SalesManCommissions
                            where p.SN == sn
                            select p;
                foreach (tbl_SalesManCommission supplier in query)
                {
                    DB.tbl_SalesManCommissions.DeleteOnSubmit(supplier);
                }
                try
                {
                    DB.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static Int64 InsertSalesManCommissionReport(tbl_TempSalesmanCommissionReport entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_TempSalesmanCommissionReports.InsertOnSubmit(entry);
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
