using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Dto;
using ParkingLot.Service;

namespace ParkingLot.UI
{
    public class CustomerMenus
    {
        //Write menu for customer details, *Includes Transactions*
        public static void WriteCustomerDetailMenu(int i)
        {
                Console.Clear();
                Console.WriteLine("|*******************************************************************************************");
                Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("|");
                Console.WriteLine("|         Here is the customer detail for your selected customer. Please review your        ");
                Console.WriteLine("|          navigation options below the transaction printout and enter the desired          ");
                Console.WriteLine("|                             number, followed by -ENTER-.                                  ");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("============================================================================================");
                Console.WriteLine("");

                CustomerService DetailService = new CustomerService();
                CustomerDto customer = DetailService.GetCustomerDetails(i);

                if (customer != null)
                {
                    Console.WriteLine(">Key:   {0} \t \t  |First Name: {1} \t |Email: {2} \t"
                        , customer.CustomerKey
                        , customer.FirstName
                        , customer.Email);
                    Console.WriteLine("____________________________________________________________________________________________");
                    Console.WriteLine("|Phone: {0} \t  |Last Name:  {1} \t |Cell: {2} \t"
                        , customer.Phone
                        , customer.LastName
                        , customer.Cell);
                    Console.WriteLine("============================================================================================");
                    Console.WriteLine("                       Here are " + customer.FirstName + "'s transactions                   ");
                    Console.WriteLine("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
                    foreach (var tran in customer.CustomerLotStays)
                    {
                        Console.WriteLine(">Transaction Key:   {0} \t \t |Customer: {1} \t |Spot Number: {2} \t"
                            , tran.LotStayKey
                            , tran.CustomerFirstName + " " + tran.CustomerLastName
                            , tran.ParkingSpotNumber);
                        Console.WriteLine("============================================================================================");
                        Console.WriteLine("|Stay Start: {0} \t |Stay End: {1} |Stay Cost: {2} \t"
                            , tran.StartStay
                            , tran.EndStay
                            , tran.StayCost.ToString());
                        Console.WriteLine("____________________________________________________________________________________________");
                    }
                    Console.WriteLine("0: Go to Main Menu");
                    Console.WriteLine("A: New Transaction");
                    Console.WriteLine("B: Edit Customer Info");
                    Console.WriteLine("C: Delete Customer");
                    Console.WriteLine("D: Go to Customer Search");
                    Console.WriteLine("Otherwise enter a transaction key and -ENTER- to view transaction details");

                    string selection = Console.ReadLine();

                    switch (selection.ToLower())
                    {
                        case "0":
                            MainMenu.WriteMainMenu();
                            break;
                        case "a":
                            LotStayMenus.WriteAddLotStayMenu(customer.CustomerKey);
                            break;
                        case "b":
                            WriteEditCustomerMenu(customer);
                            break;
                        case "c":
                            CustomerMenus.WriteDeleteCustomerMenu(customer);
                            break;
                        case "d":
                            SearchMenus.WriteCustomerSearchMenu();
                            break;
                        default:
                            //parse input into valid int to grab lotstay details
                            int x = 0;
                            string s = selection;
                            while (int.TryParse(s, out x) != true)
                            {
                                Console.WriteLine("You have entered an incorrect value, please enter a positive");
                                Console.WriteLine("integer matching the Lot Stay Key you would like to view.");
                                s = Console.ReadLine();
                            }
                            LotStayMenus.WriteLotStayDetailsMenu(int.Parse(s), customer.CustomerKey);
                            break;
                    }
                }
                else
                {
                    SearchMenus.WriteErrorNoMatchMenu();
                }
            
        }

      //method overload for Customer details when coming from search to validate included customers
      public static void WriteCustomerDetailMenu(int i, IEnumerable<CustomerDto> customers)
      {
         //TODO fix this
         if (!(customers.Any(c => c.CustomerKey == i)))
         {
            SearchMenus.WriteErrorNoMatchMenu();
         }
         else
         {
            Console.Clear();
            Console.WriteLine("|*******************************************************************************************");
            Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|");
            Console.WriteLine("|         Here is the customer detail for your selected customer. Please review your        ");
            Console.WriteLine("|          navigation options below the transaction printout and enter the desired          ");
            Console.WriteLine("|                             number, followed by -ENTER-.                                  ");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("============================================================================================");
            Console.WriteLine("");

            CustomerService DetailService = new CustomerService();
            CustomerDto customer = DetailService.GetCustomerDetails(i);

            if (customer != null)
            {
               Console.WriteLine(">Key:   {0} \t \t  |First Name: {1} \t |Email: {2} \t"
                   , customer.CustomerKey
                   , customer.FirstName
                   , customer.Email);
               Console.WriteLine("____________________________________________________________________________________________");
               Console.WriteLine("|Phone: {0} \t  |Last Name:  {1} \t |Cell: {2} \t"
                   , customer.Phone
                   , customer.LastName
                   , customer.Cell);
               Console.WriteLine("============================================================================================");
               Console.WriteLine("                       Here are " + customer.FirstName + "'s transactions                   ");
               Console.WriteLine("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
               foreach (var tran in customer.CustomerLotStays)
               {
                  Console.WriteLine(">Transaction Key:   {0} \t \t |Customer: {1} \t |Spot Number: {2} \t"
                      , tran.LotStayKey
                      , tran.CustomerFirstName + " " + tran.CustomerLastName
                      , tran.ParkingSpotNumber);
                  Console.WriteLine("============================================================================================");
                  Console.WriteLine("|Stay Start: {0} \t |Stay End: {1} |Stay Cost: {2} \t"
                      , tran.StartStay
                      , tran.EndStay
                      , tran.StayCost.ToString());
                  Console.WriteLine("____________________________________________________________________________________________");
               }
               Console.WriteLine("0: Go to Main Menu");
               Console.WriteLine("A: New Transaction");
               Console.WriteLine("B: Edit Customer Info");
               Console.WriteLine("C: Delete Customer");
               Console.WriteLine("D: Go to Customer Search");
               Console.WriteLine("Otherwise enter a transaction key and -ENTER- to view transaction details");

               string selection = Console.ReadLine();

               switch (selection.ToLower())
               {
                  case "0":
                     MainMenu.WriteMainMenu();
                     break;
                  case "a":
                     LotStayMenus.WriteAddLotStayMenu(customer.CustomerKey);
                     break;
                  case "b":
                     WriteEditCustomerMenu(customer);
                     break;
                  case "c":
                     CustomerMenus.WriteDeleteCustomerMenu(customer);
                     break;
                  case "d":
                     SearchMenus.WriteCustomerSearchMenu();
                     break;
                  default:
                     //parse input into valid int to grab lotstay details
                     int x = 0;
                     string s = selection;
                     while (int.TryParse(s, out x) != true)
                     {
                        Console.WriteLine("You have entered an incorrect value, please enter a positive");
                        Console.WriteLine("integer matching the Lot Stay Key you would like to view.");
                        s = Console.ReadLine();
                     }
                     LotStayMenus.WriteLotStayDetailsMenu(int.Parse(s), customer.CustomerKey);
                     break;
               }
            }
            else
            {
               SearchMenus.WriteErrorNoMatchMenu();
            }
         }
      }

      //write menu to add new customer
      public static void WriteAddCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("   This interface allows you to add a new customer, or edit an existing one. If you have    ");
            Console.WriteLine("        navigated to this screen in order to edit an existing customer, the original        ");
            Console.WriteLine("        information will be displayed for reference, at the appropriate time and you        ");
            Console.WriteLine("                            simply need to edit as needed.                                  ");
            Console.WriteLine("");
            Console.WriteLine("============================================================================================");

            CustomerService customerservice = new CustomerService();
            CustomerDto newcust = new CustomerDto();

            //firstname
            Console.WriteLine("Enter the customer's first name, name must be less than 50 characters");
            newcust.FirstName = Console.ReadLine();
            while (newcust.FirstName.Length > 50)
            {
                Console.WriteLine("Customer's first name must be less than 50 characters, please try again");
                newcust.FirstName = Console.ReadLine();
            }

            //last name
            Console.WriteLine("Enter the customer's last name, name must be less than 50 characters");
            newcust.LastName = Console.ReadLine();
            while (newcust.LastName.Length > 50)
            {
                Console.WriteLine("Customer's last name must be less than 50 characters, please try again");
                newcust.LastName = Console.ReadLine();
            }

            //phone
            Console.WriteLine("Enter the customer's phone number, number must be less than 20 characters");
            newcust.Phone = Console.ReadLine();
            while (newcust.Phone.Length > 20)
            {
                Console.WriteLine("Customer's phone number must be less than 20 characters, please try again");
                newcust.Phone = Console.ReadLine();
            }

            //email
            Console.WriteLine("Enter the customer's email, address must be less than 50 characters");
            newcust.Email = Console.ReadLine();
            while (newcust.Email.Length > 50)
            {
                Console.WriteLine("Customer's email address must be less than 50 characters, please try again");
                newcust.Email = Console.ReadLine();
            }

            //cell
            Console.WriteLine("Enter the customer's cell number, number must be less than 20 characters");
            newcust.Cell = Console.ReadLine();
            while (newcust.Cell.Length > 20)
            {
                Console.WriteLine("Customer's cell number must be less than 20 characters, please try again");
                newcust.Cell = Console.ReadLine();
            }

            //save and submit
            Console.WriteLine("Hit -ENTER- to Save and Submit, you will be redirected to the main menu");
            Console.ReadLine();
            customerservice.AddNewCustomer(newcust);

            //return to home
            MainMenu.WriteMainMenu();
        }

        //write the menu to edit an existing customer
        public static void WriteEditCustomerMenu(CustomerDto customer)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("   This interface allows you to add a new customer, or edit an existing one. If you have    ");
            Console.WriteLine("        navigated to this screen in order to edit an existing customer, the original        ");
            Console.WriteLine("        information will be displayed for reference, at the appropriate time and you        ");
            Console.WriteLine("                            simply need to edit as needed.                                  ");
            Console.WriteLine("");
            Console.WriteLine("============================================================================================");
          

            CustomerService customerservice = new CustomerService();
            CustomerDto newcust = new CustomerDto();

            //firstname
            Console.WriteLine("Edit the customer's first name, name must be less than 50 characters");
            Console.WriteLine(customer.FirstName);
            newcust.FirstName = Console.ReadLine();
            while (newcust.FirstName.Length > 50)
            {
                Console.WriteLine("Customer's first name must be less than 50 characters, please try again");
                Console.WriteLine(customer.FirstName);
                newcust.FirstName = Console.ReadLine();
            }

            //last name
            Console.WriteLine("Edit the customer's last name, name must be less than 50 characters");
            Console.WriteLine(customer.LastName);
            newcust.LastName = Console.ReadLine();
            while (newcust.LastName.Length > 50)
            {
                Console.WriteLine("Customer's last name must be less than 50 characters, please try again");
                Console.WriteLine(customer.LastName);
                newcust.LastName = Console.ReadLine();
            }

            //phone
            Console.WriteLine("Edit the customer's phone number, number must be less than 20 characters");
            Console.WriteLine(customer.Phone);
            newcust.Phone = Console.ReadLine();
            while (newcust.Phone.Length > 20)
            {
                Console.WriteLine("Customer's phone number must be less than 20 characters, please try again");
                Console.WriteLine(customer.Phone);
                newcust.Phone = Console.ReadLine();
            }

            //email
            Console.WriteLine("Edit the customer's email, address must be less than 50 characters");
            Console.WriteLine(customer.LastName);
            newcust.Email = Console.ReadLine();
            while (newcust.Email.Length > 50)
            {
                Console.WriteLine("Customer's email address must be less than 50 characters, please try again");
                Console.WriteLine(customer.LastName);
                newcust.Email = Console.ReadLine();
            }

            //cell
            Console.WriteLine("Edit the customer's cell number, number must be less than 20 characters");
            Console.WriteLine(customer.Cell);
            newcust.Cell = Console.ReadLine();
            while (newcust.Cell.Length > 20)
            {
                Console.WriteLine("Customer's cell number must be less than 20 characters, please try again");
                Console.WriteLine(customer.Cell);
                newcust.Cell = Console.ReadLine();
            }

            //save and submit
            Console.WriteLine("Hit -ENTER- to Save and Submit, you will be redirected to the main menu");
            Console.ReadLine();
            customerservice.AddNewCustomer(newcust);
            MainMenu.WriteMainMenu();
        }

