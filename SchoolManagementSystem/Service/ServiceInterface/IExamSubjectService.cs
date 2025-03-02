using SchoolManagementSystem.MVC.Entites.Models;

namespace SchoolManagementSystem.Service.ServiceInterface
{
    public interface IExamSubjectService
    {
        Task<List<ExamSubject>> GetExamSubjectsAsync ( );
        Task<bool> AddExamSubjectAsync ( ExamSubject examSubject );
    }
}
