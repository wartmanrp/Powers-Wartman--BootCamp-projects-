using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Data;
using ParkingLot.Dto;

namespace ParkingLot.Service
{
    public class SearchService
    {
        //Search by customer key
        public CustomerDto CustomerSearchByKey(int i)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {
                var customer = db.Customers
                    .Where(c => c.IsDeleted == false)
                    .Select(c => new CustomerDto
                    {
                        CustomerKey = c.CustomerKey
                    ,
                        FirstName = c.FirstName
                    ,
                        LastName = c.LastName
                    ,
                        FullName = (c.FirstName + " " + c.LastName)
                    ,
                        Phone = c.Phone
                    ,
                        Email = c.Email
                    ,
                        Cell = c.Cell
                    }).FirstOrDefault(c => c.CustomerKey == i);

                return customer;
            }
        }

        //search by customer name or part
        public IEnumerable<CustomerDto> CustomerSearchByName(string input)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {
                var customers = db.Customers
                    .Where(c => c.IsDeleted == false)
                    .Select(c => new CustomerDto
                    {
                        CustomerKey = c.CustomerKey
                    ,
                        FirstName = c.FirstName
                    ,
                        LastName = c.LastName
                    ,
                        FullName = (c.FirstName + " " + c.LastName)
                    ,
                        Phone = c.Phone
                    ,
                        Email = c.Email
                    ,
                        Cell = c.Cell
                    }).Where(c => c.FirstName.Contains(input) || c.LastName.Contains(input) || c.FullName.Contains(input));
                return customers.ToList();
            }
        }
    }
}
