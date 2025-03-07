namespace Test {

    internal class Program { 

        static void Main(string[] args)
        {
            Console.WriteLine("CharmBeads.alih SHOP");

            string uname = "alih", upass = "beads";

            Console.WriteLine(uname);
            Console.WriteLine(upass);

            Console.WriteLine("Enter Username: ");
            string userName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Password: ");
            string userPass = Convert.ToString(Console.ReadLine());

            if (userName == uname && userPass == upass)
            {

                Console.WriteLine("Successfully LogIn!!");

                Console.WriteLine("What are you looking for?");
                Console.WriteLine("Search: ");

                string[] actions = new string[] { "[1}Shop, {2}Order, {3}Exit" };

                Console.WriteLine("ACTIONS");

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }
                Console.Write("Enter Action: ");

                int userAction = Convert.ToInt16(Console.ReadLine());

                switch (userAction)
                {
                    case 1:
                        Console.WriteLine("WELCOME TO THE CHARMBEADS SHOP!" + "\n" + "\n" + "*****PICTURE*****" 
                            + "\n" + "Phone Charm - ₱75");

                        Console.WriteLine("*****PICTURE*****" + "\n" + "Keychain - ₱115");

                        Console.WriteLine("*****PICTURE*****" + "\n" + "Bracelet - ₱135");

                        break;

                    case 2:
                        Console.Write("Enter the product: ");
                        string toOrder = Convert.ToString(Console.ReadLine());

                        string phoneCharm = Convert.ToString(Console.ReadLine());
                        string keyChain = Convert.ToString(Console.ReadLine());
                        string braceLet = Convert.ToString(Console.ReadLine());

                        int pcharm = 75, kchain = 115, bl = 135;

                        if (toOrder == phoneCharm)
                        {

                            Console.WriteLine("Is Phone Charm - ₱75 you want to buy? ");
                            string confirmation = Convert.ToString(Console.ReadLine());

                            if (confirmation == "yes")
                            {
                                Console.WriteLine("Phone Charm - ₱75" + "\n" + "successfully ordered!");
                            }

                            else
                            {
                                Console.WriteLine(toOrder);
                            }
                        }

                        else if (toOrder == keyChain)
                        {

                            Console.WriteLine("Is Keychain - ₱115 you want to buy? ");
                            string confirmation = Convert.ToString(Console.ReadLine());

                            if (confirmation == "yes")
                            {
                                Console.WriteLine("Keychain - ₱115" + "\n" + "successfully ordered!");
                            }

                            else
                            {
                                Console.WriteLine(toOrder);
                            }
                        }

                        else if (toOrder == braceLet)
                        {

                            Console.WriteLine("Is Bracelet - ₱135 you want to buy? ");
                            string confirmation = Convert.ToString(Console.ReadLine());

                            if (confirmation == "yes")
                            {
                                Console.WriteLine("Keychain - ₱135" + "\n" + "successfully ordered!");
                            }

                            else
                            {
                                Console.WriteLine(toOrder);
                            }
                          }

                        else
                        {
                            Console.WriteLine("No more other than the 3 products");
                        }

                        break;

                    case 3:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        break;
                }

            }
            else
            {
                Console.WriteLine("Incorrect Password. Try again.");
            }
        }
    }
 }
