using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Core.Entities;
using Pin.DartsTournament.Core.Interfaces;
using Pin.DartsTournament.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Infrastructure.Services
{
    public class LegRepository : BaseRepository<Leg>, ILegRepository
    {
        public LegRepository(DartsDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Leg> GetAllAsync()
        {
            return _table.AsNoTracking()
                .Include(g => g.Sets)
                    .ThenInclude(l => l.Throws)
                .Include(g => g.PlayerLegs)
                    .ThenInclude(pg => pg.Player);
        }

        public override async Task<Leg> GetByIdAsync(long? id)
        {
            return await GetAllAsync().FirstOrDefaultAsync(g => g.Id.Equals(id));
        }

        public override async Task<Leg> UpdateAsync(Leg entity)
        {
            try
            {
                var dbEntity = await _table.FindAsync(entity.Id);

                dbEntity.ScorePlayer1 = entity.ScorePlayer1;
                dbEntity.ScorePlayer2 = entity.ScorePlayer2;
                dbEntity.IsActive = entity.IsActive;
                dbEntity.IsPlayed = entity.IsPlayed;
                dbEntity.TournamentId = entity.TournamentId;

                await _dbContext.SaveChangesAsync();

                return await GetByIdAsync(entity.Id);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task AddPlayersToGame(IEnumerable<Player> players, long? legId)
        {
            try
            {
                var leg = await GetByIdAsync(legId);

                foreach (var player in players)
                {
                    _dbContext.PlayerLegs.Add(new PlayerLeg
                    {
                        LegId = leg.Id,
                        PlayerId = player.Id
                    });

                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
