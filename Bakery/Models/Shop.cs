using System;
using static System.Console;
using System.Collections.Generic;

namespace Bakery
{
    public class Store
    {
        protected Dictionary<string, int> pastryItems;
        protected Dictionary<string, int> breadItems;
        private int _total;

        // default constructor, init dictionaries
        public Store()
        {
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
            if (AskYesNo("Would you like to order? (y/n)"))
            {
                ShowMenu();
                PurchaseSequence();
                StartStore();
            }
            if (AskYesNo("Would you like to checkout? (y/n)"))
            {
                ShowOrder();
            }
            if (!AskYesNo("Would you like to quit? (y/n)"))
            {
                StartStore();
            }
        }
        public void PurchaseSequence()
        {
            DrawLine();
            WriteLine("Type the name of item you would like: ");
            string item = ReadLine();
            DrawLine();
            WriteLine($"Type the number of {item}s would you like: ");
            int num = int.Parse(ReadLine());
            DrawLine();

        }
        public void MakePurchase(string itemName, int quantity)
        {
            int price;
            if (pastryItems.TryGetValue(itemName, out price))
            {
                BakeryItem pastry = new BakeryItem(itemName, price, quantity);
            }
            else if (breadItems.TryGetValue(itemName, out price))
            {
                BakeryItem bread = new BakeryItem(itemName, price, quantity);
            }
            else
            {
                WriteLine($"Sorry, can't find {itemName} on the menu.");
                DrawLine();
                StartStore();
            }

        }

        public void ShowOrder()
        {
            WriteLine($"------- You have {BakeryItem.orderList.Count} items in your order --------");
            foreach(BakeryItem i in BakeryItem.orderList)
            {
                WriteLine($"Item Name: {i.ItemName} ... Quantity: {i.Quantity}   .... ${i.Price}");
            }
            DrawLine();
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
            return 0;

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