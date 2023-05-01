using System.ComponentModel.DataAnnotations;

namespace Do_an_co_so.Models
{
    public class Token
    {
        [Key]
        public int TokenID { get; set; }
        public string CustomerUserName { get; set; }    
        public string TokenValue { get; set; }

        public DateTime Expiry { get; set; }

        public Token(string customerUserName, string tokenValue, DateTime expiry)
        {
            CustomerUserName = customerUserName;
            TokenValue = tokenValue;
            Expiry = expiry;
        }
    }
}
