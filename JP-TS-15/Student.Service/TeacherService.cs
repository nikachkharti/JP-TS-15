using Microsoft.Data.SqlClient;
using Student.Library;
using Student.Service.Interfaces;
using System.Data;

namespace Student.Service
{
    public class TeacherService : ITeacherService
    {
        public void AddNewTeacher(TeacherModel newModel)
        {
            string sqlExpression = @$"
            INSERT INTO Teachers(FirstName,LastName,DateOfBirth,Pin,Email,Salary)
            VALUES
            (N'{newModel.FirstName}',N'{newModel.LastName}','{newModel.DateOfBirth}','{newModel.Pin}','{newModel.Email}',{newModel.Salary})";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.Text;

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
        public List<TeacherModel> GetAllTeachers()
        {
            const string sqlExpression = @"SELECT [Id]
                                            ,[FirstName]
                                            ,[LastName]
                                            ,[DateOfBirth]
                                            ,[Pin]
                                            ,[Email]
                                            ,[Salary]
                                        FROM [Teachers]";

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
        public TeacherModel GetSingleTeacher(int id)
        {
            string sqlExpression = @$"SELECT [Id]
                                        ,[FirstName]
                                        ,[LastName]
                                        ,[DateOfBirth]
                                        ,[Pin]
                                        ,[Email]
                                        ,[Salary]
                                    FROM [Teachers]
                                    WHERE Id = {id}";

            TeacherModel result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Id = reader.GetInt32(0);
                            result.FirstName = reader.GetString(1);
                            result.LastName = reader.GetString(2);
                            result.DateOfBirth = reader.GetDateTime(3);
                            result.Pin = reader.GetString(4);
                            result.Email = reader.GetString(5);
                            result.Salary = reader.GetInt32(6);
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
