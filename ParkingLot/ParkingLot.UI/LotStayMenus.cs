using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Dto;
using ParkingLot.Service;

namespace ParkingLot.UI
{
    public class LotStayMenus
    {
        //View Lot stay details
        public static void WriteLotStayDetailsMenu(int l, int c)
        {
            Console.Clear();
            LotStayService stayservice = new LotStayService();
            LotStayDto stay = stayservice.GetLotStayDetails(l, c);

            Console.Clear();
            Console.WriteLine("|*******************************************************************************************");
            Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|");
            Console.WriteLine("|         Here is the customer detail for your selected transaction. Please review your     ");
            Console.WriteLine("|          navigation options below the transaction details and enter the desired           ");
            Console.WriteLine("|                             choice, followed by -ENTER-.                                  ");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("============================================================================================");
            Console.WriteLine("");

            if(stay != null)
            {
                Console.WriteLine("<> <> <> <> <> <> <> <> <> <> <>  Customer:" + stay.CustomerFirstName + " " + stay.CustomerLastName + "  <> <> <> <> <> <> <> <> <> <> <> ");
                Console.WriteLine("");
                Console.WriteLine("|Key:   {0} \t \t  |Key Card Key: {1} \t |Spot Number: {2} \t |Lot Number: {3}"
                    , stay.LotStayKey
                    , stay.KeyCardKey
                    , stay.ParkingSpotNumber
                    , stay.ParkingLotNumber);
                Console.WriteLine("|___________________________________________________________________________________________");
                Console.WriteLine("|Start Stay: {0}  |EndStay:  {1}   |Stay Cost: {2} \t"
                    , stay.StartStay
                    , stay.EndStay
                    , "$" + stay.StayCost.ToString()                    
                    );
                Console.WriteLine("|===========================================================================================");
                Console.WriteLine("|");
                Console.WriteLine("|A: Edit LotStay Info");
                Console.WriteLine("|B: Delete LotStay");
                Console.WriteLine("|C: Back to Customer Detail");
                Console.WriteLine("|D: Go to Customer Search");
                Console.WriteLine("|Any Key: Go to Main Menu");

                var selection = Console.ReadLine();

                switch (selection.ToLower())
                {
                    case "a":
                        WriteEditLotStayMenu(stay.LotStayKey, stay.CustomerKey);
                        break;
                    case "b":
                        WriteDeleteLotStayMenu(stay);
                        break;
                    case "c":
                        CustomerMenus.WriteCustomerDetailMenu(stay.CustomerKey);
                        break;
                    case "d":
                        SearchMenus.WriteCustomerSearchMenu();
                        break;
                    default:
                        MainMenu.WriteMainMenu();
                            break;
                }
            } else
            {
                SearchMenus.WriteErrorNoMatchMenu();
            }

        }
        
        //print gui for adding new from blank
        public static void WriteAddLotStayMenu(int c)
        {
            LotStayService stayservice = new LotStayService();
            Console.Clear();
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("   This interface allows you to add a new Lot Stay for the customer you were just viewing.  ");
            Console.WriteLine("       Simply input the requested information and follow the prompts. When you are done     ");
            Console.WriteLine("          you will be redirected to the Customer Details for the customer of the new        ");
            Console.WriteLine("                   transaction in order to confirm input or continue                        ");
            Console.WriteLine("");

            LotStayDto newstay = new LotStayDto();

            DateTime date = DateTime.Now;
            Console.WriteLine("Input StartStay(must be in the format: 'M/DD/YYYY HH:MM:SS AM')");
            string start = Console.ReadLine();

            //check datetime format
            while(DateTime.TryParse(start, out date) != true)
            {
                Console.WriteLine("StartStay must be in the format: M/DD/YYYY HH:MM:SS AM'");
                start = Console.ReadLine();
            }

            //assign startstay value to dto
            newstay.StartStay = DateTime.Parse(start);

            //endstay
            Console.WriteLine("Input EndStay must be in the format: 'M/DD/YYYY HH:MM:SS AM')");
            string end = Console.ReadLine();
            
            //check datetime format
            if(end != "")
            {
                while (DateTime.TryParse(end, out date) != true)
                {
                    Console.WriteLine("EndStay must be in the format: 'M/DD/YYYY HH:MM:SS AM'");
                    end = Console.ReadLine();
                }

                //check to ensure end comes after start
                while (!(DateTime.Parse(end) > newstay.StartStay))
                {
                    Console.WriteLine("EndStay must be later than start stay");
                    end = Console.ReadLine();
                }

               //assign endstay value to dto
                newstay.EndStay = DateTime.Parse(end);
            } else
            {
                newstay.EndStay = null;
            }

            //keycard
            newstay.KeyCardKey = stayservice.GetKeyCard(c);
            newstay.CustomerKey = c;
            //parking spot
            Console.WriteLine("ParkingSpotNumber, must be an integer greater than 0.");
            int spot;
            string s = Console.ReadLine();

            //validate input as integer
            while (int.TryParse(s, out spot) != true)
            {
                Console.WriteLine("ParkingSpotNumber, must be an integer greater than 0.");
                s = Console.ReadLine();
            }
            newstay.ParkingSpotNumber = int.Parse(s);

            //save and submit
            Console.WriteLine("Hit -ENTER- to Save and Sumbit");
            Console.ReadLine();
            stayservice.AddLotStay(newstay);
            CustomerMenus.WriteCustomerDetailMenu(c);
        }

