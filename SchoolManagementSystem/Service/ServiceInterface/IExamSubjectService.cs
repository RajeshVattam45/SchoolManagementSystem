using SchoolManagementSystem.MVC.Entites.Models;

namespace SchoolManagementSystem.Service.ServiceInterface
{
    public interface IExamSubjectService
    {
        Task<List<ExamSubject>> GetExamSubjectsAsync ( );
        Task<bool> AddExamSubjectAsync ( ExamSubject examSubject );
        Task DeleteExamSubject(int  id );
        Task <ExamSubject> GetExamSubjectById(int id);
        Task UpdateExamSubject(ExamSubject examSubject );
        // Task GetExamSubjectById(int id);
    }
}
