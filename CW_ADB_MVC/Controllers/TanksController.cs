﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CW_ADB_MVC.Models;

namespace CW_ADB_MVC.Controllers
{
    public class TanksController : Controller
    {
        private toplivoEntities db = new toplivoEntities();

        // GET: Tanks
        public ActionResult Index(string TankTypeFind="")
        {
            ViewBag.Title = "Емкости";

            var tanks = from m in db.Tanks
                        where m.TankType.StartsWith(TankTypeFind)
                        select m;
            
            return View(tanks.ToList());
        }

        // GET: Tanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tanks tanks = db.Tanks.Find(id);
            if (tanks == null)
            {
                return HttpNotFound();
            }
            return View(tanks);
        }

        // GET: Tanks/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Емкости";

            return View();
        }

        // POST: Tanks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tanks tanks, HttpPostedFileBase upload)
        {

            
            
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    // формируем имя файла
                    string fileName = tanks.TankID.ToString() + System.IO.Path.GetExtension(upload.FileName);
                    // сохраняем файл в папку Images в проекте
                    upload.SaveAs(Server.MapPath("~/Images/" + fileName));
                    tanks.TankPicture = fileName;
                    db.Tanks.Add(tanks);
                    db.SaveChanges();
                    int id = tanks.TankID;
                    return RedirectToAction("Edit", new { id  = tanks.TankID });
                }    
                
                
                db.Tanks.Add(tanks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tanks);
        }

        // GET: Tanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tanks tanks = db.Tanks.Find(id);
            if (tanks == null)
            {
                return HttpNotFound();
            }
            return View(tanks);
        }

        // POST: Tanks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tanks tanks, HttpPostedFileBase upload)
        {
            ViewBag.Title = "Емкости";

            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    // формируем имя файла
                    string fileName = tanks.TankID.ToString() +System.IO.Path.GetExtension(upload.FileName);
                    // сохраняем файл в папку Images в проекте
                    upload.SaveAs(Server.MapPath("~/Images/" + fileName));
                    tanks.TankPicture = fileName;
                    db.Entry(tanks).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Edit");

                }

                db.Entry(tanks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tanks);
        }

        // GET: Tanks/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Емкости";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tanks tanks = db.Tanks.Find(id);
            if (tanks == null)
            {
                return HttpNotFound();
            }
            return View(tanks);
        }

        // POST: Tanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            

            //Удаление заданной записи из таблицы Tanks
            Tanks tanks = db.Tanks.Find(id);
            
            db.Tanks.Remove(tanks);
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
