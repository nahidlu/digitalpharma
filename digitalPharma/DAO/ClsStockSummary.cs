using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsStockSummary
    {
       public static int GetStockQuantityByProductID(string ProductID)
        {
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_StockSummaries
                        where p.ProductID == ProductID && p.ShopID == GlobalVariable.ShopID
                        select p.StockQty.Value;
                if (q.Count() > 0)
                {
                    return Convert.ToInt16(q.Sum());
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

       
    }
}
