using Microsoft.AspNetCore.SignalR;
using Supermarket.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.HubConfig
{
    public class ChatHub: Hub
    {
                public async Task BroadcastChartData(List<Chat> data) => await Clients.All.SendAsync("broadcastchartdata", data);
    }
}