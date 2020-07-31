using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set;}

        [Required]
        [MaxLength(50)]
        public string LogoUrl { get; set; }

        [Required]
        public Initials Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public int SecondaryKitColorId { get; set; }

        public Color Color { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }
    }
}
