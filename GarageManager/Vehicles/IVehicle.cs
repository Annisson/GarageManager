namespace GarageManager.Vehicles
{
    internal interface IVehicle
    {
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        uint VehicleID { get; }

        string VehicleInformation();
    }
}