using SchoolManagementSystem.MVC.Entities.Models;
using System.Collections.Generic;

namespace SchoolManagementSystem.Repository.Repositories
{
    public interface IClassSubjectTeacherRepository
    {
        //Task<List<ClassSubjectTeacher>> GetAllClassSubjectTeachers ( );
        Task<List<ClassSubjectTeacher>> GetAllAsync ( );
    }
}
