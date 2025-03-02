using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Controllers
{
    public class ExamScheduleController : Controller
    {
        private readonly IExamScheduleService _examScheduleService;
        private readonly SchoolDbContext _context;

        public ExamScheduleController ( IExamScheduleService examScheduleService, SchoolDbContext context )
        {
            _examScheduleService = examScheduleService;
            _context = context;
        }

        public IActionResult Index ( )
        {
            var schedules = _examScheduleService.GetAllSchedules ();
            return View ( schedules );
        }

        public IActionResult Create ( )
        {
            ViewBag.Exams = new SelectList ( _context.Exams, "ExamId", "ExamName" );
            ViewBag.Classes = new SelectList ( _context.Classes, "ClassId", "ClassName" );
            ViewBag.Subjects = new SelectList ( _context.Subjects, "SubjectId", "SubjectName" );
            return View ();
        }

        [HttpPost]
        public IActionResult Create ( ExamSchedule schedule )
        {
            if (ModelState.IsValid)
            {
                _examScheduleService.AddSchedule ( schedule );
                return RedirectToAction ( "Index" );
            }

            ViewBag.Exams = new SelectList ( _context.Exams, "ExamId", "ExamName", schedule.ExamId );
            ViewBag.Classes = new SelectList ( _context.Classes, "ClassId", "ClassName", schedule.ClassId );
            ViewBag.Subjects = new SelectList ( _context.Subjects, "Id", "SubjectName", schedule.SubjectId );
            return View ( schedule );
        }
    }
}
