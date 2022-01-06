using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Entities
{
    public class PlayerGame
    {
        public long PlayerId { get; set; }
        public long GameId { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
    }
}
