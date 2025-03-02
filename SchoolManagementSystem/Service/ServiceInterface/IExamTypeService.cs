using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Service.ServiceInterface
{
    public interface IExamTypeService
    {
        Task<IEnumerable<ExamType>> GetAllExamTypesAsync ( );
        Task<ExamType> GetExamTypeByIdAsync ( int id );
        Task AddExamTypeAsync ( ExamType examType );
        Task UpdateExamTypeAsync ( ExamType examType );
        Task DeleteExamTypeAsync ( int id );
    }
}
