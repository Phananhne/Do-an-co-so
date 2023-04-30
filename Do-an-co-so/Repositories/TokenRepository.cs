using Do_an_co_so.Data;
using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;


namespace Do_an_co_so.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly Do_an_co_soContext _context;
        public TokenRepository(Do_an_co_soContext context)
        {
            _context = context;
        }

        public bool CheckToken(string userName, string token)
        {
            return _context.Tokens.FirstOrDefault(Token => Token.CustomerUserName == userName && Token.TokenValue == token && Token.Expiry > DateTime.Now) != null;
        }
    }
}
