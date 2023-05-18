namespace JP_TS_15_MainConsoleProject
{
    public class User
    {
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

        //კომპოზიცია
        public Account Account { get; set; }
    }
}
