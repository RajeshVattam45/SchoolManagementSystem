using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Repository.Repositories;
using SchoolManagementSystem.MVC.Service.ServiceInterface;

namespace SchoolManagementSystem.MVC.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService ( ISubjectRepository subjectRepository )
        {
            _subjectRepository = subjectRepository;
        }

        public IEnumerable<Subject> GetAllSubjects ( )
        {
            return _subjectRepository.GetAllSubjects ();
        }

        public Subject GetSubjectById ( int id )
        {
            return _subjectRepository.GetSubjectById ( id );
        }

        public void AddSubject ( Subject subject )
        {
            _subjectRepository.AddSubject ( subject );
        }

        public void UpdateSubject ( Subject subject )
        {
            _subjectRepository.UpdateSubject ( subject );
        }

        public void DeleteSubject ( int id )
        {
            _subjectRepository.DeleteSubject ( id );
        }
    }
}
