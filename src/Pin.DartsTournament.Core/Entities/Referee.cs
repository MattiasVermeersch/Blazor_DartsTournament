namespace Pin.DartsTournament.Core.Entities
{
    public class Referee : EntityBase 
    {
        public string Name { get; set; }    
        public ICollection<Leg> Games { get; set; }    
        public Tournament Tournament { get; set; }
        public long? TournamentId { get; set; }
    }
}