using Restaurant.Enum;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.Repos;
using System.Data;

namespace Restaurant.Services
{
    public class UiService : IUiService
    {
        public ActionTypes GetActionType()
        {
            do
            {
                Console.WriteLine("Pick an option: ");
                Console.WriteLine("[1] Seat clients.");
                Console.WriteLine("[2] Fill in client order.");
                Console.WriteLine("[3] Table availability.");
                Console.WriteLine("[4] Send check via email.");
                Console.WriteLine("[5] EXIT");

                string? menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                    case "SEAT":
                        return ActionTypes.SEAT;
                    case "2":
                    case "CHECK":
                        return ActionTypes.ORDER;
                    case "3":
                    case "LAST":
                        return ActionTypes.TABLES;
                    case "4":
                    case "TAEKOUT":
                        return ActionTypes.EMAIL;
                    case "5":
                    case "EXIT":
                        return ActionTypes.EXIT;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }
            while (true);
        }
        public int SelectingNumberOfClientsToSeat()
        {
            Console.WriteLine("How many people will be seated?");
            int numberOfCustomers = Convert.ToInt32(Console.ReadLine());
            return numberOfCustomers;
        }

        public void PrintingTableList()
        {
            Tables.tables.ForEach(t => Console.WriteLine($"Table number: {t.Id} | seating capacity: {t.SeatingCapacity} | occupied: {t.Occupied}"));
        }

        public Table PickingTable()
        {
            Console.WriteLine("Please pick a table.");
            int tableNumber = Convert.ToInt32(Console.ReadLine());
            Table selectedTable = Tables.tables.Single(t => t.Id == tableNumber);
            return selectedTable;
        }

        public int OrderingMenuItems()
        {
            Console.WriteLine("Please write items id");
            int clientOrder = Convert.ToInt32(Console.ReadLine());
            return clientOrder;
        }
        public void PrintMenu()
        {
            Menu.menu.ForEach(item => Console.WriteLine($"Id: {item.Id} | Name: {item.Item} {item.Price}eu"));
        }

        public bool AreClientsSeated()
        {
            Console.WriteLine("Are clients seated? [Y]YES [N]NO");
            string answer = Console.ReadLine();
            if(answer.Equals("Y")) 
            { return true; }
            else 
            { return false; }
        }

        public int TableSelectionForWaiter()
        {
            Console.WriteLine("At which table are the clients seated?");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void PrintOrder(Order order)
        { 
            Console.WriteLine("CHECK");
            Console.WriteLine($"Check id: {order.Id}");
            Console.WriteLine($"Table : {order.Table}");
            foreach(var item in order.Menu)
            {
                Console.WriteLine($"Id: {item.Id} | Name: {item.Item} {item.Price}eu");
            }
            Console.WriteLine($"Total price: {order.Sum}eu");
            Console.WriteLine($"Date: {order.Date}");
        }

    }
}
