using Student.Library;

namespace Student.Service.Interfaces
{
    public interface IStudentServiceRepository
    {
        List<StudentModel> GetAllStudents();
    }
}
