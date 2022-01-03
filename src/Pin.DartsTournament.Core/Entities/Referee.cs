namespace Pin.DartsTournament.Core.Entities
{
    public class Referee : EntityBase 
    {
        public string Name { get; set; }    
        public Game Game { get; set; }  
        public IEnumerable<Game> Games { get; set; }    
    }
}