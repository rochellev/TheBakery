using System;
using static System.Console;
using System.Collections.Generic;

namespace Bakery
{
    class Store
    {
        protected Dictionary<string, Pastry> pastryOrdered;
        protected Dictionary<string, int> menuItems;
        private int _total = 0;
        // default constructor
        public Store()
        {
            pastryOrdered = new Dictionary<string, Pastry>();
            menuItems = new Dictionary<string, int>()
            {
                {"Eclair", 2},
                {"Bear Claw", 3},
                {"Croissant", 5}
            };
        }
        public void StartStore()
        {
            WriteLine("~~~ Welcome to The Bakery ~~~");
            PurchaseSequence();

        }
        public void PurchaseSequence()
        {
            if (AskYesNo("Would you like to view the menu? y/n"))
            {
                WriteLine("The Bakery Menu!");
                DrawLine();
                ShowMenu();
                GetUserOrder();
            }
            if(AskYesNo("Ready to checkout? (y/n)"))
            {
                ShowOrder();
                // checkout
            }
            PurchaseSequence();
        }
        public void GetUserOrder()
        {
            WriteLine("Type the name of item you would like");
            string item = ReadLine();
            DrawLine();
            WriteLine($"Type the number of {item}s would you like");
            int num = int.Parse(ReadLine());
            DrawLine();
            MakePurchase(item, num);
        }
        public void MakePurchase(string itemName, int quantity)
        {
            int price;
            // see if a menu item
            if (menuItems.TryGetValue(itemName, out price))
            {
                Pastry order;
                // check if already ordered
                if (pastryOrdered.TryGetValue(itemName, out order))
                {
                    order.Quantity += quantity;
                }
                else
                {
                    Pastry newItem = new Pastry(itemName, price, quantity);
                    pastryOrdered.Add(itemName, newItem);
                }
                ShowOrder();
                PurchaseSequence();
            }
            else
            {
                WriteLine($"Sorry, could not find {itemName} on the menu.");
                PurchaseSequence();
            }

        }
        public void ShowOrder()
        {
            WriteLine("------- Your order --------");
            DrawLine();
            foreach (KeyValuePair<string, Pastry> p in pastryOrdered)
            {
                _total += p.Value.Quantity * p.Value.Price;
                WriteLine($"Item: {p.Key} ..... Quatity: {p.Value.Quantity}");
            }
            DrawLine();
            WriteLine($"Total = ${_total}");
            DrawLine();
            PurchaseSequence();
        }
        public void ShowMenu()
        {
            DrawLine();
            foreach (KeyValuePair<string, int> kvp in menuItems)
            {
                WriteLine($"{kvp.Key} ........ ${kvp.Value}");
            }
            DrawLine();
        }

        // helper functions for UI
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