using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.Repository.Implementation;
using SchoolManagementSystem.Repository.Repositories;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Service.Implementation
{
    public class ExamSubjectService : IExamSubjectService
    {
        private readonly IExamSubjectRepository _examSubjectRepository;

        public ExamSubjectService ( IExamSubjectRepository examSubjectRepository )
        {
            _examSubjectRepository = examSubjectRepository;
        }

        public async Task<List<ExamSubject>> GetExamSubjectsAsync ( )
        {
            return await _examSubjectRepository.GetAllExamSubjectsAsync ();
        }

        public async Task<bool> AddExamSubjectAsync ( ExamSubject examSubject )
        {
            return await _examSubjectRepository.AddExamSubjectAsync ( examSubject );
        }

    }
}
