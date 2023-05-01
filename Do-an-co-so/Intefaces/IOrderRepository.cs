using Do_an_co_so.Models;
namespace Do_an_co_so.Intefaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task UpdatePaymentState(int orderId);
    }
}
