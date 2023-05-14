using Do_an_co_so.Data;
using Do_an_co_so.Models;
using MailChimp.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Do_an_co_so.Helpers;

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
            return View(Carts);
        }
        public IActionResult Checkout()
        {
            return View(_context.Categories.ToList());
        }
        public IActionResult Shopdetail()
        {
            return View();
        }
        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if(data == null)
                {
                    data = new List<CartItem>();

                }
                return data;
            }
        }
        public IActionResult AddToCart(int id, int SoLuong )
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaHH == id);
            if(item == null)
            {
                var hanghoa = _context.Products.SingleOrDefault(p => p.ProductId == id);
                item = new CartItem
                {
                    MaHH = id,
                    TenHH = hanghoa.ProductName,
                    DonGia = (double)hanghoa.ProductPrice,
                    SoLuong = SoLuong,
                    Hinh = hanghoa.ProductImage

                };
                myCart.Add(item);
            }
            else
            {
                item.SoLuong+=SoLuong;

            }
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index");
        }

    }
}
