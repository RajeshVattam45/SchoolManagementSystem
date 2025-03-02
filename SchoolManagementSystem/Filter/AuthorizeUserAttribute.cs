using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Filter
{
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {
        public readonly string _role;

        public AuthorizeUserAttribute ( string role = null )
        {
            _role = role;
        }

        public override void OnActionExecuting ( ActionExecutingContext context )
        {
            var user = context.HttpContext.Session.GetString ( "UserEmail" );
            var userRole = context.HttpContext.Session.GetString ( "UserRole" );

            if (string.IsNullOrEmpty ( user ))
            {
                // Redirect to Login if no user session exists
                context.Result = new RedirectToActionResult ( "Login", "Account", null );
            }
            else if (!string.IsNullOrEmpty ( _role ) && userRole != _role)
            {
                // If a role is specified and the user does not match, deny access
                context.Result = new RedirectToActionResult ( "AccessDenied", "Account", null );
            }

            if (string.IsNullOrEmpty ( user ))
            {
                context.Result = new RedirectToActionResult ( "Login", "Account", null );
            }
            base.OnActionExecuting ( context );
        }
    }
}
