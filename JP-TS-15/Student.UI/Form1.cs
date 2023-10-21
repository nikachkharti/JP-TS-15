using Student.Library;
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

        private void addTeacherBtn_Click(object sender, EventArgs e)
        {
            TeacherModel teacherModel = new()
            {
                FirstName = firstNameValue.Text,
                LastName = lastNameValue.Text,
                Email = emailValue.Text,
                Pin = pinValue.Text,
                Salary = int.Parse(salaryValue.Text),
                DateOfBirth = DOBValue.Value
            };

            _teacherService.AddNewTeacher(teacherModel);
            RefreshData();
        }

        private void RefreshData()
        {
            TeachersList.DataSource = _teacherService.GetAllTeachers();
        }


        //TODO სახელი არ იყოს ცარიელი მაქს. 50
        //TODO გვარი არ იყოს ცარიელი მაქს. 50
        //TODO Pin არ იყოს ცარიელი ზუსტად 11 სიმბოლო
        //TODO EMail არ იყოს ცარიელი შეიცავდეს @ და . სიმბოლოებს
        //TODO Salary არ იყოს ცარიელი და უარყოფითი რიცხვი.


        //TODO წაშლის ფუნქციონალი.
        //TODO რედაქტირების ფუნქციონალი.


    }
}