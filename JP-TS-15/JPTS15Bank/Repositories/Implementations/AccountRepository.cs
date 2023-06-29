using JPTS15Bank.Models;
using JPTS15Bank.Repositories.Interfaces;

namespace JPTS15Bank.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private const string _filePath = @"../../../Data/Accounts.csv";
        private List<Account> _accounts = new();
        public AccountRepository()
        {
            _accounts = File
                .ReadAllLines(_filePath)
                .Skip(1)
                .Select(x => x.ToAccount())
                .ToList();
        }

        public void AddAccount(Account model)
        {
            int maxId = _accounts.Max(x => x.Id);
            model.Id = maxId += 1;

            _accounts.Add(model);
            File.AppendAllText(_filePath, model.ToCsv());
        }

        public Account GetAccountById(int id)
        {
            Account result = _accounts.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<Account> GetAccountsByCustomerId(int customerId)
        {
            List<Account> result = _accounts
                .Where(x => x.CustomerId == customerId)
                .ToList();

            return result;
        }

        public List<Account> GetAllAccounts()
        {
            return _accounts;
        }
    }

    internal static class AccountExtension
    {
        internal static string ToCsv(this Account model) => $"\n{model.Id},{model.Iban},{model.Currency},{model.Balance},{model.CustomerId},{model.Name}";

        internal static Account ToAccount(this string input)
        {
            string[] csvInput = input.Split(',');

            Account result = new Account();
            result.Id = int.Parse(csvInput[0]);
            result.Iban = csvInput[1];
            result.Currency = csvInput[2];
            result.Balance = decimal.Parse(csvInput[3]);
            result.CustomerId = int.Parse(csvInput[4]);
            result.Name = csvInput[5];
            result.Customer = GetCustomer(result.CustomerId);

            return result;
        }

        private static Customer GetCustomer(int id)
        {
            CustomerRepository repo = new();
            Customer result = repo.GetCustomerById(id);

            return result;
        }

    }
}
