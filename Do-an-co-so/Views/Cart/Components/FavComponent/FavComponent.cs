using Do_an_co_so.Models;
using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Views.Cart.Components.FavComponent
{
    public class FavComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Favorite> fav)
        {
            return View("FavComponent", fav);
        }
    }
}
