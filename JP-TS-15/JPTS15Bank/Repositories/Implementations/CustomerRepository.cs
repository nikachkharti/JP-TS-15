using JPTS15Bank.Models;
using JPTS15Bank.Repositories.Interfaces;

namespace JPTS15Bank.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private const string _filePath = @"../../../Data/Customers.csv";
        private List<Customer> _customers = new();

        public CustomerRepository()
        {
            _customers = File
                .ReadAllLines(_filePath)
                .Skip(1)
                .Select(x => x.ToCustomer())
                .ToList();
        }

        /// <summary>
        /// ჩაამატებს ახალ მომხმარებელს არამარტო ლისტში არამედ ფაილშიც.
        /// Id-ს გაზრდის ავტომატურად.
        /// </summary>
        /// <param name="model"></param>
        public void AddCustomer(Customer model)
        {
            //TODO მონაცემების შენახვამდე დაწერეთ ვალიდაციის ფუნქციები:
            //1. პირადობის ნომერი უნდა იყოს 11 ნიშნა
            //2. ტელეფონის ნომერი უდა იყოს 9 ნიშნა
            //3. Email უნდა შეიცავდეს @ და . სიმბოლოებს

            int maxId = _customers.Max(x => x.Id);
            model.Id = maxId += 1;

            _customers.Add(model);
            File.AppendAllText(_filePath, model.ToCsv());
        }


        /// <summary>
        /// წამოიღებს პირველივე ისეთ ჩანაწერს რომელიც აკმაყოფილებს გადაცემულ ID -ს
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Customer GetCustomerById(int id) => _customers.FirstOrDefault(x => x.Id == id);



        //TODO დაწერეთ წაშლის მეთოდი
    }


    internal static class CustomerExtension
    {
        internal static string ToCsv(this Customer model)
            => $"\n{model.Id},{model.Name},{model.IdentityNumber},{model.PhoneNumber},{model.Email},{model.Type}";
        internal static Customer ToCustomer(this string input)
        {
            string[] csvInput = input.Split(',');

            Customer result = new()
            {
                Id = int.Parse(csvInput[0]),
                Name = csvInput[1],
                IdentityNumber = csvInput[2],
                PhoneNumber = csvInput[3],
                Email = csvInput[4],
                Type = (CustomerType)Enum.Parse(typeof(CustomerType), csvInput[5])
            };

            return result;
        }
    }

}
