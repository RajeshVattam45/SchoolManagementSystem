using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.Repository.Repositories;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class ExamSubjectRepository : IExamSubjectRepository
    {
        private readonly SchoolDbContext _context;

        public ExamSubjectRepository ( SchoolDbContext context )
        {
            _context = context;
        }

        public async Task<List<ExamSubject>> GetAllExamSubjectsAsync ( )
        {
            return await _context.ExamSubjects
                .Include ( es => es.Exam )
                .Include ( es => es.Subject )
                .ToListAsync ();
        }

        public async Task<bool> AddExamSubjectAsync ( ExamSubject examSubject )
        {
            if (examSubject == null) return false;

            _context.ExamSubjects.Add ( examSubject );
            await _context.SaveChangesAsync ();
            return true;
        }
    }
}
