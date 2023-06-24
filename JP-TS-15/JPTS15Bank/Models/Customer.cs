using System.Diagnostics.CodeAnalysis;

namespace JPTS15Bank.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public CustomerType Type { get; set; }

        public override bool Equals(object obj)
        {
            return new CustomerEquilityComparer().Equals(this, obj as Customer);
        }

        public override int GetHashCode()
        {
            return new CustomerEquilityComparer().GetHashCode(this);
        }

    }

    class CustomerEquilityComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y) => x.IdentityNumber == y.IdentityNumber;

        public int GetHashCode(Customer obj) => obj.Email.Length;
    }
}
