using SchoolManagementSystem.MVC.Entities.Models;

namespace SchoolManagementSystem.Service.ServiceInterface
{
    public interface IClassSubjectTeachersService
    {
        Task<List<ClassSubjectTeacher>> GetAllClassSubjectTeachersAsync ( );
    }
}
