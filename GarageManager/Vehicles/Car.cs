using static GarageManager.Vehicles.Car;

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
        public Car(uint vehicleID, string color, int numberOfWheels, FuelType fuelType) : base(vehicleID, color, numberOfWheels)
        {
            CarFuelType = fuelType;
        }

        public virtual string VehicleInformation()
        {
            return base.VehicleInformation() + $", FuelType: {CarFuelType}.";
        }
    }
}
