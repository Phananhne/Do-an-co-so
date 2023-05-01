using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Do_an_co_so.Models
{
    public class Order
    {
        [Key] 
        public int OrderId { get; set; }
        public DateTime DayOrder { get; set; }
        public DateTime DayDelivery { get; set; }

        public bool PaidState { get; set; }
        public bool DeliveryState { get; set; }
        public float TotalMoney { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
