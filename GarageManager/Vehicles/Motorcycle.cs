namespace GarageManager.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public enum EngineType
        {
            InlineFour,
            Vtwin,
            SingleCylinder,
            Rotary,
            Boxer
        }
        public EngineType MotorcycleEngine { get; set; }
        public bool HasSidecar { get; set; }
        public Motorcycle(uint vehicleID, string color, int numberOfWheels, EngineType motorcycleEngine, bool hasSideCar) : base(vehicleID, color, numberOfWheels)
        {
            MotorcycleEngine = motorcycleEngine;
            HasSidecar = hasSideCar;
        }

        public override string VehicleInformation()
        {
            return base.VehicleInformation() + $", MotorcycleEngine: {MotorcycleEngine}, HasSidecar: {(HasSidecar ? "Yes" : "No")}";
        }
    }
}
