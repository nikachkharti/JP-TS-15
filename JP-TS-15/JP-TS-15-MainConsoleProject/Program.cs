using JP_TS_15_MainConsoleProject;
using JP_TS_15_MainConsoleProject.Shooter;

#region Inheritence and abstract classes class code

////Person p1 = new() { FirstName = "Giorgi", LatName = "Giorgadze", Age = 20 };

//Student s1 = new() { FirstName = "Aleksandre", LatName = "Teliashvili", Age = 20, Score = 200 };
//s1.Talk();
////Employee e1 = new() { FirstName = "Davit", LatName = "Davitadze", Age = 30, Salary = 1000 };

//Subject csharp = new() { Name = "C#" };
//Lecturer l1 = new() { FirstName = "Nika", LatName = "Chkhartihvili", Age = 28, Salary = 5000, Subject = csharp };
//l1.Talk();
//Administration a1 = new() { FirstName = "Davit", LatName = "Davitadze", Age = 30, Salary = 10000 };
//a1.Talk();





//void Login(Person person) => Console.WriteLine($"Hello {person.FirstName}");


//abstract class Person
//{
//    public string FirstName { get; set; }
//    public string LatName { get; set; }
//    public int Age { get; set; }
//    public abstract void Talk();
//}

//class Student : Person
//{
//    public double Score { get; set; }

//    public override void Talk()
//    {
//        Console.WriteLine($"Hello my name is {FirstName} {LatName} I have {Score}");
//    }
//}

//abstract class Employee : Person
//{
//    public decimal Salary { get; set; }
//}

//class Subject
//{
//    public string Name { get; set; }
//}

//class Lecturer : Employee
//{
//    public Subject Subject { get; set; }

//    public override void Talk()
//    {
//        Console.WriteLine($"Hello my name is {FirstName} {LatName} I have {Subject.Name} I have {Salary}");
//    }
//}

//class Administration : Employee
//{
//    public override void Talk()
//    {
//        Console.WriteLine($"Hello my name is {FirstName} {LatName} I have {Salary}");
//    }
//}


#endregion



//1. Player - ფული,სიცოცხლე,სახელი BuyWeapon DONE
//2. Weapon - ტყვიების რაოდენობა,Damage,ფასი,სახელი DONE
//3. დაწერეთ იარაღის გასროლის ლოგიკა... DONE




Player playerNika = new() { Name = "Nika" };
Player playerGiorgi = new() { Name = "Giorgi" };

playerNika.DisplayYourself();
playerGiorgi.DisplayYourself();

Console.WriteLine("--------------------------");

playerNika.BuyWeapon(new Glock());
playerNika.DisplayYourself();

Console.WriteLine("--------------------------");
playerNika.Shoot(playerGiorgi);