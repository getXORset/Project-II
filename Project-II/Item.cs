using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_II
{
    //The class gives getters and setters for an Item
    public class Item
    {
        public Item(DateTime date_transaction, string title, char sign, decimal amount)
        {
            Date_transaction = date_transaction;
            Title = title; //the title of the transaction
            Sign = sign; //income or expense
            Amount = amount; //the amount of the transaction
        }
        public DateTime Date_transaction { get; set; }
        public String Title { get; set; }
        public char Sign { get; set; }
        public decimal Amount { get; set; }
    }
}
