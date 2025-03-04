using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.Repository.Repositories;
using System.Linq;

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

        public async Task DeleteExamSubjectAsync ( int id )
        {
            var examSubject = await _context.ExamSubjects.FindAsync ( id );
            if(examSubject != null)
            {
                _context.ExamSubjects.Remove ( examSubject );
                await _context.SaveChangesAsync ();
            }
        }

        public async Task<ExamSubject> GetExamSubjectByIdAsync ( int id )
        {
            return await _context.ExamSubjects.FindAsync(id);
        }

        public async Task UpdateExamSubjectAsync ( ExamSubject examSubject )
        {
            _context.ExamSubjects.Update(examSubject);
            await _context.SaveChangesAsync ();
        }

        //public async Task<ExamSubject> GetExamSchedulesByIdAsync ( int id )
        //{
        //    return await _context.ExamSubjects.FindAsync ( id );
        //}

    }
}
