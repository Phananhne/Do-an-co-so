using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Do_an_co_so.Repositories
{
    public class CartRepository : ICartRepository
    {
        const string CART = "Cart";
        public List<Item> Get(ISession session)
        {
            var value = session.GetString(CART);
            if (value == null)
                return new List<Item>();
            var result = JsonConvert.DeserializeObject<List<Item>>(value);
            if (result == null)
                return new List<Item>();
            return result;
        }

        public List<Item> Set(ISession session, List<Item> cart)
        {
            session.SetString(CART, JsonConvert.SerializeObject(cart));
            return cart;
        }
    }
}
