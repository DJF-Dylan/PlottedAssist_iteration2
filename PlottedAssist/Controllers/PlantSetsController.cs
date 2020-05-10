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
    public class PlantSetsController : Controller
    {
        private ProjectModel db = new ProjectModel();

        // GET: PlantSets
        public ActionResult Index()
        {
            return View(db.PlantSet.ToList());
        }

        // GET: PlantSets/Details/5
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

        //Ajax page to filter the plant list
        public PartialViewResult GetPlantData(string selected = "All Plant")
        {
            IEnumerable<PlantSet> data = db.PlantSet.ToList();
            if (selected == "All Plant")
            {
                data = db.PlantSet.ToList();
            }
            else if (selected == "Spring")
            {
                data = db.PlantSet.Where(p => p.PlantSpring == "1").ToList();
            }
            else if(selected == "Summer")  
            {
                data = db.PlantSet.Where(p => p.PlantSummer == "1").ToList();
            }
            else if (selected == "Autumn")
            {
                data = db.PlantSet.Where(p => p.PlantAutumn == "1").ToList();
            }
            else if (selected == "Winter")
            {
                data = db.PlantSet.Where(p => p.PlantWinter == "1").ToList();
            }
            else if (selected == "All Year")
            {
                data = db.PlantSet.Where(p => p.PlantSpring == "1" & p.PlantSummer == "1" & p.PlantAutumn == "1" & p.PlantWinter == "1").ToList();
            }
            else if (selected == "Trees" || selected == "Small Plants" || selected == "Shrubs" || selected == "Creepers")
            {
                data = db.PlantSet.Where(p => p.PlantType == selected).ToList();
            }
            return PartialView(data);
        }

        // GET: PlantSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlantSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlantCommonName,PlantSciName,PlantPhotoPath,PlantType,PlantSpring,PlantSummer,PlantAutumn,PlantWinter,PlantDesc,PlantFlowersPath,PlantFlowerColors,PlantSunNeedPath,PlantWaterFrq,PlantPruningFrq,PlantFertilizerFrq,PlantMistFrq,PlantSoilSand,PlantSoilClay,PlantSoilLoom,PlantHabitat,PlantDroughtTol,PlantCompanion,PlantBird,PlantButterfly,PlantBees,PlantInsects,PlantLarve")] PlantSet plantSet)
        {
            if (ModelState.IsValid)
            {
                db.PlantSet.Add(plantSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plantSet);
        }

        // GET: PlantSets/Edit/5
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

        // POST: PlantSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlantCommonName,PlantSciName,PlantPhotoPath,PlantType,PlantSpring,PlantSummer,PlantAutumn,PlantWinter,PlantDesc,PlantFlowersPath,PlantFlowerColors,PlantSunNeedPath,PlantWaterFrq,PlantPruningFrq,PlantFertilizerFrq,PlantMistFrq,PlantSoilSand,PlantSoilClay,PlantSoilLoom,PlantHabitat,PlantDroughtTol,PlantCompanion,PlantBird,PlantButterfly,PlantBees,PlantInsects,PlantLarve")] PlantSet plantSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plantSet);
        }

        // GET: PlantSets/Delete/5
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

        // POST: PlantSets/Delete/5
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
