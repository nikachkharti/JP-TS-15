﻿using Student.Library;

namespace Student.Service.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherModel> GetAllTeachers();
        TeacherModel GetTeacherById(int id);
    }
}
