using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsProductCategory
    {
        public static Int64 InsertProductCategory(tbl_ProductCategory entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_ProductCategories.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return entry.CategoryID;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static Int64 UpdateProductCategory(tbl_ProductCategory entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_ProductCategories
                            where p.CategoryID == entry.CategoryID
                            select p;
                foreach (tbl_ProductCategory supplier in query)
                {
                    supplier.CategoryName = entry.CategoryName;
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

        public static int DeleteProductCategory(Int64  ProductCategoryID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_ProductCategories
                            where p.CategoryID ==  ProductCategoryID
                            select p;
                foreach (tbl_ProductCategory supplier in query)
                {
                    DB.tbl_ProductCategories.DeleteOnSubmit(supplier);
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

        public static List<tbl_ProductCategory> GetProductCategoryList()
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_ProductCategories
                           // orderby p.SN ascending
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

        public static tbl_ProductCategory GetProductCategorySingleInfo(Int64 ProductCategoryID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_ProductCategories
                            where p.CategoryID == ProductCategoryID
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
        public static tbl_ProductCategory GetProductCategorySingleInfoByName(string ProductCategoryName)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_ProductCategories
                            where p.CategoryName == ProductCategoryName
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
