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
    public class RefereeRepository : BaseRepository<Referee>, IRefereeRepository
    {
        public RefereeRepository(DartsDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Referee> UpdateAsync(Referee entity)
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
    }
}
