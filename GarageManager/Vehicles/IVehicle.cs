namespace GarageManager.Vehicles
{
    internal interface IVehicle
    {
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        string VehicleID { get; }

        string VehicleInformation();
    }
}