using JPTS15Bank.Repositories.Implementations;
using JPTS15Bank.Models;

CustomerRepository repo = new();

var obj1 = new Customer()
{
    IdentityNumber = "12345678945",
    Email = "nika@gmail.com",
    Name = "Nika Chkhartishvili",
    PhoneNumber = "557744181",
    Type = CustomerType.Physicial
};

repo.AddCustomer(obj1);


//var obj2 = new Customer()
//{
//    IdentityNumber = "12345678945",
//    Email = "nika@gmail.com",
//    Name = "Nika Chkhartishvili",
//    PhoneNumber = "55774411",
//    Type = CustomerType.Physicial
//};









