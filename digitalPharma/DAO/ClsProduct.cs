using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace digitalPharma.DAO
{
    class ClsProduct
    {
        public static Int64 InsertProductName(tbl_Product entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_Products.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return entry.SN;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static Int64 UpdateProductName(tbl_Product entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Products
                            where p.SN == entry.SN
                            select p;
                foreach (tbl_Product supplier in query)
                {
                    supplier.CategoryID = entry.CategoryID;
                    supplier.ProductName = entry.ProductName;
                    supplier.DosagesID = entry.DosagesID;
                    supplier.ProductUse = entry.ProductUse;
                    supplier.SupplierID = entry.SupplierID;
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

        public static int DeleteProductName(Int64  SN)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Products
                            where p.SN == SN
                            select p;
                foreach (tbl_Product supplier in query)
                {
                    DB.tbl_Products.DeleteOnSubmit(supplier);
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


        public static int DeleteProductNameByCategoryID(Int64 CategoryID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Products
                            where p.CategoryID == CategoryID
                            select p;
                foreach (tbl_Product supplier in query)
                {
                    DB.tbl_Products.DeleteOnSubmit(supplier);
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

        //this function is not necessay remove
        public static List<tbl_Product> GetProductNameList()
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Products
                            orderby p.SN ascending
                            select p;
                if(query.Count()!=0)
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public static tbl_Product GetProductNameSingleInfo(Int64 SN)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Products
                            where p.SN == SN
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

        public static tbl_Product GetProductInfoByID(string ID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Products
                            where p.ProductID == ID
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

        public static string GetProductIDByName(string name)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Products
                            where p.ProductName == name
                            select p.ProductID;
                if (query.Count() != 0)
                {
                    return query.ToString(); ;
                }
                else
                {
                    return null;
                }
            }
        }

        public static string[] GetProductNameAndCategoryNameByID(string ProductID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = (from p in DB.tbl_Products
                             from q in DB.tbl_ProductCategories
                             where p.ProductID == ProductID && p.CategoryID == q.CategoryID
                             select new { ProductName = p.ProductName, CategoryName=q.CategoryName });
                if (query.Count() != 0)
                {
                    string[] AllInfo = new string[2];
                    AllInfo[0] = query.Single().ProductName;
                    AllInfo[1] = query.Single().CategoryName;
                    return AllInfo;
                }
                else
                {
                    return null;
                }

            }
        }
        
        public static bool CheckIsDuplicatId(string ProductID)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var r = from p in DB.tbl_Products
                    where p.ProductID == ProductID
                    select p;

            if (r.Count() == 0)
                return false;
            else
                return true;
        }

        public static bool CheckIsDuplicatName(string ProductName)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_Products
                    where p.ProductName == ProductName
                    select p;

            if (q.Count() == 0)
                return false;
            else
                return true;
        }

        
        public static void  GetIDandLastValue(out int LastValue, out string ProductID, out int SN)
        {
            string month = "", day = "";
            if (Convert.ToDouble(DateTime.Now.Month.ToString()) < 10)
            {
                month = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                month = DateTime.Now.Month.ToString();
            }
            if (Convert.ToDouble(DateTime.Now.Day.ToString()) < 10)
            {
                day = "0" + DateTime.Now.Day.ToString();
            }
            else
            {
                day = DateTime.Now.Day.ToString();
            }
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_LastMaxValueOfPIDs
                    select p;
            LastValue= int.Parse(q.First().LastIdValue.ToString()) + 1;
            ProductID = DateTime.Now.Year.ToString().Substring(2) + month + day + LastValue.ToString();
            SN = int.Parse(q.First().SN.ToString());               
        }
    }
}
