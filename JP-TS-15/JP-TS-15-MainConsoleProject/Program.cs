using JP_TS_15_MainConsoleProject;


User user = new()
{
    FirstName = "Nika",
    LastName = "Chkhartishvili",
    Pin = "12345678945",
    Account = new Account()
    {
        AccountNumber = "1234567894512345678945",
        Balance = 100.2m,
        Currency = "GEL"
    }
};


Console.WriteLine($"{user.FirstName} {user.LastName} {user.Pin} {user.Account.AccountNumber} {user.Account.Currency} {user.Account.Balance}");