        //print gui for editing existing lotstay
        public static void WriteEditLotStayMenu(int l, int c)
        {
            LotStayService stayservice = new LotStayService();
            Console.Clear();
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("      This interface allows you to edit the Lot Stay you have selected. Input the requested ");
            Console.WriteLine("        information and follow the prompts. When you are done  you will be redirected       ");
            Console.WriteLine("          to the LotStay Details for the new transaction in order to confirm input          ");
            Console.WriteLine("                           and either edit again, or continue                               ");
            Console.WriteLine("");

            LotStayDto editedLotStay = new LotStayDto();
            LotStayDto originalLotStay = stayservice.GetLotStayDetails(l, c);
            editedLotStay.LotStayKey = originalLotStay.LotStayKey;
            //startstay
            Console.WriteLine("Edit StartStay, must be in the format: 'M/DD/YYYY HH:MM:SS AM')");
            Console.WriteLine(originalLotStay.StartStay);
            DateTime date = DateTime.Now;
            string start = Console.ReadLine();

            //check datetime format
            while(DateTime.TryParse(start, out date) != true)
            {
                Console.WriteLine("StartStay must be in the format: M/DD/YYYY HH:MM:SS AM'");
                start = Console.ReadLine();

            }

            //assign startstay value to dto
            editedLotStay.StartStay = DateTime.Parse(start);

            //endstay
            Console.WriteLine("Edit EndStay, must be in the format: 'M/DD/YYYY HH:MM:SS AM')");
            Console.WriteLine(originalLotStay.EndStay);
            string end = Console.ReadLine();

            //validate the datetime format
            if(end != "")
            {
                while(DateTime.TryParse(end, out date) != true)
                {
                    Console.WriteLine("EndStay must be in the format: 'M/DD/YYYY HH:MM:SS AM')");
                    end = Console.ReadLine();
                }

                //check to ensure end comes after start
                while (!(DateTime.Parse(end) > editedLotStay.StartStay))
                {
                    Console.WriteLine("EndStay must be later than start stay");
                    end = Console.ReadLine();
                }

                //assign endstay to dto
                editedLotStay.EndStay = DateTime.Parse(end);
            } else
            {
                editedLotStay.EndStay = null;
            }
            

            //keycard
            editedLotStay.KeyCardKey = originalLotStay.KeyCardKey;

            //customerkey
            editedLotStay.CustomerKey = originalLotStay.CustomerKey;

            //parking spot
            Console.WriteLine("Edit the ParkingSpotNumber, must be an integer greater than 0.");
            Console.WriteLine(originalLotStay.ParkingSpotNumber);
            int spot;
            string s = Console.ReadLine();

            //validate input as integer
            while(int.TryParse(s, out spot) != true)
            {
                Console.WriteLine("ParkingSpotNumber must be an integer greater than 0.");
                s = Console.ReadLine();
            }

            //assign to dto
            editedLotStay.ParkingSpotNumber = int.Parse(s);

            //save and submit
            Console.WriteLine("Hit -ENTER- to Save and Sumbit");
            Console.ReadLine();
            stayservice.EditLotStay(editedLotStay);
            WriteLotStayDetailsMenu(editedLotStay.LotStayKey, editedLotStay.CustomerKey);
        }
        
        //write menu to confirm deletion of lotstay
        public static void WriteDeleteLotStayMenu(LotStayDto lotstay)
        {
            Console.Clear();
            Console.WriteLine("|*******************************************************************************************");
            Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Welcome to Powers' Park-n-Go~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|");
            Console.WriteLine("|         You have selected to delete a Lot Stay for " + lotstay.CustomerFirstName + " " + lotstay.CustomerLastName + " from the system. If");
            Console.WriteLine("|             you have reached this menu in error, please stop, press -0- and -ENTER- to    ");
            Console.WriteLine("|             return to the detail menu for the transaction in question. If you would like  ");
            Console.WriteLine("|               to confirm deletion press any key on your keyboard, followed by -ENTER-     ");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("============================================================================================");
            Console.WriteLine("");

            var selection = Console.ReadLine();

            switch (selection)
            {
                case "0":
                    WriteLotStayDetailsMenu(lotstay.LotStayKey, lotstay.CustomerKey);
                    break;
                default:
                    Console.WriteLine("Press Enter to confirm deletion of selected transaction, you cannot undo this. ");
                    Console.ReadLine();
                    Console.WriteLine("Are you sure? Press -ENTER- to finalize deletion...");
                    Console.ReadLine();
                    LotStayService.DeleteLotStay(lotstay.LotStayKey);
                    Console.Clear();
                    Console.WriteLine("You have deleted lotstay #" + lotstay.LotStayKey +", press any key to go to the main menu");
                    Console.ReadLine();
                    MainMenu.WriteMainMenu();
                    break;
            }
        }
    }
}
