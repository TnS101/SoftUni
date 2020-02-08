namespace Cakes.Utilities.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApplication1.Data;
    using WebApplication1.Data.Models;

    public class AddCommment
    {
        public void Add(WebsiteDbContext context, string content,int topicId)
        {
            context.Topics.FirstOrDefault(c => c.Id == topicId).Comments.Add(new Comment
            {
                Content = content,
                Replies = new List<Reply>(),
                Likes = 0,
                SubmitTime = DateTime.UtcNow,
            });
            context.SaveChanges();
        }
    }
}
