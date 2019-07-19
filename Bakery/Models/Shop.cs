using System;
using static System.Console;
using System.Collections.Generic;

namespace Bakery
{
    class Store
    {
        protected List<Pastry> pastryOrdered;
        protected Dictionary<string, int> menuItems;
        // default constructor
        public Store()
        {
            pastryOrdered = new List<Pastry>();
            menuItems = new Dictionary<string, int>()
            {
                {"Eclair   ", 2},
                {"Bear Claw", 3},
                {"Croissant", 5}
            };
        }
        public void Welcome()
        {
            WriteLine("~~~ Welcome to The Bakery ~~~");
            if(AskYesNo("Would you like to view the menu? y/n"))
            {
                WriteLine("Great!");
                DrawLine();
                ShowMenu();
                
            }
        }
        public void ShowMenu()
        {
            foreach(KeyValuePair<string, int> kvp in menuItems)
            {
                WriteLine($"{kvp.Key} ........ ${kvp.Value}");
            }
        }
        public void DrawLine()
        {
           WriteLine("---------------------------");
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