using InventoryDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static InventorySupplies;

namespace Inventory_BusinessDataLogic
{
    public class InventoryService
    {
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
                stockList.Add(new InventorySupplies(name, qty));
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

        public List<InventorySupplies> GetStockList(string type)
        {
            return type.ToLower() == "bead" ? ItemStock.BeadStocks : ItemStock.CharmStocks;
        }

        public int GetTotalStocks()
        {
            return ItemStock.BeadStocks.Sum(i => i.Quantity) + ItemStock.CharmStocks.Sum(i => i.Quantity);
        }
      }
    }
    
