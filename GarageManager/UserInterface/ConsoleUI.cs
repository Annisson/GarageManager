using GarageManager.Garage;

namespace GarageManager.UserInterface
{
    internal class ConsoleUI
    {

        public static void MainMenu()
        {
            bool run = true;

            do
            {
                Console.WriteLine("Please navigate through the menu by inputting the number (1, 2, 3, 4 or 0) of your choice"
                    + "\n1. Setup Garage"
                    + "\n2. Park a vehicle"
                    + "\n3. Pick up a vehicle"
                    + "\n4. Information"
                    + "\n0. Exit the application");

                string? input = Console.ReadLine(); // Släcker null-varningen eftersom null-check görs nedan

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input.");
                }
                else
                {
                    Console.Clear();
                    switch (input)
                    {
                        case "1":
                            SetupGarageSubMenu();
                            break;
                        case "2":
                            GarageHandler gh = new();
                            gh.ParkVehicle();
                            break;
                        case "3":
                            Console.WriteLine(" Pick up a vehicle");
                            break;
                        case "4":
                            InformationSubMenu();
                            break;
                        case "0":
                            ExitApplication();
                            break;
                        default:
                            SwitchDefault();
                            break;
                    }
                }
            } while (run);
        }

        public static void SetupGarageSubMenu()
        {
            bool run = true;

            do
            {
                Console.WriteLine("Information sub menu\n\nPlease navigate through the menu by inputting the number (1, 2, 3, 4 or 0) of your choice"
                    + "\n1. Use existing garage"
                    + "\n2. Setup new garage"
                    + "\n3. Return to the main menu"
                    + "\n0. Exit the application");

                string? input = Console.ReadLine(); // Släcker null-varningen eftersom null-check görs nedan

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Clear();
                    Console.WriteLine("Input error");
                }
                else
                {
                    Console.Clear();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("List of all vehicles and their properties");
                            break;
                        case "2":
                            Console.WriteLine("List of vehicletypes and number of each type");
                            break;
                        case "3":
                            MainMenu();
                            break;
                        case "0":
                            ExitApplication();
                            break;
                        default:
                            SwitchDefault();
                            break;
                    }
                }
            } while (run);
        }

        public static void InformationSubMenu()
        {
            bool run = true;

            do
            {
                Console.WriteLine("Information sub menu\n\nPlease navigate through the menu by inputting the number (1, 2, 3, 4, 5 or 0) of your choice"
                    + "\n1. List of all vehicles"
                    + "\n2. List of vehicletypes"
                    + "\n3. Search vehicle by ID-number"
                    + "\n4. Search vehicle by properties"
                    + "\n5. Return to the main menu"
                    + "\n0. Exit the application");

                string? input = Console.ReadLine(); // Släcker null-varningen eftersom null-check görs nedan

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Clear();
                    Console.WriteLine("Input error");
                }
                else
                {
                    Console.Clear();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("List of all vehicles and their properties");
                            break;
                        case "2":
                            Console.WriteLine("List of vehicletypes and number of each type");
                            break;
                        case "3":
                            Console.WriteLine("Search vehicle by ID-number");
                            break;
                        case "4":
                            Console.WriteLine("Search vehicle by properties");
                            break;
                        case "5":
                            MainMenu();
                            break;
                        case "0":
                            ExitApplication();
                            break;
                        default:
                            SwitchDefault();
                            break;
                    }
                }
            } while (run);
        }

        private static void ExitApplication()
        {
            Console.WriteLine("Exiting application...");
            Environment.Exit(0);
        }

        private static void SwitchDefault()
        {
            Console.Clear();
            Console.WriteLine("Please enter some valid input (1, 2, 3, 4, 5 or 0)");
        }
    }
}
