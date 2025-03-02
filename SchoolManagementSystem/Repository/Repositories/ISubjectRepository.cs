using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.MVC.Repository.Repositories
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubjects ( );
        Subject GetSubjectById ( int id );
        void AddSubject ( Subject subject );
        void UpdateSubject ( Subject subject );
        void DeleteSubject ( int id );
    }
}
