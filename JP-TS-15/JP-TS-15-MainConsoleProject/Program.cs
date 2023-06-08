using JP_TS_15_MainConsoleProject;

int[] intArray = { 2, 1, 2, 3, 4, 11, -1, -2, 11 };
string[] names = { "Nika", "Giorgi", "Daviti", "Daviti" };



var result = Algorithm.FindLastIndex<string>(names, x => x == "Lasha");




Console.ReadLine();
