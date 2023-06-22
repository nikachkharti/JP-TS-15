using JPTS15Bank.Repositories.Implementations;
using JPTS15Bank.Models;

CustomerRepository repo = new();
repo.AddCustomer(new Customer()
{
    Id = 100,
    IdentityNumber = "12345678945",
    Email = "nika@gmail.com",
    Name = "Nika",
    PhoneNumber = "554774411",
    Type = CustomerType.Physicial
});


Console.ReadKey();