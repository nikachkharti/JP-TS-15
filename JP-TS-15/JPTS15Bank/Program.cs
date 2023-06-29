using JPTS15Bank.Repositories.Implementations;
using JPTS15Bank.Models;

CustomerRepository customerRepo = new();
AccountRepository accountRepo = new();

//var obj1 = new Customer()
//{
//    IdentityNumber = "12345678945",
//    Email = "nika@gmail.com",
//    Name = "Nika Chkhartishvili",
//    PhoneNumber = "557744181",
//    Type = CustomerType.Physicial
//};

//customerRepo.AddCustomer(obj1);

var acc1 = new Account()
{
    Iban = "GE59874125541257486541",
    Currency = "GEL",
    Balance = 100,
    CustomerId = 21,
    Name = string.Empty
};

accountRepo.AddAccount(acc1);













