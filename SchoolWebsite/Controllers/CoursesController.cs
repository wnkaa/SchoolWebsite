using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolWebsite.Models;
using SchoolWebsite.Helpers;
namespace SchoolWebsite.Controllers
{
    public class CoursesController : Controller
    {
        private readonly Context ctx = new Context();
        private readonly IRepository<Course> repoCourse;
        private readonly IRepository<Lector> repoLector;
        private readonly IRepository<Przedmiot> repoPrzedmiot;
        public CoursesController()
        {
            repoCourse = new RepositoryT<Course>(ctx);
            repoLector = new RepositoryT<Lector>(ctx);
            repoPrzedmiot = new RepositoryT<Przedmiot>(ctx);
        }

        // GET: Courses
        [Authorize(Roles="admin")]
        public ActionResult Index()
        {
            return View(repoCourse.GetAll());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repoCourse.Get(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("admin"))
            {
                return View(course);
            }
            else
            {
                return View("courseDetailsUser", course);
            }
        }

        // GET: Courses/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            List<Przedmiot> przedmioty = repoPrzedmiot.GetAll().ToList();
            ViewBag.Przedmioty = przedmioty;
            List<Lector> lectors = repoLector.GetAll().ToList();
            ViewBag.Lectors = lectors;

            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,LectorID,PrzedmiotID,Name,PeopleLimit")] Course course, string[] selectedPrzedmiot,string[] selectedLector)
        {
            //all przedmiots and lectors
           var lectors= repoLector.GetAll();
           var przedmiots = repoPrzedmiot.GetAll();
            //hash sets
           var selectedPrzedmiots = new HashSet<string>(selectedPrzedmiot);
           var selectedLectors = new HashSet<string>(selectedLector);
            //course to update

           foreach (var item in lectors)
           {
               if (selectedLectors.Contains(item.LectorID.ToString()))
               {
                       course.Lectors.Add(item);
               }
               
           }
            foreach (var item in przedmiots)
	       {
               if (selectedPrzedmiots.Contains(item.PrzedmiotID.ToString()))
               {
                   course.Przedmioty.Add(item);
               }
	       }
            if (ModelState.IsValid)
            {
                repoCourse.Add(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repoCourse.Get(id);
            ViewBag.AssignedPrzedmiots = DBhelper.assignedPrzedmiots(course);
            List<Przedmiot> przedmioty = repoPrzedmiot.GetAll().ToList();
            ViewBag.Przedmioty = przedmioty;

            ViewBag.AssignedLectors = DBhelper.assignedLectors(course);
            List<Lector> lectors = repoLector.GetAll().ToList();
            ViewBag.Lectors = lectors;

            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Name,PeopleLimit,PrzedmiotID,LectorID")] Course course, string[] selectedPrzedmiot, string[] selectedLector )
        {
            if (ModelState.IsValid)
            {
                // Get data about all lectors and przedmiots
                var przedmioty = repoPrzedmiot.GetAll();
                var lectors = repoLector.GetAll();
                //Data from check boxes
                var selectedPrzedmiots = new HashSet<string>(selectedPrzedmiot);
                var selectedLectors = new HashSet<string>(selectedLector);
                
                //course to update
                var kurs = repoCourse.Get(course.CourseID);
                kurs.Name = course.Name;
                kurs.PeopleLimit = course.PeopleLimit;
                //some logic
                foreach (var item in przedmioty)
                {
                    if (selectedPrzedmiots.Contains(item.PrzedmiotID.ToString()))
                    {
                        if (!kurs.Przedmioty.Any(p=> p.PrzedmiotID == item.PrzedmiotID))
                        {
                            kurs.Przedmioty.Add(item);
                        }
                    }
                    else
                    {
                        if (kurs.Przedmioty.Any(p => p.PrzedmiotID == item.PrzedmiotID))
                        {
                            kurs.Przedmioty.Remove(item);
                        }
                    }
                }
                foreach (var item in lectors)
                {
                    if(selectedLectors.Contains(item.LectorID.ToString()))
                    {
                        if (!kurs.Lectors.Any(l => l.LectorID == item.LectorID))
                        {
                            kurs.Lectors.Add(item);
                        }
                    }
                    else
                    {
                        if (kurs.Lectors.Any(l => l.LectorID == item.LectorID))
                        {
                            kurs.Lectors.Remove(item);
                        }
                    }
                }

                repoCourse.Edit(kurs,kurs.CourseID);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repoCourse.Get(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = repoCourse.Get(id);
            repoCourse.Delete(course);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repoCourse.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
