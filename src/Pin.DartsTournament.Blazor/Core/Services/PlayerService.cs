using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Blazor.Models;
using Pin.DartsTournament.Blazor.Interfaces;
using Pin.DartsTournament.Core.Entities;
using Pin.DartsTournament.Core.Interfaces;

namespace Pin.DartsTournament.Blazor.Services
{
    public class PlayerService : IPlayerService
    {
        protected readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> AddAsync(Player entity)
        {
            return await _playerRepository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(long? id)
        {
            return await _playerRepository.DeleteByIdAsync(id);
        }

        public async Task<Player> GetByIdAsync(long? id)
        {
            return await _playerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Player>> ListAllAsync()
        {
            return await _playerRepository.ListAllAsync();
        }

        public async Task<Player> UpdateAsync(Player entity)
        {
            return await _playerRepository.UpdateAsync(entity);
        }

        public async Task ResolveLegForPlayerAsync(long? playerId, bool hasWon)
        {
            await _playerRepository.ResolveLegForPlayerAsync(playerId, hasWon);
        }

        public async Task<IEnumerable<PlayerStatisticsModel>> GetPlayerStatisticsAsync()
        {
            var players = await _playerRepository.GetPlayerStatisticsAsync();

            var modelList = new List<PlayerStatisticsModel>();

            foreach(var player in players)
            {
                var setList = player.Sets.ToList();

                double averageScore = 0;
                int allT20 = 0;
                int numberOfTrebles = 0;
                int numberOfDoubles = 0;

                if(setList.Count() > 0)
                {
                    averageScore = setList.Average(s => s.Score);

                    allT20 = setList.Sum(s => s.Throws.Count(t => t.Type.Equals("T20")));

                    numberOfTrebles = setList.Sum(s => s.Throws.Count(t => t.Type.Contains("T")));
                    numberOfDoubles = setList.Sum(s => s.Throws.Count(t => t.Type.Contains("D")));
                }
                

                var model = new PlayerStatisticsModel
                {
                    PlayerName = player.Name,
                    Wins = player.Wins,
                    Losses = player.Losses,
                    TypeCountT20 = allT20,
                    NumberOfTrebles = numberOfTrebles,
                    NumberOfDoubles = numberOfDoubles,
                    AverageScore = averageScore
                };

                modelList.Add(model);
            }

            return modelList;
        }

        public async Task<PlayerStatisticsModel> GetTopTriplePlayerAsync() 
        {
            var list = await GetPlayerStatisticsAsync();

            return list.OrderByDescending(p => p.NumberOfTrebles).First();
        }

        public async Task<PlayerStatisticsModel> GetTopDoublePlayerAsync()
        {
            var list = await GetPlayerStatisticsAsync();

            return list.OrderByDescending(p => p.NumberOfDoubles).First();
        }

        public async Task<PlayerStatisticsModel> GetTopT20PlayerAsync()
        {
            var list = await GetPlayerStatisticsAsync();

            return list.OrderByDescending(p => p.TypeCountT20).First();
        }
    }
}
