using Microsoft.Data.SqlClient;
using BankGPT.Library;
using BankGPT.Repository.Interfaces;

namespace BankGPT.Repository
{
    public class CustomersService : ICustomersService
    {
        public List<CustomersModel> GetAllCustomers()
        {
            const string sqlExpression = @"SELECT
	                                        Id,
	                                        FullName,
	                                        IdentityNumber,
	                                        PhoneNumber,
	                                        Email,
                                            [Type]
                                        FROM Customers";

            List<CustomersModel> result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
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
    }
}
