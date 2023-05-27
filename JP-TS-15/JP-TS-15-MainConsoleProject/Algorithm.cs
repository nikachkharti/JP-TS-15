namespace JP_TS_15_MainConsoleProject
{
    public static class Algorithm
    {
        public static Vehicle[] Take(Vehicle[] vehicles, int quantity)
        {
            if (vehicles.Length <= quantity)
            {
                throw new ArgumentOutOfRangeException("Insuficcinet data");
            }

            Vehicle[] result = new Vehicle[quantity];
            for (int i = 0; i < quantity; i++)
            {
                result[i] = vehicles[i];
            }

            return result;
        }
        public static Vehicle[] Select(string[] stringArray)
        {
            Vehicle[] vehicleArray = new Vehicle[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                vehicleArray[i] = Vehicle.Parse(stringArray[i]);
            }

            return vehicleArray;
        }
        public static List<Vehicle> FindAll(Vehicle[] vehicles, string make)
        {
            List<Vehicle> result = new();

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i].Make.Contains(make))
                {
                    result.Add(vehicles[i]);
                }
            }

            return result;
        }
        public static Vehicle[] OrderBy(Vehicle[] vehicleArray)
        {
            for (int i = 0; i < vehicleArray.Length - 1; i++)
            {
                for (int j = i + 1; j < vehicleArray.Length; j++)
                {
                    if (vehicleArray[j].Combined > vehicleArray[i].Combined)
                    {
                        //Swap
                        Vehicle temporary = vehicleArray[j];
                        vehicleArray[j] = vehicleArray[i];
                        vehicleArray[i] = temporary;
                    }
                }
            }

            return vehicleArray;
        }
    }
}
