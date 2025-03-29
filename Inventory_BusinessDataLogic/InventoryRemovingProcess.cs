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
        public static int addBeadStocks;
        public static int addCharmStocks;

        public static bool UpdateBeadStocks(Actions userAction, int amountDeduct)
        {

            if (userAction == Actions.RemoveBeadStocks)//removing beads stocks
            {
                for (int i = 0; i < beadStocks.Count; i++)
                {
                    string[] parts = beadStocks[i].Split(':');  // Split "BeadName: Quantity"
                    string name = parts[0].Trim();
                    int stock = Convert.ToInt16(parts[1].Trim());

                    return true;

                    if (name.Equals(beadsName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (userAction == Actions.RemoveBeadStocks && amountDeduct <= stock)
                        {
                            stock -= amountDeduct; // Subtract stock
                            return true;

                            if (stock > 0)
                            {
                                beadStocks[i] = $"{name}: {stock}";  // Update list
                            }
                            else
                            {
                                beadStocks.RemoveAt(i);  // Remove if stock is 0

                                beads -= amountDeduct;  // Update total count

                                return true;
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
                    int stock = Convert.ToInt16(parts[1].Trim());

                    return true;

                    if (name.Equals(charmName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (userAction == Actions.RemoveCharmStocks && amountDeduct <= stock)
                        {
                            stock -= amountDeduct; // Subtract stock
                            return true;

                            if (stock > 0)
                            {
                                charmStocks[i] = $"{name}: {stock}";  // Update list
                            }
                            else
                            {
                                charmStocks.RemoveAt(i);  // Remove if stock is 0

                                charms -= amountDeduct;  // Update total count

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

