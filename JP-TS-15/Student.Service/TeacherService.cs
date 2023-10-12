using Microsoft.Data.SqlClient;
using Student.Library;
using Student.Service.Interfaces;
using System.Data;

namespace Student.Service
{
    public class TeacherService : ITeacherService
    {
        public List<TeacherModel> GetAllTeachers()
        {
            const string sqlExpression = @"SELECT [Id]
                                            ,[FirstName]
                                            ,[LastName]
                                            ,[DateOfBirth]
                                            ,[Pin]
                                            ,[Email]
                                            ,[Salary]
                                        FROM [JPTS15].[dbo].[Teachers]";

            List<TeacherModel> result = new();
            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(new TeacherModel
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                DateOfBirth = reader.GetDateTime(3),
                                Pin = reader.GetString(4),
                                Email = reader.GetString(5),
                                Salary = reader.GetInt32(6)
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

        public TeacherModel GetTeacherById(int id)
        {
            string sqlExpression = @$"SELECT 
                                       [Id]
                                       ,[FirstName]
                                       ,[LastName]
                                       ,[DateOfBirth]
                                       ,[Pin]
                                       ,[Email]
                                       ,[Salary]
                                     FROM [JPTS15].[dbo].[Teachers]
                                     WHERE Id = {id}";

            TeacherModel result = new();


            return result;

        }
    }
}
