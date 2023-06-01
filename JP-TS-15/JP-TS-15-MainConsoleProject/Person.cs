namespace JP_TS_15_MainConsoleProject
{
    public class Person
    {

        //Auto Property
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string pin;
        public string Pin
        {
            get { return pin; }
            set
            {
                if (value.Length == 11)
                {
                    pin = value;
                }
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 18 && value <= 25)
                {
                    age = value;
                }
            }
        }







    }
}
