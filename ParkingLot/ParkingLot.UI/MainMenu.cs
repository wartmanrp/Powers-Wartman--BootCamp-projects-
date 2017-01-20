using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Service;


namespace ParkingLot.UI
{
    class MainMenu
    {
        public static void WriteMainMenu()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("   Please begin navigation by selection from the following options using the corresponding  ");
            Console.WriteLine("                        number, followed by the -ENTER- key.                                ");
            Console.WriteLine("");
            Console.WriteLine("\t 1. Customer Search");
            Console.WriteLine("\t 2. Add New Customer");
            Console.WriteLine("\t 3. Exit Application");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    SearchMenus.WriteCustomerSearchMenu();
                    break;

                case "2":
                    CustomerMenus.WriteAddCustomerMenu();
                    break;

                case "3":
                    Console.WriteLine("Are you sure? Hit enter twice to exit.");
                    Console.ReadKey();
                    break;

                default:        
                    Console.WriteLine("Please choose a valid option from the menu above!");
                    Console.ReadKey();
                    Console.Clear();
                    WriteMainMenu();
                    break;
            }
            Console.ReadLine();
        }
    }
}
