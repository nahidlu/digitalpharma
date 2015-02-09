using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digitalPharma.DAO
{
    class ClsDosageDescription
    {
        public static tbl_DosagesDescription GetDosagesDescriptionSingleInfo(int ID)
        {
            using (EasySaleDataContext DB = new EasySaleDataContext())
            {
                var query = from p in DB.tbl_DosagesDescriptions
                            where p.DosagesID == ID
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
