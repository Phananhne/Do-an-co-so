using Microsoft.AspNetCore.Mvc;
using Do_an_co_so.Models;

namespace Do_an_co_so.Views.Cart.Components.OrdersComponent
{
    public class OrdersComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Order> obj)
        {
            return View(obj);
        }
    }
}
