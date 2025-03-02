using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Controllers
{
    public class ExamTypeController : Controller
    {
        private readonly IExamTypeService _examTypeService;

        public ExamTypeController ( IExamTypeService examTypeService )
        {
            _examTypeService = examTypeService;
        }

        // List all ExamTypes
        public async Task<IActionResult> Index ( )
        {
            var examTypes = await _examTypeService.GetAllExamTypesAsync ();
            return View ( examTypes );
        }

        // Create ExamType
        public IActionResult Create ( )
        {
            return View ();
        }

        [HttpPost]
        public async Task<IActionResult> Create ( ExamType examType )
        {
            if (ModelState.IsValid)
            {
                await _examTypeService.AddExamTypeAsync ( examType );
                return RedirectToAction ( nameof ( Index ) );
            } else
            {
                foreach(var modelError in ModelState.Values.SelectMany(x => x.Errors )){
                    Console.WriteLine ( $"Error: {modelError.ErrorMessage}" );
                }
            }
            return View ( examType );
        }

        // Edit ExamType
        public async Task<IActionResult> Edit ( int id )
        {
            var examType = await _examTypeService.GetExamTypeByIdAsync ( id );
            if (examType == null) return NotFound ();
            return View ( examType );
        }

        [HttpPost]
        public async Task<IActionResult> Edit ( ExamType examType )
        {
            if (ModelState.IsValid)
            {
                await _examTypeService.UpdateExamTypeAsync ( examType );
                return RedirectToAction ( nameof ( Index ) );
            }
            return View ( examType );
        }

        // Delete ExamType
        public async Task<IActionResult> Delete ( int id )
        {
            var examType = await _examTypeService.GetExamTypeByIdAsync ( id );
            if (examType == null) return NotFound ();
            return View ( examType );
        }

        [HttpPost, ActionName ( "Delete" )]
        public async Task<IActionResult> DeleteConfirmed ( int id )
        {
            await _examTypeService.DeleteExamTypeAsync ( id );
            return RedirectToAction ( nameof ( Index ) );
        }
    }
}
