using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Repository.Repositories;

namespace SchoolManagementSystem.MVC.Repository.Implementation
{
    public class ClassRepository : IClassRepository
    {
        private readonly SchoolDbContext _context;

        public ClassRepository ( SchoolDbContext context )
        {
            _context = context;
        }

        public IEnumerable<Class> GetAllClasses ( )
        {
            return _context.Classes.ToList ();
        }

        public Class GetClassById ( int id )
        {
            return _context.Classes.FirstOrDefault ( c => c.ClassId == id );
        }

        public void AddClass ( Class cls )
        {
            _context.Classes.Add ( cls );
            _context.SaveChanges ();
        }

        public void UpdateClass ( Class cls )
        {
            _context.Classes.Update ( cls );
            _context.SaveChanges ();
        }

        public void DeleteClass ( int id )
        {
            var cls = _context.Classes.Find ( id );
            if (cls != null)
            {
                _context.Classes.Remove ( cls );
                _context.SaveChanges ();
            }
        }
    }
}
