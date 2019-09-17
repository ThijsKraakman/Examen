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
    public class LocatieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); //connectie met de db

        // GET: Locatie
        public ActionResult Index()
        {
            return View(db.LocatieDbSet.ToList()); //laat alle rijen in de db zien van de Locatie tabel
        }

        // GET: Locatie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locatie locatie = db.LocatieDbSet.Find(id); //zoek de locatie met hetzelfde id als is meegegeven in de link
            if (locatie == null)
            {
                return HttpNotFound();
            }
            return View(locatie);
        }

        // GET: Locatie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locatie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocatieId,Adres,Postcode,Plaats")] Locatie locatie) //maakt een nieuwe locatie aan mat LocatieId, Adres, Postcode en Plaats
        {
            if (ModelState.IsValid)
            {
                db.LocatieDbSet.Add(locatie); //maakt een nieuwe locatie aan mat LocatieId, Adres, Postcode en Plaats
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locatie);
        }

        // GET: Locatie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locatie locatie = db.LocatieDbSet.Find(id); //zoek de locatie met hetzelfde id als is meegegeven in de link
            if (locatie == null)
            {
                return HttpNotFound();
            }
            return View(locatie);
        }

        // POST: Locatie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocatieId,Adres,Postcode,Plaats")] Locatie locatie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locatie).State = EntityState.Modified;
                db.SaveChanges(); //slaat de fabrikant op met de aangepaste data
                return RedirectToAction("Index");
            }
            return View(locatie);
        }

        // GET: Locatie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locatie locatie = db.LocatieDbSet.Find(id); //zoek de locatie met hetzelfde id als is meegegeven in de link
            if (locatie == null)
            {
                return HttpNotFound();
            }
            return View(locatie);
        }

        // POST: Locatie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locatie locatie = db.LocatieDbSet.Find(id); // verwijder de locatie met hetzelfde id als is meegegeven in de link
            db.LocatieDbSet.Remove(locatie);
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