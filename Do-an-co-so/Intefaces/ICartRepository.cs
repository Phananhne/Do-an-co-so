using Do_an_co_so.Models;
namespace Do_an_co_so.Intefaces
{
    public interface ICartRepository
    {
        public List<Item> Get(ISession session);
        public List<Item> Set(ISession session, List<Item> cart);
    }
}
