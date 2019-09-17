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
    [Authorize(Roles = "Directie")]
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            List<Product> AllGerechten = db.ProductDbSet.ToList();
            var products = (from d in db.ProductDbSet  //query om producten te laten zien waar het productId op ProductFabrikant hetzelfde is als het fabrikantid op ProductFabrikant
                            join c in db.ProductFabrikantDbSet on d.ProductId equals c.ProductId
                            join a in db.FabrikantDbSet on c.FabrikantId equals a.FabrikantId
                            select new ProductViewModel // vult de lijst met data van de producten
                            {
                                ProductId = d.ProductId,
                                Naam = d.Naam,
                                Type = d.Type,
                                MinimaalAantal = d.MinimaalAantal,
                                InkoopPrijs = d.InkoopPrijs,
                                VerkoopPrijs = d.VerkoopPrijs,
                                FabrikantNaam = a.Naam,
                            });
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            Product foundProduct = db.ProductDbSet.Find(id);

            if (foundProduct == null)
                return this.RedirectToAction("Index");

            productViewModel.ProductId = foundProduct.ProductId; //laat de data van het product zien vanuit de viewmodel
            productViewModel.Naam = foundProduct.Naam;
            productViewModel.Type = foundProduct.Type;
            productViewModel.MinimaalAantal = foundProduct.MinimaalAantal;
            productViewModel.InkoopPrijs = foundProduct.InkoopPrijs;
            productViewModel.VerkoopPrijs = foundProduct.VerkoopPrijs;

            return View(productViewModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            List<Fabrikant> listFabrikanten = new List<Fabrikant>(); //lijst met alle fabrikanten
            listFabrikanten = db.FabrikantDbSet.ToList(); //lijst met alle fabrikanten

            List<SelectListItem> listFabrikantenItem = new List<SelectListItem>(); //fabrikant die geselecteerd kan worden
            ProductViewModel productViewModel = new ProductViewModel();

            foreach (Fabrikant fabrikant in listFabrikanten)
            {
                var item = new SelectListItem
                {
                    Value = fabrikant.FabrikantId.ToString(), //fabrikantId dat word opgeslagen in de koppeltabel
                    Text = fabrikant.Naam //laat de naam van de fabrikant zien in de dropdown
                };

                listFabrikantenItem.Add(item);
            }

            SelectList fabrikantList = new SelectList(listFabrikantenItem.OrderBy(i => i.Text), "Value", "Text");
            productViewModel.ProductFabrikant = fabrikantList;

            return View(productViewModel);
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            Product newProduct = new Product(productViewModel.Naam, productViewModel.Type, productViewModel.MinimaalAantal, productViewModel.InkoopPrijs, productViewModel.VerkoopPrijs); //maak een nieuw product aan
            ProductFabrikant_regel newProductFabrikantRegel = new ProductFabrikant_regel(); //maak een nieuwe productfabrikanregel aan

            if (productViewModel.FabrikantId != null)
            {
                foreach (int item in productViewModel.FabrikantId)
                {
                    Fabrikant foundFabrikant = db.FabrikantDbSet.Find(item);
                    ProductFabrikant_regel productFabrikant = new ProductFabrikant_regel { Fabrikant = foundFabrikant, Product = newProduct }; //de data die opgeslagen word in de productfabrikant regel
                    newProduct.ProductFabrikant.Add(productFabrikant); //voeg koppeltabel regel toe
                }

                db.ProductDbSet.Add(newProduct); //voeg het product toe
                db.SaveChanges();
            }
            return this.RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductDbSet.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Naam,Type,InkoopPrijs,VerkoopPrijs,MinimaalAantal")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductDbSet.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.ProductDbSet.Find(id);
            db.ProductDbSet.Remove(product);
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