namespace Pin.DartsTournament.Core.Entities
{
    public class Leg : EntityBase
    {
        public int Score { get; set; }
        public Player Player { get; set; }
        public IEnumerable<Dart> Throws { get; set; }
    }
}