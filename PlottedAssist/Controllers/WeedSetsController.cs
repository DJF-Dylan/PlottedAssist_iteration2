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
    public class WeedSetsController : Controller
    {
        private ProjectModel db = new ProjectModel();

        // GET: WeedSets
        public ActionResult Index()
        {
            var weedSet = db.WeedSet.Include(w => w.PlantSet);
            return View(weedSet.ToList());
        }

        public PartialViewResult WeedFilter(string selected = "All")
        {
            IEnumerable<WeedSet> data = db.WeedSet.ToList();
            if (selected == "All")
            {
                data = db.WeedSet.ToList();
            }
            else if (selected == "White" || selected == "Yellow" || selected == "Purple" || selected == "No")
            {
                data = db.WeedSet.Where(p => p.WeedFlowerColor == selected).ToList();
            }
            ViewBag.select = selected;  
            return PartialView(data);
        }

        // GET: WeedSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeedSet weedSet = db.WeedSet.Find(id);
            if (weedSet == null)
            {
                return HttpNotFound();
            }
            return View(weedSet);
        }

        // GET: WeedSets/Create
        public ActionResult Create()
        {
            ViewBag.PlantId = new SelectList(db.PlantSet, "Id", "PlantCommonName");
            return View();
        }

        // POST: WeedSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlantId,WeedCommonName,WeedSciName,WeedPhotoPath,WeedDesc,WeedFlowerColor,WeedControl")] WeedSet weedSet)
        {
            if (ModelState.IsValid)
            {
                db.WeedSet.Add(weedSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantId = new SelectList(db.PlantSet, "Id", "PlantCommonName", weedSet.PlantId);
            return View(weedSet);
        }

        // GET: WeedSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeedSet weedSet = db.WeedSet.Find(id);
            if (weedSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantId = new SelectList(db.PlantSet, "Id", "PlantCommonName", weedSet.PlantId);
            return View(weedSet);
        }

        // POST: WeedSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlantId,WeedCommonName,WeedSciName,WeedPhotoPath,WeedDesc,WeedFlowerColor,WeedControl")] WeedSet weedSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weedSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantId = new SelectList(db.PlantSet, "Id", "PlantCommonName", weedSet.PlantId);
            return View(weedSet);
        }

        // GET: WeedSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeedSet weedSet = db.WeedSet.Find(id);
            if (weedSet == null)
            {
                return HttpNotFound();
            }
            return View(weedSet);
        }

        // POST: WeedSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeedSet weedSet = db.WeedSet.Find(id);
            db.WeedSet.Remove(weedSet);
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
