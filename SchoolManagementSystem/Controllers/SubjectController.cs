using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Service.ServiceInterface;
using SchoolManagementSystem.Service.Implementation;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.MVC.Controllers
{
  public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IEmployeeService _employeeService;

        public SubjectController ( ISubjectService subjectService, IEmployeeService employeeService )
        {
            _subjectService = subjectService;
            _employeeService = employeeService;
        }

        // GET: Subject/Index
        public async Task<IActionResult> Index ( )
        {
            var subjects =  _subjectService.GetAllSubjects ();
            return View ( subjects );
        }

        // GET: Subject/Create
        public async Task<IActionResult> Create ( )
        {
            var employees = await _employeeService.GetAllEmployeeAsync ();
            ViewBag.Employees = employees;
            return View ();
        }

        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ( Subject subject )
        {
            if ( ModelState.IsValid )
            {
                 _subjectService.AddSubject ( subject );
                return RedirectToAction ( nameof ( Index ) );
            }

            // If the model state is not valid, reload the employees for the dropdown
            var employees = await _employeeService.GetAllEmployeeAsync ();
            ViewBag.Employees = employees;
            return View ( subject );
        }

        // GET: Subject/Edit/5
        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit ( int id )
        {
            var subject =  _subjectService.GetSubjectById ( id );

            if (subject == null)
            {
                return NotFound ();
            }

            var employees = await _employeeService.GetAllEmployeeAsync ();
            ViewBag.Employees = employees;
            return View ( subject );
        }

        // POST: Subject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit ( int id, Subject subject )
        {
            if (id != subject.Id)
            {
                return NotFound ();
            }

            if (ModelState.IsValid)
            {
                 _subjectService.UpdateSubject ( subject );
                return RedirectToAction ( nameof ( Index ) );
            }

            var employees = await _employeeService.GetAllEmployeeAsync ();
            ViewBag.Employees = employees;
            return View ( subject );
        }

        public async Task<IActionResult> Delete ( int id )
        {
            var student =  _subjectService.GetSubjectById ( id );
            if (student == null)
                return NotFound ();

            return View ( student );
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName ( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed ( int id )
        {
             _subjectService.DeleteSubject ( id );
            return RedirectToAction ( nameof ( Index ) );
        }
    }
}
