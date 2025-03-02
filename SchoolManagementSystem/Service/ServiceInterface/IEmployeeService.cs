using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Service.ServiceInterface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync ( );
        Task<Employee> GetEmployeeByIdAsync ( int id );
        Task<Employee> GetEmployeeByEmailAsync ( string email );
        Task RegisterEmployeeAsync ( Employee employee );
        Task UpdateEmployeeAsync ( Employee employee );
        Task DeleteEmployeeAsync ( int id );
    }
}
