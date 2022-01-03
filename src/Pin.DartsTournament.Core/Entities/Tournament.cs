using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Entities
{
    public class Tournament : EntityBase
    {
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Referee> Referees { get; set; }
    }
}
