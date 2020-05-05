using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    public class HomeController : Controller
    {
        private EFDatabaseContext context;

        public HomeController(EFDatabaseContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Products);
        }
    }
}