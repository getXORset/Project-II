using Project_II;
using System.IO;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

List<Item> itemslist = new List<Item>(); //Creats the list for the items

Runner runner = new Runner(0); //The object which runs the application

string path1 = @"C:\Users\tambu\source\repos\Project-II\Project-II\bankaccount.txt"; //The path to the file
if (File.Exists(path1)) //Checks whether the file exists
{
    string[] itemsAsString = File.ReadAllLines(path1); //Loads the itemslist from the file "bankaccount.txt
    for (int i = 0; i < itemsAsString.Length; i++)
    {
        string[] itemSplits = itemsAsString[i].Split(';'); //Splits the text line of the text file on ';'
        DateTime date_transaction = DateTime.Parse(itemSplits[0]); //Gets the DateTime object
        string title = itemSplits[1]; //Gets the title
        char sign = char.Parse(itemSplits[2]); //Gets the sign (plus or minus)
        decimal amount = decimal.Parse(itemSplits[3]); //Gets the amount

        Item item;
        item = new Item(date_transaction, title, sign, amount); //Creats the new item;
        itemslist.Add(item); //Adds the item to the itemslist
    }
}
else
{
    File.Create(path1).Close(); //Creates the file and closes it
    //string startUp = "null/null/null; ; ; 0"; //An empty item with 0 SEK
    //File.WriteAllText(path1, startUp); //Writes the startup string to the file
}

runner.Start(runner, itemslist); //The method for starting the application to run. The runner is passed recursively.