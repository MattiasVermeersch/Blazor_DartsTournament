namespace Pin.DartsTournament.Core.Entities
{
    public class Throw : EntityBase
    {
        public string Type { get; set; }
        public int Number { get; set; }
        public Leg Leg { get; set; }
        public long? LegId { get; set; }
    }
}