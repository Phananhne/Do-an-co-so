using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Views.Shared.Components.AccountComponent
{
    public class AccountComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
