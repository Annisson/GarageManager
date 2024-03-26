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

        public void RemoveVehicle(T vehicle)
        {
            // ToDo: Remove vehicle


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
