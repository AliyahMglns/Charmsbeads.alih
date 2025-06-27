using InventoryDataService;
using Inventory_BusinessDataLogic;
using InventoryBusinessDataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;
using static InventorySupplies;

namespace Test
{

    public class MenuService
    {
        private InventoryService inventoryService = new();
        private AccountService accountService = new();

        private string loggedInAccount = string.Empty;

        public void Start()
        {
            Console.WriteLine("CharmBeads.alih INVENTORY SYSTEM");

            while (true)
            {
                Console.Write("Enter Account Number: ");
                var account = Console.ReadLine();
                Console.Write("Enter PIN: ");
                var pin = Console.ReadLine();

                if (accountService.ValidateAccount(account, pin))
                {
                    loggedInAccount = account;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect credentials. Try again.\n");
                }
            }

            int option = 0;
            do
            {
                ShowMenu();
                int.TryParse(Console.ReadLine(), out option);
                Console.WriteLine();
                HandleOption(option);
            } while (option != 6);
        }

        private void ShowMenu()
        {
            Console.WriteLine("\n[1] Add Beads");
            Console.WriteLine("[2] Add Charms");
            Console.WriteLine("[3] Remove Beads");
            Console.WriteLine("[4] Remove Charms");
            Console.WriteLine("[5] View Stocks");
            Console.WriteLine("[6] Exit");
            Console.Write("Select an option: ");
        }

        private void HandleOption(int option)
        {
            switch (option)
            {
                case 1:
                    AddItem("Add Beads");
                    break;
                case 2:
                    AddItem("Add Charms");
                    break;
                case 3:
                    RemoveItem("Remove Beads");
                    break;
                case 4:
                    RemoveItem("Remove Charms");
                    break;
                case 5:
                    ViewStocks();
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private void AddItem(string label)
        {
            string type = label.Contains("Bead", StringComparison.OrdinalIgnoreCase) ? "bead" : "charm";

            Console.Write($"Enter {type} name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter amount to add: ");
            int.TryParse(Console.ReadLine(), out int qty);

            var stockList = type == "bead" ? ItemStock.BeadStocks : ItemStock.CharmStocks;
            var existing = stockList.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
            {
                existing.Quantity += qty;
            }
            else
            {
                stockList.Add(new InventorySupplies(name, qty));
            }

            // Save to file
            var storage = new BeadsStorage();
            if (type == "bead")
                BeadsStorage.SaveBeads(stockList.Select(s => $"{s.Name}: {s.Quantity}").ToList());
            else
                BeadsStorage.SaveCharms(stockList.Select(s => $"{s.Name}: {s.Quantity}").ToList());
        }

        private void RemoveItem(string label)
        {
            string type = label.Contains("Bead", StringComparison.OrdinalIgnoreCase) ? "bead" : "charm";

            Console.Write($"Enter {type} name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter amount to remove: ");
            int.TryParse(Console.ReadLine(), out int qty);

            bool success = inventoryService.RemoveItem(type, name, qty);

            if (success)
            {
                if (type == "bead")
                {
                    accountService.UpdateBeads(loggedInAccount, ItemStock.BeadStocks.Sum(b => b.Quantity));
                    BeadsStorage.SaveBeads(ItemStock.BeadStocks.Select(b => $"{b.Name}: {b.Quantity}").ToList());
                }
                else
                {
                    accountService.UpdateCharms(loggedInAccount, ItemStock.CharmStocks.Sum(c => c.Quantity));
                    BeadsStorage.SaveCharms(ItemStock.CharmStocks.Select(c => $"{c.Name}: {c.Quantity}").ToList());
                }

                Console.WriteLine($"Removed {qty} {type}(s) of '{name}'.\n");
            }
            else
            {
                Console.WriteLine("Failed to remove items. Not enough stock or invalid name.\n");
            }
        }
        private void ViewStocks()
        {
            Console.WriteLine("\nBead Stocks:");
            foreach (var bead in ItemStock.BeadStocks)
                Console.WriteLine($" {bead.Name}: {bead.Quantity}");

            Console.WriteLine("\nCharm Stocks:");
            foreach (var charm in ItemStock.CharmStocks)
                Console.WriteLine($" {charm.Name}: {charm.Quantity}");

            Console.WriteLine($"\nTotal Stock: {inventoryService.GetTotalStocks()}\n");
        }
    }
}
