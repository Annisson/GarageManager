using GarageManager.Garage;
using GarageManager.Helpers;
using GarageManager.Vehicles;

namespace GarageManager.UserInterface
{
    internal class ConsoleUI
    {
        private GarageHandler garageHandler;

        public ConsoleUI(GarageHandler garageHandler)
        {
            this.garageHandler = garageHandler;
        }

        public void NewGarage()
        {
            int capacity = Util.GetIntInput("Enter the size of the garage: ");
            string setupMessage = garageHandler.SetupNewGarage(capacity);
            Console.WriteLine(setupMessage);
        }

        public void ExistingGarageContents(IEnumerable<Vehicle> vehicles)
        {
            Console.WriteLine("\nVehicles currently in the garage:");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.VehicleInformation());
            }
            PauseAndClearConsole();
        }

        public void PauseAndClearConsole()
        {
            Console.WriteLine("\nPress Enter to continue..."); // Paus för att inte hoppa direkt till menyn igen
            Console.ReadLine();
            Console.Clear();
        }


    }
}
