namespace Pin.DartsTournament.Blazor.Models
{
    public class PlayerStatisticsModel
    {
        public string PlayerName { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? TypeCountT20 { get; set; }
        public int? NumberOfTrebles { get; set; }
        public int? NumberOfDoubles { get; set; }
        public double AverageScore { get; set; }
    }
}
