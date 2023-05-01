using Microsoft.AspNetCore.SignalR;

namespace Do_an_co_so.Hubs
{
    public class CustomerHub : Hub
    {
        public static int _customerCounter = 0;
        public override Task OnConnectedAsync()
        {
            _customerCounter++;
            Clients.All.SendAsync("updateCustomerCounter", _customerCounter).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _customerCounter--;
            Clients.All.SendAsync("updateCustomerCounter", _customerCounter).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }
        public static int CustomerCount
        {
            get
            {
                return _customerCounter;
            }
            set
            {
                _customerCounter = value;
            }
        }
    }
}
