namespace Pin.DartsTournament.Core.Entities
{
    public class Throw : EntityBase
    {
        public string Type { get; set; }
        public int Number { get; set; }
        public Set Set { get; set; }
        public long? SetId { get; set; }
    }
}