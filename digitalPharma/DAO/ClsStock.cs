using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsStock
    {
        public static Int64 InsertStock(tbl_StockDetail entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_StockDetails.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return entry.SN;
                }
                catch
                {
                    return 0;
                }
            }
        }
       

        public static Int64 DeleteStock(string id)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_StockDetails
                            where p.ProductID == id
                            select p;
                foreach (tbl_StockDetail supplier in query)
                {
                    DB.tbl_StockDetails.DeleteOnSubmit(supplier);
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

        public static Int64 InsertTempStockReport(tbl_TempStockReport entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_TempStockReports.InsertOnSubmit(entry);
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
