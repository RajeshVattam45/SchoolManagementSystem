using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Controllers
{
    public class ClassSubjectTeacherController : Controller
    {
        public readonly IClassSubjectTeachersService _service;
        public ClassSubjectTeacherController ( IClassSubjectTeachersService service )
        {
            _service = service;
        }

        public async Task<IActionResult> Index ( )
        {
            var classSubjectTeachers = await _service.GetAllClassSubjectTeachersAsync ();
            return View ( classSubjectTeachers );
        }
    }
}
