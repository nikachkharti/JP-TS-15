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

        private void Form1_Load(object sender, EventArgs e)
        {
            var allTeachers = _teacherService.GetAllTeachers();
            TeachersList.DataSource = allTeachers;
        }


    }
}