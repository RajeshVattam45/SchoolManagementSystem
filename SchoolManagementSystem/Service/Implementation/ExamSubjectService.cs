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

        public async Task DeleteExamSubject(int id)
        {
            await _examSubjectRepository.DeleteExamSubjectAsync( id );
        }

        public async Task<ExamSubject> GetExamSubjectById ( int id )
        {
           return await _examSubjectRepository.GetExamSubjectByIdAsync ( id );
        }

        public async Task UpdateExamSubject ( ExamSubject examSubject )
        {
            await _examSubjectRepository.UpdateExamSubjectAsync ( examSubject );
        }

        //public async Task GetExamSubjectById ( int id )
        //{
        //    await _examSubjectRepository.GetExamSubjectByIdAsync ( id );
        //}
    }
}
