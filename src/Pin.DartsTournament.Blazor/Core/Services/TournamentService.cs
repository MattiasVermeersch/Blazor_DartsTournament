using Pin.DartsTournament.Blazor.Interfaces;
using Pin.DartsTournament.Core.Interfaces;
using Pin.DartsTournament.Core.Entities;

namespace Pin.DartsTournament.Blazor.Services
{
    public class TournamentService : ITournamentService
    {
        protected readonly ITournamentRepository _tournamentRepository;
        protected readonly IPlayerRepository _playerRepository;
        protected readonly IRefereeRepository _refereeRepository;

        public TournamentService(ITournamentRepository tournamentRepository,
            IPlayerRepository playerRepository,
            IRefereeRepository refereeRepository)
        {
            _tournamentRepository = tournamentRepository;
            _playerRepository = playerRepository;
            _refereeRepository = refereeRepository;
        }
        public Task<Tournament> AddAsync(Tournament entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tournament> GetByIdAsync(long? id)
        {
            var result = await _tournamentRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<IEnumerable<Tournament>> ListAllAsync()
        {
            var result = await _tournamentRepository.ListAllAsync();
            return result;
        }

        public Task<Tournament> UpdateAsync(Tournament entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Tournament> AddPlayerToTournament(Player player)
        {
            await _playerRepository.AddAsync(player);
            return await GetByIdAsync(player.Id);
        }

        public async Task<Tournament> AddRefereeToTournament(Referee referee)
        {
            await _refereeRepository.AddAsync(referee);
            return await GetByIdAsync(referee.TournamentId);
        }
    }
}
