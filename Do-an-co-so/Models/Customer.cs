using System.ComponentModel.DataAnnotations;

namespace Do_an_co_so.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerUserName { get; set; }
            
        public string CustomerPassword { get; set; }

        public DateTime CustomerDateCreated { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }

        public string? CustomerPhone { get; set; }
        public bool CustomerState { get; set; }

        public string CustomerImage { get; set; }
    }
}
