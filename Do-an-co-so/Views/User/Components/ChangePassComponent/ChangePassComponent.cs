using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Do_an_co_so.Views.User.Components.ChangePassComponent
{
    public class ChangePassComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
