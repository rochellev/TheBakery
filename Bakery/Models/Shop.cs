using System;
using static System.Console;

// Store will interact with user
namespace Bakery
{
    class Store
    {
        public Store(){}
        public void Welcome()
        {
            WriteLine("~~~ Welcome to The Bakery ~~~");
            if(AskYesNo("Would you like to view the menu? y/n"))
            {
                WriteLine("Great!");
                WriteLine("---------------------------");
            }
        }
        public void DisplayMenu()
        {
            WriteLine("Menu is here");
        }
        public bool CheckYes(string str)
        {
            if (str == "y" || str == "Y" || str == "yes" || str == "Yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // return true for yes
        public bool AskYesNo(string question)
        {
            WriteLine($"{question}");
            return CheckYes(Console.ReadLine());
        }
    }
}