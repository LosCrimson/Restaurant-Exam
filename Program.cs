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
            MenuService ser = new MenuService();
            ser.PopulateMenu();
            Menu.menu.ForEach(p => Console.WriteLine($"{p.Id} {p.Item} {p.Price}eu"));
            Console.ReadLine();

            var uiService = new UiService();
            var orders = new Orders();
            var listService = new ListService();
            var emailService = new EmailService();
            var orderService = new OrderService(uiService, orders, listService, emailService);
            orderService.MainMenu();
            Console.ReadLine();
        }
    }
}