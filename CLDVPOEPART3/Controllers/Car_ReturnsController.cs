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
    public class Car_ReturnsController : Controller
    {
        private ST10079848LesediEntities2000 db = new ST10079848LesediEntities2000();

        // GET: Car_Returns
        public ActionResult Index()
        {
            var car_Returns = db.Car_Returns.Include(c => c.Car);
            return View(car_Returns.ToList());
        }

        // GET: Car_Returns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Returns car_Returns = db.Car_Returns.Find(id);
            if (car_Returns == null)
            {
                return HttpNotFound();
            }
            return View(car_Returns);
        }

        // GET: Car_Returns/Create
        public ActionResult Create()
        {
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "Car_Make");
            return View();
        }

        // POST: Car_Returns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarNo,Inspector_Name,Driver_Name,End_Date,Elapsed_Date,Fine,RentalID")] Car_Returns car_Returns)
        {
            if (ModelState.IsValid)
            {
                db.Car_Returns.Add(car_Returns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "Car_Make", car_Returns.CarNo);
            return View(car_Returns);
        }

        // GET: Car_Returns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Returns car_Returns = db.Car_Returns.Find(id);
            if (car_Returns == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "Car_Make", car_Returns.CarNo);
            return View(car_Returns);
        }

        // POST: Car_Returns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarNo,Inspector_Name,Driver_Name,End_Date,Elapsed_Date,Fine,RentalID")] Car_Returns car_Returns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_Returns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "Car_Make", car_Returns.CarNo);
            return View(car_Returns);
        }

        // GET: Car_Returns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Returns car_Returns = db.Car_Returns.Find(id);
            if (car_Returns == null)
            {
                return HttpNotFound();
            }
            return View(car_Returns);
        }

        // POST: Car_Returns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car_Returns car_Returns = db.Car_Returns.Find(id);
            db.Car_Returns.Remove(car_Returns);
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
