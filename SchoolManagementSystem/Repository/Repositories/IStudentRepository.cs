using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Repository.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync ( );
        Task<Student> GetStudentByIdAsync ( int id );
        Task<Student> GetStudentByEmailAsync ( string email );
        Task AddStudentAsync ( Student student );
        Task UpdateStudentAsync ( Student student );
        Task DeleteStudentAsync ( int id );
    }
}
