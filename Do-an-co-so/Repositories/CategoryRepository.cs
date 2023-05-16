using Do_an_co_so.Data;
using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;
using Microsoft.EntityFrameworkCore;

namespace Do_an_co_so.Repositories
{
    public class CategoryRepository : RepositoryBase<Categories>, ICategoryRepository
    {
        public CategoryRepository(Do_an_co_soContext context) : base(context)
        {
        }

        public Table[] GetRevenueStructure(int year)
        {
            return _context.OrderDetails
                           .Where(o => o.Order.DayOrder.Year == year)
                           .GroupBy(d => new { d.Product.Category.CategoryId, d.Product.Category.CategoryName })
                           .Select(t => new Table
                           {
                               Key = t.Key.CategoryName,
                               Value = (int)t.Sum(k => k.Quantity * k.UnitPrice)
                           }).ToArray();
        }
    }
}
