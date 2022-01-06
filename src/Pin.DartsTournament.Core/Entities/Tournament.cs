using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Entities
{
    public class Tournament : EntityBase
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Referee> Referees { get; set; }
    }
}
