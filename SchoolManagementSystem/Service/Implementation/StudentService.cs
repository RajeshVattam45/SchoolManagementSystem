using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Repositories;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService ( IStudentRepository studentRepository )
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync ( )
        {
            return await _studentRepository.GetAllStudentsAsync ();
        }

        public async Task<Student> GetStudentByIdAsync ( int id )
        {
            return await _studentRepository.GetStudentByIdAsync ( id );
        }

        public async Task<Student> GetStudentByEmailAsync ( string email )
        {
            return await _studentRepository.GetStudentByEmailAsync ( email );
        }

        public async Task RegisterStudentAsync ( Student student )
        {
            student.Id = 0;
            await _studentRepository.AddStudentAsync ( student );
        }

        public async Task UpdateStudentAsync ( Student student )
        {
            await _studentRepository.UpdateStudentAsync ( student );
        }

        public async Task DeleteStudentAsync ( int id )
        {
            await _studentRepository.DeleteStudentAsync ( id );
        }

    }
}
