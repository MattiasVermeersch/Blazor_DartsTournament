using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public PlayerStatistics Statistics { get; set; }
    }
}
