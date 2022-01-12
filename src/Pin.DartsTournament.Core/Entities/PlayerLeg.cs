using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Entities
{
    public class PlayerLeg
    {
        public long PlayerId { get; set; }
        public long LegId { get; set; }
        public Player Player { get; set; }
        public Leg Leg { get; set; }
    }
}
