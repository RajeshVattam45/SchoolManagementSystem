using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Repositories;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class ExamTypeRepository : IExamTypeRepository
    {
        private readonly SchoolDbContext _context;

        public ExamTypeRepository ( SchoolDbContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamType>> GetAllExamTypesAsync ( )
        {
            return await _context.ExamTypes.ToListAsync ();
        }

        public async Task<ExamType> GetExamTypeByIdAsync ( int id )
        {
            return await _context.ExamTypes.FindAsync ( id );
        }

        public async Task AddExamTypeAsync ( ExamType examType )
        {
            await _context.ExamTypes.AddAsync ( examType );
            await _context.SaveChangesAsync ();
        }

        public async Task UpdateExamTypeAsync ( ExamType examType )
        {
            _context.ExamTypes.Update ( examType );
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteExamTypeAsync ( int id )
        {
            var examType = await _context.ExamTypes.FindAsync ( id );
            if (examType != null)
            {
                _context.ExamTypes.Remove ( examType );
                await _context.SaveChangesAsync ();
            }
        }
    }
}
