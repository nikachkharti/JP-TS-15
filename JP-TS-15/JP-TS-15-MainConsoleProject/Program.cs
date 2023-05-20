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

//შექმენით User - ების მასივი სადაც შეინახავთ რამდნეიმე User-ს.
//დაწერეთ ფუნქცია FindTheRichest მოძებნეთ ყველაზე მდიდარი User -ი თქვენს 
//User ებს შორის და ჩაწერეთ ამ User-ის შესახებ სრული ინფორმაცია File-ში...




