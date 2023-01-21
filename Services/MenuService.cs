using CsvHelper.Configuration;
using CsvHelper;
using Restaurant.Models;
using System.Globalization;
using System;
using Restaurant.Repos;
using Restaurant.Interfaces;

namespace Restaurant.Services
{
    public class MenuService : IMenuService
    {
        public void ReadCsvFile(string filePath)
        {
            string[] csvLines = File.ReadAllLines(filePath);

            for (int i = 1; i < csvLines.Length; i++) 
            {
                MenuItem item = new MenuItem(csvLines[i]);
                Menu.menu.Add(item);
            }
        }

        public void PopulateMenu()
        {
            ReadCsvFile("./Food.csv");
            ReadCsvFile("./Drinks.csv");
            SortMenuId();
        }

        public void SortMenuId() 
        {
            int i = 1;
            Menu.menu.ForEach(p => p.Id = i++);
        }
    }
}
