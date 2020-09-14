namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Topic
    {
        public Topic()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int Likes { get; set; }

        public DateTime SubmitTime { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
