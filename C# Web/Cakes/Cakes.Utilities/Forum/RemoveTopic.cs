namespace Cakes.Utilities.Forum
{
    using System.Linq;
    using WebApplication1.Data;

    public class RemoveTopic
    {
        public void Remove(WebsiteDbContext context, int topicId)
        {
            var topicToRemove = context.Topics.FirstOrDefault(t => t.Id == topicId);
            foreach (var comment in context.Comments.Where(c => c.TopicId == topicId))
            {
                context.Comments.Remove(comment);
            }
            context.SaveChanges();
            context.Topics.Remove(topicToRemove);
            context.SaveChanges();
        }
    }
}
