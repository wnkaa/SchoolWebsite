using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolWebsite.Models;
namespace SchoolWebsite.Controllers
{
    public class CourseController : Controller
    {
        private readonly Context ctx = new Context();
        private IRepository<Course> courseRep;
        public CourseController()
        {
            courseRep = new RepositoryT<Course>(ctx);
        }
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var detale = courseRep.GetAll().FirstOrDefault(k => k.CourseID == id);
                return View(detale);
            }
            return View();
        }
    }
}