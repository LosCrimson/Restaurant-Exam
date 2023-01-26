using Restaurant.Models;

namespace Restaurant.Repos
{
    public class Tables : Repositories<Tables>
    {
        public List<Table> tables = new List<Table>
        {
            new Table(1, 1, false),
            new Table(2, 1, false),
            new Table(3, 2, false),
            new Table(4, 2, false),
            new Table(5, 4, false),
            new Table(6, 4, false),
            new Table(7, 6, false),
            new Table(8, 6, false),
            new Table(9, 8, false),
            new Table(10, 10, false),
        };
    }
}
