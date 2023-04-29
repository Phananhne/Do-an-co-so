using System.ComponentModel.DataAnnotations;

namespace Do_an_co_so.Models
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }
        public string BannerName { get; set;}

        public int ProductDiscount { get; set; }
        public float BannerPrice { get; set; }
         
        public string BannerDescription { get; set; }

        public string BannerImage { get; set; }

        public DateTime BannerDateCreated { get; set; }


    }
}
