using Student.Library;

namespace Student.Service.Interfaces
{
    public interface IStudentService
    {
        List<StudentModel> GetAllStudents();
        //TODO --- დაწერეთ GetSingleStudent (int id) რომელიც მონაცემთა ბაზიდან წამოიღებს ერთ კონკრეტულ სტუდენტს
    }
}
