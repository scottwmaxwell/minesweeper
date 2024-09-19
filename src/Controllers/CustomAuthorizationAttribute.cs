
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Minesweeper.Controllers
{
    internal class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("Test");
            string userName = context.HttpContext.Session.GetString("username");

            if (userName == null)
            {
                context.Result = new RedirectResult("/login");
            }
            else
            {
                Console.WriteLine("Session exists...");
                // Do nothing. let the session proceed.
            }
        }
    }
}