namespace Pin.DartsTournament.Core.Entities
{
    public class Set : EntityBase
    {
        public int Score { get; set; }
        public Player Player { get; set; }
        public long? PlayerId { get; set; }
        public Leg Leg { get; set; }
        public long? LegId { get; set; }
        public ICollection<Throw> Throws { get; set; }
    }
}