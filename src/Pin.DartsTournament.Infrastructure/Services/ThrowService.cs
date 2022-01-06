﻿using Pin.DartsTournament.Core.Entities;
using Pin.DartsTournament.Core.Interfaces;
using Pin.DartsTournament.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Infrastructure.Services
{
    public class ThrowService : BaseService<Throw>, IThrowService
    {
        public ThrowService(DartsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
