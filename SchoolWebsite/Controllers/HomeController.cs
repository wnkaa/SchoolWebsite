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
        private readonly Context ctx = new Context();
        public HomeController(IMailSender ims )
        {
            mailSender = ims;
            lectorRep = new RepositoryT<Lector>(ctx);
        }
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var przedmiot = ctx.Przedmioty.Where(p => p.Specie.Name == "Human").FirstOrDefault();
            ViewBag.sprawdz = przedmiot.Name;
            return View();
        }
        public ActionResult Education()
        {
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