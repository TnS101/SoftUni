namespace Domain.Entities
{
    using System;

    public class Reply
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public Comment Comment { get; set; }

        public DateTime SubmitTime { get; set; }

        public int Likes { get; set; }
    }
}
