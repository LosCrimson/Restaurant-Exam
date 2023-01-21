using Restaurant.Enum;
using Restaurant.Interfaces;
using Restaurant.Repos;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Tables.tables.ForEach(t => Console.WriteLine($"Table number: {t.Id}, seating capacity: {t.SeatingCapacity}, occupied: {t.Occupied}"));
        }

        public Table PickingTable()
        {
            Console.WriteLine("Please pick a table.");
            int tableNumber = Convert.ToInt32(Console.ReadLine());
            Table selectedTable = Tables.tables.Single(t => t.Id == tableNumber);
            return selectedTable;
        }



    }
}
