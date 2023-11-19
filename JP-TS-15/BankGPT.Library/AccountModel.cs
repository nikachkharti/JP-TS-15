namespace BankGPT.Library
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }
}
