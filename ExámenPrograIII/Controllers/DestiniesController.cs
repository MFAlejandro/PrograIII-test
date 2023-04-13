using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExámenPrograIII;

namespace ExámenPrograIII.Controllers
{
    public class DestiniesController : Controller
    {
        private DestiniesEntities db = new DestiniesEntities();

        // GET: Destinies
        public ActionResult Index()
        {
            return View(db.Destinies.ToList());
        }

        // GET: Destinies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinies destinies = db.Destinies.Find(id);
            if (destinies == null)
            {
                return HttpNotFound();
            }
            return View(destinies);
        }

        // GET: Destinies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DestinyID,Photo,Name,Description,Price")] Destinies destinies)
        {
            if (ModelState.IsValid)
            {
                db.Destinies.Add(destinies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destinies);
        }

        // GET: Destinies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinies destinies = db.Destinies.Find(id);
            if (destinies == null)
            {
                return HttpNotFound();
            }
            return View(destinies);
        }

        // POST: Destinies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DestinyID,Photo,Name,Description,Price")] Destinies destinies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destinies);
        }

        // GET: Destinies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinies destinies = db.Destinies.Find(id);
            if (destinies == null)
            {
                return HttpNotFound();
            }
            return View(destinies);
        }

        // POST: Destinies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destinies destinies = db.Destinies.Find(id);
            db.Destinies.Remove(destinies);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
