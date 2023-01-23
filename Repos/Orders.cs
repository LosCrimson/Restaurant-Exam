using Restaurant.Models;

namespace Restaurant.Repos
{
    public class Orders : Repositories<Order>
    {
        public List<Order> orders = new List<Order>();
    }
}
