using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsSupplier
    {
        public static Int64 InsertSupplier(tbl_Supplier entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                try
                {
                    DB.tbl_Suppliers.InsertOnSubmit(entry);
                    DB.SubmitChanges();
                    return entry.SupplierID;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static Int64 UpdateSupplier(tbl_Supplier entry)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Suppliers
                            where p.SupplierID == entry.SupplierID
                            select p;
                foreach (tbl_Supplier supplier in query)
                {
                    supplier.SupplierName = entry.SupplierName;
                    supplier.Address = entry.Address;
                    supplier.ContactPerson = entry.ContactPerson;
                    supplier.ContactNo = entry.ContactNo;
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

        public static Int64 DeleteSupplier(int  SupplierID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Suppliers
                            where p.SupplierID == SupplierID
                            select p;
                foreach (tbl_Supplier supplier in query)
                {
                    DB.tbl_Suppliers.DeleteOnSubmit(supplier);
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

       
        public static tbl_Supplier GetSupplierSingleInfo(int SupplierID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Suppliers
                            where p.SupplierID == ( SupplierID)
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
        public static tbl_Supplier GetSupplierSingleInfoByName(string SupplierName)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_Suppliers
                            where p.SupplierName == SupplierName
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
