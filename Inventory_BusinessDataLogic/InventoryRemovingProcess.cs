using System;
using System.Collections.Generic;
using System.Linq;
using InventoryDataService;
using static InventorySupplies;

namespace Inventory_BusinessDataLogic
{
    public class InventoryRemovingProcess
    {
        public static List<String> beadStocks = new List<string>();
        public static List<String> charmStocks = new List<string>();
        public static string beadsName;
        public static string charmName;
        public static int beads = 0;
        public static int charms = 0;


        static InventoryRemovingProcess()
        {
            beadStocks = BeadsStorage.Beads();
            charmStocks = BeadsStorage.Charms();
            beads = beadStocks.Sum(s => int.Parse(s.Split(':')[1].Trim()));
            charms = charmStocks.Sum(s => int.Parse(s.Split(':')[1].Trim()));
        }

        public static bool UpdateBeadStocks(Actions userAction, int amountDeduct)
        {
            if (userAction == Actions.RemoveBeadStocks)
            {
                var bead = ItemStock.BeadStocks.FirstOrDefault(b => b.Name.Equals(beadsName, StringComparison.OrdinalIgnoreCase));
                if (bead != null && bead.Quantity >= amountDeduct)
                {
                    bead.Quantity -= amountDeduct;
                    if (bead.Quantity == 0)
                        ItemStock.BeadStocks.Remove(bead);

                    BeadsStorage.SaveBeads(ItemStock.BeadStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
                    return true;
                }
            }
            return false;
        }


        public static bool UpdateCharmStocks(Actions userAction, int amountDeduct)
        {
            if (userAction == Actions.RemoveCharmStocks)
            {
                var charm = ItemStock.BeadStocks.FirstOrDefault(b => b.Name.Equals(charmName, StringComparison.OrdinalIgnoreCase));
                if (charm != null && charm.Quantity >= amountDeduct)
                {
                    charm.Quantity -= amountDeduct;
                    if (charm.Quantity == 0)
                        ItemStock.BeadStocks.Remove(charm);

                    BeadsStorage.SaveBeads(ItemStock.CharmStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
                    return true;
                }
            }
            return false;
        }
    

        public static void setBeadsName()
        {
            beadsName = Console.ReadLine();
        }

        public static void setCharmsName()
        {
            charmName = Console.ReadLine();
        }
    }

}