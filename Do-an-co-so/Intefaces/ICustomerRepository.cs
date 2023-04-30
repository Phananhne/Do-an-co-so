using Do_an_co_so.Models;
namespace Do_an_co_so.Intefaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        //Lấy ra danh sách customer : số lượng đơn hàng từ startDate đến endDate
        public List<Table> GetTopOrder(DateTime startDate, DateTime endDate);

        //Lấy ra danh sách customer : số tiền đã tiêu từ startDate đến endDate
        public List<Table> GetTopRevenue(DateTime startDate, DateTime endDate);
    }
}
