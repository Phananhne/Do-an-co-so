using System.ComponentModel.DataAnnotations;

namespace Do_an_co_so.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CategoryDateCreated { get; set; }
        public string? CategoriesImage { set; get; }


    }
}
