using System.ComponentModel.DataAnnotations;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.DbModels
{
    public class Cake
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(5, 50)]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageURL { get; set; }
        
        public int? ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
