using InventoryBusinessDataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

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

        private void AddItem(string type)
        {
            Console.Write($"Enter {type} name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter amount to add: ");
            int.TryParse(Console.ReadLine(), out int qty);

            inventoryService.AddItem(type, name, qty);

            if (type == "bead") accountService.UpdateBeads(loggedInAccount, inventoryService.BeadStocks.Sum(b => b.Quantity));
            else accountService.UpdateCharms(loggedInAccount, inventoryService.CharmStocks.Sum(c => c.Quantity));

            Console.WriteLine($"Added {qty} {name} {type}(s).\n");
        }

        private void RemoveItem(string type)
        {
            Console.Write($"Enter {type} name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter amount to remove: ");
            int.TryParse(Console.ReadLine(), out int qty);

            bool success = inventoryService.RemoveItem(type, name, qty);

            if (success)
            {
                if (type == "bead") accountService.UpdateBeads(loggedInAccount, inventoryService.BeadStocks.Sum(b => b.Quantity));
                else accountService.UpdateCharms(loggedInAccount, inventoryService.CharmStocks.Sum(c => c.Quantity));

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
            foreach (var bead in inventoryService.BeadStocks)
                Console.WriteLine($"- {bead.Name}: {bead.Quantity}");

            Console.WriteLine("\nCharm Stocks:");
            foreach (var charm in inventoryService.CharmStocks)
                Console.WriteLine($"- {charm.Name}: {charm.Quantity}");

            Console.WriteLine($"\nTotal Stock: {inventoryService.GetTotalStocks()}\n");
        }
    }
}
