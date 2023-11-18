using BankGPT.Library;
using BankGPT.Repository.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

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

                    command.Parameters.AddWithValue("Iban", accountModel.Iban);
                    command.Parameters.AddWithValue("Currency", accountModel.Currency);
                    command.Parameters.AddWithValue("Balance", accountModel.Balance);
                    command.Parameters.AddWithValue("CustomerId", accountModel.CustomerId);
                    command.Parameters.AddWithValue("Name", accountModel.Name);

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
            const string sqlExpression = "DeleteAccounts";

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
                                Balance = reader.GetFloat(3),
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

        public async Task<List<AccountModel>> GetAllAccountsOfCustomerAsync()
        {
            const string sqlExpression = "AllAccountsByCustomerId";

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
                            result.Id = reader.GetInt32(0);
                            result.FullName = reader.GetString(1);
                            result.IdentityNumber = reader.GetString(2);
                            result.PhoneNumber = reader.GetString(3);
                            result.Email = reader.GetString(4);
                            result.Type = reader.GetString(5);
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

                    command.Parameters.AddWithValue("Iban", accountModel.Iban);
                    command.Parameters.AddWithValue("Currency", accountModel.Currency);
                    command.Parameters.AddWithValue("Balance", accountModel.Balance);
                    command.Parameters.AddWithValue("CustomerId", accountModel.CustomerId);
                    command.Parameters.AddWithValue("Name", accountModel.Name);
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
