using Student.Service.Interfaces;
using Xunit;

namespace Student.Service.Tests
{
    public class Teacher_Service_Should
    {
        private readonly ITeacherService _teacherService;
        public Teacher_Service_Should()
        {
            _teacherService = new TeacherService();
        }

        [Fact]
        void Return_All_Teachers_From_Database()
        {
            var result = _teacherService.GetAllTeachers();
        }

        [Fact]
        void Return_Single_Teacher_From_Database()
        {
            var result = _teacherService.GetSingleTeacher(1);
        }
    }
}
