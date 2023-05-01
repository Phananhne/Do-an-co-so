using Do_an_co_so.Data;
using Do_an_co_so.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Do_an_co_so.Controllers
{
    public class HomeController : Controller
    {
        /* private readonly ILogger<HomeController> _logger;

         public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;
         }*/
        private readonly Do_an_co_soContext _context;

        public HomeController(Do_an_co_soContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Pages()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Contact()
        {
            /*return View(_context.Product.ToList());*/
            return View();
        }

    }
}