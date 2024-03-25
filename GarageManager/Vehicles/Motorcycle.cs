namespace GarageManager.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public double Cylindervolume  { get; set; }
        public Motorcycle(string color, int numberOfWheels, double cylindervolume) : base(color, numberOfWheels)
        {
            Cylindervolume = cylindervolume;
        }

        public override string VehicleInformation()
        {
            return base.VehicleInformation() + $", Cylindervolume: {Cylindervolume}";
        }
    }
}
