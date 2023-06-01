namespace Do_an_co_so.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool IsActive { get; set; }

    }
}
