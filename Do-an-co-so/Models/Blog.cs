using System.ComponentModel.DataAnnotations;

namespace Do_an_co_so.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogName { get; set; }

        public string? BlogContent { get; set; }
        public string? BlogImage { get; set; }
        public DateTime BlogDateCreated { get; set; }


    }
}
