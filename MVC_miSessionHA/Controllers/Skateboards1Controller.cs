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
    public class Skateboards1Controller : Controller
    {
        private produitModel db = new produitModel();

        // GET: Skateboards1
        [Authorize]
        public ActionResult Index()
        {
            //var skateboards = db.Skateboards.Include(s => s.Marque);
            return View(db.Skateboards.ToList());
        }

        // GET: Skateboards1/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skateboard skateboard = db.Skateboards.Find(id);
            if (skateboard == null)
            {
                return HttpNotFound();
            }
            return View(skateboard);
        }

        // GET: Skateboards1/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.MarqueID = new SelectList(db.Marques, "MarqueID", "Nom");
            return View();
        }

        // POST: Skateboards1/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public ActionResult Create([Bind(Include = "SkateboardID,MarqueID,Style,Image")] Skateboard skateboard)
        {
            if (ModelState.IsValid)
            {
                db.Skateboards.Add(skateboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarqueID = new SelectList(db.Marques, "MarqueID", "Nom", skateboard.MarqueID);
            return View(skateboard);
        }

        // GET: Skateboards1/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skateboard skateboard = db.Skateboards.Find(id);
            if (skateboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarqueID = new SelectList(db.Marques, "MarqueID", "Nom", skateboard.MarqueID);
            return View(skateboard);
        }

        // POST: Skateboards1/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "SkateboardID,MarqueID,Style,Image")] Skateboard skateboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skateboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarqueID = new SelectList(db.Marques, "MarqueID", "Nom", skateboard.MarqueID);
            return View(skateboard);
        }

        // GET: Skateboards1/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skateboard skateboard = db.Skateboards.Find(id);
            if (skateboard == null)
            {
                return HttpNotFound();
            }
            return View(skateboard);
        }

        // POST: Skateboards1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Skateboard skateboard = db.Skateboards.Find(id);
            db.Skateboards.Remove(skateboard);
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
