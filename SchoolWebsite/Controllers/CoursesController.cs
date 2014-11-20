using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolWebsite.Models;

namespace SchoolWebsite.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IRepository<Course> repoCourse;
        private readonly IRepository<Lector> repoLector;
        private readonly IRepository<Przedmiot> repoPrzedmiot;
        public CoursesController()
        {
            repoCourse = new RepositoryT<Course>(new Context());
            repoLector = new RepositoryT<Lector>(new Context());
            repoPrzedmiot = new RepositoryT<Przedmiot>(new Context());
        }

        // GET: Courses
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
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,LectorID,PrzedmiotID,Name,PeopleLimit")] Course course)
        {
            if (ModelState.IsValid)
            {
                repoCourse.Add(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,LectorID,PrzedmiotID,Name,PeopleLimit")] Course course)
        {
            if (ModelState.IsValid)
            {
                repoCourse.Edit(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
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
