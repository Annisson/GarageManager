using GarageManager.Vehicles;
using System.Collections;

namespace GarageManager.Garage
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle 
    {
        private T[] vehicles; // Privat array för samling av fordon

        public Garage(int capacity) // Konstruktor som tar in kapaciteten som argument
        {
            vehicles = new T[capacity];
        }

        public void AddVehicle(T vehicle)
        {
            int index = Array.FindIndex(vehicles, x => x == null); // Hittar första plats(index) i arrayen so är null, dvs första lediga plats

            if (index != -1) // FindIndex returnerar -1 om den inte hittar en ledig plats, så om index inte är -1 så tilldelas första bästa plats nedan
            {
                vehicles[index] = vehicle; // Tilldelar arrayen den platsen som var ledig
                Console.WriteLine($"The {vehicle.GetType().Name} with ID-number \"{vehicle.VehicleID}\" has been added to the garage.");
            }
            else
            {
                Console.WriteLine("The garage is full, you cannot add any more vehicles.");
            }
        }

        public void RemoveVehicle(string vehicleID)
        {
            string searchID = vehicleID.ToUpper();

            if (searchID is not null)
            {
                T vehicleToRemove = vehicles.FirstOrDefault(x => x != null && x.VehicleID.ToUpper() == searchID)!; // Första bästa Vehicle som matchar user input VehicleID

                if (vehicleToRemove is not null) // Om fordonet hittas
                {
                    int index = Array.IndexOf(vehicles, vehicleToRemove); // Spara index för det fordonet som ska tas bort
                    vehicles[index] = null!; // Sätt till null för att ta bort fordonet, nu är platsen ledig igen
                    Console.WriteLine($"Vehicle with ID \"{vehicleID}\" has been removed from the garage.");
                }
                else
                {
                    Console.WriteLine($"Vehicle with ID \"{vehicleID}\" not found in the garage.");
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in vehicles) 
            {
                if (vehicle is not null)
                {
                    yield return vehicle; // Returnerar en vehicle åt gången om den inte är null
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
