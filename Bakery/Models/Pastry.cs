namespace Bakery
{
    public class Pastry
    {
        private int _price;
        public int Price 
        {
            get {return _price;}
            set { _price = value;}
        }
        private string _pastryName;
        public string PastryName
        {
            get {return _pastryName;}
            set { _pastryName = value;}
        }
        private int _quantity;
        public int Quantity 
        {
            get {return _quantity;}
            set { _quantity = value;}
        }
        // default constuctor
        public Pastry() {}
        
        public Pastry(string name, int price, int quantity)
        {
            _pastryName = name;
            _price = price;
            _quantity = quantity;
        }

    }
}