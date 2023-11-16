using Microsoft.Data.SqlClient;
using BankGPT.Library;
using BankGPT.Repository.Interfaces;
using System.Data;

namespace BankGPT.Repository
{
    public class CustomersService : ICustomersService
    {
        public void CreateCustomer(CustomersModel customersModel)
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

                    connection.Open();
                    command.ExecuteNonQuery();
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
        }

        public void DeleteCustomer(int id)
        {
            const string sqlExpression = "DeleteCustomers";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
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
        }

        public List<CustomersModel> GetAllCustomers()
        {
            const string sqlExpression = "AllCustomers";

            List<CustomersModel> result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {n
                            result.Add(new CustomersModel
                            {
                                Id = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                                IdentityNumber = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
                                Email = reader.GetString(4),
                                Type = reader.GetString(5),
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

        public CustomersModel GetSingleCustomer(int id)
        {
            const string sqlExpression = "SingleCustomer";

            CustomersModel result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
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
                    connection.Close();
                }
            }


            return result;
        }

        public void UpdateCustomer(CustomersModel customersModel)
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

                    connection.Open();
                    command.ExecuteNonQuery();
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
        }
    }
}
