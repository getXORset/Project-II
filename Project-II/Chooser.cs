using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_II
{
    // The Chooser class shows the menu for the user and transmits the user's choice, by reference.
    public class Chooser
    {
        //The method startMenu() shows the starting menu and handles the user's choice
        public bool startMenu(ref int choice, decimal balance)
        {
            Console.ForegroundColor = ConsoleColor.White; // White colour for the text
            Console.BackgroundColor = ConsoleColor.DarkBlue; // Darkblue colour for the texts background
            Console.Clear(); // Applies the colours to the whole screen
            while (true) // Loops the menu until the user gives a correct answer
            {
                string Menu = ">>Welcome to TrackMoney\n>>You have currently " + balance + " SEK on your account.\n" +
                    ">>Pick an option:\n>>(1) Show items (All/Expense(s)/Income(s))\n>>(2) Add New Expense/Income\n" +
                    ">>(3) Edit Item (edit/remove)\n>>(4) Save and Quit\n>>Your choice: ";
                Console.Write(Menu);
                bool correctChoice = int.TryParse(Console.ReadLine(), out int value);
                if (correctChoice)
                {
                    if (value < 1 || value > 4) // If the user gives any other digit than showed in the menu
                    {
                        Console.WriteLine("You can only choose any of the 4 alternatives in the menu!");
                        Console.WriteLine();
                    }
                    else // When the answer is correct
                    {
                        choice = value;
                        break;
                    }
                }
                else // If the user answers with anything else than an integer
                {
                    Console.WriteLine("You must answer with a digit (1-4)!");
                    Console.WriteLine();
                }
            }
            return true;
        }
    }
}
