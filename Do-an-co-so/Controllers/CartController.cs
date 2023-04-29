using Do_an_co_so.Data;
using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Controllers
{
    public class CartController : Controller
    {
        private readonly Do_an_co_soContext _context;

        public CartController(Do_an_co_soContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }
        public IActionResult Checkout()
        {
            return View(_context.Categories.ToList());
        }
        public IActionResult Shopdetail()
        {
            return View();
        }
    }
}
