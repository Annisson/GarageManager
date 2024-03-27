using GarageManager.UserInterface;

namespace GarageManager.Garage
{
    internal interface IGarageHandler
    {
        void ListAllVehicles(ConsoleUI consoleUI);
        void ListAllVehicleTypes(ConsoleUI consoleUI);
        void ParkVehicle(ConsoleUI consoleUI);
        void PickUpVehicle(string vehicleID);
        void SearchVehicleByID(ConsoleUI consoleUI);
        void SearchVehicleByProperties(ConsoleUI consoleUI);
        string SetupNewGarage(int capacity);
        void UseExistingGarage(ConsoleUI consoleUI);
    }
}