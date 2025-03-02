using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.MVC.Service.ServiceInterface
{
    public interface IClassService
    {
        IEnumerable<Class> GetAllClasses ( );
        Class GetClassById ( int id );
        void AddClass ( Class cls );
        void UpdateClass ( Class cls );
        void DeleteClass ( int id );
    }
}
