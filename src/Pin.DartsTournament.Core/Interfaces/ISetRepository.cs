using Pin.DartsTournament.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Interfaces
{
    public interface ISetRepository : IBaseRepository<Set>
    {
        Task<IEnumerable<Set>> GetPlayerSetsFromLeg(long? legId, Player player);
    }
}
