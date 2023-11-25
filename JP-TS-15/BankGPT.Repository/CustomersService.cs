using Microsoft.Data.SqlClient;
using BankGPT.Library;
using BankGPT.Repository.Interfaces;
using System.Data;

namespace BankGPT.Repository
{
    public class CustomersService : ICustomersService
    {
        public async Task CreateCustomerAsync(CustomersModel customersModel)
        {
            const string sqlExpression = "AddCustomer";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("fullName", customersModel.FullName);
                    command.Parameters.AddWithValue("identityNumber", customersModel.IdentityNumber);
                    command.Parameters.AddWithValue("phoneNumber", customersModel.PhoneNumber);
                    command.Parameters.AddWithValue("email", customersModel.Email);
                    command.Parameters.AddWithValue("type", customersModel.Type);

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

        public async Task DeleteCustomerAsync(int id)
        {
            const string sqlExpression = "DeleteCustomers";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("id", id);

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

        public async Task<List<CustomersModel>> GetAllCustomersAsync()
        {
            const string sqlExpression = "AllCustomers";

            List<CustomersModel> result = new();

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
                            result.Add(new CustomersModel
                            {
                                Id = reader.GetInt32(0),
                                FullName = reader.GetString(1).Trim(),
                                IdentityNumber = reader.GetString(2).Trim(),
                                PhoneNumber = reader.GetString(3).Trim(),
                                Email = reader.GetString(4).Trim(),
                                Type = reader.GetString(5).Trim()
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

        public async Task<CustomersModel> GetSingleCustomerAsync(int id)
        {
            const string sqlExpression = "SingleCustomer";

            CustomersModel result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("customerId", id);

                    await connection.OpenAsync();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Id = reader.GetInt32(0);
                            result.FullName = reader.GetString(1).Trim();
                            result.IdentityNumber = reader.GetString(2).Trim();
                            result.PhoneNumber = reader.GetString(3).Trim();
                            result.Email = reader.GetString(4).Trim();
                            result.Type = reader.GetString(5).Trim();
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

        public async Task UpdateCustomerAsync(CustomersModel customersModel)
        {
            const string sqlExpression = "UpdateCustomer";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("fullName", customersModel.FullName);
                    command.Parameters.AddWithValue("identityNumber", customersModel.IdentityNumber);
                    command.Parameters.AddWithValue("phoneNumber", customersModel.PhoneNumber);
                    command.Parameters.AddWithValue("email", customersModel.Email);
                    command.Parameters.AddWithValue("type", customersModel.Type);
                    command.Parameters.AddWithValue("id", customersModel.Id);

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
