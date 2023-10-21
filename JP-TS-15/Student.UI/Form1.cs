using Student.Library;
using Student.Service;
using Student.Service.Interfaces;

namespace Student.UI
{
    public partial class Form1 : Form
    {
        private readonly ITeacherService _teacherService;
        public TeacherModel SelectedTeacher { get; set; }
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


        private void ClearForm()
        {
            firstNameValue.Text = string.Empty;
            lastNameValue.Text = string.Empty;
            emailValue.Text = string.Empty;
            pinValue.Text = string.Empty;
            salaryValue.Text = string.Empty;
            DOBValue.Value = DateTime.Now;
        }

        private void addTeacherBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormIsValid())
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
                    ClearForm();
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("შემოყვანილი ინფორმაცია არასოწორია", "არასწორი ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "დაფიქსირდა შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshData()
        {
            TeachersList.DataSource = _teacherService.GetAllTeachers();
        }



        private bool FormIsValid()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(firstNameValue.Text) && firstNameValue.Text.Length > 50)
                result = false;
            else if (string.IsNullOrWhiteSpace(lastNameValue.Text) && lastNameValue.Text.Length > 50)
                result = false;
            else if (string.IsNullOrWhiteSpace(pinValue.Text) && pinValue.Text.Length != 11)
                result = false;
            else if (string.IsNullOrWhiteSpace(emailValue.Text) && !emailValue.Text.Contains('@') && !emailValue.Text.Contains('.'))
                result = false;
            else if (int.Parse(salaryValue.Text) < 0)
                result = false;
            else if (_teacherService.GetAllTeachers().Any(x => x.Pin.Contains(pinValue.Text.Trim())))
                result = false;

            return result;
        }

        private void TeachersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectedTeacher = TeachersList.SelectedItem as TeacherModel;
                firstNameValue.Text = SelectedTeacher.FirstName;
                lastNameValue.Text = SelectedTeacher.LastName;
                DOBValue.Value = SelectedTeacher.DateOfBirth;
                pinValue.Text = SelectedTeacher.Pin;
                emailValue.Text = SelectedTeacher.Email;
                salaryValue.Text = SelectedTeacher.Salary.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "დაფიქსირდა შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //TODO წაშლის ფუნქციონალი.
        //TODO რედაქტირების ფუნქციონალი.

    }
}