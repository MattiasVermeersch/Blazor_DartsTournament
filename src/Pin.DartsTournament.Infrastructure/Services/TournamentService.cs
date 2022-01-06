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
    public class TournamentService : BaseService<Tournament>, ITournamentService
    {
        public TournamentService(DartsDbContext dbContext) : base(dbContext) 
        { 
        }

        public override IQueryable<Tournament> GetAllAsync()
        {
            return _dbContext.Tournaments.AsNoTracking()
                .Include(t => t.Referees)
                .Include(t => t.Players);
        }

        public override async Task<Tournament> GetByIdAsync(long id)
        {
            return await GetAllAsync().FirstOrDefaultAsync(t => t.Id.Equals(id));
        }
    }
}
