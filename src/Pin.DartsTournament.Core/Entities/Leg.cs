namespace Pin.DartsTournament.Core.Entities
{
    public class Leg : EntityBase
    {
        public int Score { get; set; }
        public Player Player { get; set; }
        public long? PlayerId { get; set; }
        public Game Game { get; set; }
        public long? GameId { get; set; }
        public ICollection<Throw> Throws { get; set; }
    }
}