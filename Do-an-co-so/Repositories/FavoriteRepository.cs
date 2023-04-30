using Do_an_co_so.Data;
using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;

namespace Do_an_co_so.Repositories
{
    public class FavoriteRepository : RepositoryBase<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(Do_an_co_soContext context) : base(context)
        {

        }
    }
}
