using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Filter;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.MVC.Service.ServiceInterface;

namespace SchoolManagementSystem.MVC.Controllers
{
    [AuthorizeUser]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;

        public ClassController ( IClassService classService )
        {
            _classService = classService;
        }

        public IActionResult Index ( )
        {
            var classes = _classService.GetAllClasses ();
            return View ( classes );
        }

        public IActionResult Details ( int id )
        {
            var cls = _classService.GetClassById ( id );
            if (cls == null) return NotFound ();
            return View ( cls );
        }

        public IActionResult Create ( )
        {
            return View ();
        }

        [HttpPost]
        public IActionResult Create ( Class cls )
        {
            if (ModelState.IsValid)
            {
                _classService.AddClass ( cls );
                return RedirectToAction ( nameof ( Index ) );
            }
            return View ( cls );
        }

        public IActionResult Edit ( int id )
        {
            var cls = _classService.GetClassById ( id );
            if (cls == null) return NotFound ();
            return View ( cls );
        }

        [HttpPost]
        public IActionResult Edit ( Class cls )
        {
            if (ModelState.IsValid)
            {
                _classService.UpdateClass ( cls );
                return RedirectToAction ( nameof ( Index ) );
            }
            return View ( cls );
        }

        //public IActionResult Delete ( int id )
        //{
        //    var cls = _classService.GetClassById ( id );
        //    if (cls == null) return NotFound ();
        //    return View ( cls );
        //}

        //[HttpPost, ActionName ( "Delete" )]
        //public IActionResult DeleteConfirmed ( int id )
        //{
        //    _classService.DeleteClass ( id );
        //    return RedirectToAction ( nameof ( Index ) );
        //}

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete ( int id )
        {
            var cls =  _classService.GetClassById ( id );
            if (cls == null)
                return NotFound ();

            return View ( cls );
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName ( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed ( int id )
        {
             _classService.DeleteClass ( id );
            return RedirectToAction ( nameof ( Index ) );
        }
    }
}
