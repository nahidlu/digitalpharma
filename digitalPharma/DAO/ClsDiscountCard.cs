using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace digitalPharma.DAO
{
    class ClsDiscountCard
    {
        public static double GetDiscountAmount(string CardID, double CartTotal)
        {
            double DiscountAmount = 0;
            EasySaleDataContext DB = new EasySaleDataContext();
            var q = from p in DB.tbl_DiscountCards
                    where p.CardID == CardID && p.CardActivationDate.Value.Date <= DateTime.Now.Date
                    && p.CardExpiredDate.Value.Date >= DateTime.Now.Date && p.CardStatus == 1
                    select p;
            if (q.Count() > 0)
            {
                double DicountPercent = Convert.ToDouble(q.Single().DiscountPC.ToString());
                DiscountAmount = (DicountPercent * CartTotal) / 100;
            }
            else
            {
               // MessageBox.Show("This Card is not Valid or Expired.");
            }
            return DiscountAmount;
        }
    }
}
