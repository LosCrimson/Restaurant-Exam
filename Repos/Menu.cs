using Restaurant.Models;

namespace Restaurant.Repos
{
    public class Menu : Repositories<Menu>
    {
        public List<MenuItem> menu = new List<MenuItem>();
    }
}
