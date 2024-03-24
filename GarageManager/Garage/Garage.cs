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


        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in vehicles) 
            {
                yield return vehicle; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
