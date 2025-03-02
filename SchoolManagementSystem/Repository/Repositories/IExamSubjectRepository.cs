using SchoolManagementSystem.MVC.Entites.Models;

namespace SchoolManagementSystem.Repository.Repositories
{
    public interface IExamSubjectRepository
    {
        Task<List<ExamSubject>> GetAllExamSubjectsAsync ( );
        Task<bool> AddExamSubjectAsync ( ExamSubject examSubject );
    }
}
