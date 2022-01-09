namespace Pin.DartsTournament.Core.Entities
{
    public class Game : EntityBase
    {
        public ICollection<Leg> Legs { get; set; }
        public ICollection<PlayerGame> PlayerGames { get; set; }
        public Tournament Tournament { get; set; }
        public long? TournamentId { get; set; }
        public bool IsActive { get; set; } = default;
        public bool IsPlayed { get; set; } = default;
    }
}