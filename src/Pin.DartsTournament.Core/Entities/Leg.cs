namespace Pin.DartsTournament.Core.Entities
{
    public class Leg : EntityBase
    {
        public int Score { get; set; }
        public Player Player { get; set; }
        public ICollection<Throw> Throws { get; set; }
    }
}