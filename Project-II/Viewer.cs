using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_II
{
    //The Viewer class prints the itemslist as string lines in the console
    internal class Viewer
    {
        List<Item> itemslist;
        internal Viewer(List<Item> itemslist)
        {
            this.itemslist = itemslist;
        }

        //The method showItemsList() shows the itemslist in the console
        internal void showItemslist (List<Item> itemslist)
        {
            int number = 1; //The variable is used to index the transactions in the transactions list           

            //Parses the months number to the verbal abbreviation
            foreach (Item i in itemslist)
            {
                int month = i.Date_transaction.Month;
                string monthVerbal = "Jan";
                switch (month)
                {
                    case 1:
                       monthVerbal = "Jan";
                        break;
                    case 2:
                        monthVerbal = "Feb";
                        break;
                    case 3:
                        monthVerbal = "Mar";
                        break;
                    case 4:
                        monthVerbal = "Apr";
                        break;
                    case 5:
                        monthVerbal = "Mai";
                        break;
                    case 6:
                        monthVerbal = "Jun";
                        break;
                    case 7:
                        monthVerbal = "Jul";
                        break;
                    case 8:
                        monthVerbal = "Aug";
                        break;
                    case 9:
                        monthVerbal = "Sep";
                        break;
                    case 10:
                        monthVerbal = "Oct";
                        break;
                    case 11:
                        monthVerbal = "Nov";
                        break;
                    case 12:
                        monthVerbal = "Dec";
                        break;
                }
                //Writes the list to the console
                Console.WriteLine(number + "  " + monthVerbal.PadRight(6) + i.Title.PadRight(16) + i.Sign.ToString().PadRight(2) + i.Amount.ToString());
                number++;
            }
        }
       
        //The method showAssortedList() shows a menu with assortion alternatives and executes according to user's choice 
        internal void showAssortedList()
        {
            while (true)
            {
                //The assortion menu
                string menuAssortion = "1. Assort ascending by month\n2. Assort descending by month\n3. Assort ascending by title\n" +
                    "4. Assort descending by title\n5. Assort ascending by amount\n6. Assort descending by amount\n" +
                    "7. Show only incomes\n8. Show only expenses";
                Console.WriteLine();
                Console.WriteLine("Press any of the alternatives in the menu!");
                Console.WriteLine();
                Console.WriteLine(menuAssortion);
                int assortionChoice = Console.ReadKey(true).KeyChar;
                switch (assortionChoice)
                {
                    case ('1'):
                        Console.WriteLine();
                        Console.WriteLine("Assorted ascending by month");
                        Console.WriteLine();
                        List<Item> sortedDateAscending = itemslist.OrderBy(i => i.Date_transaction.Month).ThenBy(i => i.Title).ToList();
                        showItemslist(sortedDateAscending); //Calls method to print the assortion in the console
                        break;
                    case ('2'):
                        Console.WriteLine();
                        Console.WriteLine("Assorted descending by month");
                        Console.WriteLine();
                        List<Item> sortedDateDescending = itemslist.OrderByDescending(i => i.Date_transaction.Month).ThenBy(i => i.Title).ToList();
                        showItemslist(sortedDateDescending); //Calls method to print the assortion in the console
                        break;
                    case ('3'):
                        Console.WriteLine();
                        Console.WriteLine("Assorted ascending by title");
                        Console.WriteLine();
                        List<Item> sortedTitleAscending = itemslist.OrderBy(i => i.Title).ThenBy(i => i.Date_transaction.Month).ToList();
                        showItemslist(sortedTitleAscending); //Calls method to print the assortion in the console
                        break;
                    case ('4'):
                        Console.WriteLine();
                        Console.WriteLine("Assorted descending by title");
                        Console.WriteLine();
                        List<Item> sortedTitleDescending = itemslist.OrderByDescending(i => i.Title).ThenBy(i => i.Date_transaction.Month).ToList();
                        showItemslist(sortedTitleDescending); //Calls method to print the assortion in the console
                        break;
                    case ('5'):
                        Console.WriteLine();
                        Console.WriteLine("Assorted ascending by amount");
                        Console.WriteLine();
                        List<Item> sortedAmountAscending = itemslist.OrderBy(i => i.Amount).ThenBy(i => i.Date_transaction.Month).ToList();
                        showItemslist(sortedAmountAscending); //Calls method to print the assortion in the console
                        break;
                    case ('6'):
                        Console.WriteLine();
                        Console.WriteLine("Assorted descending by amount");
                        Console.WriteLine();
                        List<Item> sortedAmountDescending = itemslist.OrderByDescending(i => i.Amount).ThenBy(i => i.Date_transaction.Month).ToList();
                        showItemslist(sortedAmountDescending); //Calls method to print the assortion in the console
                        break;
                    case ('7'):
                        Console.WriteLine();
                        Console.WriteLine("Only incomes");
                        Console.WriteLine();
                        List<Item> onlyIncomes = new List<Item>();
                        foreach (Item item in itemslist)
                        {
                            if (item.Sign == '+')
                            {
                                onlyIncomes.Add(item);
                            }
                        }
                        showItemslist(onlyIncomes); //Calls method to print the assortion in the console
                        break;
                    case ('8'):
                        Console.WriteLine();
                        Console.WriteLine("Only expenses");
                        Console.WriteLine();
                        List<Item> onlyExpenses = new List<Item>();
                        foreach (Item item in itemslist)
                        {
                            if (item.Sign == '-')
                            {
                                onlyExpenses.Add(item);
                            }
                        }
                        showItemslist(onlyExpenses); //Calls method to print the assortion in the console
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("You can only choose one of the alternatives in the menu!");
                        continue;
                }
                Console.WriteLine();
                Console.Write("Press any key to continue!...");
                Console.ReadKey(true);
                break;
            }
        }
    }
}
