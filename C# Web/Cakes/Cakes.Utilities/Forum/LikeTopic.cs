namespace Cakes.Utilities.Forum
{
    using System.Linq;
    using WebApplication1.Data;

    public class LikeTopic
    {
        public void Like(WebsiteDbContext context, int topicId)
        {
            context.Topics.FirstOrDefault(t => t.Id == topicId).Likes++;
            context.SaveChanges();
        }
    }
}
