using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interfaces
{
    public interface IMenuService
    {
        void ReadCsvFile(string filePath);
        void PopulateMenu();
        void SortMenuId();
    }
}
