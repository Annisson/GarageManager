using GarageManager.Vehicles;

namespace GarageManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my ~*~ Garage ~*~");



            // TODO: Testar, tas bort

            var car1 = new Car("red", 4, Car.FuelType.Gasoline); 
            var mc = new Motorcycle("black", 2, Motorcycle.EngineType.Rotary, false);
            var plane1 = new Airplane("white", 4, 2, 35.79);
            var bus1 = new Bus("red", 8, 30);
            var boat1 = new Boat("white", 0, 7);

            Console.WriteLine(car1.VehicleInformation()); 
            Console.WriteLine(mc.VehicleInformation());
            Console.WriteLine(plane1.VehicleInformation());
            Console.WriteLine(bus1.VehicleInformation());
            Console.WriteLine(boat1.VehicleInformation());

            // ToDo: Ta bort hit



            //while (true)
            //{
            //    Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2 or 0) of your choice"
            //        + "\n1. "
            //        + "\n2. "
            //        + "\n0. Exit the application");
            //    char input = ' '; //Creates the character input to be used with the switch-case below.
            //    try
            //    {
            //        input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            //        Console.Clear();
            //    }
            //    catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Please enter some input!");
            //    }
            //    switch (input)
            //    {
            //        case '1':

            //            break;
            //        case '2':

            //            break;
            //        case '3':

            //            break;
            //        case '4':

            //            break;
            //        case '0':
            //            Environment.Exit(0);
            //            break;
            //        default:
            //            Console.WriteLine("Please enter some valid input (1, 2, or 0)");
            //            break;
            //    }
            //}
        }
    }
}
