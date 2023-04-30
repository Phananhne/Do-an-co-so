using Do_an_co_so.Data;
using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;

namespace Do_an_co_so.Repositories
{
    public class BannerRepository : RepositoryBase<Banner>, IBannerRepository
    {
        public BannerRepository(Do_an_co_soContext context) : base(context)
        {

        }
    }
}
