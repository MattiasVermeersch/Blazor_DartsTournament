namespace Pin.DartsTournament.Core.Entities
{
    public class Leg : EntityBase
    {
        public int ScorePlayer1 { get; set; }
        public int ScorePlayer2 { get; set; }
        public long? CurrentlyPlayingId { get; set; }
        public long? WinnerId { get; set; }
        public ICollection<Set> Sets { get; set; }
        public ICollection<PlayerLeg> PlayerLegs { get; set; }
        public Tournament Tournament { get; set; }
        public long? TournamentId { get; set; }
        public bool IsActive { get; set; } = default;
        public bool IsPlayed { get; set; } = default;
    }
}