using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Repository.Repositories;

namespace SchoolManagementSystem.MVC.Repository.Implementation
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolDbContext _context;

        public SubjectRepository ( SchoolDbContext context )
        {
            _context = context;
        }

        public IEnumerable<Subject> GetAllSubjects ( )
        {
            return _context.Subjects.Include ( s => s.Employee ).ToList ();
        }

        public Subject GetSubjectById ( int id )
        {
            return _context.Subjects.Include ( s => s.Employee ).FirstOrDefault ( s => s.Id == id );
        }

        public void AddSubject ( Subject subject )
        {
            _context.Subjects.Add ( subject );
            _context.SaveChanges ();
        }

        public void UpdateSubject ( Subject subject )
        {
            _context.Subjects.Update ( subject );
            _context.SaveChanges ();
        }

        public void DeleteSubject ( int id )
        {
            var subject = _context.Subjects.Find ( id );
            if (subject != null)
            {
                _context.Subjects.Remove ( subject );
                _context.SaveChanges ();
            }
        }
    }
}
