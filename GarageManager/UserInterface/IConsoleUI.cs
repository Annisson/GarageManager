using GarageManager.Garage;
using GarageManager.Vehicles;

namespace GarageManager.UserInterface
{
    internal interface IConsoleUI
    {
        void NewGarage();
        void PauseAndClearConsole();
        void PrintGarageContents(IEnumerable<Vehicle> vehicles);
        void PrintListAllVehicleTypes(IEnumerable<Vehicle> vehicles);
        void PrintRemoveVehicle(GarageHandler handler);
    }
}