using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;
using Restaurant.Repos;

namespace Restaurant.Services
{
    public class ListService
    {
        public List<MenuItem> FindingMenuItemsViaID(List<int> idList)
        {
            List<MenuItem> clientItemList = new List<MenuItem>();
            foreach(var id in idList)
            {
                foreach(var menuItem in Menu.menu)
                {
                    if(id == menuItem.Id)
                    {
                        clientItemList.Add(menuItem);
                    }
                }
            }
            return clientItemList;
        }

        public double SumOfMenuItems(List<MenuItem> clientItemList)
        {
            double sum = 0;
            foreach (var clientItem in clientItemList) 
            {
                sum += clientItem.Price; 
            }
            return sum;
        }
    }
}
