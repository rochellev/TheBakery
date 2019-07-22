namespace Bakery
{
    public class Bread
    {
        private int _price;
        public int Price 
        {
            get {return _price;}
            set { _price = value;}
        }
        private string _breadName;
        public string BreadName
        {
            get {return _breadName;}
            set { _breadName = value;}
        }
        private int _quantity;
        public int Quantity 
        {
            get {return _quantity;}
            set { _quantity = value;}
        }
        public Bread() {}
        
        public Bread(string name, int price, int quantity)
        {
            _breadName = name;
            _price = price;
            _quantity = quantity;
        }
    }
}