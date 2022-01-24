using Microsoft.AspNetCore.SignalR;

namespace Pin.DartsTournament.Blazor.Hubs
{
    public class DartsHub : Hub
    {
        public async Task SendTournament()
        {
            await Clients.All.SendAsync("GetTournament");
        }

        public async Task SendToStatistics()
        {
            await Clients.All.SendAsync("GetStatistics");
        }

        public async Task SendLegData()
        {
            await Clients.All.SendAsync("GetLegData");
        }
    }
}
