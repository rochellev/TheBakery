using System;
using static System.Console;
using System.Collections.Generic;

namespace Bakery
{
    class Store
    {
        protected Dictionary<string, Pastry> pastryOrdered;
        protected Dictionary<string, Bread> breadOrdered;
        protected Dictionary<string, int> pastryItems;
        protected Dictionary<string, int> breadItems;
        private int _total;

        // default constructor, init dictionaries
        public Store()
        {
            pastryOrdered = new Dictionary<string, Pastry>();
            breadOrdered = new Dictionary<string, Bread>();
            _total = 0;
            pastryItems = new Dictionary<string, int>()
            {
                {"Eclair", 2},
                {"Bear Claw", 2},
                {"Croissant", 2}
            };
            breadItems = new Dictionary<string, int>()
            {
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
            if (pastryItems.TryGetValue(itemName, out price))
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
            if (breadItems.TryGetValue(itemName, out price))
            {
                Bread bOrder;
                if (breadOrdered.TryGetValue(itemName, out bOrder))
                {
                    bOrder.Quantity += quantity;
                }
                else
                {
                    Bread newBItem = new Bread(itemName, price, quantity);
                    breadOrdered.Add(itemName, newBItem);
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
            foreach (KeyValuePair<string, Bread> b in breadOrdered)
            {
                _total += b.Value.Quantity * b.Value.Price;
                WriteLine($"Item: {b.Key} ..... Quatity: {b.Value.Quantity}");

            }

            DrawLine();
            if (!fishished)
            {
                DrawLine();
                PurchaseSequence();
            }
            else
            {
                int theTotal = calculateTotal();
                WriteLine($"Total = ${theTotal}");
            }
        }
        public void ShowMenu()
        {
            DrawLine();
            foreach (KeyValuePair<string, int> kvp in pastryItems)
            {
                WriteLine($"{kvp.Key} ........ ${kvp.Value}");
            }
            foreach (KeyValuePair<string, int> k in breadItems)
            {
                WriteLine($"{k.Key} ........ ${k.Value}");
            }
            DrawLine();
        }
        public int calculateTotal()
        {
            int pastryCount = 0;
            int breadCount = 0;
            int discount = 0;
            int bDiscount = 0;
            foreach (KeyValuePair<string, Pastry> pastry in pastryOrdered)
            {
                pastryCount += pastry.Value.Quantity;
            }
            foreach( KeyValuePair<string, Bread> bread in breadOrdered)
            {
                breadCount += bread.Value.Quantity;
            }
            if(pastryCount >= 3)
            {
                discount = pastryCount/3; 
                 
            }
            if(breadCount >= 3)
            {
                bDiscount = breadCount/3;
            }
            _total = (discount * 2) + (bDiscount * 5);

            return _total;

        }


        // helper functions for UI
        public void Bye()
        {
            WriteLine("Bye!");
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