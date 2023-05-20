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
        public void Transfer(decimal transferAmount, User userToRecive)
        {
            try
            {
                if (Account.Balance >= transferAmount)
                {
                    Account.Balance -= transferAmount;
                    userToRecive.Account.Balance += transferAmount;
                }
                else
                {
                    throw new ArgumentException("Unable to transfer amount");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
