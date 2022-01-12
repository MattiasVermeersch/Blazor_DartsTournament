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
        protected readonly ILegRepository _legRepository;

        public TournamentService(ITournamentRepository tournamentRepository,
            IPlayerRepository playerRepository,
            IRefereeRepository refereeRepository,
            ILegRepository legRepository)
        {
            _tournamentRepository = tournamentRepository;
            _playerRepository = playerRepository;
            _refereeRepository = refereeRepository;
            _legRepository = legRepository;
        }
        public async Task<Tournament> AddAsync(Tournament entity)
        {
            return await _tournamentRepository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _tournamentRepository.DeleteByIdAsync(id);
        }

        public async Task<Tournament> GetByIdAsync(long? id)
        {
            return await _tournamentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Tournament>> ListAllAsync()
        {
            return await _tournamentRepository.ListAllAsync();
        }

        public async Task<Tournament> UpdateAsync(Tournament entity)
        {
            return await _tournamentRepository.UpdateAsync(entity);
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

        public async Task StartTournament(long? id)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(id);
            var players = await _playerRepository.GetPlayersByTournamentIdAsync(id);

            await GenerateRandomMatchesAsync(players, id);

            tournament.IsActive = true;

            await _tournamentRepository.UpdateAsync(tournament);
        }

        private async Task GenerateRandomMatchesAsync(IEnumerable<Player> players, long? tournamentId)
        {
            for(int i = 0; i < (players.Count() - 1); i++)
            {
                for(int j = i + 1; j < players.Count(); j++)
                {
                    Leg newLeg = new Leg
                    {
                        ScorePlayer1 = 501,
                        ScorePlayer2 = 501,
                        TournamentId = tournamentId
                    };

                    var twoPlayersForLeg = new List<Player>
                    {
                        players.ToList()[i],
                        players.ToList()[j],
                    };

                    var dbLeg = await _legRepository.AddAsync(newLeg);
                    await _legRepository.AddPlayersToGame(twoPlayersForLeg, dbLeg.Id);
                }
            }
        }
    }
}
