using Xunit;

namespace Student.Service.Tests
{
    public class Teacher_Service_Should
    {
        [Fact]
        void Return_All_Teachers_From_Database()
        {
            TeacherService teacherService = new();
            var result = teacherService.GetAllTeachers();
        }
    }
}
