using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Do_an_co_so.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
        public string? ProductDescription { get; set; }

        public int ProductAmount { get; set; }
        public int ProductDiscount { get; set; }

        public string? ProductImage { get; set;}

        public DateTime ProductDateCreated { get; set; }
        [ForeignKey("Categories")]         
        
        public int CategoryId { get; set; }

        public virtual Categories? Categories { get; set; } //Điều hướng tới Categories

        [ForeignKey("ProductRating")]
        public int ProductRating { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<ProductRating>? ProductRatings { get; set; }
        public virtual ICollection<Favorite>? Favorites { get; set; }
    }
}
