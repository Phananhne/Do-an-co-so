using Do_an_co_so.Data;
using Microsoft.AspNetCore.Mvc;

namespace Do_an_co_so.Models
{
    public class sidebar_item_shopViewComponent: ViewComponent
    {
        private readonly Do_an_co_soContext _context;

        public sidebar_item_shopViewComponent(Do_an_co_soContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_context.Categories.ToList());
        }
    }
}
