namespace Restaurant.Models
{
    public class Table
    {
        private int _id;
        private int _seatingCapacity;
        private bool _occupied;

        public int Id { get { return _id;} set { _id = value; } }
        public int SeatingCapacity { get { return _seatingCapacity; } set { _seatingCapacity = value; } }
        public bool Occupied { get { return _occupied; } set { _occupied = value; } }

        public Table(int id, int seatingCapacity, bool occupied) 
        {
            _id = id;
            _seatingCapacity = seatingCapacity;
            _occupied = occupied;
        }
    }
}
