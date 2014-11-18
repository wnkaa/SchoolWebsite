using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolWebsite.Models;
using System.Net.Mail;
using System.Net;
using SchoolWebsite.Helpers;
namespace SchoolWebsite.Controllers
{
    public class HomeController : Controller
    {
        private IMailSender mailSender;
        private IRepository<Lector> lectorRep;
        private IRepository<Course> courseRep;
        private readonly Context ctx = new Context();
        public HomeController(IMailSender ims )
        {
            mailSender = ims;
            lectorRep = new RepositoryT<Lector>(ctx);
            courseRep = new RepositoryT<Course>(ctx);
        }
        
        // GET: Home
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
                return RedirectToAction("Index", "Admin");
            return View();
        }

        public ActionResult About()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult Education(int Rodzaj =0)
        {
            ViewBag.Rodzaje = new SelectList(ctx.Species, "SpecieID", "Name");
            if (Request.IsAjaxRequest())
            {
                var kursy = courseRep.GetAll();
                var end = kursy.Where(x => x.Przedmioty.FirstOrDefault().SpecieID == Rodzaj);
                return PartialView("_CourseList", end);
            }
            else
            return View();
           
        }
    
        public ActionResult Lectors()
        {

            var lektorzy = lectorRep.GetAll();
            return View(lektorzy);
        }
        public ActionResult Contact()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                mailSender.send(model.Email, model.Name, model.Text);
                ViewBag.success = "Udalo sie wyslac maila";
                return View();
            }
            return View(model);
        }
       
    }
}