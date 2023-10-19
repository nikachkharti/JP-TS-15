using Student.Library;

namespace Student.Service.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherModel> GetAllTeachers();
        TeacherModel GetSingleTeacher(int id);
        void AddNewTeacher(TeacherModel newModel);
    }
}
