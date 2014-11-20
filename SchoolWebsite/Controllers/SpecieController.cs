using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolWebsite.Models;

namespace SchoolWebsite.Controllers
{
    [Authorize(Roles = "admin")]
    public class SpecieController : Controller
    {
        private readonly Context ctx = new Context();
        private readonly IRepository<Specie> repoSpecie;
        public SpecieController()
        {
            repoSpecie = new RepositoryT<Specie>(ctx);
        }
        // GET: Specie
       
        public ActionResult Index()
        {
            return View(repoSpecie.GetAll());
        }
        // Get specie/create
   

        public ActionResult Create()
        {
            return View();
        }
        //post specie/create
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Name")] Specie specie)
        {
            if (ModelState.IsValid)
            {
                repoSpecie.Add(specie);
                return RedirectToAction("Index");
            }

            return View(specie);
        }
        //get specie/edit
  
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var specie = repoSpecie.Get(id);
            if (specie == null)
            {
                return HttpNotFound();
            }
            return View(specie);
        }
        //post specie/edit
    
        [HttpPost]
         [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Name")]Specie sp)
         {
             if(ModelState.IsValid){
                 repoSpecie.Edit(sp);
                 return RedirectToAction("Index");
             }
             return View(sp);
         }

        //get specie/delete
   
        public ActionResult Delete(int id)
        {

            return View(repoSpecie.Get(id));
       
        }

        //post specie/delete
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id )
        {
            if (id == null)
                return HttpNotFound();
            else
            {
                Specie sp = repoSpecie.Get(id);
                repoSpecie.Delete(sp);
               return RedirectToAction("Index");
                
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repoSpecie.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}