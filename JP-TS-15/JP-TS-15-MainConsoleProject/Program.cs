using JP_TS_15_MainConsoleProject;

User user1 = new()
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
User user2 = new()
{
    FirstName = "Giorgi",
    LastName = "Giorgadze",
    Pin = "12345678745",
    Account = new Account()
    {
        AccountNumber = "1234567884512345678945",
        Balance = 20,
        Currency = "GEL"
    }
};
User user3 = new()
{
    FirstName = "Irakli",
    LastName = "Giorgadze",
    Pin = "12345678744",
    Account = new Account()
    {
        AccountNumber = "1234767884512345678945",
        Balance = 5,
        Currency = "GEL"
    }
};


User[] allUsers =
{
    user1,
    user2,
    user3,
    new User
    {
        FirstName = "Guja",
        LastName = "Gujiashvili",
        Pin = "12345678944",
        Account = new Account()
        {
            AccountNumber = "1234767884572345678945",
            Balance = 5000,
            Currency = "GEL"
        }
    }
};
User richestGuy = FindTheRichest(allUsers);

File.WriteAllText("../../../richestUser.txt", $"{richestGuy.FirstName} {richestGuy.LastName} {richestGuy.Account.AccountNumber} {richestGuy.Account.Currency} {richestGuy.Account.Balance}");



User FindTheRichest(User[] userCollection)
{
    User richestUser = userCollection[0];

    for (int i = 0; i < userCollection.Length; i++)
    {
        if (userCollection[i].Account.Balance >= richestUser.Account.Balance)
        {
            richestUser = userCollection[i];
        }
    }

    return richestUser;
}







//1.შექმენით User - ების მასივი სადაც შეინახავთ რამდნეიმე User-ს.
//დაწერეთ ფუნქცია FindTheRichest მოძებნეთ ყველაზე მდიდარი User -ი თქვენს 

//User ებს შორის და ჩაწერეთ ამ User-ის შესახებ სრული ინფორმაცია File-ში...






