using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Repository.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync ( );
        Task<Employee> GetEmployeeByIdAsync ( int id );
        Task<Employee> GetEmployeeByEmailAsync ( string email );
        Task AddEmployeeAsync ( Employee employee );
        Task UpdateEmployeeAsync ( Employee employee );
        Task DeleteEmployeeAsync ( int id );
    }
}
