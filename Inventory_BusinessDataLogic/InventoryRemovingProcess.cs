using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_BusinessDataLogic
{
    public class InventoryRemovingProcess
    {
        public static List<String> beadStocks = new List<String>();
        public static List<String> charmStocks = new List<String>();
        public static string beadsName;
        public static string charmName;
        public static int beads = 0;  // Total bead count
        public static int charms = 0; // Total charm count

        public static bool UpdateBeadStocks(Actions userAction, int amountDeduct)
        {

            if (userAction == Actions.RemoveBeadStocks)//removing beads stocks
            {
                for (int i = 0; i < beadStocks.Count; i++)
                {
                    string[] parts = beadStocks[i].Split(':');  // Split "BeadName: Quantity"
                    string name = parts[0].Trim();
                    beads = int.Parse(parts[1].Trim()); //Convert quantity to integer
                    
                    if (name.Equals(beadsName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (userAction == Actions.RemoveBeadStocks && amountDeduct <= beads) //ensure we have enough stock to remove
                        {
                            beads -= amountDeduct; // Subtract stock


                            if (beads > 0)
                            {
                                beadStocks[i] = $"{name}: {beads}";  // Update the beadStocks in the list
                            }
                            else
                            {
                                beadStocks.RemoveAt(i);  // Remove if stock is 0

                                return true; //successfully updated beadStocks
                            }

                        }

                    }


                }

            }

            return false;

        }

        public static bool UpdateCharmStocks(Actions userAction, int amountDeduct)
        {

            if (userAction == Actions.RemoveCharmStocks)//removing charms stocks
            {
                for (int i = 0; i < charmStocks.Count; i++)
                {
                    string[] parts = charmStocks[i].Split(':');  // Split "CharmName: Quantity"
                    string name = parts[0].Trim();

                    if (name.Equals(charmName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (userAction == Actions.RemoveCharmStocks && amountDeduct <= charms)
                        {
                            charms -= amountDeduct; // Subtract stock


                            if (charms > 0)
                            {
                                charmStocks[i] = $"{name}: {charms}";  // Update list
                            }
                            else
                            {
                                charmStocks.RemoveAt(i);  // Remove if stock is 0

                                return true;
                            }

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
