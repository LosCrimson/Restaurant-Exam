using Restaurant.Models;

namespace Restaurant.Repos
{
    public class Menu : Repositories<Menu>
    {
        public static List<MenuItem> menu = new List<MenuItem>();
    }
}
