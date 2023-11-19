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

        public async Task DeleteAccountAsync(int accountId)
        {
            const string sqlExpression = "DeleteAccount";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("id", accountId);

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

        public async Task<List<AccountModel>> GetAllAccountsAsync()
        {
            const string sqlExpression = "AllAccounts";

            List<AccountModel> result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new AccountModel
                            {
                                Id = reader.GetInt32(0),
                                Iban = reader.GetString(1),
                                Currency = reader.GetString(2),
                                Balance = reader.GetDouble(3),
                                CustomerId = reader.GetInt32(4),
                                Name = reader.GetString(5),
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }


            return result;
        }

        public async Task<AccountModel> GetSingleAccountAsync(int accountId)
        {
            const string sqlExpression = "SingleAccount";

            AccountModel result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", accountId);

                    await connection.OpenAsync();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Id = reader.GetInt32(0);
                            result.Iban = reader.GetString(1);
                            result.Currency = reader.GetString(2);
                            result.Balance = reader.GetDouble(3);
                            result.CustomerId = reader.GetInt32(4);
                            result.Name = reader.GetString(5);
                        }
                    }
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


            return result;
        }

        public async Task UpdateAccountAsync(AccountModel accountModel)
        {
            const string sqlExpression = "UpdateAccount";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("iban", accountModel.Iban);
                    command.Parameters.AddWithValue("currency", accountModel.Currency);
                    command.Parameters.AddWithValue("balance", accountModel.Balance);
                    command.Parameters.AddWithValue("customerId", accountModel.CustomerId);
                    command.Parameters.AddWithValue("name", accountModel.Name);
                    command.Parameters.AddWithValue("id", accountModel.Id);

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

        
    }
}
