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
    public class LegService : BaseService<Leg>, ILegService
    {
        public LegService(DartsDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Leg> GetAllAsync()
        {
            return _dbContext.Legs.AsNoTracking()
                .Include(l => l.Throws)
                .Include(l => l.Player);
        }

        public override Task<Leg> GetByIdAsync(long id)
        {
            return GetAllAsync().FirstOrDefaultAsync(l => l.Id.Equals(id));
        }
    }
}
