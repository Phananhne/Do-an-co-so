using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Do_an_co_so.Models
{
    public class ProductRating
    {
        [Key]
        public int ProductRatingId { get; set; }
        public int Stars { get; set; }
        public string? RatingContent { get; set; }
        public DateTime PRDateCreated { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

    }
}
