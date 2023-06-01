namespace JP_TS_15_MainConsoleProject
{
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public byte Cylinder { get; set; }
        public float Engine { get; set; }
        public string Drive { get; set; }
        public string Transmission { get; set; }
        public byte City { get; set; }
        public byte Combined { get; set; }
        public byte Highway { get; set; }

        public static Vehicle Parse(string value)
        {
            string[] separatedValue = value.Split(',');

            Vehicle result = new();
            result.Make = separatedValue[0];
            result.Model = separatedValue[1];
            result.Cylinder = byte.Parse(separatedValue[2]);
            result.Engine = float.Parse(separatedValue[3]);
            result.Drive = separatedValue[4];
            result.Transmission = separatedValue[5];
            result.City = byte.Parse(separatedValue[6]);
            result.Combined = byte.Parse(separatedValue[7]);
            result.Highway = byte.Parse(separatedValue[8]);

            return result;
        }
    }
}
