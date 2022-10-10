using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project_II
{
    //The Adder class adds a new item to the itemslist
    internal class Adder
    {
        //The properties of the item
        DateTime date_transaction = DateTime.Now;
        string title;
        char sign;
        decimal amount;

        List<Item> itemslist; //The itemslist

        internal Adder(List<Item> itemslist)
        {
            this.itemslist = itemslist;
        }
        //The method RegisterItem() handles registration alternatives and input values from the user
        internal void RegisterItem()
        {

            while (true) // Loops the menu until the user gives a correct answer
            {
                Console.WriteLine("Would you like to register an income or an expense?");
                Console.WriteLine("1. Income\n2. Expense");
                Console.Write("Your choice: ");
                bool correctChoice = int.TryParse(Console.ReadLine(), out int value);
                if (correctChoice)
                {
                    if (value < 1 || value > 2) // If the user gives any other digit than showed in the menu
                    {
                        Console.WriteLine("You can only choose any of the 2 alternatives in the menu!");
                        Console.WriteLine();
                    }
                    else // When the answer is correct
                    {
                        int registerType = value;
                        switch (registerType)
                        {
                            case 1:
                                sign = '+';
                                buildItem(sign); //Builds an income item
                                break;
                            case 2:
                                sign = '-';
                                buildItem(sign); //Builds an expense item
                                break;
                        }
                        break;
                    }
                }
                else // If the user answers with anything else than an integer
                {
                    Console.WriteLine("You must answer with a digit (1 or 2)!");
                    Console.WriteLine();
                }
            }
        }
        //The method buildItem() builds the item and adds it to the itemslist
        private bool buildItem(char sign)
            {
            while (true)
            {
                Console.WriteLine("Enter title (maximum 12 characters): ");
                title = Console.ReadLine();
                if (title.Length > 12)
                {
                    Console.WriteLine();
                    Console.WriteLine("To many caracters!");
                }
                else { break; }
            }
            while (true)
            {
                Console.WriteLine("Enter the amount in SEK (maximum 12 characters): ");
                try
                {
                    amount = decimal.Parse(Console.ReadLine());
                    if (amount.ToString().Length > 12)
                    {
                        Console.WriteLine();
                        Console.WriteLine("To many caracters!");
                    }
                    else { break; }
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("Wrong format!");
                }
            }
            Item item = new Item(date_transaction, title, sign, amount); //Builds an item
            itemslist.Add(item); //Adds an item to the itemslist
            return true;
        }
    }
}
