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
    public class DoanViensController : Controller
    {
        private QLDVDbContext db = new QLDVDbContext();

        // GET: DoanViens
        public ActionResult Index()
        {
            var doanViens = db.DoanViens.Include(d => d.ChiDoan);
            return View(doanViens.ToList());
        }

        // GET: DoanViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanVien doanVien = db.DoanViens.Find(id);
            if (doanVien == null)
            {
                return HttpNotFound();
            }
            return View(doanVien);
        }

        // GET: DoanViens/Create
        public ActionResult Create()
        {
            ViewBag.ChiDoan_Id = new SelectList(db.ChiDoans, "Id", "Ma_cd");
            return View();
        }

        // POST: DoanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ma_dv,Ten_dv,Ngay_sinh,Que_quan,Dan_toc,Ngay_vao_doan,ChiDoan_Id")] DoanVien doanVien)
        {
            if (ModelState.IsValid)
            {
                db.DoanViens.Add(doanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChiDoan_Id = new SelectList(db.ChiDoans, "Id", "Ma_cd", doanVien.ChiDoan_Id);
            return View(doanVien);
        }

        // GET: DoanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanVien doanVien = db.DoanViens.Find(id);
            if (doanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChiDoan_Id = new SelectList(db.ChiDoans, "Id", "Ma_cd", doanVien.ChiDoan_Id);
            return View(doanVien);
        }

        // POST: DoanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ma_dv,Ten_dv,Ngay_sinh,Que_quan,Dan_toc,Ngay_vao_doan,ChiDoan_Id")] DoanVien doanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChiDoan_Id = new SelectList(db.ChiDoans, "Id", "Ma_cd", doanVien.ChiDoan_Id);
            return View(doanVien);
        }

        // GET: DoanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanVien doanVien = db.DoanViens.Find(id);
            if (doanVien == null)
            {
                return HttpNotFound();
            }
            return View(doanVien);
        }

        // POST: DoanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoanVien doanVien = db.DoanViens.Find(id);
            db.DoanViens.Remove(doanVien);
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
