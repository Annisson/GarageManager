namespace GarageManager.Vehicles
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public Bus(uint vehicleID, string color, int numberOfWheels, int numberOfSeats) : base(vehicleID, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string VehicleInformation()
        {
            return base.VehicleInformation() + $", NumberOfSeats: {NumberOfSeats}";
        }
    }
}
