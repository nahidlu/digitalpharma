using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsRecentProductPrice
    {
        public static Int64 InsertRecentProductPrice(tbl_RecentProductPrice entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_RecentProductPrices.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return 1;
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

        public static tbl_RecentProductPrice GetProductInfoByID(string ProductID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_RecentProductPrices
                            where p.ProductID == ProductID
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


       
    }
}
