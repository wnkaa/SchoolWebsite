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
        private ILectorsRepository lectorRep;
        private readonly Context ctx = new Context();
        public HomeController(IMailSender ims)
        {
            mailSender = ims;
         //   lectorRep = ilr;
        }
        
        // GET: Home
        public ActionResult Index()
        {
            RepositoryT<Lector> lektorzy = new RepositoryT<Lector>(ctx);
            var spr = lektorzy.GetAll();
            ViewBag.sprawdz = spr.FirstOrDefault().Name;

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

          //  var lektorzy = lectorRep.GetAll();
            return View();
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User usr, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string username = usr.Username;
                string password = usr.Password;
            }

            return View();
        }
    }
}