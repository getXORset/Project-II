using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_II
{
    //The Editor class makes it possible to edit items in the itemslist
    internal class Editor
    {
        private int transactionnumber; //indexnumber of a transaction
        private int typeOfChange; //shows the type of edit wanted by the user
        private string title; //the title of the transaction
        private decimal amount; //the amount of the transaction
        List<Item> itemslist; //The list with the items
        internal Editor(List<Item> itemslist)
        {
            this.itemslist = itemslist;
        }

        //In the method EditItem() the user can choice which item to edit and how to edit it and it gets edited
        internal void EditItem()
        {
            while(true)
            {
                Console.WriteLine("Choose which transaction to edit!");
                bool correctChoice = int.TryParse(Console.ReadLine(), out int value);
                if (correctChoice)
                {
                    if (value < 1 || value > itemslist.Count) // If the user gives any other digit than showed in the list
                    {
                        Console.WriteLine("You can only choose any of the transactions in the list!");
                        Console.WriteLine();
                    }
                    else // When the answer is correct
                    {
                        transactionnumber = value;
                        break;
                    }
                }
                else // If the user answers with anything else than an integer
                {
                    Console.WriteLine("You must answer with a digit!");
                    Console.WriteLine();
                }
            }
            while(true)
            {
                string menu = "1. Delete the transaction\n2. Change title\n3. Change amount";
                Console.WriteLine(menu);
                Console.WriteLine();
                Console.WriteLine("Choose alternative!");
                bool correctChoice = int.TryParse(Console.ReadLine(), out int value);
                if (correctChoice)
                {
                    if (value < 1 || value > 3) // If the user gives any other digit than showed in the list
                    {
                        Console.WriteLine("You can only choose any of the 3 alternatives in the menu!");
                        Console.WriteLine();
                    }
                    else // When the answer is correct
                    {
                        typeOfChange = value;
                        break;
                    }
                }
                else // If the user answers with anything else than an integer
                {
                    Console.WriteLine("You must answer with a digit!");
                    Console.WriteLine();
                }

            }
            Item item = itemslist[transactionnumber - 1];
            switch (typeOfChange)
            {
                case 1:
                    itemslist.RemoveAt(transactionnumber-1);
                    break;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("Enter the new title! (maximum 12 characters): ");
                        title = Console.ReadLine();
                        if (title.Length > 12)
                        {
                            Console.WriteLine();
                            Console.WriteLine("To many caracters!");
                        }
                        else { break; }
                    }
                    item.Title = title;
                    break;
                case 3:
                    while (true)
                    {
                        Console.WriteLine("Enter the new amount in SEK (maximum 12 characters): ");
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
                    item.Amount = amount;
                    break;
            }
        }
    }
}
