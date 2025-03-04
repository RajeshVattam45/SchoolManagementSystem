using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Filter;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.MVC.Service.ServiceInterface;
using SchoolManagementSystem.Service.Implementation;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Controllers
{
    public class ExamSubjectController : Controller
    {
        private readonly IExamSubjectService _examSubjectService;
        private readonly IExamService _examService;
        private readonly ISubjectService _subjectService;

        public ExamSubjectController ( IExamSubjectService examSubjectService, IExamService examService, ISubjectService subjectService )
        {
            _examSubjectService = examSubjectService;
            _examService = examService;
            _subjectService = subjectService;
        }

        public async Task<IActionResult> Index ( )
        {
            var examSubjects = await _examSubjectService.GetExamSubjectsAsync ();
            return View ( examSubjects );
        }

        //public async IActionResult Create ( )
        //{
        //    ViewBag.Exmas = new SelectList(await _examSubjectService.GetExamSubjectsAsync(), "ExamId", "ExamName");
        //    return View ();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create ( ExamSubject examSubject )
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _examSubjectService.AddExamSubjectAsync ( examSubject );
        //        return RedirectToAction ( "Index" );
        //    }
        //    else
        //    {
        //        foreach (var modelError in ModelState.Values.SelectMany ( x => x.Errors ))
        //        {
        //            Console.WriteLine ( $"Error: {modelError.ErrorMessage}" );
        //        }
        //    }
        //    return View ( examSubject );
        //}
        public async Task<IActionResult> Create ( )
        {
            ViewBag.Exams = new SelectList ( await _examService.GetAllExamsAsync (), "ExamId", "ExamName" );
            ViewBag.Subjects = new SelectList ( _subjectService.GetAllSubjects (), "SubjectId", "SubjectName" );
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

            // Repopulate dropdowns if model validation fails
            ViewBag.Exams = new SelectList ( await _examService.GetAllExamsAsync (), "ExamId", "ExamName" );
            ViewBag.Subjects = new SelectList ( _subjectService.GetAllSubjects (), "SubjectId", "SubjectName" );

            return View ( examSubject );
        }

        public async Task<IActionResult> Delete ( int id )
        {
            var examSubject = await _examSubjectService.GetExamSubjectById ( id );
            if (examSubject == null)
            {
                return NotFound ();
            }
            return View ( examSubject );
        }

        [HttpPost, ActionName ( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed ( int id )
        {
            await _examSubjectService.DeleteExamSubject ( id );
            return RedirectToAction ( nameof ( Index ) );
        }

        // GET: ExamSubject/Edit/5
        public async Task<IActionResult> Edit ( int id )
        {
            var examSubject = await _examSubjectService.GetExamSubjectById ( id );
            if (examSubject == null)
            {
                return NotFound ();
            }
            return View ( examSubject );
        }


        // Edit Exam (POST)
        [HttpPost]
        public async Task<IActionResult> Edit ( ExamSubject examSubject )
        {
            if (ModelState.IsValid)
            {
                await _examSubjectService.UpdateExamSubject ( examSubject );
                return RedirectToAction ( nameof ( Index ) );
            }
            
            return View ( examSubject );
        }     
    }
}
