using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsShop
    {
        public static tbl_Shop GetShopInfo(int ShopID)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_Shops
                    where p.ShopID == ShopID
                    select p;
            if (q.Count() > 0)
            {

                return q.Single();
            }
            else
            {
                return null;
            }
        }
    }
}
