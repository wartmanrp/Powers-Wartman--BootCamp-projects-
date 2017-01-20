using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Dto;
using ParkingLot.Data;
using ParkingLot.Common;
using System.Data.Entity;

namespace ParkingLot.Service
{
    public class CustomerService
    {
        //get details with transactions for specified customer
        public CustomerDto GetCustomerDetails(int i)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {
                LotStayService stays = new LotStayService();
                //FullNameService fname = new FullNameService();
                Customer c =
                 db.Customers.Where(cu => cu.IsDeleted == false)
                 .FirstOrDefault(cu => cu.CustomerKey == i);

                if (c == null)
                {
                    return null;
                }
                else
                {
                    CustomerDto custdto = new CustomerDto();
                    custdto.CustomerKey = c.CustomerKey;
                    custdto.FirstName = c.FirstName;
                    custdto.LastName = c.LastName;
                    custdto.FullName = (c.FirstName + " " + c.LastName);
                    custdto.Phone = c.Phone;
                    custdto.Email = c.Email;
                    custdto.Cell = c.Cell;
                    custdto.CustomerLotStays = stays.GetCustomerLotStayList(c.CustomerKey);

                    //return object
                    return custdto;
                }
            }
        }

        //instantiate new customer object and add to db
        public void AddNewCustomer (CustomerDto newcust)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {
                //set customer values via dto
                Customer Customer = db.Customers.Add(new Customer {
                    FirstName = newcust.FirstName
                    , LastName = newcust.LastName
                    , Phone = newcust.Phone
                    , Email = newcust.Email
                    , Cell = newcust.Cell
                    , IsDeleted = false 
                });
                db.SaveChanges();

                //create new keycard for customer
                KeyCard KeyCard = db.KeyCards.Add(new KeyCard
                {
                    CustomerKey = Customer.CustomerKey
                });

                db.SaveChanges();
            }
        }

        //edits a customer
        public static void EditCustomer (CustomerDto customer)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {

                Customer editedcustomer = new Customer();
                editedcustomer.CustomerKey = customer.CustomerKey;

                db.Customers.Attach(editedcustomer);
                    editedcustomer.FirstName = customer.FirstName;
                    editedcustomer.LastName = customer.LastName;
                    editedcustomer.Phone = customer.Phone;
                    editedcustomer.Email = customer.Email;
                    editedcustomer.Cell = customer.Cell;
                    editedcustomer.IsDeleted = false;

                db.SaveChanges();
            }
        }

        //soft deletes a customer
        public static void DeleteCustomer (int c)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {
                var customer = 
                    db.Customers
                    .FirstOrDefault(u => u.CustomerKey.Equals(c));
                customer.IsDeleted = true;

                db.SaveChanges();
            }
        }
    }
}

