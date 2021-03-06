using Pin.DartsTournament.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Task<Player> GetPlayerByName(string name);
        Task<IEnumerable<Player>> GetPlayersByTournamentIdAsync(long? tournamentId);
        Task ResolveLegForPlayerAsync(long? playerId, bool hasWon);
        Task<IEnumerable<Player>> GetPlayerStatisticsAsync();
    }
}
