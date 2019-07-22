using System;
using static System.Console;
using System.Collections.Generic;

namespace Bakery
{
    class Store
    {
        protected Dictionary<string, Pastry> pastryOrdered;
        protected Dictionary<string, int> menuItems;
        protected Dictionary<string, Bread> breadOrdered;
        private int _total;
        // default constructor, init dictionaries
        public Store()
        {
            pastryOrdered = new Dictionary<string, Pastry>();
            breadOrdered = new Dictionary<string, Bread>();
            _total = 0;
            menuItems = new Dictionary<string, int>()
            {
                {"Eclair", 2},
                {"Bear Claw", 3},
                {"Croissant", 5},
                {"Sourdough", 5},
                {"Baguette", 5},
                {"Rye Bread", 5}
            };
        }
        public void StartStore()
        {
            WriteLine("~~~ Welcome to The Bakery ~~~");
            PurchaseSequence();

        }
        public void PurchaseSequence()
        {
            if (AskYesNo("Would you like to order? y/n"))
            {
                WriteLine("The Bakery Menu!");
                DrawLine();
                ShowMenu();
                GetUserOrder();
            }
            else
            {
                if (AskYesNo("Ready to checkout? (y/n)"))
                {
                    ShowOrder(true);
                    Bye();
                    // checkout
                }
                else
                {
                    if (!AskYesNo("quit?"))
                    {
                        PurchaseSequence();
                    }
                }
            }


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
                ShowOrder(false);
                PurchaseSequence();
            }
            else
            {
                WriteLine($"Sorry, could not find {itemName} on the menu.");
                PurchaseSequence();
            }

        }
        public void ShowOrder(bool fishished)
        {
            WriteLine("------- Your order --------");
            DrawLine();
            _total = 0;
            foreach (KeyValuePair<string, Pastry> p in pastryOrdered)
            {
                _total += p.Value.Quantity * p.Value.Price;
                WriteLine($"Item: {p.Key} ..... Quatity: {p.Value.Quantity}");

            }
            DrawLine();
            if (!fishished)
            {
                DrawLine();
                PurchaseSequence();
            }
            else
            {
                WriteLine($"Total = ${_total}");
            }
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
        public void Bye()
        {
            WriteLine("Bye!");
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