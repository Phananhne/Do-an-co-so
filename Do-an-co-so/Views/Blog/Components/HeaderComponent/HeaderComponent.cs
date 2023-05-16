using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Views.Blog.Components.HeaderComponent
{
    public class HeaderComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
