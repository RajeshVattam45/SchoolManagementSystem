using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.Repository.Repositories;

namespace SchoolManagementSystem.Repository.Implementation
{
    public class ExamScheduleRepository : IExamScheduleRepository
    {
        private readonly SchoolDbContext _context;

        public ExamScheduleRepository ( SchoolDbContext context )
        {
            _context = context;
        }

        public IEnumerable<ExamSchedule> GetAllSchedules ( )
        {
            return _context.ExamSchedules
                .Include ( e => e.Exam )
                .Include ( e => e.Class )
                .Include ( e => e.Subject )
                .ToList ();
        }

        public ExamSchedule GetScheduleById ( int id )
        {
            return _context.ExamSchedules
                .Include ( e => e.Exam )
                .Include ( e => e.Class )
                .Include ( e => e.Subject )
                .FirstOrDefault ( e => e.ScheduleId == id );
        }

        public void AddSchedule ( ExamSchedule schedule )
        {
            _context.ExamSchedules.Add ( schedule );
            _context.SaveChanges ();
        }

        public void UpdateSchedule ( ExamSchedule schedule )
        {
            _context.ExamSchedules.Update ( schedule );
            _context.SaveChanges ();
        }

        public void DeleteSchedule ( int id )
        {
            var schedule = _context.ExamSchedules.Find ( id );
            if (schedule != null)
            {
                _context.ExamSchedules.Remove ( schedule );
                _context.SaveChanges ();
            }
        }
    }
}
