using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Entities
{
    public class PlayerStatistics : BaseEntity
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int NumberOfTriples { get; set; }
        public int NumberOfDoubles { get; set; }
        public Player Player { get; set; }
    }
}
