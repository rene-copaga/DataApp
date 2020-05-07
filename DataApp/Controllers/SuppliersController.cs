using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}