using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsPurchase
    {
        public static Int64 InsertPurchaseInvInfo(tbl_PurchaseInvInfo entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_PurchaseInvInfos.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
        
        public static Int64 UpdatePurchaseInvInfo(tbl_PurchaseInvInfo entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_PurchaseInvInfos
                            where p.InvoiceNo == entry.InvoiceNo
                            select p;
                foreach (tbl_PurchaseInvInfo supplier in query)
                {
                    supplier.Discount = entry.Discount;
                    supplier.InvTotal = entry.InvTotal;
                    supplier.InvoiceDate = entry.InvoiceDate;
                    supplier.ReceivedDate = entry.ReceivedDate;
                    supplier.CarryingCost = entry.CarryingCost;
                    supplier.SubTotal = entry.SubTotal;
                    supplier.SupplierID = entry.SupplierID;
                    supplier.TotalVat = entry.TotalVat;
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

        public static Int64 DeletePurchaseInvInfo(string InvoiceNo)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_PurchaseInvInfos
                            where p.InvoiceNo == InvoiceNo
                            select p;
                foreach (tbl_PurchaseInvInfo supplier in query)
                {
                    DB.tbl_PurchaseInvInfos.DeleteOnSubmit(supplier);
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
        public static tbl_PurchaseInvInfo GetPurchaseInvInfoSingle(string InvoiceNo)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_PurchaseInvInfos
                            where p.InvoiceNo == InvoiceNo
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
      
        public static Int64 InsertPurchaseProductInfo(tbl_PurchaseProductInfo entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_PurchaseProductInfos.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return entry.SN;
                }
                catch
                {
                    return 0;
                }
            }
        }
       

        public static Int64 DeletePurchaseProductInfo(string PID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_PurchaseProductInfos
                            where p.ProductID == PID
                            select p;
                foreach (tbl_PurchaseProductInfo supplier in query)
                {
                    DB.tbl_PurchaseProductInfos.DeleteOnSubmit(supplier);
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
                
        public static tbl_PurchaseProductInfo GetPurchaseProductInfoSingle(string id)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_PurchaseProductInfos
                            where p.ProductID == id
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

        public static tbl_PurchaseProductInfo GetLastPurchaseProductInfo(string id)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_PurchaseProductInfos
                            where p.ProductID == id
                            select p.SN;
                if (query.Count() != 0)
                {
                    var r = from p in DB.tbl_PurchaseProductInfos
                            where p.SN == query.Max()
                            select p;
                    if (r.Count() > 0)
                        return r.Single();
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
        }
        

        public static tbl_PurchaseProductInfo GetPurchaseProductInfoByProductIdAndInvoiceNo(string id, string InvoiceNO)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_PurchaseProductInfos
                            where p.ProductID == id && p.InvoiceNo == InvoiceNO
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

        public static tbl_PurchaseProductInfo GetPurchaseProductInfoByProductIdAndInvoiceNoHidden(string id, string InvoiceNoHiddden)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_PurchaseProductInfos
                            where p.ProductID == id && p.InvoiceNoHidden == InvoiceNoHiddden
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
