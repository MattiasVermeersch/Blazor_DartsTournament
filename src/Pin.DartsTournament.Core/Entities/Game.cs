namespace Pin.DartsTournament.Core.Entities
{
    public class Game : EntityBase
    {
        public ICollection<Leg> Legs { get; set; }
        public ICollection<PlayerGame> PlayerGames { get; set; }
    }
}