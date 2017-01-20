using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Dto
{
    public class CustomerDto
    {
        public int CustomerKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }

        //non-entity fields
        public IEnumerable<LotStayDto> CustomerLotStays { get; set; }


    }
}