        //Write menu for confirming soft delete of customer
        public static void WriteDeleteCustomerMenu(CustomerDto customer)
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("|*******************************************************************************************");
            Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|");
            Console.WriteLine("|         You have selected to delete " + customer.FullName + " from the system. If you have reached    ");
            Console.WriteLine("|             this menu in error, please stop, press -0- and -ENTER- to return to           ");
            Console.WriteLine("|             the detail menu for the customer in question. If you would like to            ");
            Console.WriteLine("|                confirm deletion press any key on your keyboard, followed by -ENTER-       ");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("============================================================================================");
            Console.WriteLine("");

            var selection = Console.ReadLine();

            switch (selection)
            {
                case "0":
                    WriteCustomerDetailMenu(customer.CustomerKey);
                    break;
                default:
                    Console.WriteLine("Press Enter to confirm deletion of " + customer.FullName + ", you cannot undo this. ");
                    Console.ReadLine();
                    Console.WriteLine("Are you sure? Press -ENTER- to finalize deletion...");
                    Console.ReadLine();
                    CustomerService.DeleteCustomer(customer.CustomerKey);
                    Console.Clear();
                    Console.WriteLine("You have deleted " + customer.FullName +", press any key to go to the main menu");
                    Console.ReadLine();
                    MainMenu.WriteMainMenu();
                    break;
            }
        }
    }
}
