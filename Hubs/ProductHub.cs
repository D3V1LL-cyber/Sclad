using Склад.Models;
using Microsoft.AspNetCore.SignalR;

namespace Склад.Hubs

{
    public class ProductHub : Hub
    {
        public async Task SendProductUpdate()
        {
            await Clients.All.SendAsync("ReceiveProductUpdate");
        }
    }
}
