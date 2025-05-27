using System;
using System.Collections.Generic;
using System.Linq;
using InventoryDataService;

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

        public static BeadsStorage fileStorage = new BeadsStorage();

        static InventoryRemovingProcess()
        {
            beadStocks = fileStorage.LoadBeads();
            charmStocks = fileStorage.LoadCharms();
            beads = beadStocks.Sum(s => int.Parse(s.Split(':')[1].Trim()));
            charms = charmStocks.Sum(s => int.Parse(s.Split(':')[1].Trim()));
        }

        public static bool UpdateBeadStocks(Actions userAction, int amountDeduct)
        {
            if (userAction == Actions.RemoveBeadStocks)
            {
                for (int i = 0; i < beadStocks.Count; i++)
                {
                    string[] parts = beadStocks[i].Split(':');
                    string name = parts[0].Trim();
                    beads = int.Parse(parts[1].Trim());

                    if (name.Equals(beadsName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (amountDeduct <= beads)
                        {
                            beads -= amountDeduct;

                            if (beads > 0)
                            {
                                beadStocks[i] = $"{name}: {beads}";
                            }
                            else
                            {
                                beadStocks.RemoveAt(i);
                            }

                            fileStorage.SaveBeads(beadStocks);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool UpdateCharmStocks(Actions userAction, int amountDeduct)
        {
            if (userAction == Actions.RemoveCharmStocks)
            {
                for (int i = 0; i < charmStocks.Count; i++)
                {
                    string[] parts = charmStocks[i].Split(':');
                    string name = parts[0].Trim();
                    charms = int.Parse(parts[1].Trim());

                    if (name.Equals(charmName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (amountDeduct <= charms)
                        {
                            charms -= amountDeduct;

                            if (charms > 0)
                            {
                                charmStocks[i] = $"{name}: {charms}";
                            }
                            else
                            {
                                charmStocks.RemoveAt(i);
                            }

                            fileStorage.SaveCharms(charmStocks);
                            return true;
                        }
                    }
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