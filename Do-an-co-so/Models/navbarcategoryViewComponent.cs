using Do_an_co_so.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Do_an_co_so.Models
{
    public class navbarcategoryViewComponent : ViewComponent
    {
        private readonly Do_an_co_soContext _context;

        public navbarcategoryViewComponent(Do_an_co_soContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_context.Categories.ToList());
        }
    }
}
