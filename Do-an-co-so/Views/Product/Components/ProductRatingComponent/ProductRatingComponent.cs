using Do_an_co_so.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Views.Product.Components.ProductRatingComponent
{
    public class ProductRatingComponent : ViewComponent
    {
        private readonly IProductRatingRepository _repo;
        public ProductRatingComponent(IProductRatingRepository repo)
        {
            _repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var obj = await _repo.GetListAsync(filter: x => x.ProductId == id, includeProperties: "Customer");
            return View("ProductRatingComponent", obj);
        }
    }
}
