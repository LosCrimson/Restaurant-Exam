﻿using Restaurant.Enum;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.Repos;
using System.Net;
using FluentEmail.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using MailKit.Search;

namespace Restaurant.Services
{
    public class OrderService : IOrderService
    {

        private UiService _uiService;
        private Orders _orders;
        private ListService _listService;
        private EmailService _emailService;

        public OrderService(UiService uiService, Orders orders, ListService listService, EmailService emailService)
        { 
            _uiService = uiService; 
            _orders = orders;
            _listService = listService;
            _emailService = emailService;
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
                        RegisterClientOrder();
                        break;
                    case ActionTypes.TABLES:
                        ChangingTableOcupancy();
                        break;
                    case ActionTypes.EMAIL:
                        SendCheckViaEmail();
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

        public void RegisterClientOrder()
        {
            if(!_uiService.AreClientsSeated())
            {
                SeatClients();
            }
            _uiService.PrintMenu();
            Console.WriteLine("What would you like to order?");
            Console.WriteLine("When done press ENTER");
            List<int> idList = new List<int>();
            try 
            {
                while(true) 
                {
                    int itemID = _uiService.OrderingMenuItems();
                    if (itemID > Menu.menu.Count)
                    {
                        Console.WriteLine("There no item like this in the Menu. Try again.");
                    }
                    else
                    { idList.Add(itemID); }
                }
            }
            catch(FormatException) 
            {
                List<MenuItem> clientItemList = _listService.FindingMenuItemsViaID(idList);
                int tableId = _uiService.TableSelectionForWaiter();
                int orderId = _orders.orders.Count + 1;
                _orders.orders.Add(new Order(orderId, tableId, clientItemList, _listService.SumOfMenuItems(clientItemList), DateTime.Now));
                _uiService.PrintOrder(_orders.Retrieve(orderId, _orders.orders));
                PrintOrderToFile(orderId);
            }
        }

        public async Task PrintOrderToFile(int orderId)
        {
            Order order = _orders.Retrieve(orderId, _orders.orders);
            await File.WriteAllLinesAsync($"Check_{Guid.NewGuid()}.txt" , _listService.ConverOrderToString(order));
        }

        public void SendCheckViaEmail()
        {
            Order order = _orders.Retrieve(_uiService.SelectingCheckIdForEmail(), _orders.orders);
            _emailService.SendEmail(String.Concat(_listService.ConverOrderToString(order)), _uiService.SelectingCheckEmail());
        }
        
    }
}
