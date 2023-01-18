using Restaurant.Models;

namespace Restaurant.Repos
{
    public class Orders : Repositories<Orders>
    {
        public List<Order> orders = new List<Order>();
    }
}
