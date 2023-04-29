using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Do_an_co_so.Models
{
    public class DiscountDetail
    {
        [ForeignKey("Discount")]
        public int DiscountId { get; set; }
        public virtual Discount? Discount { get; set; } //Điều hướng tới Categories

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; } //Điều hướng tới Categories

    }
}
