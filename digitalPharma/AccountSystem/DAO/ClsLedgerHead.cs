using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.AccountSystem.DAO
{
    class ClsLedgerHead
    {
        public static int GetSubGLIDByAccountNo(int AccountNO)
        {
            int SubGLID = 0;
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_LedgerHeads
                    where p.AccountNo == AccountNO
                    select p;
            if (q != null)
            {
                SubGLID = q.Single().SubGLID.Value;
            }            
            return SubGLID;
        }

        public static tbl_LedgerHead GetSingleLedgerHead(string AccountName)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_LedgerHeads
                    where p.AccountName == AccountName
                    select p;
            if (q != null)
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
