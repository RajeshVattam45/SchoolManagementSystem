using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Entities.Models;
using SchoolManagementSystem.Repository.Repositories;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class ClassSubjectTeacherRepository : IClassSubjectTeacherRepository
    {
        public readonly SchoolDbContext _context;

        public ClassSubjectTeacherRepository ( SchoolDbContext context )
        {
            _context = context;
        }

        public async Task<List<ClassSubjectTeacher>> GetAllAsync ( )
        {
            return await _context.ClassSubjectTeachers
               .Include ( cst => cst.Class )
               .Include ( cst => cst.Subject )
               .Include ( cst => cst.Employee )
               .ToListAsync ();
        }
    }
}
