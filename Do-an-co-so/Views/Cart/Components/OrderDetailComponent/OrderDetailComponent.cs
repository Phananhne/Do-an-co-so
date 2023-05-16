using Do_an_co_so.Models;
using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Views.Cart.Components.OrderDetailComponent
{
    public class OrderDetailComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<OrderDetail> obj)
        {
            return View(obj);
        }
    }
}
