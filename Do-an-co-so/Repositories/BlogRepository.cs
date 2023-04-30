using Do_an_co_so.Data;
using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;
using Microsoft.EntityFrameworkCore;
namespace Do_an_co_so.Repositories
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(Do_an_co_soContext context) : base(context)
        {
        }
    }
}
