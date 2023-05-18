namespace JP_TS_15_MainConsoleProject
{
    public class Account
    {
        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
            set
            {
                if (value.Length == 22)
                {
                    accountNumber = value;
                }
            }
        }

        private string currency;
        public string Currency
        {
            get { return currency; }
            set
            {
                if (value.Length == 3)
                {
                    currency = value;
                }
            }
        }

        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value > 0)
                {
                    balance = value;
                }
            }
        }


    }
}
