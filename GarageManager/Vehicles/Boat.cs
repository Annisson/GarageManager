namespace GarageManager.Vehicles
{
    internal class Boat : Vehicle
    {
        public double Lenght { get; set; }
        public Boat(string color, int numberOfWheels, double lenght) : base(color, numberOfWheels)
        {
            Lenght = lenght;
        }

        public override string VehicleInformation()
        {
            return base.VehicleInformation() + $", Lenght: {Lenght}m";
        }
    }
}
