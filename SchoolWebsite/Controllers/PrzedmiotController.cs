using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolWebsite.Models;
using System.Net;
namespace SchoolWebsite.Controllers
{
    [Authorize(Roles = "admin")]
    public class PrzedmiotController : Controller
    {
       
        private readonly IRepository<Przedmiot> repoPrzedmioty;
        private readonly IRepository<Specie> repoSpecies;
        public PrzedmiotController()
        {
            repoPrzedmioty = new RepositoryT<Przedmiot>(new Context());
            repoSpecies = new RepositoryT<Specie>(new Context());
        }
        // GET: Przedmiot
        public ActionResult Index()
        {
            return View(repoPrzedmioty.GetAll());
        }
        //get przedmiot/details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Przedmiot prz = repoPrzedmioty.Get(id);
            if (prz == null)
                return HttpNotFound();
            return View(prz);
        }
        //get przedmiot/create
        public ActionResult Create()
        {
            ViewBag.SpecieID = new SelectList(repoSpecies.GetAll(), "SpecieID", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Name,SpecieID")]Przedmiot prz)
        {
            if (ModelState.IsValid)
            {
                repoPrzedmioty.Add(prz);
                return RedirectToAction("Index");
            }
            ViewBag.SpecieID = new SelectList(repoSpecies.GetAll(), "SpecieID", "Name");
            return View(prz);
        }
        //get przedmiot/edit/2
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Przedmiot przedmiot = repoPrzedmioty.Get(id);
            if(przedmiot==null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecieID = new SelectList(repoSpecies.GetAll(), "SpecieID", "Name", przedmiot.SpecieID);
            return View(przedmiot);
        }
        //post przedmiot/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,SpecieID")]Przedmiot prz)
        {
            if (ModelState.IsValid)
            {
                repoPrzedmioty.Edit(prz);
                return RedirectToAction("Index");
            }
            ViewBag.SpecieID = new SelectList(repoSpecies.GetAll(), "SpecieID", "Name", prz.SpecieID);
            return View(prz);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmiot prz = repoPrzedmioty.Get(id);
            if (prz == null)
                return HttpNotFound();
            else
                return View(prz);
        }
        //post  przedmiot/delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Przedmiot prz = repoPrzedmioty.Get(id);
            repoPrzedmioty.Delete(prz);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repoPrzedmioty.Dispose();
                repoSpecies.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}