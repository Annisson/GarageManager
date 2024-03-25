namespace GarageManager.Vehicles
{
    internal class Car : Vehicle
    {
        public int PreviousOwners { get; set; }
        public Car(string color, int numberOfWheels, int previousOwners) : base(color, numberOfWheels)
        {
            PreviousOwners = previousOwners;
        }

        public override string VehicleInformation()
        {
            return base.VehicleInformation() + $", PreviousOwners: {PreviousOwners}";
        }
    }
}
