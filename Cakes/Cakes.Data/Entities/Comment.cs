using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Comment
    {
        public Comment()
        {
            Replies = new List<Reply>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        [Required]
        public DateTime SubmitTime { get; set; }

        public int? TopicId { get; set; }

        public Topic Topic { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}
