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
    public class SetRepository : BaseRepository<Set>, ISetRepository
    {
        public SetRepository(DartsDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Set> GetAllAsync()
        {
            return _table.AsNoTracking()
                .Include(l => l.Throws)
                .Include(l => l.Leg)
                .Include(l => l.Player);
        }

        public override async Task<Set> GetByIdAsync(long? id)
        {
            return await GetAllAsync().FirstOrDefaultAsync(l => l.Id.Equals(id));
        }

        public override async Task<Set> UpdateAsync(Set entity)
        {
            try
            {
                var dbEntity = await _table.FindAsync(entity.Id);

                dbEntity.Score = entity.Score;
                dbEntity.PlayerId = entity.PlayerId;
                dbEntity.LegId = entity.LegId;

                await _dbContext.SaveChangesAsync();

                return await GetByIdAsync(entity.Id);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Set>> GetPlayerSetsFromLeg(long? legId, Player player)
        {
            return await GetAllAsync()
                .Where(s => s.LegId.Equals(legId))
                .Where(s => s.PlayerId.Equals(player.Id))
                .ToListAsync();
        }
    }
}
