using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CW_ADB_MVC.Models;

namespace CW_ADB_MVC.Controllers
{
    public class View_AllOperationsController : Controller
    {
        private toplivoEntities db = new toplivoEntities();

        // GET: View_AllOperations
        public ActionResult Index()
        {
            return View(db.View_AllOperations.ToList());
        }

        // GET: View_AllOperations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_AllOperations view_AllOperations = db.View_AllOperations.Find(id);
            if (view_AllOperations == null)
            {
                return HttpNotFound();
            }
            return View(view_AllOperations);
        }

        // GET: View_AllOperations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: View_AllOperations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperationID,FuelID,TankID,Inc_Exp,Date,FuelType,TankType")] View_AllOperations view_AllOperations)
        {
            if (ModelState.IsValid)
            {
                db.View_AllOperations.Add(view_AllOperations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view_AllOperations);
        }

        // GET: View_AllOperations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_AllOperations view_AllOperations = db.View_AllOperations.Find(id);
            if (view_AllOperations == null)
            {
                return HttpNotFound();
            }
            return View(view_AllOperations);
        }

        // POST: View_AllOperations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperationID,FuelID,TankID,Inc_Exp,Date,FuelType,TankType")] View_AllOperations view_AllOperations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view_AllOperations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view_AllOperations);
        }

        // GET: View_AllOperations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_AllOperations view_AllOperations = db.View_AllOperations.Find(id);
            if (view_AllOperations == null)
            {
                return HttpNotFound();
            }
            return View(view_AllOperations);
        }

        // POST: View_AllOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            View_AllOperations view_AllOperations = db.View_AllOperations.Find(id);
            db.View_AllOperations.Remove(view_AllOperations);
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
