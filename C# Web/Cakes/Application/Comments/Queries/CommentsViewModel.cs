namespace Application.Comments.Queries
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;

    public class CommentsViewModel
    {
        public CommentsViewModel()
        {
            Replies = new HashSet<Reply>();
        }

        public string Content { get; set; }

        public int Likes { get; set; }

        public DateTime SubmitTime { get; set; }

        public int TopicId { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}
