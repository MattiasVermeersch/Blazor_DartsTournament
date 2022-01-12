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
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DartsDbContext dbContext) : base(dbContext) 
        { 
            
        }

        public override IQueryable<Player> GetAllAsync()
        {
            return _table.AsNoTracking()
                .Include(p => p.PlayerLegs)
                    .ThenInclude(pg => pg.Leg);
        }

        public override async Task<Player> GetByIdAsync(long? id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public override async Task<Player> UpdateAsync(Player entity)
        {
            try
            {
                var dbEntity = await _table.FindAsync(entity.Id);

                dbEntity.Name = entity.Name;
                dbEntity.TournamentId = entity.TournamentId;

                await _dbContext.SaveChangesAsync();

                return await GetByIdAsync(entity.Id);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Player> GetPlayerByName(string name)
        {
            return await GetAllAsync().FirstOrDefaultAsync(p => p.Name.Equals(name));
        }

        public async Task<IEnumerable<Player>> GetPlayersByTournamentIdAsync(long? tournamentId)
        {
            return await GetAllAsync()
                .Where(p => p.TournamentId.Equals(tournamentId))
                .ToListAsync();
        }

        public async Task ResolveLegForPlayer(long? playerId, bool hasWon)
        {
            try
            {
                var dbEntity = await _table.FindAsync(playerId);

                if(hasWon) dbEntity.Wins++;

                else dbEntity.Losses++;

                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
