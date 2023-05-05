using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Views.User.Components.ShowProfileComponent
{
    public class ShowProfileComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
