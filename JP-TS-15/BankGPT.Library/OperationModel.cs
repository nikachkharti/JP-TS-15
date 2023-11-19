namespace BankGPT.Library
{
    public class OperationModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public DateTime HappendAt { get; set; }
    }
}
