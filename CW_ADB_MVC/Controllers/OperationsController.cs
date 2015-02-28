﻿using System;
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
    public class OperationsController : Controller
    {
        private toplivoEntities db = new toplivoEntities();

        // GET: Operations
        public ActionResult Index(string FuelType, string TankType, int page = 0)
        {



            var operations = from m in db.View_AllOperations
                             select m;

            var FuelLst = new List<string>();
            var FuelQry = from f in db.Fuels
                          orderby f.FuelType
                          select f.FuelType;
            FuelLst.AddRange(FuelQry.Distinct());
            ViewBag.FuelType = new SelectList(FuelLst);

            var TankLst = new List<string>();
            var TankQry = from t in db.Tanks
                          orderby t.TankType
                          select t.TankType;
            TankLst.AddRange(TankQry.Distinct());
            ViewBag.TankType = new SelectList(TankLst);

            ViewBag.page = page;

            if (string.IsNullOrEmpty(FuelType))
            {
                if (string.IsNullOrEmpty(TankType))
                {
                    return View(operations.ToList());
                }
                else
                {
                    operations = operations.Where(x => x.TankType == TankType);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(TankType))
                {

                    operations = operations.Where(x => x.FuelType == FuelType);
                }
                else
                {
                    operations = operations.Where(x => x.TankType == TankType).Where(x => x.FuelType == FuelType);
                    ViewBag.page = 0;


                }
            }

            return View(operations);



        }

        // GET: Operations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operations operations = db.Operations.Find(id);
            if (operations == null)
            {
                return HttpNotFound();
            }
            return View(operations);
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperationID,FuelID,TankID,Inc_Exp,Date")] Operations operations)
        {
            if (ModelState.IsValid)
            {
                db.Operations.Add(operations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operations);
        }

        // GET: Operations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operations operations = db.Operations.Find(id);
            if (operations == null)
            {
                return HttpNotFound();
            }
            return View(operations);
        }

        // POST: Operations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperationID,FuelID,TankID,Inc_Exp,Date")] Operations operations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operations);
        }

        // GET: Operations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operations operations = db.Operations.Find(id);
            if (operations == null)
            {
                return HttpNotFound();
            }
            return View(operations);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operations operations = db.Operations.Find(id);
            db.Operations.Remove(operations);
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