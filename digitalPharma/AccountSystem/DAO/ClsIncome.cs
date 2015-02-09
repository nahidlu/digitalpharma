using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace digitalPharma.AccountSystem.DAO
{
    class ClsIncome
    {
        public static DataTable GetIncomeHeadNameDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            try
            {
                EasySaleDataContext DB = new EasySaleDataContext();
                var q = from p in DB.tbl_LedgerHeads
                        where (p.GLID == 1000 && p.AccountNo != GlobalVariable.CashInHandAccountNo) || p.GLID == 2000
                        select p;//new { id = p.AccountNo, name = p.AccountName });
                foreach (var r in q)
                {
                    dt.Rows.Add(r.AccountNo, r.AccountName);
                }
            }
            catch
            {

            }
            return dt;
        }
    }
}
