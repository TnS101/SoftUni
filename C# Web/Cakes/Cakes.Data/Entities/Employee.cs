using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        public decimal Salary { get; set; }

        public string ImageURL { get; set; }
    }
}
