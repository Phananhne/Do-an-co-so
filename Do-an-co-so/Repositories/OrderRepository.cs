using Do_an_co_so.Data;
using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;
namespace Do_an_co_so.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(Do_an_co_soContext context) : base(context)
        {

        }
        public async Task UpdatePaymentState(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            order.PaidState = true;
            await _context.SaveChangesAsync();
        }
    }
}
