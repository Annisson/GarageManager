using System.Text;

namespace GarageManager.Vehicles
{
    public class VehicleID
    {
        private static readonly Random random = new();  // Sätter readonly för att de inte ska kunna sättas någon annanstans i projektet
        private static readonly HashSet<string> usedIDs = []; // HashSet för att spara alla unika ID-nummer vartefter de skapas

        public string GenerateVehicleID() // För att generera unika ID-nummer (t.ex. ABC123)
        {
            string newID; // Håller variabeln för nya ID-numret
            do
            {
                char[] letterChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // Dessa ska gå att välja för de första 3 characters i ID-numret
                StringBuilder stringBuilder= new(); // För att bygga ihop nya ID-numret
                for (int i = 0; i < 3; i++) // Så länge i är mindre än 3 (antalet vi behöver för första delen), så genereras en ny random bokstav och läggs till i strängen
                {
                    stringBuilder.Append(letterChars[random.Next(letterChars.Length)]);
                }
                stringBuilder.Append(random.Next(1, 10)); // Fortsätter att bygga på strängen med siffror nu, genererar en random siffra mellan 1-9 x 3
                stringBuilder.Append(random.Next(1, 10));
                stringBuilder.Append(random.Next(1, 10)); 
                newID = stringBuilder.ToString(); // Spara ned nya ID-numret och gör om till en sträng
            } while (usedIDs.Contains(newID)); // Om HashSet innehåller det nyskapade ID-numret så körs loopen igen, annars går den vidare

            usedIDs.Add(newID); // Lägger till nya ID-numret i HashSet för att spara alla unika ID-nummer och förhindra dubletter
            return newID;
        }

    }
}
