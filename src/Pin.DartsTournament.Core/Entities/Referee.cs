namespace Pin.DartsTournament.Core.Entities
{
    public class Referee : EntityBase 
    {
        public string Name { get; set; }    
        public ICollection<Game> Games { get; set; }    
    }
}