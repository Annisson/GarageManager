using GarageManager.Helpers;
using GarageManager.UserInterface;
using GarageManager.Vehicles;

namespace GarageManager.Garage
{
    internal class GarageHandler
    {
        private Garage<Vehicle> garage; // Default 50 parkeringsplatser
        private int capacity;

        public GarageHandler()
        {
            garage = new Garage<Vehicle>(50); // Default 50 parkeringsplatser
        }


        public string SetupNewGarage(int capacity) // Låter användaren bestämma antal platser i garaget
        {
            this.capacity = capacity;
            garage = new Garage<Vehicle>(this.capacity); // Tilldelar nya värdet som användaren valt

            if (garage is not null)
            {
                return $"Garage setup successful. You now have {capacity} available slots in the garage.";
            }
            else
            {
                return "Failed to setup garage.";
            }

        }

        public void UseExistingGarage(ConsoleUI consoleUI) // Garage med några fordon redan populerade
        {
            garage.AddVehicle(new Car("Red", 4, 2));
            garage.AddVehicle(new Motorcycle("Black", 2, 400));
            garage.AddVehicle(new Airplane("White", 4, 2, 35.79));
            garage.AddVehicle(new Bus("Red", 8, 30));
            garage.AddVehicle(new Boat("White", 0, 7));

            if (garage is not null)
            {
                consoleUI.PrintGarageContents(garage);
            }
            else
            {
                Console.WriteLine("Garage is not initialized.");
            }
        }

        public void ParkVehicle(ConsoleUI consoleUI)
        {
            Console.WriteLine("\nPlease enter information below about the vehicle you want to park");

            string type = Util.GetVehicleTypeInput(); // Vilket typ av vehicle användaren vill registrera
            string color = Util.GetStringInput("Color: ");
            int numberOfWheels = Util.GetIntInput("Number of Wheels: ");

            Vehicle vehicle = CreateVehicle(type, color, numberOfWheels); // Kallar på createVehicle metoden och skickar in det användaren valt som gäller för alla vehicles

            if (vehicle is not null)
            {
                garage.AddVehicle(vehicle); // Lägg till i garaget
                Console.WriteLine(vehicle.VehicleInformation()); // Skriver ut alla egenskaper
            }
            else
            {
                Console.WriteLine("Invalid vehicle type.");
            }
            consoleUI.PauseAndClearConsole();
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

        public void PickUpVehicle(string vehicleID)
        {
            garage.RemoveVehicle(vehicleID);
        }

        public void ListAllVehicles(ConsoleUI consoleUI)
        {
            if (garage is not null)
            {
                consoleUI.PrintGarageContents(garage);
            }
            else
            {
                Console.WriteLine("Garage is not initialized.");
            }
        }

        public void ListAllVehicleTypes(ConsoleUI consoleUI)
        {
            if (garage is not null)
            {
                consoleUI.PrintListAllVehicleTypes(garage);
            }
            else
            {
                Console.WriteLine("Garage is not initialized.");
            }
        }

        public void SearchVehicleByID(ConsoleUI consoleUI)
        {
            string vehicleID = Util.GetStringInput("Search for the following VehicleID(input ex. ABC123): ").ToUpper();

            if (vehicleID is not null)
            {
                // Första bästa Vehicle som matchar användarens input av VehicleID, kan hantera acb123, AbC123, ABC123
                Vehicle vehicleToRemove = garage.FirstOrDefault(x => x != null && string.Equals(x.VehicleID, vehicleID, StringComparison.OrdinalIgnoreCase))!;

                if (vehicleToRemove is not null) // Om fordonet hittas
                {
                    Console.WriteLine($"Vehicle with ID \"{vehicleID}\" was found!");
                }
                else
                {
                    Console.WriteLine($"There is no vehicle with ID \"{vehicleID}\" in this garage.");
                }
            }
            consoleUI.PauseAndClearConsole();
        }

        public void SearchVehicleByProperties(ConsoleUI consoleUI)
        {
            string userSearchInput = Util.GetStringInput("Avaliable propreties to search for are VechicleID, Color, and/or NumberOfWheels" +
                "\nInput example; Color: Red, NumberOfWheels: 4" +
                "\nYour search: ");

            string[] criteriaSplit = userSearchInput.Split(',');  // Delar upp userinput, t.ex skulle ovan ge "Color : Red" och "NumberOfWheels: 4".

            List<Vehicle> matchingVehicles = new List<Vehicle>(); // För att spara ned alla träffar

            foreach (Vehicle vehicle in garage)
            {
                bool vehicleFound = true;

                foreach (var item in criteriaSplit)
                {
                    string[] parts = item.Split(':'); // Delar upp sök så t.ex. "Color : Red" nu blir "Color" och "Red"
                    string propertyName = parts[0].Trim(); // Här sparas property, t.ex "Color" samt trimmar bort alla spaces innan och efter ordet
                    string propertyValue = parts[1].Trim(); // Här sparas sökordet, t.ex "Red" samt trimmar bort alla spaces innan och efter ordet

                    switch (propertyName) // Kollar om property input stämmer med faktiska properties nedan
                    {
                        case "Color":
                            if (!string.Equals(vehicle.Color, propertyValue, StringComparison.OrdinalIgnoreCase)) // Om fordonet inte har Color + det värde som angavs
                            {                                                                               // så sätts bool nedan till false och då sparas inte fordonet
                                vehicleFound = false;
                            }
                            break;
                        case "NumberOfWheels":
                            if (vehicle.NumberOfWheels != int.Parse(propertyValue))
                            {
                                vehicleFound = false;
                            }
                            break;
                        default: // Om property name är fel
                            vehicleFound = false; 
                            break;
                    }

                    if (!vehicleFound) // Om inget i sökningen stämmer alls på current vechicle
                    {
                        break;
                    }
                }

                if (vehicleFound) // Om boolen fortfarande är true så finns fordonet, och då läggs den till i listan
                {
                    matchingVehicles.Add(vehicle);
                }
            }

            if (matchingVehicles.Count > 0) // Om det finns minst ett fordon i listan så printas de ut i konsollen
            {
                Console.WriteLine("Vehicles found that match the search input:");
                foreach (var vehicle in matchingVehicles)
                {
                    Console.WriteLine(vehicle.VehicleInformation());
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles that match the search input.");
            }
            consoleUI.PauseAndClearConsole();
        }

    }
}
