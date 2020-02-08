using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Data.Models;

namespace WebApplication1.Models
{
    public class Customer
    {
        public Customer()
        {
            Comments = new HashSet<Comment>();
            Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Password { get; set; }

        [Range(10, 100)]
        public int Age { get; set; }

        public decimal Balance { get; set; }

        public string ImageURL { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}
