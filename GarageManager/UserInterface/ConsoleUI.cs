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

        public void PrintGarageContents(IEnumerable<Vehicle> vehicles)
        {
            Console.WriteLine("\nVehicles currently in the garage:");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.VehicleInformation());
            }
            PauseAndClearConsole();
        }

        public void PrintRemoveVehicle(GarageHandler handler)
        {
            string vehicleID = Util.GetStringInput("Enter the VehicleID of the vehicle you want to remove: "); 
            handler.PickUpVehicle(vehicleID); // Skicka in ID nummer för fordonet som ska tas bort
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
