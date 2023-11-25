using BankGPT.Library;
using BankGPT.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;

namespace BankGPT.Repository
{
    public class OperationService : IOperationService
    {
        public async Task CreateOperationAsync(OperationModel model)
        {
            const string sqlExpression = "CreateOperation";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("type", model.Type);
                    command.Parameters.AddWithValue("currency", model.Currency);
                    command.Parameters.AddWithValue("amount", model.Amount);
                    command.Parameters.AddWithValue("customerId", model.CustomerId);
                    command.Parameters.AddWithValue("accountId", model.AccountId);
                    command.Parameters.AddWithValue("happendAt", model.HappendAt);

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

        public async Task DeleteOperationAsync(int operationId)
        {
            const string sqlExpression = "DeleteOperation";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("id", operationId);

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

        public async Task<List<OperationModel>> GetAllOperationsAsync()
        {
            const string sqlExpression = "AllOperations";

            List<OperationModel> result = new();

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
                            result.Add(new OperationModel
                            {
                                Id = reader.GetInt32(0),
                                Type = reader.GetString(1).Trim(),
                                Currency = reader.GetString(2).Trim(),
                                Amount = reader.GetDouble(3),
                                AccountId = reader.GetInt32(4),
                                CustomerId = reader.GetInt32(5),
                                HappendAt = reader.GetDateTime(6)
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

        public async Task<OperationModel> GetAllOperationsForAccountAsync(int accountId)
        {
            const string sqlExpression = "AllOperationsForAccount";

            OperationModel result = new();

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
                            result.Type = reader.GetString(1).Trim();
                            result.Currency = reader.GetString(2).Trim();
                            result.Amount = reader.GetDouble(3);
                            result.AccountId = reader.GetInt32(4);
                            result.CustomerId = reader.GetInt32(5);
                            result.HappendAt = reader.GetDateTime(6);
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

        public async Task<OperationModel> GetAllOperationsForCustomerAsync(int customerId)
        {
            const string sqlExpression = "AllOperationsForCustomer";

            OperationModel result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", customerId);

                    await connection.OpenAsync();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Id = reader.GetInt32(0);
                            result.Type = reader.GetString(1).Trim();
                            result.Currency = reader.GetString(2).Trim();
                            result.Amount = reader.GetDouble(3);
                            result.AccountId = reader.GetInt32(4);
                            result.CustomerId = reader.GetInt32(5);
                            result.HappendAt = reader.GetDateTime(6);
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
    }
}
