using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Do_an_co_so.Models;
using Do_an_co_so.Data;

namespace Do_an_co_so.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdmProductRatingController : Controller
    {
        private readonly Do_an_co_soContext _context;

        public AdmProductRatingController(Do_an_co_soContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var do_an_co_soContext = _context.ProductRatings.Include(p => p.Customer).Include(p => p.Product);
            return View(await do_an_co_soContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductRatings == null)
            {
                return NotFound();
            }

            var productRating = await _context.ProductRatings
                .Include(p => p.Customer)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductRatingId == id);
            if (productRating == null)
            {
                return NotFound();
            }

            return View(productRating);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductRatings == null)
            {
                return NotFound();
            }

            var productRating = await _context.ProductRatings
                .Include(p => p.Customer)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductRatingId == id);
            if (productRating == null)
            {
                return NotFound();
            }

            return View(productRating);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductRatings == null)
            {
                return Problem("Entity set 'Do_an_co_soContext.ProductRatings'  is null.");
            }
            var productRating = await _context.ProductRatings.FindAsync(id);
            if (productRating != null)
            {
                _context.ProductRatings.Remove(productRating);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
