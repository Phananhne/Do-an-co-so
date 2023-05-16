using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;
using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Views.Cart.Components.ItemComponent
{
    public class ItemComponent : ViewComponent
    {
        private readonly IProductRepository _productRepo;

        public ItemComponent(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public IViewComponentResult Invoke(Item item)
        {
            return View(item);
        }
    }
}
