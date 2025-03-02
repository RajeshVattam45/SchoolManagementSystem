using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.MVC.Repository.Repositories
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetAllClasses ( );
        Class GetClassById ( int id );
        void AddClass ( Class cls );
        void UpdateClass ( Class cls );
        void DeleteClass ( int id );
    }
}
