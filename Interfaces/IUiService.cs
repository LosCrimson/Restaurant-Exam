using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Enum;
using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IUiService
    {
        ActionTypes GetActionType();
        int SelectingNumberOfClientsToSeat();
        void PrintingTableList(List<Table> tables);
        Table PickingTable(List<Table> tables);
        int OrderingMenuItems();
        void PrintMenu(List<MenuItem> menu);
        bool AreClientsSeated();
        int TableSelectionForWaiter();
        void PrintOrder(Order order);
        int SelectingCheckIdForEmail();
        string SelectingCheckEmail();

    }
}
