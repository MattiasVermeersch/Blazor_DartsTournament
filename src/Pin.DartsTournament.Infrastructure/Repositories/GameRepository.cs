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
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DartsDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Game> GetAllAsync()
        {
            return _dbContext.Games.AsNoTracking()
                .Include(g => g.Legs)
                    .ThenInclude(l => l.Throws)
                .Include(g => g.PlayerGames)
                    .ThenInclude(pg => pg.Player);
        }

        public override async Task<Game> GetByIdAsync(long id)
        {
            return await GetAllAsync().FirstOrDefaultAsync(g => g.Id.Equals(id));
        }
    }
}
