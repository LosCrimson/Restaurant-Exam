namespace Restaurant.Models
{
    public class MenuItem
    {
        private int _id;
        private string _item;
        private double _price;
        public int Id { get { return _id; } set { _id = value; } }
        public string Item { get { return _item; } set { _item = value; } }
        public double Price { get { return _price; } set { _price = value; } }

        public MenuItem(int id, string item, double price) 
        {
            _id = id;
            _item = item;
            _price = price;
        }

        public MenuItem(string rowData)
        {
            string[] data = rowData.Split(',');

            _id = Convert.ToInt16(data[0]);
            _item = data[1];
            _price = Convert.ToDouble(data[2]);
        }
    }
}
