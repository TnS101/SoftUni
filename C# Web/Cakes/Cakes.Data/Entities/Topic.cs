using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Data.Models
{
    public class Topic
    {
        public Topic()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Category { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int Likes { get; set; }

        [Required]
        public DateTime SubmitTime { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
