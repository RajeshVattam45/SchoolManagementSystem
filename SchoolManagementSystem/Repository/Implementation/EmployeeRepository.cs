using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Repositories;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SchoolDbContext _context;

        public EmployeeRepository ( SchoolDbContext context )
        {
            _context = context;
        }

        public async Task AddEmployeeAsync ( Employee employee )
        {
            await _context.Employees.AddAsync ( employee );
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteEmployeeAsync ( int id )
        {
            var employee = await _context.Employees.FindAsync ( id );
            if (employee != null)
            {
                _context.Employees.Remove ( employee );
                await _context.SaveChangesAsync ();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync ( )
        {
            return await _context.Employees.ToListAsync ();
        }

        public async Task<Employee> GetEmployeeByIdAsync ( int id )
        {
           return await _context.Employees.FindAsync ( id );
        }

        public async Task<Employee> GetEmployeeByEmailAsync ( string email )
        {
            return await _context.Employees.FirstOrDefaultAsync ( e => e.Email == email );
        }

        public async Task UpdateEmployeeAsync ( Employee employee )
        {
            _context.Employees.Update ( employee );
            await _context.SaveChangesAsync ();
        }
    }
}
