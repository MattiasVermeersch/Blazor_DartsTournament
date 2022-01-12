using Pin.DartsTournament.Core.Entities;

namespace Pin.DartsTournament.Blazor.Interfaces
{
    public interface ITournamentService : IBaseService<Tournament>
    {
        Task<Tournament> AddPlayerToTournament(Player player);
        Task<Tournament> AddRefereeToTournament(Referee referee);
        Task StartTournament(long? id);
    }
}
