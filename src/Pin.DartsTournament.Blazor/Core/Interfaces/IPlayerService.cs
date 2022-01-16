using Pin.DartsTournament.Blazor.Models;
using Pin.DartsTournament.Core.Entities;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Blazor.Interfaces
{
    public interface IPlayerService : IBaseService<Player>
    {
        Task ResolveLegForPlayerAsync(long? playerId, bool hasWon);
        Task<IEnumerable<PlayerStatisticsModel>> GetPlayerStatisticsAsync();
        Task<PlayerStatisticsModel> GetTopTriplePlayerAsync();
        Task<PlayerStatisticsModel> GetTopDoublePlayerAsync();
        Task<PlayerStatisticsModel> GetTopT20PlayerAsync();
    }
}
