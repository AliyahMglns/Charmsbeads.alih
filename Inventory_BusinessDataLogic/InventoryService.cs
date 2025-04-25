using InventoryDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBusinessDataLogic
{
    public class InventoryService
    {
        public List<ItemsDataService> BeadStocks { get; private set; } = new();
        public List<ItemsDataService> CharmStocks { get; private set; } = new();

        public void AddItem(string type, string name, int qty)
        {
            var stockList = GetStockList(type);
            var existing = stockList.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
            {
                existing.Quantity += qty;
            }
            else
            {
                stockList.Add(new InventoryItem(name, qty));
            }
        }

        public bool RemoveItem(string type, string name, int qty)
        {
            var stockList = GetStockList(type);
            var item = stockList.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (item != null && item.Quantity >= qty)
            {
                item.Quantity -= qty;
                if (item.Quantity == 0)
                    stockList.Remove(item);
                return true;
            }
            return false;
        }

        public List<InventoryItem> GetStockList(string type)
        {
            return type.ToLower() == "bead" ? BeadStocks : CharmStocks;
        }

        public int GetTotalStocks() => BeadStocks.Sum(i => i.Quantity) + CharmStocks.Sum(i => i.Quantity);
    }
}
