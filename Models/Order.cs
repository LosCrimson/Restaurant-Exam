namespace Restaurant.Models
{
    public class Order
    {
        private int _id;
        private int _table;
        private List<MenuItem> _menu;
        private double _sum;
        private DateTime _date;

        public int Id { get { return _id; } set { _id = value; } }
        public int Table { get { return _table;} set { _table = value; } }
        public List<MenuItem> Menu { get { return _menu;} set { _menu = value; } }
        public double Sum { get { return _sum;} set { _sum = value; } }
        public DateTime Date { get { return _date;} set { _date = value; } }

        public Order(int id, int table, List<MenuItem> menu, double sum, DateTime date) 
        {
            _id = id;
            _table = table;
            _menu = menu;
            _sum = sum;
            _date = date;
        }
    }
}
