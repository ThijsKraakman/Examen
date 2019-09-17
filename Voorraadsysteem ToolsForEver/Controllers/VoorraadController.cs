using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Voorraadsysteem_ToolsForEver.Models;
using Voorraadsysteem_ToolsForEver.ViewModels;

namespace Voorraadsysteem_ToolsForEver.Controllers
{
    [Authorize]
    public class VoorraadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string search)
        {
            List<Voorraad> AllProducten = db.VoorraadDbSet.ToList();
            var products = (from d in db.VoorraadDbSet  //query om producten te laten zien waar het voorraaditemid op ProductVoorraad hetzelfde is als het voorraaditemid op ProductLocatie
                            join c in db.ProductVoorraadDbSet on d.VoorraadItemId equals c.VoorraadItemId
                            join e in db.ProductLocatieDbSet on d.VoorraadItemId equals e.VoorraadItemId

                            join a in db.ProductDbSet on c.ProductId equals a.ProductId
                            join g in db.LocatieDbSet on e.LocatieId equals g.LocatieId

                            select new VoorraadViewModel // vult de lijst met data van de producten
                            {
                                VoorraadItemId = d.VoorraadItemId,
                                Naam = a.Naam,
                                Type = a.Type,
                                MinimaalAantal = a.MinimaalAantal,
                                InkoopPrijs = a.InkoopPrijs,
                                VerkoopPrijs = a.VerkoopPrijs,
                                Aantal = e.Aantal,
                                Plaats = g.Plaats
                            });

            if (!String.IsNullOrEmpty(search)) //zoek functie
            {
                products = products.Where(s => s.Naam.Contains(search) || s.Plaats.Contains(search)); //zoeken op productnaam of locatie
            }

            return View(products);
        }

        public ActionResult Rotterdam(string search)
        {
            List<Voorraad> AllProducten = db.VoorraadDbSet.ToList();
            var products = (from d in db.VoorraadDbSet //query om producten te laten zien waar het voorraaditemid op ProductVoorraad hetzelfde is als het voorraaditemid op ProductLocatie
                            join c in db.ProductVoorraadDbSet on d.VoorraadItemId equals c.VoorraadItemId
                            join e in db.ProductLocatieDbSet on d.VoorraadItemId equals e.VoorraadItemId

                            join a in db.ProductDbSet on c.ProductId equals a.ProductId
                            join g in db.LocatieDbSet on e.LocatieId equals g.LocatieId

                            select new VoorraadViewModel
                            {
                                VoorraadItemId = d.VoorraadItemId,
                                Naam = a.Naam,
                                Type = a.Type,
                                MinimaalAantal = a.MinimaalAantal,
                                InkoopPrijs = a.InkoopPrijs,
                                VerkoopPrijs = a.VerkoopPrijs,
                                Aantal = e.Aantal,
                                Plaats = g.Plaats
                            });

            if (!String.IsNullOrEmpty(search)) //zoek functie
            {
                products = products.Where(s => s.Naam.Contains(search) || s.Plaats.Contains(search)); //zoeken op product of locatie
            }

            return View(products.Where(r => r.Plaats == "Rotterdam").ToList()); //laat alleen de producten zien waar Plaats gelijk is aan Rotterdam
        }

        public ActionResult Almere(string search)
        {
            List<Voorraad> AllProducten = db.VoorraadDbSet.ToList();
            var products = (from d in db.VoorraadDbSet
                            join c in db.ProductVoorraadDbSet on d.VoorraadItemId equals c.VoorraadItemId
                            join e in db.ProductLocatieDbSet on d.VoorraadItemId equals e.VoorraadItemId

                            join a in db.ProductDbSet on c.ProductId equals a.ProductId
                            join g in db.LocatieDbSet on e.LocatieId equals g.LocatieId

                            select new VoorraadViewModel
                            {
                                VoorraadItemId = d.VoorraadItemId,
                                Naam = a.Naam,
                                Type = a.Type,
                                MinimaalAantal = a.MinimaalAantal,
                                InkoopPrijs = a.InkoopPrijs,
                                VerkoopPrijs = a.VerkoopPrijs,
                                Aantal = e.Aantal,
                                Plaats = g.Plaats
                            });

            if (!String.IsNullOrEmpty(search)) //zoek functie
            {
                products = products.Where(s => s.Naam.Contains(search) || s.Plaats.Contains(search)); //zoeken op product of locatie
            }

            return View(products.Where(r => r.Plaats == "Almere").ToList());
        }

        public ActionResult Eindhoven(string search)
        {
            List<Voorraad> AllProducten = db.VoorraadDbSet.ToList();
            var products = (from d in db.VoorraadDbSet
                            join c in db.ProductVoorraadDbSet on d.VoorraadItemId equals c.VoorraadItemId
                            join e in db.ProductLocatieDbSet on d.VoorraadItemId equals e.VoorraadItemId

                            join a in db.ProductDbSet on c.ProductId equals a.ProductId
                            join g in db.LocatieDbSet on e.LocatieId equals g.LocatieId

                            select new VoorraadViewModel
                            {
                                VoorraadItemId = d.VoorraadItemId,
                                Naam = a.Naam,
                                Type = a.Type,
                                MinimaalAantal = a.MinimaalAantal,
                                InkoopPrijs = a.InkoopPrijs,
                                VerkoopPrijs = a.VerkoopPrijs,
                                Aantal = e.Aantal,
                                Plaats = g.Plaats
                            });

            if (!String.IsNullOrEmpty(search)) //zoek functie
            {
                products = products.Where(s => s.Naam.Contains(search) || s.Plaats.Contains(search)); //zoeken op product of locatie
            }

            return View(products.Where(r => r.Plaats == "Eindhoven").ToList());
        }

        // GET: Voorraad/Details/5
        public ActionResult Details(int? id)
        {
            VoorraadViewModel voorraadViewModel = new VoorraadViewModel();
            Voorraad foundVoorraad = db.VoorraadDbSet.Find(id);
            if (foundVoorraad == null)
                return this.RedirectToAction("Index");

            voorraadViewModel.VoorraadItemId = foundVoorraad.VoorraadItemId;
            voorraadViewModel.ConnectedProducts = db.ProductVoorraadDbSet.Where(pv => pv.VoorraadItemId == id).Select(pv => pv.Product).ToList();
            voorraadViewModel.ConnectedLocaties = db.ProductLocatieDbSet.Where(pl => pl.VoorraadItemId == id).Select(pl => pl.Locatie).ToList();
            return View(voorraadViewModel);
        }

        // GET: Voorraad/Create
        public ActionResult Create()
        {
            List<Locatie> listLocaties = new List<Locatie>(); //maakt een nieuwe lijst aan met daarin de locaties van de Locaties tabel
            List<Product> listProducts = new List<Product>(); //maakt een nieuwe lijst aan met daarin de producten van de Products tabel

            listLocaties = db.LocatieDbSet.ToList(); //maakt er een lijst van
            listProducts = db.ProductDbSet.ToList();

            List<SelectListItem> listLocatieItem = new List<SelectListItem>(); //maakt een item aan die je kan selecteren
            List<SelectListItem> listProductItem = new List<SelectListItem>();

            VoorraadViewModel voorraadViewModel = new VoorraadViewModel(); //nieuw viewmodel aanmaken om data in te kunnen stoppen

            foreach (Locatie locatie in listLocaties) //maakt voor elke locatie in locaties een locatie aan die je kan selecten in de dropdownlist
            {
                var item = new SelectListItem
                {
                    Value = locatie.LocatieId.ToString(),
                    Text = locatie.Plaats
                };

                listLocatieItem.Add(item);
            }

            SelectList locatieList = new SelectList(listLocatieItem.OrderBy(i => i.Text), "Value", "Text");
            voorraadViewModel.ProductLocatie = locatieList;

            foreach (Product product in listProducts)
            {
                var item = new SelectListItem
                {
                    Value = product.ProductId.ToString(),
                    Text = product.Naam
                };

                listProductItem.Add(item);
            }
            SelectList productList = new SelectList(listProductItem.OrderBy(i => i.Text), "Value", "Text");
            voorraadViewModel.VoorraadProduct = productList;
            return View(voorraadViewModel);
        }

        // POST: Voorraad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoorraadViewModel voorraadViewModel)
        {
            Voorraad newVoorraad = new Voorraad();

            ProductLocatie_regel newLocatie = new ProductLocatie_regel(voorraadViewModel.Aantal);

            ProductLocatie_regel newProductLocatieRegel = new ProductLocatie_regel(voorraadViewModel.Aantal);

            if (voorraadViewModel.ProductId != null)
            {
                foreach (int item in voorraadViewModel.ProductId)
                {
                    Product foundProduct = db.ProductDbSet.Find(item);
                    ProductVoorraad_regel productVoorraad = new ProductVoorraad_regel { Product = foundProduct, Voorraad = newVoorraad }; //maak een nieuwe productvoorraadregel aan met het id van product en id van voorraad
                    newVoorraad.VoorraadProduct.Add(productVoorraad);
                }
            }
            if (voorraadViewModel.LocatieId != null)
            {
                foreach (int item in voorraadViewModel.LocatieId)
                {
                    Locatie foundLocatie = db.LocatieDbSet.Find(item);
                    ProductLocatie_regel productLocatie = new ProductLocatie_regel { Locatie = foundLocatie, Voorraad = newVoorraad, Aantal = newProductLocatieRegel.Aantal }; //maak een nieuwe productlocatie regel aan in de db met productid van product en locatieid van loatie en het aantal (stuks) producten dat is meegegeven
                    newVoorraad.LocatieProduct.Add(productLocatie);
                }

                db.VoorraadDbSet.Add(newVoorraad);
                db.SaveChanges();
            }
            return this.RedirectToAction("Index");
        }

        // GET: Voorraad/Edit/5
        public ActionResult Edit(int? id)
        {
            ProductLocatie_regel productLocatie_Regel = new ProductLocatie_regel();

            Voorraad foundVoorraad = db.VoorraadDbSet.Find(id);
            productLocatie_Regel.Aantal = db.ProductLocatieDbSet.Where(pl => pl.VoorraadItemId == id).Select(pl => pl.Aantal).FirstOrDefault(); //om aantal te tonen op de view
            productLocatie_Regel.LocatieId = db.ProductLocatieDbSet.Where(pl => pl.VoorraadItemId == id).Select(pl => pl.LocatieId).FirstOrDefault(); // om locatie id te tonen op de view

            if (foundVoorraad == null)
                return this.RedirectToAction("Index");

            productLocatie_Regel.VoorraadItemId = foundVoorraad.VoorraadItemId;

            return View(productLocatie_Regel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoorraadItemId,Aantal,LocatieId")] ProductLocatie_regel voorraad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voorraad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voorraad);
        }

        // GET: Voorraad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voorraad voorraad = db.VoorraadDbSet.Find(id);
            if (voorraad == null)
            {
                return HttpNotFound();
            }
            return View(voorraad);
        }

        // POST: Voorraad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voorraad voorraad = db.VoorraadDbSet.Find(id);

            db.VoorraadDbSet.Remove(voorraad);

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