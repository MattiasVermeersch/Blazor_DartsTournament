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
    public class PlayerService : BaseService<Player>, IPlayerService
    {
        public PlayerService(DartsDbContext dbContext) : base(dbContext) 
        { 
        }

        public override IQueryable<Player> GetAllAsync()
        {
            return _dbContext.Players.AsNoTracking()
                .Include(p => p.PlayerGames)
                    .ThenInclude(pg => pg.Game);
        }

        public override async Task<Player> GetByIdAsync(long id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<Player> GetPlayerByName(string name)
        {
            return await GetAllAsync().FirstOrDefaultAsync(p => p.Name.Equals(name));
        }
    }
}
