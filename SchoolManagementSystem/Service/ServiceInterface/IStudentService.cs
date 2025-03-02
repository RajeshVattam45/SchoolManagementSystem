using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Service.ServiceInterface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync ( );
        Task<Student> GetStudentByIdAsync ( int id );
        Task<Student> GetStudentByEmailAsync ( string email );
        Task RegisterStudentAsync ( Student student );
        Task UpdateStudentAsync ( Student student );
        Task DeleteStudentAsync ( int id );
    }
}
