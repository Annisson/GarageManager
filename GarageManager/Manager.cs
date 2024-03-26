using GarageManager.Garage;
using GarageManager.Helpers;
using GarageManager.UserInterface;

namespace GarageManager
{
    internal class Manager
    {

        internal static void Run()
        {
            Console.WriteLine("~*~ Welcome to my Garage ~*~\n");
            MainMenu();
        }

        public static void MainMenu()
        {
            GarageHandler handler = new();
            ConsoleUI consoleUI = new(handler);
            bool run = true;

            do
            {
                Console.WriteLine("Please navigate through the menu by inputting the number (1, 2, 3, 4 or 0) of your choice"
                    + "\n1. Setup new garage"
                    + "\n2. Use existing garage"
                    + "\n3. Park a vehicle"
                    + "\n4. Pick up a vehicle"
                    + "\n5. Information"
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
                            consoleUI.NewGarage();
                            break;
                        case "2":
                            handler.UseExistingGarage(consoleUI);
                            break;
                        case "3":
                            handler.ParkVehicle(consoleUI);
                            break;
                        case "4":
                            Console.WriteLine("Pick up a vehicle");  // ToDo: Pick up vehicle/remove
                            break;
                        case "5":
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
