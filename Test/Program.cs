using Microsoft.VisualBasic;
using System.ComponentModel.Design;

namespace Test
{

    internal class Program
    {
        static string[] actions = new string[] { "[1] Add Beads, [2] Add Charm, [3] View Stocks, [4] Pull Out Charms, [5] Exit" };
        static int beads = 0;
        static int charms = 0;
        static List<String> beadsStocks = new List<String>();
        static List<String> charmsStocks = new List<String>();
        static List<String> updatedStocks = new List<String>();
       
        static void Main(string[] args)
        {
            Console.WriteLine("CharmBeads.alih INVENTORY");

            Console.WriteLine("\nACTIONS");

            displayActions();

            int userAction = getUserActions();

            while (userAction != 5)
            {
                switch (userAction)
                {
                    case 1: //ADDING BEADS
                        addBeads();
                        break;

                    case 2: //ADD CHARM
                        addCharms();
                        break;

                    case 3: //VIEW STOCKS
                        viewStocks();
                        break;

                    case 4: //PULL OUT CHARMS
                        pullOut();
                        break;

                    case 5: //EXIT SYSTEM
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Input, please enter a value ranging from 1-5.");
                        break;
                }
                displayActions();
                userAction = getUserActions();

            }

            static int getUserActions()
            {
                int userAction = Convert.ToInt16(Console.ReadLine());

                return userAction;
            }
            static void displayActions() //Displaying actions
            {

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }
                Console.WriteLine("________________________________________");
                Console.Write("\nEnter Action: ");
            }


            static void addBeads() //Adding bead stocks
            {
                Console.Write("\nBEADS NAME AND COLOR: ");
                string beadsName = Console.ReadLine();

                Console.Write("\nADD OR RESTOCK AMOUNT OF BEAD/S: ");
                int addBeadStocks = Convert.ToInt16(Console.ReadLine());

                beadsStocks.Add(beadsName + ":" + addBeadStocks);
                Console.WriteLine("You have added " + addBeadStocks + "pcs. of " + beadsName + " beads successfully!");

                beads += addBeadStocks;

                Console.WriteLine("________________________________________ \n");


            }


            static void addCharms()
            {
                Console.Write("\nCHARM NAME AND CLASSIFICATION: ");
                string charmName = Console.ReadLine();

                Console.Write("\nADD OR RESTOCK AMOUNT OF CHARM/S: ");
                int addCharmStocks = Convert.ToInt16(Console.ReadLine());
                charmsStocks.Add(charmName + ": " + addCharmStocks);

                Console.WriteLine("You have added " + addCharmStocks + "pcs. of " + charmName + " charm/s successfully!");
                charms += addCharmStocks;

                Console.WriteLine("________________________________________");
                Console.WriteLine(" ");
            }


            static void viewStocks()
            {
                foreach (var beadsAmount in beadsStocks)
                {
                    Console.WriteLine(beadsAmount);
                }

                foreach (var charmsAmount in charmsStocks)
                {
                    Console.WriteLine(charmsAmount);
                }

                int totalStocks = charms + beads;

                Console.WriteLine("Total stocks: " + totalStocks + "\n");
                Console.WriteLine("________________________________________");
                Console.WriteLine(" ");
            }


            static void pullOut()
            {
                
                Console.WriteLine("Select Which item to deduct or remove: ");
                Console.WriteLine("[1] Beads, [2] Charms");

                int selectOption = Convert.ToInt16(Console.ReadLine());
                
                if (selectOption == 1)
                {
                    foreach (var beadsAmount in beadsStocks)
                    {
                        Console.WriteLine(beadsAmount);

                    }
                   

                }
                else if (selectOption == 2)
                {
                    foreach (var charmsAmount in charmsStocks)
                    {
                        Console.WriteLine(charmsAmount);
                    }
                    
                }
            }

        }
    }
}

