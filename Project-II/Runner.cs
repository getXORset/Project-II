using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_II
{
    //The Runner class runs the application
    internal class Runner
    {
        public decimal balance; //The variable for the balance of the account
        internal Runner(decimal balance)
        {
            this.balance = balance;
        }
        //The method Start() starts the application
        internal void Start(Runner runner, List<Item> itemslist)
        {
            int choice = 0; //The user's menu choice
            decimal sumIncomes = 0; //The sum of the incomes
            decimal sumExpenses = 0; //The sum of the expenses
            bool showMenu = false; //Initiation of the menu variable (on/off)
            Chooser chooser = new Chooser(); //Initiation of the chooser object
            Saver saver = new Saver(itemslist); //Initiation of the saver object

            //Loop to sum up incomes and expenses
            foreach (Item item in itemslist)
            {
                if (item.Sign == '+')
                {
                    sumIncomes += item.Amount;
                }
                if (item.Sign == '-')
                {
                    sumExpenses += item.Amount;
                }
            }
            balance = sumIncomes - sumExpenses; //The balance of the account is counted
            showMenu = chooser.startMenu(ref choice, balance); //Shows the startmenu
            ChoiceExecutor choiceExecutor = new ChoiceExecutor(choice, itemslist); //Initiates the execution of the user's choice
            choiceExecutor.Manager(runner); //Runs the choice's execution
        }
    }
}
