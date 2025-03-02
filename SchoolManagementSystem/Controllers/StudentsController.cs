using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Filter;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Service;
using SchoolManagementSystem.Service.ServiceInterface;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
   
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController ( IStudentService studentService )
        {
            _studentService = studentService;
        }

        [AuthorizeUser ( "Admin" )]
        // GET: Students
        public async Task<IActionResult> Index ( )
        {
            var students = await _studentService.GetAllStudentsAsync ();
            return View ( students );
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details ( int id )
        {
            var student = await _studentService.GetStudentByIdAsync ( id );
            if (student == null)
                return NotFound ();

            return View ( student );
        }

        [AuthorizeUser ( "Admin" )]
        // GET: Students/Create
        public IActionResult Create ( )
        {
            return View ();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ( [Bind ( "StudentId,FirstName,LastName,PhoneNumber,Role,PermanentAddress,CurrentAddress,Pincode,Age,DateOfBirth,FatherName,FatherPhoneNumber,PreviousSchool,PreviousSchoolPercentage,Email,PasswordHash,ClassId" )] Student student )
        {
            if (ModelState.IsValid)
            {
                await _studentService.RegisterStudentAsync ( student );
                return RedirectToAction ( nameof ( Index ) );

                //if (student.Role == "Admin")
                //{
                //    return RedirectToAction ( nameof ( Index ) );
                //}
                //else
                //{
                //    return RedirectToAction ( "Login", "Account", new { email = student.Email, password = student.PasswordHash } );   
                //}
            }
            return View ( student );
        }

        [AuthorizeUser ( "Admin" )]
        // GET: Students/Edit/5
        public async Task<IActionResult> Edit ( int id )
        {
            var student = await _studentService.GetStudentByIdAsync ( id );
            if (student == null)
                return NotFound ();

            return View ( student );
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit ( int id, [Bind ( "Id,StudentId,FirstName,LastName,PhoneNumber,Role,PermanentAddress,CurrentAddress,Pincode,Age,DateOfBirth,FatherName,FatherPhoneNumber,PreviousSchool,PreviousSchoolPercentage,Email,PasswordHash,ClassId" )] Student student )
        {
            if (id != student.Id)
                return NotFound ();

            if (ModelState.IsValid)
            {
                
                await _studentService.UpdateStudentAsync ( student );
                // Redirect to AccountController's Login action with email and password
               
                return RedirectToAction ( nameof ( Index ) );
            } else
            {
                foreach(var modelError in ModelState.Values.SelectMany(x => x.Errors ))
                {
                    Console.WriteLine ( $"Error: {modelError.ErrorMessage} " );
                }
            }
            return View ( student );
        }

        [AuthorizeUser ( "Admin" )]
        // GET: Students/Delete/5
        public async Task<IActionResult> Delete ( int id )
        {
            var student = await _studentService.GetStudentByIdAsync ( id );
            if (student == null)
                return NotFound ();

            return View ( student );
        }


        // POST: Students/Delete/5
        [HttpPost, ActionName ( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed ( int id )
        {
            await _studentService.DeleteStudentAsync ( id );
            return RedirectToAction ( nameof ( Index ) );
        }

        //[HttpGet]
        //public async Task<IActionResult> StudentProfile ( )
        //{

        //    var email = User.Identity.Name; // Retrieve the logged-in user's email
        //    var student = await _studentService.GetStudentByEmailAsync ( email );

        //    if (student == null)
        //    {
        //        return NotFound ( "Student not found" );
        //    }

        //    return View ( student );
        //}

        [AuthorizeUser ( "Student" )]
        public async Task<IActionResult> StudentProfile ( )
        {
            string userEmail = HttpContext.Session.GetString ( "UserEmail" );

            if (string.IsNullOrEmpty ( userEmail ))
            {
                return RedirectToAction ( "Login", "Account" );
            }

            var student = await _studentService.GetStudentByEmailAsync ( userEmail );
            if (student == null)
            {
                return NotFound ();
            }

            return View ( student );
        }

        [HttpGet]
        public IActionResult StudentMarks ( )
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudentAttendance()
        {
            return View();
        }
    }
}
