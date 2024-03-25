namespace GarageManager.Helpers
{
    internal static class Util
    {
        public static string GetStringInput(string inputMessage)
        {
            string? userInput = null; // Släcker null-varning eftersom man inte kommer ut ur loopen nedan om man angett null/empty/whitespace
            while (string.IsNullOrWhiteSpace(userInput))   // Kör while-loopen tills dess att valid input har getts
            {
                Console.Write(inputMessage);
                userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput)) // Feedback vid felaktig input
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            return userInput;
        }

        public static int GetIntInput(string inputMessage)
        {
            int value;
            string userInput;
            bool isValidInput = false;
            do
            {
                userInput = GetStringInput(inputMessage); // Kallar på string metoden för user input, sedan körs parse nedan
                if (!int.TryParse(userInput, out value)) // Om userinput inte går att parse 
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                else
                {
                    isValidInput = true; // Om parse var lyckad
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
            string? userInput = null; // Släcker null-varning eftersom man inte kommer ut ur loopen nedan om man angett null/empty/whitespace
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.Write("\nEnter the number corresponding to the vehicle type: ");
                userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                else if (!IsVehicleTypeValid(userInput)) // Om användaren matar in något annat värde än de som anges i metoden nedan(1, 2, 3, 4, 5)
                {
                    Console.WriteLine("Invalid vehicle type. Please enter a valid number.");
                    userInput = null; // Sätter om värdet till null så användaren måste fortsätta mata in värden tills det blir korrekt
                }
            }
            return userInput;
        }

        private static bool IsVehicleTypeValid(string userInput)
        {
            return userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5";
        }
    }
}
