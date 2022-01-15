using Pin.DartsTournament.Core.Entities;

namespace Pin.DartsTournament.Blazor.Interfaces
{
    public interface ILegService : IBaseService<Leg>
    {
        Task<Leg> StartMatch(long id);
        Task SubmitSet(IEnumerable<Throw> thrown, long? legId, long? playerId);
    }
}
