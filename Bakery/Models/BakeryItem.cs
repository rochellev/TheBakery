using System.Collections.Generic;
// pastry and bread will inherit from this
namespace Bakery
{
    public class BakeryItem
    {
        public static List<BakeryItem> orderList = new List<BakeryItem> {};
        private int _price;
        public int Price 
        {
            get {return _price;}
            set { _price = value;}
        }
        private string _itemName;
        public string ItemName
        {
            get {return _itemName;}
            set { _itemName = value;}
        }
        private int _quantity;
        public int Quantity 
        {
            get {return _quantity;}
            set { _quantity = value;}
        }
     
        public BakeryItem(string name, int price, int quantity)
        {
            _itemName = name;
            _price = price;
            _quantity = quantity;
            orderList.Add(this);
        }

    }
}