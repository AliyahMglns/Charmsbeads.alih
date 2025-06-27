using System;
using System.Runtime.CompilerServices;
using System.Transactions;
using Inventory_BusinessDataLogic;
using InventoryDataService;
using Test;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{

    public static string[] actions = new string[] { "[1] Add Beads, [2] Add Charms, [3] Remove Bead Stocks, [4] Remove Charm Stocks, [5] View Stocks" };
    public static void Main(string[] args)
    {

        var menu = new MenuService();
        menu.Start();


        static int getUserActions()
        {
            Console.Write(": ");
            int userAction = Convert.ToInt16(Console.ReadLine());

            return userAction;
        }

        static void displayActions()
        {
            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
            Console.WriteLine("____________________________________");
            Console.Write("\nEnter Action");
        }

        static void addBeads()
        {
            Console.Write("\nBEADS NAME AND COLOR: ");
            InventoryRemovingProcess.setBeadsName();

            Console.Write("\nADD OR RESTOCK AMOUNT OF BEAD/S: ");
            int addingBeads = Convert.ToInt16(Console.ReadLine());
            InventoryRemovingProcess.beadStocks.Add($"{InventoryRemovingProcess.beadsName}: {addingBeads}");
            BeadsStorage.SaveBeads(InventoryRemovingProcess.beadStocks);

            InventoryRemovingProcess.beads += addingBeads;
            Console.WriteLine($"You have added {addingBeads} pcs. of {InventoryRemovingProcess.beadsName} beads successfully!");
            Console.WriteLine("____________________________________ \n");

        }

        static void addCharms()
        {
            Console.Write("\nCHARM NAME AND CLASSIFICATION: ");
            InventoryRemovingProcess.setCharmsName();

            Console.Write("\nADD OR RESTOCK AMOUNT OF CHARM/S: ");
            int addingCharms = Convert.ToInt16(Console.ReadLine());
            InventoryRemovingProcess.charmStocks.Add($"{InventoryRemovingProcess.charmName}: {addingCharms}");
            BeadsStorage.SaveCharms(InventoryRemovingProcess.charmStocks);

            InventoryRemovingProcess.charms += addingCharms;
            Console.WriteLine($"You have added {addingCharms} pcs. of {InventoryRemovingProcess.charmName} charm/s successfully!");
            Console.WriteLine("____________________________________ \n");
        }

        static void viewStocks()
        {
            foreach (var Beads in InventoryRemovingProcess.beadStocks)
            {
                Console.WriteLine(Beads);
            }

            foreach (var charms in InventoryRemovingProcess.charmStocks)
            {
                Console.WriteLine(charms);
            }
            Console.WriteLine($"Total Beads in Stock: {InventoryRemovingProcess.beads}");
            Console.WriteLine($"Total Charms in Stock: {InventoryRemovingProcess.charms}");

            int totalStocks = InventoryRemovingProcess.charms + InventoryRemovingProcess.beads;
            Console.WriteLine("Total Stocks: " + totalStocks);
            Console.WriteLine("____________________________________ \n");
        }

        static void removeBeadsStocks()
        {
            Console.WriteLine("____________________________________ \n");
            Console.Write("\nEnter bead name: ");
            InventoryRemovingProcess.setBeadsName();

            Console.Write("Enter amount of beads to remove: ");
            int removeAmt = Convert.ToInt16(getUserActions());

            if (!InventoryRemovingProcess.UpdateBeadStocks(Actions.RemoveBeadStocks, removeAmt))
            {
                Console.WriteLine($"{removeAmt} {InventoryRemovingProcess.beadsName} beads removed successfully.");


            }
        }


        static void removeCharmStocks()
        {
            Console.WriteLine("____________________________________ \n");
            Console.Write("\nEnter charm name: ");
            InventoryRemovingProcess.setCharmsName();

            Console.Write("Enter amount of charms to remove: ");
            int removeAmt = Convert.ToInt16(getUserActions());

            if (!InventoryRemovingProcess.UpdateCharmStocks(Actions.RemoveCharmStocks, removeAmt))
            {
                Console.WriteLine($"{removeAmt} {InventoryRemovingProcess.charmName} beads removed successfully.");


            }
        }


    }

}