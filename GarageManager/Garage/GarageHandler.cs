using GarageManager.Helpers;
using GarageManager.Vehicles;

namespace GarageManager.Garage
{
    internal class GarageHandler
    {
        //  ingen kontakt mellan Garage och UI, allt hamnar här

        Garage<Vehicle> newGarage = new(10);

        public void ParkVehicle()
        {
            Console.WriteLine("\nPlease enter information below about the vehicle you want to park");

            string type = Util.GetVehicleTypeInput(); // Vilket typ av vehicle användaren vill registrera
            string color = Util.GetStringInput("Color: ");
            int numberOfWheels = Util.GetIntInput("Number of Wheels: ");

            Vehicle vehicle = CreateVehicle(type, color, numberOfWheels); // Kallar på createVehicle metoden och skickar in det användaren valt som gäller för alla vehicles

            if (vehicle != null)
            {
                newGarage.AddVehicle(vehicle); // Lägg till i garaget
                Console.WriteLine(vehicle.VehicleInformation()); // Skriver ut alla egenskaper
            }
            else
            {
                Console.WriteLine("Invalid vehicle type.");
            }
            Console.WriteLine("\nPress Enter to continue..."); // Paus för att inte hoppa direkt till menyn igen
            Console.ReadLine();
            Console.Clear();
        }

        private Vehicle CreateVehicle(string type, string color, int numberOfWheels)
        {
            switch (type)
            {
                case "1": // Airplane
                    int numberOfEngines = Util.GetIntInput("Number of engines: ");
                    double wingspan = Util.GetDoubleInput("Wingspan in meters: ");
                    return new Airplane(color, numberOfWheels, numberOfEngines, wingspan);

                case "2": // Boat
                    double length = Util.GetDoubleInput("Length of the boat in meters: ");
                    return new Boat(color, numberOfWheels, length);

                case "3": // Bus
                    int numberOfSeats = Util.GetIntInput("Number of seats: ");
                    return new Bus(color, numberOfWheels, numberOfSeats);

                case "4": // Car
                    int previousOwners = Util.GetIntInput("Number of previous owners: ");
                    return new Car(color, numberOfWheels, previousOwners);

                case "5": // Motorcycle
                    double cylindervolume = Util.GetDoubleInput("Cylindervolume: ");
                    return new Motorcycle(color, numberOfWheels, cylindervolume);

                default:
                    return null!; // Släcker null-varningen eftersom det hanteras i ParkVehicle metoden
            }
        }





    }
}
