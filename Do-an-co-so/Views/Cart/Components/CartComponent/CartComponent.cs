using Do_an_co_so.Models;
using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Views.Cart.Components.CartComponent
{
    public class CartComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Item> list)
        {
            return View(list);
        }
    }
}
