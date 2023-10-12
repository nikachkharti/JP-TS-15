using Student.Library;

namespace Student.Service.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherModel> GetAllTeachers();

        //TODO --- დაწერეთ GetSingleTeacher(int id) რომელიც მონაცემთა ბაზიდან წამოიღებს ერთ კონკრეტულ მასწავლებელს
    }
}
