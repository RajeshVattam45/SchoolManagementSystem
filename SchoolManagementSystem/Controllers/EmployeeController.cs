using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Filter;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Service.Implementation;
using SchoolManagementSystem.Service.ServiceInterface;

namespace SchoolManagementSystem.Controllers
{
    // [AuthorizeUser]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController ( IEmployeeService employeeService )
        {
            _employeeService = employeeService;
        }

        // GET: Employees
        public async Task<IActionResult> Index ( )
        {
            var employee = await _employeeService.GetAllEmployeeAsync ();
            return View ( employee );
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details ( int id )
        {
            var student = await _employeeService.GetEmployeeByIdAsync ( id );
            if (student == null)
                return NotFound ();

            return View ( student );
        }

        // GET: Students/Create
        public IActionResult Create ( )
        {
            return View ();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ( [Bind ( "Id,EmployeeId,FirstName,LastName,PhoneNumber,Role,PermanentAddress,CurrentAddress,Pincode,EmployeeType,EmployeeSalary,Email,PasswordHash" )] Employee employee )
        {
            if (ModelState.IsValid)
            {
                await _employeeService.RegisterEmployeeAsync ( employee );
                return RedirectToAction ( nameof ( Index ) );
                //if (employee.Role == "Admin")
                //{
                //    return RedirectToAction ( nameof ( Index ) );
                //}
                //else
                //{
                //    return RedirectToAction ( "Login", "Account", new { email = employee.Email, password = employee.PasswordHash } );
                //}
            }
            else
            {
                // Log errors to console
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var errors = ModelState[modelStateKey].Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine ( $"Error in {modelStateKey}: {error.ErrorMessage}" );
                    }
                }
            }
            return View ( employee );
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit ( int id )
        {
            var employee = await _employeeService.GetEmployeeByIdAsync ( id );
            if (employee == null)
                return NotFound ();

            return View ( employee );
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit ( int id, [Bind ( "Id,EmployeeId,FirstName,LastName,PhoneNumber,Role,PermanentAddress,CurrentAddress,Pincode,Email,PasswordHash,EmployeeType,EmployeeSalary" )] Employee employee )
        {
            if (id != employee.Id)
                return NotFound ();

            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync ( employee );
                // Redirect to AccountController's Login action with email and password

                return RedirectToAction ( nameof ( Index ) );
            }
            else
            {
                foreach (var modelError in ModelState.Values.SelectMany ( x => x.Errors ))
                {
                    Console.WriteLine ( $"Error: {modelError.ErrorMessage} " );
                }
            }
            return View ( employee );
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete ( int id )
        {
            var employee = await _employeeService.GetEmployeeByIdAsync ( id );
            if (employee == null)
                return NotFound ();

            return View ( employee );
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName ( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed ( int id )
        {
            await _employeeService.DeleteEmployeeAsync ( id );
            return RedirectToAction ( nameof ( Index ) );
        }

        [AuthorizeUser ( "Teacher" )]
        public async Task<IActionResult> EmployeeProfile ( )
        {
            string userEmail = HttpContext.Session.GetString ( "UserEmail" );

            if (string.IsNullOrEmpty ( userEmail ))
            {
                return RedirectToAction ( "Login", "Account" );
            }

            var student = await _employeeService.GetEmployeeByEmailAsync ( userEmail );
            if (student == null)
            {
                return NotFound ();
            }

            return View ( student );
        }

        public IActionResult EmployeeAttendance()
        {
            return View();
        }

        public IActionResult EmployeeSubjects()
        {
            return View();
        }
    }
}
