namespace Restaurant.Models
{
    public class Menu
    {
        private int _id;
        private string _item;
        private double _price;
        public int Id { get { return _id; } set { _id = value; } }
        public string Item { get { return _item; } set { _item = value; } }
        public double Price { get { return _price; } set { _price = value; } }

        public Menu(int id, string item, double price) 
        {
            _id = id;
            _item = item;
            _price = price;
        }
    }
}
