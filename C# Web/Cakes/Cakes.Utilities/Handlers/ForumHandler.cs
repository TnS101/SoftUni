namespace Cakes.Utilities.Handlers
{
    using global::Cakes.Utilities.Forum;

    public class ForumHandler
    {
        public ForumHandler()
        {
        }

        public CreateTopic CreateTopic { get; set; } = new CreateTopic();

        public EditTopic EditTopic { get; set; } = new EditTopic();

        public LikeTopic LikeTopic { get; set; } = new LikeTopic();

        public RemoveTopic RemoveTopic { get; set; } = new RemoveTopic();
    }
}
