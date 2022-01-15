using Pin.DartsTournament.Blazor.Interfaces;
using Pin.DartsTournament.Core.Entities;
using Pin.DartsTournament.Core.Interfaces;

namespace Pin.DartsTournament.Blazor.Services
{
    public class LegService : ILegService
    {
        protected readonly ILegRepository _legRepository;
        protected readonly ISetRepository _setRepository;
        protected readonly IThrowRepository _throwRepository;
        public LegService(ILegRepository legRepository,
            ISetRepository setRepository, IThrowRepository throwRepository)
        {
            _legRepository = legRepository;
            _setRepository = setRepository;
            _throwRepository = throwRepository;
        }
        
        public Task<Leg> GetByIdAsync(long? id)
        {
            return _legRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Leg>> ListAllAsync()
        {
            return _legRepository.ListAllAsync();
        }

        public Task<Leg> AddAsync(Leg entity)
        {
            return _legRepository.AddAsync(entity);
        }

        public Task<Leg> UpdateAsync(Leg entity)
        {
            return _legRepository.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(long id)
        {
            return _legRepository.DeleteByIdAsync(id);
        }

        public async Task<Leg> StartMatch(long id)
        {
            var leg = await GetByIdAsync(id);
            leg.IsActive = true;
            return await _legRepository.UpdateAsync(leg);
        }

        public async Task SubmitSet(IEnumerable<Throw> thrown, long? legId, long? playerId)
        {
            var newSet = new Set();
            var score = 0;

            foreach(var dart in thrown)
            {
                score += dart.Number;
            }

            newSet.LegId = legId;
            newSet.PlayerId = playerId;
            newSet.Score = score;

            var set = await _setRepository.AddAsync(newSet);

            await AddThrowsToSet(thrown, set.Id);
            await CalculateScore(score, legId, playerId);
        }

        private async Task AddThrowsToSet(IEnumerable<Throw> thrown, long? setId)
        {
            foreach(var dart in thrown)
            {
                dart.SetId = setId;
                await _throwRepository.AddAsync(dart);
            }

            await _setRepository.GetByIdAsync(setId);
        }

        private async Task CalculateScore(int score, long? legId, long? currentPlayerId)
        {
            var leg = await _legRepository.GetByIdAsync(legId);

            var player1 = leg.PlayerLegs.First().Player;
            var player2 = leg.PlayerLegs.Last().Player;

            if (currentPlayerId == player1.Id) 
            { 
                leg.ScorePlayer1 -= score;
                //Update current
                leg.CurrentlyPlayingId = player2.Id;
            }

            if (currentPlayerId == player2.Id)
            {
                leg.ScorePlayer2 -= score;
                leg.CurrentlyPlayingId = player1.Id;
            }


            await _legRepository.UpdateAsync(leg);
        }
    }
}
