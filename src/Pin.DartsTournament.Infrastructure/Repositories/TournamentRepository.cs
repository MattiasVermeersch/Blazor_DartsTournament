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
    public class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(DartsDbContext dbContext) : base(dbContext) 
        { 
        }

        public override IQueryable<Tournament> GetAllAsync()
        {
            return _dbContext.Tournaments.AsNoTracking()
                .Include(t => t.Referees)
                .Include(t => t.Players)
                .Include(t => t.Games)
                    .ThenInclude(g => g.PlayerLegs)
                        .ThenInclude(pg => pg.Player);
        }

        public override async Task<Tournament> GetByIdAsync(long? id)
        {
            return await GetAllAsync().FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        public override async Task<Tournament> UpdateAsync(Tournament entity)
        {
            try
            {
                var dbTournament = await _dbContext.Set<Tournament>().FindAsync(entity.Id);

                dbTournament.Name = entity.Name;
                dbTournament.Date = entity.Date;
                dbTournament.IsActive = entity.IsActive;

                await _dbContext.SaveChangesAsync();

                return await GetByIdAsync(entity.Id);
            }
           catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
