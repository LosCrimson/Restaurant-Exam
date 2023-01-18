using Restaurant.Models;

namespace Restaurant.Services
{
    public class MenuService
    {
        public List<MenuItem> ReadCsvFile()
        {
            using (var foodReader = new StreamReader("Food.csv"))
            using (var drinkReader = new StreamReader("Drinks.csv"))
                while(!foodReader.EndOfStream || !drinkReader.EndOfStream)
            {
                
            }
        }
    }
}
