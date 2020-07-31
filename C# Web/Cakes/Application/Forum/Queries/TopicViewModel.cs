namespace Application.Forum.Queries
{
    using System;

    public class TopicViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int Likes { get; set; }

        public DateTime SubmitTime { get; set; }

        public int CommentCount { get; set; }
    }
}
