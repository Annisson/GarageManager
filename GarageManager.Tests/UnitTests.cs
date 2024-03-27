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

        [Fact]
        public void RemoveVehicle_ShouldRemoveVehicleFromGarage()
        {
            // Arrange
            var garage = new Garage<Vehicle>(5);
            var vehicleToAdd = new Car("Red", 4, 2); // Lägger till en Car i garaget som sedan ska kunna tas bort
            garage.AddVehicle(vehicleToAdd);

            // Act
            string vehicleToRemoveId = vehicleToAdd.VehicleID; // Plockar ut VehicleID som satts på Car
            garage.RemoveVehicle(vehicleToRemoveId); // Tar bort Vehicle som matchar VehicleID ovan

            //Assert
            Assert.DoesNotContain(vehicleToAdd, garage); // Jämför Car jag skickade in och kollar att Garaget INTE innehåller den vehiclen
        }


    }
}