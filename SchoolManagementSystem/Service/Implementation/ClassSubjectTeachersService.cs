using SchoolManagementSystem.MVC.Entities.Models;
using SchoolManagementSystem.Repository.Repositories;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Service.Implementation
{
    public class ClassSubjectTeachersService : IClassSubjectTeachersService
    {
        private readonly IClassSubjectTeacherRepository _repository;

        public ClassSubjectTeachersService ( IClassSubjectTeacherRepository repository )
        {
            _repository = repository;
        }

        public async Task<List<ClassSubjectTeacher>> GetAllClassSubjectTeachersAsync ( )
        {
            return await _repository.GetAllAsync ( ) ;
        }       
    }
}
