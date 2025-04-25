using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


public class InventorySupplies
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public InventorySupplies(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
    public static class ItemStock
    {
        
        public static List<InventorySupplies> BeadStocks { get; private set; } = new();
        public static List<InventorySupplies> CharmStocks { get; private set; } = new();
    }
   
}