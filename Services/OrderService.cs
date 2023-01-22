using Restaurant.Enum;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.Repos;

namespace Restaurant.Services
{
    public class OrderService : IOrderService
    {

        private UiService _uiService;


        public OrderService(UiService uiService)
        { 
            _uiService = uiService; 

        }
        public void MainMenu() 
        {
            while(true) 
            {
                switch(_uiService.GetActionType())
                {
                    case ActionTypes.SEAT:
                        SeatClients();
                        break;
                    case ActionTypes.ORDER:

                        break;
                    case ActionTypes.TABLES:
                        ChangingTableOcupancy();
                        break;
                    case ActionTypes.EMAIL:

                        break;
                    case ActionTypes.EXIT:
                        return;
                }
            }
        }

        public void SeatClients()
        {
            int numberOfCustomers = _uiService.SelectingNumberOfClientsToSeat();
            _uiService.PrintingTableList();
            Table selectedTable = _uiService.PickingTable();
            if (selectedTable.Occupied == false)
            {
                if (numberOfCustomers <= selectedTable.SeatingCapacity)
                {
                    Console.WriteLine($"Is this table now occupied by this group? {selectedTable.Occupied = true}");
                }
                else
                {
                    Console.WriteLine("Selected table is to small to accomidate this group of customers.");
                }
            }
            else 
            {
                Console.WriteLine("Selected table already occupied.");
            }
        }

       public void ChangingTableOcupancy()
        {
            _uiService.PrintingTableList();
            Console.WriteLine("");
            Console.WriteLine("To make table unoccupied please type in table number.");
            Console.WriteLine("Otherwise press Enter.");
            try
            {
                int tableId = Convert.ToInt32(Console.ReadLine());
                try
                {
                    Tables.tables.Single(t => t.Id == tableId).Occupied = false;
                    Console.WriteLine($"Table {tableId} is free now.");
                } 
                catch(InvalidOperationException) 
                {
                    Console.WriteLine($"This table {tableId} does not exist please try again");
                }
            }
               catch(FormatException) 
            { }
            Console.WriteLine("");
        }


    }
}
