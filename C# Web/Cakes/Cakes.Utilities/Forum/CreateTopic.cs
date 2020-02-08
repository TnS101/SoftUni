namespace Cakes.Utilities.Forum
{
    using System;
    using System.Collections.Generic;
    using WebApplication1.Data;
    using WebApplication1.Data.Models;
    using WebApplication1.Models;

    public class CreateTopic
    {
        public void Create(WebsiteDbContext context, string topicName, string category, string content, Customer customer)
        {
            context.Topics.Add(new Topic
            {
                Name = topicName,
                Category = category,
                SubmitTime = DateTime.UtcNow,
                Content = content,
                Comments = new List<Comment>(),
                CustomerId = customer.Id
            });
            context.SaveChanges();
        }
    }
}
