using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Repository.Repositories
{
    public interface IExamTypeRepository
    {
        Task<IEnumerable<ExamType>> GetAllExamTypesAsync ( );
        Task<ExamType> GetExamTypeByIdAsync ( int id );
        Task AddExamTypeAsync ( ExamType examType );
        Task UpdateExamTypeAsync ( ExamType examType );
        Task DeleteExamTypeAsync ( int id );
    }
}
