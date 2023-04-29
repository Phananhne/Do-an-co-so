using System.ComponentModel.DataAnnotations;

namespace Do_an_co_so.Models
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        
        public int DiscountPercent { get; set; }
        public string? Description { get; set; }


    }
}
