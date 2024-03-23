namespace GarageManager.Vehicles
{
    internal class Boat : Vehicle
    {
        public double Lenght { get; set; }
        public Boat(uint vehicleID, string color, int numberOfWheels, double lenght) : base(vehicleID, color, numberOfWheels)
        {
            Lenght = lenght;
        }

        public override string VehicleInformation()
        {
            return base.VehicleInformation() + $", Lenght: {Lenght}m";
        }
    }
}
