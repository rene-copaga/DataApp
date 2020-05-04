using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new Product[] {
                new Product { Name = "P1", Category = "Cat1", Price = 10 },
                new Product { Name = "P2", Category = "Cat2", Price = 20 },
                new Product { Name = "P3", Category = "Cat3", Price = 30 },
            });
        }
    }
}