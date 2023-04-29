using Do_an_co_so.Data;
using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Models
{
    public class fromtheblogViewComponent: ViewComponent
    {
        private readonly Do_an_co_soContext _context;

        public fromtheblogViewComponent(Do_an_co_soContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_context.Blog.ToList());
        }
    }
}
