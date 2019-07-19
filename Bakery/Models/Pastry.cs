namespace Bakery
{
    public class Pastry
    {
        private int _price;
        public int Price { get; set; }
        private string _pastryName;
        public string PastryName { get; set; }
        // default constuctor
        public Pastry() {}
        
        public Pastry(string name, int p)
        {
            _pastryName = name;
            _price = p;
        }

    }
}