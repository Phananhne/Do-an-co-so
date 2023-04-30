using Do_an_co_so.Models;

namespace Do_an_co_so.Intefaces
{
    public interface ICategoryRepository : IRepository<Categories>
    {
        public Table[] GetRevenueStructure(int year);
    }
}
