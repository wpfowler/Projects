using System.Web;
using System.Web.Mvc;
using GuildCars.Data.Repositories;
using GuildCars.UI.Models;
using GuildCars.UI.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using GuildCars.Data.Factories;

namespace GuildCars.UI.Controllers
{
    public class AccountController : Controller
    {
        const string repType = "UserRole";

        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);
            
            //Deny disabled Users
            if(user != null)
            { 
                if (userManager.IsInRole(user.Id, "disabled"))
                {
                    ModelState.AddModelError("", "Non Authorized User");
                    return View(model);
                }
            }
            // user will be null if the password or user name is bad
            if (user == null) 
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index","Home");
            }
        }
    }
}