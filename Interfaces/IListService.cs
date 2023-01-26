using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IListService
    {
        List<MenuItem> FindingMenuItemsViaID(List<int> idList, List<MenuItem> menuList);
        double SumOfMenuItems(List<MenuItem> clientItemList);
        string[] ConverOrderToString(Order order);
    }
}
