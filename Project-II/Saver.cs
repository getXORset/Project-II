using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_II
{
    //The Saver class saves the itemslist to the file bankaccount.txt
    internal class Saver
    {
        List<Item> itemslist; //The list with the items
        internal Saver (List<Item> itemslist)
        {
            this.itemslist = itemslist;
        }
        //The method saveToList() uses stringbuilder to build strings of the list and then saves them to file
        internal void saveToList()
        {
            string path1 = @"C:\Users\tambu\source\repos\Project-II\Project-II\bankaccount.txt";
            bool existingFileFound = File.Exists(path1); //Checks whether the file exists
            if (existingFileFound)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Item item in itemslist)
                {
                    sb.Append($"{item.Date_transaction.ToShortDateString()};");
                    sb.Append($"{item.Title};");
                    sb.Append($"{item.Sign};");
                    sb.Append($"{item.Amount};");
                    sb.Append(Environment.NewLine);
                }
                File.WriteAllText(path1, sb.ToString());
            }
            else
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine("Please restart the program");
            }
        }
    }
}
