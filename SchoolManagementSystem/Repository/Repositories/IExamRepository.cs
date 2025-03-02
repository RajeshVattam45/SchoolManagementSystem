using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Entites.Models;

namespace SchoolManagementSystem.Repository.Repositories
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetAllExamsAsync ( );
        Task<Exam> GetExamByIdAsync ( int id );
        Task AddExamAsync ( Exam exam );
        Task UpdateExamAsync ( Exam exam );
        Task DeleteExamAsync ( int id );
    }
}
