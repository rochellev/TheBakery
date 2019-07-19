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
        public void PurchaseSequence(){
            if(AskYesNo("Would you like to view the menu? y/n"))
            {
                WriteLine("The Bakery Menu!");
                DrawLine();
                ShowMenu();
            }
            WriteLine("Type the name of item you would like");
            string item = ReadLine();
            DrawLine();
            WriteLine($"Type the number of {item}s would you like");
            int num = int.Parse(ReadLine());
            DrawLine();
            MakePurchase(item, num);

        }
        public void MakePurchase(string itemName, int quantity){
            // check to see valid
            int price;
            if(menuItems.TryGetValue(itemName, out price))
            {
                Pastry order = new Pastry(itemName, price, quantity);
                pastryOrdered.Add(order);
                ShowOrder();

            }
            else
            {
                WriteLine("Sorry, could not find that item in the menu.");
                PurchaseSequence();
            }

        }
        public void ShowOrder()
        {
            DrawLine();
            foreach(Pastry p in pastryOrdered)
            {
                WriteLine($"Item: {p.PastryName} ..... Quatity: {p.Quantity}");
            }
            DrawLine();
            PurchaseSequence();
        }
        public void ShowMenu()
        {
            DrawLine();
            foreach(KeyValuePair<string, int> kvp in menuItems)
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