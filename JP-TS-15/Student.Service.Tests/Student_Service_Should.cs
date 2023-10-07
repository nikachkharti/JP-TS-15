using Xunit;

namespace Student.Service.Tests
{
    public class Student_Service_Should
    {
        [Fact]
        void Return_All_Students_From_Database()
        {
            StudentServiceRepository studentServiceRepository = new();
            var result = studentServiceRepository.GetAllStudents();
        }
    }
}
