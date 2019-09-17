using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Voorraadsysteem_ToolsForEver.Models;

namespace Voorraadsysteem_ToolsForEver.Controllers
{
    [Authorize(Roles = "Directie")]
    public class FabrikantController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); //connectie met de db

        // GET: Fabrikant
        public ActionResult Index()
        {
            return View(db.FabrikantDbSet.ToList()); //laat alle rijen in de db zien van de Fabrikant tabel
        }

        // GET: Fabrikant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabrikant fabrikant = db.FabrikantDbSet.Find(id); //zoek de fabrikant met hetzelfde id als is meegegeven in de link
            if (fabrikant == null)
            {
                return HttpNotFound();
            }
            return View(fabrikant);
        }

        // GET: Fabrikant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabrikant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FabrikantId,Naam,Telefoonnummer")] Fabrikant fabrikant) //maakt een nieuwe Fabrikant aan mat FabrikantId, Naam, Telefoonnummer
        {
            if (ModelState.IsValid)
            {
                db.FabrikantDbSet.Add(fabrikant); //maakt een nieuwe Fabrikant aan mat FabrikantId, Naam, Telefoonnummer
                db.SaveChanges(); //opslaan
                return RedirectToAction("Index");
            }

            return View(fabrikant);
        }

        // GET: Fabrikant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabrikant fabrikant = db.FabrikantDbSet.Find(id); //zoek de fabrikant met hetzelfde id als is meegegeven in de link
            if (fabrikant == null)
            {
                return HttpNotFound();
            }
            return View(fabrikant);
        }

        // POST: Fabrikant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FabrikantId,Naam,Telefoonnummer")] Fabrikant fabrikant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabrikant).State = EntityState.Modified;
                db.SaveChanges(); //slaat de fabrikant op met de aangepaste data
                return RedirectToAction("Index");
            }
            return View(fabrikant);
        }

        // GET: Fabrikant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabrikant fabrikant = db.FabrikantDbSet.Find(id); //zoek de fabrikant met hetzelfde id als is meegegeven in de link
            if (fabrikant == null)
            {
                return HttpNotFound();
            }
            return View(fabrikant);
        }

        // POST: Fabrikant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fabrikant fabrikant = db.FabrikantDbSet.Find(id); //verwijder de fabrikant met hetzelfde id als is meegegeven in de link
            db.FabrikantDbSet.Remove(fabrikant);
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