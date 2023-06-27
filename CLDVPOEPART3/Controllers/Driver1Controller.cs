using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CLDVPOEPART3.Models;

namespace CLDVPOEPART3.Controllers
{
    [CustomAuthorize(Roles = "Inspector")]
    public class Driver1Controller : Controller
    {
        private ST10079848LesediEntities2000 db = new ST10079848LesediEntities2000();

        // GET: Driver1
        public ActionResult Index()
        {
            return View(db.Drivers1.ToList());
        }

        // GET: Driver1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver1 driver1 = db.Drivers1.Find(id);
            if (driver1 == null)
            {
                return HttpNotFound();
            }
            return View(driver1);
        }

        // GET: Driver1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Driver1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverID,Driver_Name,Driver_Address,Email,Mobile")] Driver1 driver1)
        {
            if (ModelState.IsValid)
            {
                db.Drivers1.Add(driver1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driver1);
        }

        // GET: Driver1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver1 driver1 = db.Drivers1.Find(id);
            if (driver1 == null)
            {
                return HttpNotFound();
            }
            return View(driver1);
        }

        // POST: Driver1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverID,Driver_Name,Driver_Address,Email,Mobile")] Driver1 driver1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driver1);
        }

        // GET: Driver1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver1 driver1 = db.Drivers1.Find(id);
            if (driver1 == null)
            {
                return HttpNotFound();
            }
            return View(driver1);
        }

        // POST: Driver1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver1 driver1 = db.Drivers1.Find(id);
            db.Drivers1.Remove(driver1);
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
