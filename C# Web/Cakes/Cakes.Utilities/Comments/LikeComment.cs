namespace Cakes.Utilities.Comments
{
    using System.Linq;
    using WebApplication1.Data;

    public class LikeComment
    {
        public void Like(WebsiteDbContext context, int commentId)
        {
            context.Comments.FirstOrDefault(c => c.Id == commentId).Likes++;
            context.SaveChanges();
        }
    }
}
