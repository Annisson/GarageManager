namespace GarageManager
{
    // Fordonsklass, basklass för alla fordon
    internal abstract class Vehicle : IVehicle
    {
        public uint VehicleID { get; private set; } // ToDo: Egen klass för att skapa detta?
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        protected Vehicle(uint vehicleID, string color, int numberOfWheels)
        {
            VehicleID = vehicleID;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public virtual string VehicleInformation()
        {
            return $"VehicleID: {VehicleID}, Color: {Color}, NumberOfWheels: {NumberOfWheels}";
        }


    }
}
