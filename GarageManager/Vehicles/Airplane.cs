namespace GarageManager.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }
        public double Wingspan { get; set; }
        public Airplane(uint vehicleID, string color, int numberOfWheels, int numberOfEngines, double wingspan) : base(vehicleID, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
            Wingspan = wingspan;
        }

        public override string VehicleInformation()
        {
            return base.VehicleInformation() + $", NumberOfEngines: {NumberOfEngines}, Wingspan: {Wingspan}";
        }
    }
}
