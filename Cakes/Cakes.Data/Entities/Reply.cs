using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Reply
    {
        public int Id { get; set; }

        [Required]
        public int CommentId { get; set; }

        public Comment Comment { get; set; }

        [Required]
        public DateTime SubmitTime { get; set; }

        public int Likes { get; set; }
    }
}
