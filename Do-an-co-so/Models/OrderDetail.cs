using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Do_an_co_so.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Product")]      
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Order? Order { get; set; }

    }
}
