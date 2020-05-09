using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PlottedAssist.Models;

namespace PlottedAssist.Controllers
{
    public class DashboardController : Controller
    {
        private ProjectModel db = new ProjectModel();

        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userPlantSet = db.UserPlantSet.Where(s => s.UserId ==
            userId).Include(d => d.PlantSet);
            return View(userPlantSet.ToList());

            //var userPlantSet = db.UserPlantSet.Include(u => u.PlantSet);
            //return View(userPlantSet.ToList());
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPlantSet userPlantSet = db.UserPlantSet.Find(id);
            if (userPlantSet == null)
            {
                return HttpNotFound();
            }
            return View(userPlantSet);
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            ViewBag.PlantId = new SelectList(db.PlantSet, "Id", "PlantCommonName");
            return View();
        }

        // POST: Dashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlantId,UserId,PlantWaterFrq,PlantPruningFrq,PlantFertilizerFrq,PlantMistFrq,StartDate,EndDate,Active")] UserPlantSet userPlantSet)
        {
            userPlantSet.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(userPlantSet);
            if (ModelState.IsValid)
            {
                db.UserPlantSet.Add(userPlantSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantId = new SelectList(db.PlantSet, "Id", "PlantCommonName", userPlantSet.PlantId);
            return View(userPlantSet);
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPlantSet userPlantSet = db.UserPlantSet.Find(id);
            if (userPlantSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantId = new SelectList(db.PlantSet, "Id", "PlantCommonName", userPlantSet.PlantId);
            return View(userPlantSet);
        }

        // POST: Dashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlantId,UserId,PlantWaterFrq,PlantPruningFrq,PlantFertilizerFrq,PlantMistFrq,StartDate,EndDate,Active")] UserPlantSet userPlantSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userPlantSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantId = new SelectList(db.PlantSet, "Id", "PlantCommonName", userPlantSet.PlantId);
            return View(userPlantSet);
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPlantSet userPlantSet = db.UserPlantSet.Find(id);
            if (userPlantSet == null)
            {
                return HttpNotFound();
            }
            return View(userPlantSet);
        }

        // POST: Dashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserPlantSet userPlantSet = db.UserPlantSet.Find(id);
            db.UserPlantSet.Remove(userPlantSet);
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
