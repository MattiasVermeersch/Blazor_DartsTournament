using Pin.DartsTournament.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Interfaces
{
    public interface ILegRepository : IBaseRepository<Leg>
    {
        Task AddPlayersToGame(IEnumerable<Player> players, long? legId);
    }
}
