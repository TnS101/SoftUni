using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public int CuntryId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
