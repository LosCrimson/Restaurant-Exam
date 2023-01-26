using CsvHelper;
using Restaurant.Models;
using Restaurant.Services;
using System.Globalization;
using Restaurant.Repos;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uiService = new UiService();
            var orders = new Orders();
            var listService = new ListService();
            var emailService = new EmailService();
            var menu = new Menu();
            var tables = new Tables();
            var menuService = new MenuService();
            var orderService = new OrderService(uiService, orders, listService, emailService, menu, tables, menuService);
            orderService.MainMenu();
            Console.ReadLine();
        }
    }
}