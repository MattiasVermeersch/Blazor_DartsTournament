﻿using Pin.DartsTournament.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Interfaces
{
    public interface IPlayerService : IBaseService<Player>
    {
        Task<Player> GetPlayerByName(string name);
    }
}
