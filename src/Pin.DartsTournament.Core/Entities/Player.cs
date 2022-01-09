namespace Pin.DartsTournament.Core.Entities
{
    public class Player : EntityBase
    {
        public string Name { get; set; }
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public ICollection<PlayerGame> PlayerGames { get; set; }
        public ICollection<Leg> Legs { get; set; }
        public Tournament Tournament { get; set; }
        public long? TournamentId { get; set; }
    }
}