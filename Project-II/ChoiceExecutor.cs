using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project_II
{
    //The ChoiceExecutor class executes the choice of the user
    internal class ChoiceExecutor
    {
        private int choice;
        List<Item> itemslist; //The list with the items


        internal ChoiceExecutor(int choice, List<Item> itemslist)
        {
            this.choice = choice;
            this.itemslist = itemslist;
        }
        //The Manager() method switches on the different user choices
        internal void Manager(Runner runner)
        {
            Viewer viewer = new Viewer(itemslist);
            Adder adder = new Adder(itemslist);
            Editor editor = new Editor(itemslist);
            Saver saver = new Saver(itemslist);
            switch (choice)
            {
                //The itemslist is written to the console
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("VIEWER");
                    Console.WriteLine();
                    viewer.showItemslist(itemslist);
                    Console.WriteLine();
                    Console.Write("Press any key to continue!...");
                    Console.ReadKey(true);
                    Console.WriteLine();
                    Console.WriteLine("Press 'y' to assort the list! Any other key to continue!");
                    int yes = Console.ReadKey(true).KeyChar.CompareTo('y'); //When the return-value equals 0, the answer is 'y'
                    if (yes == 0)
                    {
                        viewer.showAssortedList(); // Call of the method which assorts
                    } 
                    runner.Start(runner, itemslist); //To start all over again
                    break;
                //A new item gets added to the itemslist
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("ADDER");
                    adder.RegisterItem();
                    Console.WriteLine("Your item is now added to the list!");
                    Console.WriteLine();
                    Console.Write("Press any key to continue!...");
                    Console.ReadKey(true);
                    runner.Start(runner, itemslist);
                    break;
                //An item gets edited
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("EDITOR");
                    Console.WriteLine();
                    viewer.showItemslist(itemslist);
                    if (!(itemslist.Count == 0))
                    {
                        Console.WriteLine();
                        editor.EditItem();
                        Console.WriteLine();
                        Console.WriteLine("Your item is now edited!");
                        Console.WriteLine();
                        Console.Write("Press any key to continue!...");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        Console.WriteLine("You have not added any transactions!");
                        Console.WriteLine();
                        Console.Write("Press any key to continue!...");
                        Console.ReadKey(true);
                    }
                    runner.Start(runner, itemslist);
                    break;
                //The itemslist gets saved to file and the application is exited
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("SAVER");
                    
                    saver.saveToList();
                    Console.WriteLine("Your item(s) is(are) saved to file!");
                    Console.WriteLine();
                    Console.Write("Press any key to exit!...");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
