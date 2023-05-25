using JP_TS_15_MainConsoleProject;


string[] data = File.ReadAllLines(@"../../../vehicles.csv");

Vehicle[] vehicleArray = new Vehicle[data.Length];
for (int i = 0; i < data.Length; i++)
{
    vehicleArray[i] = Vehicle.Parse(data[i]);
}


Console.ReadLine();
