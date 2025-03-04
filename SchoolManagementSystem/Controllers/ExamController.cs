using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.MVC.Entites.Models;
using SchoolManagementSystem.Repository.Repositories;
using SchoolManagementSystem.Service.Implementation;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly IExamTypeService _examTypeService;

        public ExamController ( IExamService examService, IExamTypeService examTypeService )
        {
            _examService = examService;
            _examTypeService = examTypeService;
        }

        // List all Exams
        public async Task<IActionResult> Index ( )
        {
            var exams = await _examService.GetAllExamsAsync ();
            return View ( exams );
        }

        // Create Exam (GET)
        public async Task<IActionResult> Create ( )
        {
            ViewBag.ExamTypes = new SelectList ( await _examTypeService.GetAllExamTypesAsync (), "Id", "ExamTypeName" );
            return View ();
        }

        // Create Exam (POST)
        [HttpPost]
        public async Task<IActionResult> Create ( Exam exam )
        {
            if (ModelState.IsValid)
            {
                await _examService.AddExamAsync ( exam );
                return RedirectToAction ( nameof ( Index ) );
            }
            else
            {
                foreach (var errorMode in ModelState.Values.SelectMany ( x => x.Errors )) {
                    Console.WriteLine ( $"Error: {errorMode.ErrorMessage}" );
                }
            }
            ViewBag.ExamTypes = new SelectList ( await _examTypeService.GetAllExamTypesAsync (), "Id", "ExamTypeName" );
            return View ( exam );
        }

        // Edit Exam (GET)
        public async Task<IActionResult> Edit ( int id )
        {
            var exam = await _examService.GetExamByIdAsync ( id );
            if (exam == null) return NotFound ();

            ViewBag.ExamTypes = new SelectList ( await _examTypeService.GetAllExamTypesAsync (), "Id", "ExamTypeName", exam.ExamTypeId );
            return View ( exam );
        }

        // Edit Exam (POST)
        [HttpPost]
        public async Task<IActionResult> Edit ( Exam exam )
        {
            if (ModelState.IsValid)
            {
                await _examService.UpdateExamAsync ( exam );
                return RedirectToAction ( nameof ( Index ) );
            }
            ViewBag.ExamTypes = new SelectList ( await _examTypeService.GetAllExamTypesAsync (), "Id", "ExamTypeName", exam.ExamTypeId );
            return View ( exam );
        }

        //// Delete Exam (GET)
        //public async Task<IActionResult> Delete ( int id )
        //{
        //    var exam = await _examService.GetExamByIdAsync ( id );
        //    if (exam == null) return NotFound ();

        //    return View ( exam );
        //}

        //// Delete Exam (POST)
        //[HttpPost, ActionName ( "Delete" )]
        //public async Task<IActionResult> DeleteConfirmed ( int id )
        //{
        //    await _examService.DeleteExamAsync ( id );
        //    return RedirectToAction ( nameof ( Index ) );
        //}
        // GET: Students/Delete/5
        public async Task<IActionResult> Delete ( int id )
        {
            var exam = await _examService.GetExamByIdAsync ( id );
            if (exam == null)
            {
                return NotFound ("Exams Not Found");
            }

            return View ( exam );
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName ( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed ( int id )
        {
            await _examService.DeleteExamAsync ( id );
            return RedirectToAction ( nameof ( Index ) );
        }


        //public async Task<IActionResult> Delete ( int id )
        //{
        //    var exm = await _examService.GetExamByIdAsync ( id );
        //    if (exm == null)
        //        return NotFound ();

        //    return View ( exm );
        //}

        //// POST: Class/Delete/5
        //[HttpPost, ActionName ( "Delete" )]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed ( int id )
        //{
        //    _examService.DeleteExamAsync ( id );
        //    return RedirectToAction ( nameof ( Index ) );
        //}
    }

}
