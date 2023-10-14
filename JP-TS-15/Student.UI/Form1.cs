using Student.Service;
using Student.Service.Interfaces;

namespace Student.UI
{
    public partial class Form1 : Form
    {
        private readonly ITeacherService _teacherService;
        public Form1()
        {
            InitializeComponent();
            _teacherService = new TeacherService();
        }


        private void getSingleStudentBtn_Click(object sender, EventArgs e)
        {

        }

        private void getAllTeachersBtn_Click(object sender, EventArgs e)
        {
            var allTeachers = _teacherService.GetAllTeachers();
        }

        private void getSingleTeacherBtn_Click(object sender, EventArgs e)
        {
            int.TryParse(studentIdValue.Text, out int teacherId);
            var singleTeacher = _teacherService.GetSingleTeacher(teacherId);

            teacherName.Text = $"{singleTeacher.FirstName} {singleTeacher.LastName}";
            teacherName.Visible = true;
        }
    }
}