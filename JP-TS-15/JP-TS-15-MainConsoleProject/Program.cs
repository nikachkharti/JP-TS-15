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

#region Shooter Game
//Player playerNika = new() { Name = "Nika" };
//Player playerGiorgi = new() { Name = "Giorgi" };

//playerNika.DisplayYourself();
//playerGiorgi.DisplayYourself();

//Console.WriteLine("--------------------------");

//playerNika.BuyWeapon(new Glock());
//playerNika.DisplayYourself();

//Console.WriteLine("--------------------------");
//playerNika.Shoot(playerGiorgi);
#endregion


#region Interfaces


//HashSet<int> hash = new();
//hash.Add(10);
//hash.Add(120);

//HashSet<int> hash2 = new();
//hash2.Add(10);
//hash2.Add(120);
//hash2.Add(30);


//var result = hash2.Except(hash);

//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}




//Dictionary<string, int> dict = new();
//dict.Add("erti", 1);
//dict.Add("ori", 2);
//dict.Add("sami", 3);


//foreach (var item in dict)
//{
//    Console.WriteLine(item.Key);
//}




//Stack<int> intStack = new();
//intStack.Push(20);
//intStack.Push(30);
//intStack.Push(40);


//Queue<int> intQueue = new();

//intQueue.Enqueue(10);
//intQueue.Enqueue(20);
//intQueue.Enqueue(30);

//intQueue.Dequeue();
//intQueue.Dequeue();



List<int> intList = new() { 1, 2, 3 };
IEnumerable<int> t = intList.MyWhere(x => x % 2 != 0);


Console.ReadLine();

void NikasForeach(IEnumerable<int> source)
{
    var sourceEnumerator = source.GetEnumerator();
    while (sourceEnumerator.MoveNext())
    {
        Console.WriteLine(sourceEnumerator.Current);
    }
}




#endregion



