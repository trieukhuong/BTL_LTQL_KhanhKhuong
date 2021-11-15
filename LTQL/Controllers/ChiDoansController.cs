using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTQL.Models;

namespace LTQL.Controllers
{
    public class ChiDoansController : Controller
    {
        private QLDVDbContext db = new QLDVDbContext();

        // GET: ChiDoans
        public ActionResult Index()
        {
            return View(db.ChiDoans.ToList());
        }

        // GET: ChiDoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiDoan chiDoan = db.ChiDoans.Find(id);
            if (chiDoan == null)
            {
                return HttpNotFound();
            }
            return View(chiDoan);
        }

        // GET: ChiDoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiDoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ma_cd,Ten_cd")] ChiDoan chiDoan)
        {
            if (ModelState.IsValid)
            {
                db.ChiDoans.Add(chiDoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chiDoan);
        }

        // GET: ChiDoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiDoan chiDoan = db.ChiDoans.Find(id);
            if (chiDoan == null)
            {
                return HttpNotFound();
            }
            return View(chiDoan);
        }

        // POST: ChiDoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ma_cd,Ten_cd")] ChiDoan chiDoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiDoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiDoan);
        }

        // GET: ChiDoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiDoan chiDoan = db.ChiDoans.Find(id);
            if (chiDoan == null)
            {
                return HttpNotFound();
            }
            return View(chiDoan);
        }

        // POST: ChiDoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiDoan chiDoan = db.ChiDoans.Find(id);
            db.ChiDoans.Remove(chiDoan);
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
