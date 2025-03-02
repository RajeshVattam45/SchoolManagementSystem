using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Repository.Repositories;
using SchoolManagementSystem.MVC.Service.ServiceInterface;

namespace SchoolManagementSystem.MVC.Service.Implementation
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService ( IClassRepository classRepository )
        {
            _classRepository = classRepository;
        }

        public IEnumerable<Class> GetAllClasses ( )
        {
            return _classRepository.GetAllClasses ();
        }

        public Class GetClassById ( int id )
        {
            return _classRepository.GetClassById ( id );
        }

        public void AddClass ( Class cls )
        {
            _classRepository.AddClass ( cls );
        }

        public void UpdateClass ( Class cls )
        {
            _classRepository.UpdateClass ( cls );
        }

        public void DeleteClass ( int id )
        {
            _classRepository.DeleteClass ( id );
        }
    }
}
