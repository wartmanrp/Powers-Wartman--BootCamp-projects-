using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ParkingLot.Common
{
    public class Helper
    {
        public decimal? CalculateStayCost(DateTime StartStay, DateTime? EndStay)
        {
            //this method returns a staycost calculated based on the difference between two dates.
            if (EndStay != null)
            {
                TimeSpan ts = (DateTime)EndStay - StartStay;
                decimal diff = Convert.ToDecimal(ts.TotalHours);
                decimal cost = new Decimal();

                cost = diff * Convert.ToDecimal(1.5);
                return cost;
            }
            else
            {
                return null;
            }
        }
    }
}
