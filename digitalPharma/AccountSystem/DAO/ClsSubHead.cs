using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.AccountSystem.DAO
{
    class ClsSubHead
    {
        public static string GetSubHeadName(int ID)
        {
            string Name = "";
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_SubHeads
                    where p.SubGLID == ID
                    select p;
            if (q != null)
            {
                Name = q.Single().SubHeadName;
            }            
            return Name;
        }

        public static tbl_SubHead GetSubHeadSingleInfoByName(string Name)
        {
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_SubHeads
                    where p.SubHeadName == Name
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
