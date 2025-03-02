using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Repositories;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository ( SchoolDbContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync ( )
        {
            return await _context.Students.ToListAsync ();
        }

        public async Task<Student> GetStudentByIdAsync ( int id )
        {
            return await _context.Students.FindAsync ( id );
        }

        public async Task<Student> GetStudentByEmailAsync ( string email )
        {
            return await _context.Students.FirstOrDefaultAsync ( s => s.Email == email );
        }

        public async Task AddStudentAsync ( Student student )
        {
            await _context.Students.AddAsync ( student );
            await _context.SaveChangesAsync ();
        }

        public async Task UpdateStudentAsync ( Student student )
        {
            _context.Students.Update ( student );
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteStudentAsync ( int id )
        {
            var student = await _context.Students.FindAsync ( id );
            if (student != null)
            {
                _context.Students.Remove ( student );
                await _context.SaveChangesAsync ();
            }
        }
    }
}
