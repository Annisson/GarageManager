using GarageManager.Garage;
using GarageManager.Helpers;
using GarageManager.Vehicles;

namespace GarageManager.UserInterface
{
    internal class ConsoleUI : IConsoleUI
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
        public void PrintRemoveVehicle(GarageHandler handler)
        {
            string vehicleID = Util.GetStringInput("Enter the VehicleID of the vehicle you want to remove: ");
            handler.PickUpVehicle(vehicleID); // Skicka in ID nummer för fordonet som ska tas bort
            PauseAndClearConsole();
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

        public void PrintListAllVehicleTypes(IEnumerable<Vehicle> vehicles)
        {
            Dictionary<string, int> vehicleDictionary = []; // Dictionary för att spara och läsa upp vehicle type + antal

            foreach (var vehicle in vehicles)
            {
                string vehicleType = vehicle.GetType().Name; // Sparar typen av vehicle(t.ex Car, Bus osv)
                if (!vehicleDictionary.ContainsKey(vehicleType)) // Om typen som loopas detta varv inte redan finns som key så läggs den till nedan och tilldeals värdet 0
                {
                    vehicleDictionary[vehicleType] = 0;
                }
                vehicleDictionary[vehicleType]++; // Lägg sedan till +1 på den typen av vehicle det är
            }

            var sortedVehicleCount = vehicleDictionary.OrderBy(vehicleTypeCount => vehicleTypeCount.Key); // Sorterar listan av vehicles A-Z
            Console.WriteLine("\nThese are the vehicle types currently in the garage:");

            foreach (var vehicleTypeCount in sortedVehicleCount)
            {
                Console.WriteLine($"{vehicleTypeCount.Key}: {vehicleTypeCount.Value}"); // Skriver ut vehicle type + antal
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
