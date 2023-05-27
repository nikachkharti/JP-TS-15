using JP_TS_15_MainConsoleProject;


string[] data = File.ReadAllLines(@"../../../vehicles.csv");
Vehicle[] vehiclesData = Algorithm.Select(data);
var bmws = Algorithm.FindAll(vehiclesData, "BMW");
var sortedCars = Algorithm.OrderBy(vehiclesData);



Console.ReadLine();







