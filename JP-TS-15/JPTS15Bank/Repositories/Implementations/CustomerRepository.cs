using JPTS15Bank.BusinessException;
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
            if (CustomerIsValid(model) && !_customers.Any(cust => cust.Equals(model)))
            {
                int maxId = _customers.Max(x => x.Id);
                model.Id = maxId += 1;

                _customers.Add(model);
                File.AppendAllText(_filePath, model.ToCsv());
            }
            else
            {
                throw new CustomerException("Invalid data appeared");
            }
        }

        private bool CustomerIsValid(Customer modelToCheck)
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(modelToCheck.Name))
            {
                result = false;
            }

            if (modelToCheck.IdentityNumber.Length != 11)
            {
                result = false;
            }

            if (modelToCheck.PhoneNumber.Length != 9)
            {
                result = false;
            }

            if (!modelToCheck.Email.Contains('@') && !modelToCheck.Email.Contains('.'))
            {
                result = false;
            }

            return result;
        }


        /// <summary>
        /// წამოიღებს პირველივე ისეთ ჩანაწერს რომელიც აკმაყოფილებს გადაცემულ ID -ს
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Customer GetCustomerById(int id) => _customers.FirstOrDefault(x => x.Id == id);



        //TODO Customer კლასისთვის დაწერეთ წაშლის მეთოდი
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
