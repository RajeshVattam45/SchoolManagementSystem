using SchoolManagementSystem.MVC.Entites.Models;

namespace SchoolManagementSystem.Repository.Repositories
{
    public interface IExamScheduleRepository
    {
        IEnumerable<ExamSchedule> GetAllSchedules ( );
        ExamSchedule GetScheduleById ( int id );
        void AddSchedule ( ExamSchedule schedule );
        void UpdateSchedule ( ExamSchedule schedule );
        void DeleteSchedule ( int id );
    }
}
