using GarageManager.Vehicles;
using GarageManager.Garage;

namespace GarageManager.Tests
{
    public class UnitTests
    {
        [Fact]
        public void AddVehicle_ShouldAddVehicleToGarage()
        {
            // Arrange
            int capacity = 5; // Simulerar 5st platser i garaget
            var garage = new Garage<Vehicle>(capacity); // Instansierar nytt Garage med platserna ovan
            var vehicleToAdd = new Airplane("White", 4, 2, 35.79); // Simulerar ett fordon(Airplane) som ska lägags till

            // Act
            garage.AddVehicle(vehicleToAdd);

            //Assert
            Assert.Contains(vehicleToAdd, garage); // Kollar att förvantade utgång(flygplanet), stämmer med den faktiskta utgången
        }

    }
}