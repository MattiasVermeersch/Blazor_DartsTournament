using Pin.DartsTournament.Blazor.Models;
using Pin.DartsTournament.Core.Entities;

namespace Pin.DartsTournament.Blazor.Interfaces
{
    public interface ILegService : IBaseService<Leg>
    {
        Task<Leg> StartMatch(long id);
        Task SubmitSet(IEnumerable<Throw> thrown, long? legId, long? playerId);
        Task<ICollection<SetModel>> GetSetsFromPlayer(Player player, long? legId);
        Task ResolveLeg(long? playerId, Leg leg);
        Task<IEnumerable<Leg>> GetActiveLegs();
    }
}
