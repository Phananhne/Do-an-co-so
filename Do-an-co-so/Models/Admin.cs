using System.ComponentModel.DataAnnotations;

namespace Do_an_co_so.Models
{
    public class Admin
    {

        [Key]
        public int AdminId { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string? AdminEmail { get; set; }
        public string? AdminImage { get; set; }

        public DateTime AdminDateCreated { get; set; }
    }
}
