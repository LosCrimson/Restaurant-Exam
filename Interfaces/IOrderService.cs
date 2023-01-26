using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interfaces
{
    public interface IOrderService
    {
        void MainMenu();
        void SeatClients();
        void ChangingTableOcupancy();
        void RegisterClientOrder();
        Task PrintOrderToFile(int orderId);
        void SendCheckViaEmail();

    }
}
