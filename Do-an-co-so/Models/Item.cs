using System.ComponentModel;
using Do_an_co_so.Models;
namespace Do_an_co_so.Models
{
    public class Item
    {
        public Product Product { get; set; }
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        [DisplayName("Tổng tiền")]
        public decimal TotalCost
        {
            get
            {
                return Product.ProductPrice * Quantity;
            }
        }
    }
}
