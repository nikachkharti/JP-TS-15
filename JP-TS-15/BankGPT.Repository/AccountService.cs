using Microsoft.Data.SqlClient;
using BankGPT.Library;
using BankGPT.Repository.Interfaces;
using System.Data;

namespace BankGPT.Repository
{
    public class AccountService : IAccountService
    {
        public async Task CreateAccountAsync(AccountModel accountModel)
        {
            const string sqlExpression = "AddAccount";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("iban", accountModel.Iban);
                    command.Parameters.AddWithValue("Currency", accountModel.Currency);
                    command.Parameters.AddWithValue("balance", accountModel.Balance);
                    command.Parameters.AddWithValue("customerId", accountModel.CustomerId);
                    command.Parameters.AddWithValue("name", accountModel.Name);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        public Task DeleteAccountAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountModel>> GetAllAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountModel>> GetAllAccountsOfCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccountAsync(AccountModel accountModel)
        {
            throw new NotImplementedException();
        }
    }
}
