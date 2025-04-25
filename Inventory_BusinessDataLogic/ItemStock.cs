using InventoryDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataService
{
    internal class ItemStock
    {
        public List<string> BeadStocks { get; private set; } = new();
        public List<string> CharmStocks { get; private set; } = new();
    }
}
