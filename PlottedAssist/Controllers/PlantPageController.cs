using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlottedAssist.Models;

namespace PlottedAssist.Controllers
{
    public class PlantPageController : Controller
    {
        private ProjectModel db = new ProjectModel();

        // GET: PlantPage
        public ActionResult Index()
        {
            return View(db.PlantSet.ToList());
        }

        // GET: PlantPage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantSet plantSet = db.PlantSet.Find(id);
            if (plantSet == null)
            {
                return HttpNotFound();
            }
            return View(plantSet);
        }

        // GET: PlantPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlantPage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlantCommonName,PlantSciName,PlantPhotoPath,PlantType,PlantSpring,PlantSummer,PlantAutumn,PlantWinter,PlantDesc,PlantFlowersPath,PlantFlowerColors,PlantSunNeedPath,PlantWaterFrq,PlantPruningFrq,PlantFertilizerFrq,PlantMistFrq,PlantSoilSand,PlantSoilClay,PlantSoilLoom,PlantHabitat,PlantAnimal,PlantDroughtTol,PlantCompanion")] PlantSet plantSet)
        {
            if (ModelState.IsValid)
            {
                db.PlantSet.Add(plantSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plantSet);
        }

        // GET: PlantPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantSet plantSet = db.PlantSet.Find(id);
            if (plantSet == null)
            {
                return HttpNotFound();
            }
            return View(plantSet);
        }

        // POST: PlantPage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlantCommonName,PlantSciName,PlantPhotoPath,PlantType,PlantSpring,PlantSummer,PlantAutumn,PlantWinter,PlantDesc,PlantFlowersPath,PlantFlowerColors,PlantSunNeedPath,PlantWaterFrq,PlantPruningFrq,PlantFertilizerFrq,PlantMistFrq,PlantSoilSand,PlantSoilClay,PlantSoilLoom,PlantHabitat,PlantAnimal,PlantDroughtTol,PlantCompanion")] PlantSet plantSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plantSet);
        }

        // GET: PlantPage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantSet plantSet = db.PlantSet.Find(id);
            if (plantSet == null)
            {
                return HttpNotFound();
            }
            return View(plantSet);
        }

        // POST: PlantPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlantSet plantSet = db.PlantSet.Find(id);
            db.PlantSet.Remove(plantSet);
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
