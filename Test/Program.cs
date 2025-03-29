using Microsoft.VisualBasic;
using System.ComponentModel.Design;
using Inventory_BusinessDataLogic;
using System;

namespace Test
{
    internal class Program
    {
        static string[] actions = new string[]
        {
            "[1] Add Beads", "[2] Add Charms", "[3] Remove Bead Stocks", "[4] Remove Charm Stocks", "[5] View Stocks", "[6] Exit"
        };


        static void Main(string[] args)
        {
            Console.WriteLine("CharmBeads.alih INVENTORY");
            Console.WriteLine("\nACTIONS");

            displayActions();
            int userInput = getUserActions();


            while (userInput != 6) // 6 is Exit
            {
                switch (userInput)
                {
                    case 1:
                        addBeads();
                        break;
                    case 2:
                        addCharms();
                        break;
                    case 3:
                        removeBeadsStocks();
                        break;
                    case 4:
                        removeCharmStocks();
                        break;
                    case 5:
                        viewStocks();
                        break;
                    default:
                        Console.WriteLine("Invalid Number, please only enter number 1-6.");
                        break;
                }

                displayActions();
                userInput = getUserActions();
            }

            Console.WriteLine("Exiting...");
        }

        static int getUserActions()
        {
            Console.WriteLine("[Enter Input]: ");
            int userAction = Convert.ToInt16(Console.ReadLine());

            return userAction;
        }

        static void displayActions()
        {
            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
            Console.WriteLine("______________________________________");
            Console.Write("\nEnter Action: ");
        }

        static void addBeads()
        {
            Console.Write("\nBEADS NAME AND COLOR: ");
            InventoryRemovingProcess.setBeadsName();

            Console.Write("\nADD OR RESTOCK AMOUNT OF BEAD/S: ");
            int addBeadStocks = Convert.ToInt16(Console.ReadLine());
            InventoryRemovingProcess.beadStocks.Add($"{InventoryRemovingProcess.charmName}: {addBeadStocks}");

            InventoryRemovingProcess.beads += addBeadStocks;
            Console.WriteLine($"You have added {addBeadStocks} pcs. of {InventoryRemovingProcess.beadsName} beads successfully!");
            Console.WriteLine("______________________________________ \n");
            


        }

        static void addCharms()
        {
            Console.Write("\nCHARM NAME AND CLASSIFICATION: ");
            InventoryRemovingProcess.setCharmsName();
            Console.Write("\nADD OR RESTOCK AMOUNT OF CHARM/S: ");
            int addCharmStocks = Convert.ToInt16(Console.ReadLine());
            InventoryRemovingProcess.charmStocks.Add($"{InventoryRemovingProcess.charmName}: {addCharmStocks}");

            InventoryRemovingProcess.charms += addCharmStocks;
            Console.WriteLine($"You have added {addCharmStocks} pcs. of {InventoryRemovingProcess.charmName} charm/s successfully!");
            Console.WriteLine("______________________________________ \n");
        }

        static void viewStocks()
        {
            foreach (var beadstocks in InventoryRemovingProcess.beadStocks)
            {
                Console.WriteLine(addBeads);
            }

            foreach (var charmStocks in InventoryRemovingProcess.charmStocks)
            {
                Console.WriteLine(charmStocks);
            }
            Console.WriteLine($"Total Beads in Stock: {InventoryRemovingProcess.beads}");
            Console.WriteLine($"Total Charms in Stock: {InventoryRemovingProcess.charms}");

            int totalStocks = InventoryRemovingProcess.charms + InventoryRemovingProcess.beads;
            Console.WriteLine("Total Stocks: " + totalStocks);
            Console.WriteLine("______________________________________ \n");
        }
        
        static void removeBeadsStocks()
        {
            Console.Write("----------------------------------------------");
            Console.Write("\nEnter bead name: ");
            InventoryRemovingProcess.setBeadsName();

            Console.Write("Enter amount of beads to remove: ");
            int removeAmt = Convert.ToInt16(getUserActions());

            InventoryRemovingProcess.UpdateBeadStocks(Actions.RemoveBeadStocks, removeAmt);

            if (!InventoryRemovingProcess.UpdateBeadStocks(Actions.RemoveBeadStocks, removeAmt))
            {
                Console.WriteLine($"{removeAmt} {InventoryRemovingProcess.beadsName} beads removed successfully.");


            }
        }


        static void removeCharmStocks()
            {
            Console.Write("----------------------------------------------");
            Console.Write("\nEnter charm name: ");
            InventoryRemovingProcess.setCharmsName();

            Console.Write("Enter amount of charms to remove: ");
            int removeAmt = Convert.ToInt16(getUserActions());

            InventoryRemovingProcess.UpdateCharmStocks(Actions.RemoveCharmStocks, removeAmt);

            if (!InventoryRemovingProcess.UpdateCharmStocks(Actions.RemoveCharmStocks, removeAmt))
            {
                Console.WriteLine($"{removeAmt} {InventoryRemovingProcess.charmName} beads removed successfully.");


            }
        }
        
    }
   }
    
  

