using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Repositories;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Service.Implementation
{
    public class ExamTypeService : IExamTypeService
    {
        private readonly IExamTypeRepository _examTypeRepository;

        public ExamTypeService ( IExamTypeRepository examTypeRepository )
        {
            _examTypeRepository = examTypeRepository;
        }

        public async Task<IEnumerable<ExamType>> GetAllExamTypesAsync ( )
        {
            return await _examTypeRepository.GetAllExamTypesAsync ();
        }

        public async Task<ExamType> GetExamTypeByIdAsync ( int id )
        {
            return await _examTypeRepository.GetExamTypeByIdAsync ( id );
        }

        public async Task AddExamTypeAsync ( ExamType examType )
        {
            await _examTypeRepository.AddExamTypeAsync ( examType );
        }

        public async Task UpdateExamTypeAsync ( ExamType examType )
        {
            await _examTypeRepository.UpdateExamTypeAsync ( examType );
        }

        public async Task DeleteExamTypeAsync ( int id )
        {
            await _examTypeRepository.DeleteExamTypeAsync ( id );
        }
    }
}
