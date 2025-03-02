using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.Service.Implementation;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Controllers
{
    public class ExamSubjectController : Controller
    {
        private readonly IExamSubjectService _examSubjectService;

        public ExamSubjectController ( IExamSubjectService examSubjectService )
        {
            _examSubjectService = examSubjectService;
        }

        public async Task<IActionResult> Index ( )
        {
            var examSubjects = await _examSubjectService.GetExamSubjectsAsync ();
            return View ( examSubjects );
        }

        public IActionResult Create ( )
        {
            return View ();
        }

        [HttpPost]
        public async Task<IActionResult> Create ( ExamSubject examSubject )
        {
            if (ModelState.IsValid)
            {
                await _examSubjectService.AddExamSubjectAsync ( examSubject );
                return RedirectToAction ( "Index" );
            }
            else
            {
                foreach (var modelError in ModelState.Values.SelectMany ( x => x.Errors ))
                {
                    Console.WriteLine ( $"Error: {modelError.ErrorMessage}" );
                }
            }
            return View ( examSubject );
        }
    }
}
