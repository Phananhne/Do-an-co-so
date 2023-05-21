using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Do_an_co_so.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Reflection.Metadata;
using X.PagedList;
using System.Security.Claims;
using Do_an_co_so.Data;
using OfficeOpenXml;


namespace Do_an_co_so.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdmProductController : Controller
    {
        private readonly Do_an_co_soContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public AdmProductController(Do_an_co_soContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var do_an_co_soContext = _context.Products.Include(p => p.Category);
            var obj = await do_an_co_soContext.ToListAsync();
            return View(obj.ToPagedList(page, 10));
        }
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated && User.FindFirstValue(ClaimTypes.Role) != "Admin")
                return RedirectToAction("Login", "AdmAccount");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductPrice,ProductDescription,ProductAmount,ProductDiscount,ProductImage,ProductDateCreated,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                IFormFileCollection files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        var uploads = Path.Combine(_appEnvironment.WebRootPath, "Content\\img\\products\\");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                product.ProductImage = fileName;
                            }
                        }
                    }
                }
                product.ProductDateCreated = DateTime.Now;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);

        }

        public IActionResult UploadData()
        {
            if (!User.Identity.IsAuthenticated && User.FindFirstValue(ClaimTypes.Role) != "Admin")
                return RedirectToAction("Login", "AdmAccount");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult UploadData(IFormFile file)
        {
            using (var package = new ExcelPackage(file.OpenReadStream()))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var columnCount = worksheet.Dimension.Columns;
                for (int row = 9; row <= rowCount; row++)
                {
                    var productName = worksheet.Cells[row, 1].Value?.ToString().Trim();
                    var productPrice = float.Parse(worksheet.Cells[row, 2].Value?.ToString().Trim());
                    var productDescription = worksheet.Cells[row, 3].Value?.ToString().Trim();
                    var productAmount = int.Parse(worksheet.Cells[row, 4].Value?.ToString().Trim());
                    var productDiscount = int.Parse(worksheet.Cells[row, 5].Value?.ToString().Trim());
                    var productImage = worksheet.Cells[row, 6].Value?.ToString().Trim();
                    var productDateCreated = DateTime.Parse(worksheet.Cells[row, 7].Value?.ToString().Trim());
                    var categoryId = int.Parse(worksheet.Cells[row, 8].Value?.ToString().Trim());
                    var productRating = int.Parse(worksheet.Cells[row, 9].Value?.ToString().Trim());

                    var product = new Product
                    {
                        ProductName = productName,
                        ProductPrice = productPrice,
                        ProductDescription = productDescription,
                        ProductAmount = productAmount,
                        ProductDiscount = productDiscount,
                        ProductImage = productImage,
                        ProductDateCreated = productDateCreated,
                        CategoryId = categoryId,
                        ProductRating = productRating

                    };

                    _context.Products.Add(product);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'Do_an_co_soContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductPrice,ProductDescription,ProductAmount,ProductDiscount,ProductImage,ProductDateCreated,CategoryId")] Product product)
        {
            IFormFileCollection files = HttpContext.Request.Form.Files;

            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var Image in files)
                    {
                        if (Image != null && Image.Length > 0)
                        {
                            var file = Image;
                            var uploads = Path.Combine(_appEnvironment.WebRootPath, "Content\\img\\products\\");
                            if (file.Length > 0)
                            {
                                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                    product.ProductImage = fileName;
                                }
                            }
                        }
                    }
                    product.ProductDateCreated = DateTime.Now;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }
        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
