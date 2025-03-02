using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.Repository.Repositories;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Service.Implementation
{
    public class ExamScheduleService : IExamScheduleService
    {
        private readonly IExamScheduleRepository _repository;

        public ExamScheduleService ( IExamScheduleRepository repository )
        {
            _repository = repository;
        }

        public IEnumerable<ExamSchedule> GetAllSchedules ( )
        {
            return _repository.GetAllSchedules ();
        }

        public ExamSchedule GetScheduleById ( int id )
        {
            return _repository.GetScheduleById ( id );
        }

        public void AddSchedule ( ExamSchedule schedule )
        {
            _repository.AddSchedule ( schedule );
        }

        public void UpdateSchedule ( ExamSchedule schedule )
        {
            _repository.UpdateSchedule ( schedule );
        }

        public void DeleteSchedule ( int id )
        {
            _repository.DeleteSchedule ( id );
        }
    }

}
