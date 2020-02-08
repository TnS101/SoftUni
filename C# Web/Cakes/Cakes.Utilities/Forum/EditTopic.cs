namespace Cakes.Utilities.Forum
{
    using System;
    using System.Linq;
    using WebApplication1.Data;
    using WebApplication1.Data.Models;

    public class EditTopic
    {
        public void Edit(WebsiteDbContext context, string editName, string editCategory, string editContent, int topicId)
        {
            var oldTopic = context.Topics.FirstOrDefault(t => t.Id == topicId);

            if (editName == null)
            {
                editName = oldTopic.Name;
            }
            if (editCategory == null)
            {
                editCategory = oldTopic.Category;
            }

            context.Topics.Add(new Topic
            {
                Name = editName,
                Category = editCategory,
                Likes = oldTopic.Likes,
                CustomerId = oldTopic.CustomerId,
                Comments = oldTopic.Comments,
                SubmitTime = DateTime.UtcNow,
                Content = editContent
            });
            context.SaveChanges();
            context.Remove(oldTopic);
            context.SaveChanges();
        }
    }
}
