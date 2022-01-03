namespace Pin.DartsTournament.Core.Entities
{
    public class Player : EntityBase
    {
        public string Name { get; set; }
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public IEnumerable<Game> GamesPlayed { get; set; }
    }
}