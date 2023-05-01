using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Areas.Admin.Views.AdmStatistics.Components.StaticProductComponent
{
    public class StaticProductComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
