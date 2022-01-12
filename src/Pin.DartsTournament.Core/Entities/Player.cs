using System.ComponentModel.DataAnnotations;

namespace Pin.DartsTournament.Core.Entities
{
    public class Player : EntityBase
    {
        [Required(ErrorMessage = "A name is required.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public ICollection<PlayerLeg> PlayerLegs { get; set; }
        public ICollection<Set> Sets { get; set; }
        public Tournament Tournament { get; set; }
        public long? TournamentId { get; set; }
    }
}