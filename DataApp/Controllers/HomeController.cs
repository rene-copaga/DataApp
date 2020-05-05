using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DataApp.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository repository;

        public HomeController(IDataRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            var products = repository.GetProductsByPrice(25);
            ViewBag.ProductCount = products.Count();
            return View(products);
        }
    }
}