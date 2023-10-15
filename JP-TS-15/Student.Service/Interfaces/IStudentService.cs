using Student.Library;

namespace Student.Service.Interfaces
{
    public interface IStudentService
    {
        List<StudentModel> GetAllStudents();
        StudentModel GetStudentById (int id);
    }
}
