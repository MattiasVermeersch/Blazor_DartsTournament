namespace Pin.DartsTournament.Core.Entities
{
    public class Game : EntityBase
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public IEnumerable<Leg> Legs { get; set; }
    }
}