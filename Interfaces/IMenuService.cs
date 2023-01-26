using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interfaces
{
    public interface IMenuService
    {
        void ReadCsvFile(string filePath, List<MenuItem> menu);
        void SortMenuId(List<MenuItem> menu);
    }
}
