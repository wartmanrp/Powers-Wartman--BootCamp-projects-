using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Dto;
using ParkingLot.Service;

namespace ParkingLot.UI
{
    public class SearchMenus
    {
        //Write the menu for performing a customer search by key or name
        public static void WriteCustomerSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("   Here you may search by customer name or customer Id (key) when you are ready to begin    ");
            Console.WriteLine("    type your search terms below and press -ENTER-. If you would like to go back to go      ");
            Console.WriteLine("                        back to the main menu, type -0- and -ENTER-                         ");
            Console.WriteLine("");
            Console.WriteLine("\t 0: Back to Main Menu ");
            Console.WriteLine("");
            Console.WriteLine("\t    Otherwise enter");
            Console.WriteLine("\t    your search below");

            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.Clear();
                MainMenu.WriteMainMenu();
            }
            else if (input == "")
            {
                Console.WriteLine("Please enter a search term, press any key to try again");
                Console.ReadLine();
                WriteCustomerSearchMenu();
                
            }
            {
                //This parses 'input' into an integer to search by customerkey
                int i = 0;
                string s = input;
                bool result = int.TryParse(s, out i);
                if (result != false)
                {
                    SearchMenus.WriteKeySearchResultsMenu(i);
                }
                else
                {
                    SearchMenus.WriteNameSearchResultsMenu(input);
                }
            }
            Console.ReadLine();
        }

        //key results menu
        public static void WriteKeySearchResultsMenu (int i)
        {
            //clear the console
            Console.Clear();
            Console.WriteLine("|*******************************************************************************************");
            Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|");
            Console.WriteLine("|       We found the following match, if this is the user you are looking for press         ");
            Console.WriteLine("|       the -ENTER- key to view the customers details and transactions. If you would        ");
            Console.WriteLine("|           like to return to the main menu, type -0- followed by -ENTER-. If you           ");
            Console.WriteLine("|           would like to search again type -1- followed by -ENTER-, any other input        ");
            Console.WriteLine("|           will progress to the user details for the customer you have selected            ");
            Console.WriteLine("|");
            Console.WriteLine("============================================================================================");

            //Define new search service by key
            SearchService KeySearch = new SearchService();
            CustomerDto customer = KeySearch.CustomerSearchByKey(i);

            //check result set for validity
            if (customer.Equals(null))
            {
                SearchMenus.WriteErrorNoMatchMenu();
            }
            else
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
                    Console.WriteLine("");
            }

            //validate input
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    MainMenu.WriteMainMenu();
                    break;
                case "1":
                    WriteCustomerSearchMenu();
                    break;
                default:
                    Console.ReadLine();
                    CustomerMenus.WriteCustomerDetailMenu(customer.CustomerKey);
                    break;
            }
        }

        //name results menu
        public static void WriteNameSearchResultsMenu(string input)
        {
            Console.Clear();
            Console.WriteLine("|*******************************************************************************************");
            Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|");
            Console.WriteLine("|       We found the following potential matches, if any of these are the customer you are  ");
            Console.WriteLine("|          looking for, type the displayed customer key, and the -ENTER- key to view the    ");
            Console.WriteLine("|           customers details and transactions. If you would like to return to the main     ");
            Console.WriteLine("|                             menu, type -0- followed by -ENTER-                            ");
            Console.WriteLine("|");
            Console.WriteLine("============================================================================================");

            SearchService NameSearch = new SearchService();
            IEnumerable<CustomerDto> NameSearchResults = NameSearch.CustomerSearchByName(input);
            if (NameSearchResults.Count().Equals(0) || NameSearchResults.Equals(null))
            {
                SearchMenus.WriteErrorNoMatchMenu();
            }
            else
            {
                foreach (CustomerDto customer in NameSearchResults)
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
                    Console.WriteLine("");
                }
            }

            //validate input
            int x = 0;
            string selection = Console.ReadLine();
            while (int.TryParse(selection, out x) != true)
            {
                Console.WriteLine("You have entered an incorrect value, please enter a positive");
                Console.WriteLine("integer matching the Customer Key you would like to view.");
                selection = Console.ReadLine();
            }

            if (selection == "0")
            {
                //go to main menu
                MainMenu.WriteMainMenu();
            }
            else
            {
                //writes customer detail menu using given customerkey
                CustomerMenus.WriteCustomerDetailMenu(int.Parse(selection), NameSearchResults);
            }
        }

        //Write this when input is incorrect or no matches found
        public static void WriteErrorNoMatchMenu()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("   Your search has returned 0 matches, or there was an error with your input.     ");
            Console.WriteLine("    Please pick an option below, enter the corresponding number, and -ENTER-      ");
            Console.WriteLine("                      if you would like to continue system use.                   ");
            Console.WriteLine("");
            Console.WriteLine("\t 1. Back to Customer Search");
            Console.WriteLine("\t 2. Main Menu");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    WriteCustomerSearchMenu();
                    break;

                case "2":
                    Console.Clear();
                    MainMenu.WriteMainMenu();
                    break;
                default:
                    Console.WriteLine("Please choose a valid option from the menu above!");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    WriteErrorNoMatchMenu();
                    break;
            }

        }
    }
}
