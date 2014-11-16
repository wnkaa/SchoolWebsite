using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
              return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(User usr, string returnURl)
        {
            if (ModelState.IsValid)
            {
                using (SchoolDBConnectionStringEntities ctx = new SchoolDBConnectionStringEntities())
                {
                    string username = usr.Username;
                    string password = usr.Password;
                    //Check if any user with this password is on db
                    bool userValid = ctx.Users.Any(user => user.Username == username && user.Password == password);
                    //if user was found in db
                    if (userValid)
                    {
                        FormsAuthentication.SetAuthCookie(username, false);
                        
                        if (Url.IsLocalUrl(returnURl) &&
                            returnURl.Length > 1 &&
                            returnURl.StartsWith("/") &&
                            !returnURl.StartsWith("//") &&
                            !returnURl.StartsWith("/\\"))
                        {
                            return Redirect(returnURl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name of password provided is incorrect");
                    }


                }
                
            }
            return View(usr);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}