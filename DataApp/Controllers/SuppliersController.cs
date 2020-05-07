using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DataApp.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupplierRepository supplierRepository;

        public SuppliersController(ISupplierRepository supplierRepo)
        {
            supplierRepository = supplierRepo;
        }

        public IActionResult Index()
        {
            ViewBag.SupplierEditId = TempData["SupplierEditId"];
            ViewBag.SupplierCreateId = TempData["SupplierCreateId"];
            ViewBag.SupplierRelationshipId = TempData["SupplierRelationshipId"];
            return View(supplierRepository.GetAll());
        }

        public IActionResult Edit(long id)
        {
            TempData["SupplierEditId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(Supplier supplier)
        {
            supplierRepository.Update(supplier);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create(long id)
        {
            TempData["SupplierCreateId"] = id;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Change(long id)
        {
            TempData["SupplierRelationshipId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Change(Supplier supplier)
        {
            IEnumerable<Product> changed = supplier.Products
                .Where(p => p.SupplierId != supplier.Id);
            if (changed.Count() > 0)
            {
                IEnumerable<Supplier> allSuppliers
                    = supplierRepository.GetAll().ToArray();
                Supplier currentSupplier
                    = allSuppliers.First(s => s.Id == supplier.Id);
                foreach (Product p in changed)
                {
                    Supplier newSupplier
                        = allSuppliers.First(s => s.Id == p.SupplierId);
                    newSupplier.Products = newSupplier.Products
                        .Append(currentSupplier.Products
                        .First(op => op.Id == p.Id)).ToArray();
                    supplierRepository.Update(newSupplier);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}