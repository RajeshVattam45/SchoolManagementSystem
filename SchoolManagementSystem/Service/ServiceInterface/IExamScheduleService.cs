using SchoolManagementSystem.MVC.Entites.Models;

namespace SchoolManagementSystem.Service.ServiceInterface
{
    public interface IExamScheduleService
    {
        IEnumerable<ExamSchedule> GetAllSchedules ( );
        ExamSchedule GetScheduleById ( int id );
        void AddSchedule ( ExamSchedule schedule );
        void UpdateSchedule ( ExamSchedule schedule );
        void DeleteSchedule ( int id );
    }
}
