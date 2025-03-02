using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Service.ServiceInterface;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IStudentService _studentService;

        public AccountController ( IEmployeeService employeeService, IStudentService studentService )
        {
            _employeeService = employeeService;
            _studentService = studentService;
        }

        // GET: Login Page
        public IActionResult Login ( )
        {
            return View ();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login ( string email, string password )
        {
            if (string.IsNullOrEmpty ( email ) || string.IsNullOrEmpty ( password ))
            {
                ModelState.AddModelError ( "", "Email and Password are required." );
                return View ();
            }

            // Check Employee Credentials
            var employee = await _employeeService.GetEmployeeByEmailAsync ( email );
            if (employee != null && employee.PasswordHash == password)
            {
                HttpContext.Session.SetString ( "UserEmail", employee.Email );
                HttpContext.Session.SetString ( "UserRole", employee.Role );
                return RedirectToAction ( "Dashboard", "Home" );
            }

            // Check Student Credentials
            var student = await _studentService.GetStudentByEmailAsync ( email );
            if (student != null && student.PasswordHash == password)
            {
                HttpContext.Session.SetString ( "UserEmail", student.Email );
                HttpContext.Session.SetString ( "UserRole", "Student" );

                Console.WriteLine ( $"Session Email: {HttpContext.Session.GetString ( "UserEmail" )}" );
                Console.WriteLine ( $"Session Role: {HttpContext.Session.GetString ( "UserRole" )}" );

                return RedirectToAction ( "Dashboard", "Home" );
            }

            ModelState.AddModelError ( "", "Invalid Email or Password." );
            return View ();
        }

        // Logout
        public IActionResult Logout ( )
        {
            HttpContext.Session.Clear ();
            return RedirectToAction ( "Login" );
        }

        public IActionResult AccessDenied()
        {
            return View ();
        }
    }
}
