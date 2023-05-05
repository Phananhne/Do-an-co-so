using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Views.User.Components.AvatarComponent
{
    public class AvatarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
