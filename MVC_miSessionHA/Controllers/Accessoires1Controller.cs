using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_miSessionHA;
using MVC_miSessionHA.Models;

namespace MVC_miSessionHA.Controllers
{
    public class Accessoires1Controller : Controller
    {
        private produitModel db = new produitModel();

        // GET: Accessoires1
        [Authorize]
        public ActionResult Index()
        {
            var accessoires = db.Accessoires.Include(a => a.Skateboard);
            return View(accessoires.ToList());
        }

        // GET: Accessoires1/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoire accessoire = db.Accessoires.Find(id);
            if (accessoire == null)
            {
                return HttpNotFound();
            }
            return View(accessoire);
        }

        // GET: Accessoires1/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.SkateboardID = new SelectList(db.Skateboards, "SkateboardID", "Style");
            return View();
        }

        // POST: Accessoires1/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "AccessoireID,SkateboardID,NomAcc,Type,Prix")] Accessoire accessoire)
        {
            if (ModelState.IsValid)
            {
                db.Accessoires.Add(accessoire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SkateboardID = new SelectList(db.Skateboards, "SkateboardID", "Style", accessoire.SkateboardID);
            return View(accessoire);
        }

        // GET: Accessoires1/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoire accessoire = db.Accessoires.Find(id);
            if (accessoire == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkateboardID = new SelectList(db.Skateboards, "SkateboardID", "Style", accessoire.SkateboardID);
            return View(accessoire);
        }

        // POST: Accessoires1/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "AccessoireID,SkateboardID,NomAcc,Type,Prix")] Accessoire accessoire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessoire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkateboardID = new SelectList(db.Skateboards, "SkateboardID", "Style", accessoire.SkateboardID);
            return View(accessoire);
        }

        // GET: Accessoires1/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoire accessoire = db.Accessoires.Find(id);
            if (accessoire == null)
            {
                return HttpNotFound();
            }
            return View(accessoire);
        }

        // POST: Accessoires1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessoire accessoire = db.Accessoires.Find(id);
            db.Accessoires.Remove(accessoire);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
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
