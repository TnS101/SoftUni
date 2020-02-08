namespace Cakes.Utilities.Handlers
{
    using global::Cakes.Utilities.Comments;

    public class CommentHandler
    {
        public CommentHandler()
        {
        }

        public LikeComment LikeComment { get; set; } = new LikeComment();

        public AddCommment AddCommment { get; set; } = new AddCommment();
    }
}
