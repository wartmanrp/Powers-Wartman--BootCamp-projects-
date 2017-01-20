using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Dto
{
    public class LotStayDto
    {
        public int LotStayKey { get; set; }
        public int CustomerKey { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int KeyCardKey { get; set; }
        public int ParkingSpotNumber { get; set; }
        public int ParkingLotNumber { get; set; }
        public DateTime StartStay { get; set; }
        public DateTime? EndStay { get; set; }
        public decimal? StayCost { get; set; }
        //maybe add this later
        //public List<int> Keys { get; set; }
    }
}
