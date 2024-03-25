namespace GarageManager.Helpers
{
    internal static class Util
    {
        // ToDo: Lägg till att man får feedback om det är inkorrekt input, te.x siffra när man ska ge string och tvärtom

        public static string GetStringInput(string inputMessage)
        {
            string userInput;
            do
            {
                Console.Write(inputMessage);
                userInput = Console.ReadLine();
            } while (string.IsNullOrEmpty(userInput)); // Kör while-loopen tills dess att valid input har getts
            return userInput;
        }

        public static int GetIntInput(string inputMessage)
        {
            int value;
            string userInput;
            bool isValidInput = false;

            do
            {
                userInput = GetStringInput(inputMessage);
                if (!int.TryParse(userInput, out value))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                else
                {
                    isValidInput = true;
                }
            } while (!isValidInput);
            return value;
        }

        public static double GetDoubleInput(string inputMessage)
        {
            double value;
            string userInput;
            bool isValidInput = false;

            do
            {
                userInput = GetStringInput(inputMessage);
                if (!double.TryParse(userInput, out value))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                else
                {
                    isValidInput = true;
                }
            } while (!isValidInput);
            return value;
        }

        public static string GetVehicleTypeInput()
        {
            Console.WriteLine("\nType of vehicle (Number only)" +
                               "\n1. Airplane\n2. Boat\n3. Bus\n4. Car\n5. Motorcycle");
            string userInput;
            do
            {
                Console.Write("\nEnter the number corresponding to the vehicle type: ");
                userInput = Console.ReadLine();
            } while (!IsVehicleTypeValid(userInput)); // Repeat until a valid vehicle type is provided
            return userInput;
        }

        private static bool IsVehicleTypeValid(string userInput)
        {
            return userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5";
        }
    }
}
