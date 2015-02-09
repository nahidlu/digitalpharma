using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.AccountSystem.DAO
{
    class ClsHead
    {
        public static string GetGLName(int ID)
        {
            string Name = "";
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_Heads
                    where p.GLID == ID
                    select p;
            if (q != null)
            {
                Name = q.Single().GLName;
            }            
            return Name;
        }
    }
}
