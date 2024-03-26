namespace GarageManager.Vehicles
{
    internal abstract class Vehicle : IVehicle
    {
        private static readonly VehicleID vehicleID = new VehicleID(); // Sparar en instans av VehicleID-klassen så vi kan kalla på metoden som genererar unika ID-nummer

        public string VehicleID { get; private set; } 
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        protected Vehicle(string color, int numberOfWheels)
        {
            VehicleID = vehicleID.GenerateVehicleID(); // Sätter VehicleID till return av metoden som genererat unikt ID-nummer
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public virtual string VehicleInformation()
        {
            return $"{GetType().Name} with VehicleID: {VehicleID}, Color: {Color}, NumberOfWheels: {NumberOfWheels}";
        }
    }
}
