namespace GarageManager.Vehicles
{
    internal class Car : Vehicle
    {
        public enum FuelType
        {
            Gasoline,
            Diesel,
            Electric,
            Hybrid,
            Hydrogen
        }
        public FuelType CarFuelType { get; set; }
        public Car(string color, int numberOfWheels, FuelType fuelType) : base(color, numberOfWheels)
        {
            CarFuelType = fuelType;
        }

        public override string VehicleInformation()
        {
            return base.VehicleInformation() + $", FuelType: {CarFuelType}";
        }
    }
}
