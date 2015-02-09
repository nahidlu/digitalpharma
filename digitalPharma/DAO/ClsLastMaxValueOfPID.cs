using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace digitalPharma.DAO
{
    class ClsLastMaxValueOfPID
    {
        
       

        public static Int64 UpdateMaxValue(tbl_LastMaxValueOfPID entry)
        {
            EasySaleDataContext DB = new EasySaleDataContext();

            var q = from p in DB.tbl_LastMaxValueOfPIDs
                    where p.SN == entry.SN
                    select p;
            foreach (tbl_LastMaxValueOfPID val in q)
            {
                val.LastIdValue = entry.LastIdValue;
            }
            try
            {
                DB.SubmitChanges();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
        }
              
       
    }
}
