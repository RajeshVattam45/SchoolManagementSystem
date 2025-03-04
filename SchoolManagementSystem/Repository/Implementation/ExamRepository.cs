using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.Repository.Repositories;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class ExamRepository : IExamRepository
    {
        private readonly SchoolDbContext _context;

        public ExamRepository ( SchoolDbContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<Exam>> GetAllExamsAsync ( )
        {
            return await _context.Exams
                .Include ( e => e.ExamType )
                .ToListAsync ();
        }

        public async Task<Exam> GetExamByIdAsync ( int id )
        {
            return await _context.Exams
                .Include ( e => e.ExamType )
                .FirstOrDefaultAsync ( e => e.ExamId == id );
        }

        public async Task AddExamAsync ( Exam exam )
        {
            await _context.Exams.AddAsync ( exam );
            await _context.SaveChangesAsync ();
        }

        public async Task UpdateExamAsync ( Exam exam )
        {
            _context.Exams.Update ( exam );
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteExamAsync ( int id )
        {
            //var exam = await _context.Exams.FindAsync ( id );
            //if (exam != null)
            //{
            //    _context.Exams.Remove ( exam );
            //    await _context.SaveChangesAsync ();
            //}

            var exam = await _context.Exams.FindAsync ( id );
            if (exam != null)
            {
                _context.Exams.Remove ( exam );
                await _context.SaveChangesAsync ();
            }
        }

        
    }
}
