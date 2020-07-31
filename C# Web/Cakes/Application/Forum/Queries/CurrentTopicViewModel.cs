namespace Application.Forum.Queries
{
    using System.Collections.Generic;

    public class CurrentTopicViewModel
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string CustomerName { get; set; }

        public string Content { get; set; }

        public IEnumerable<CurrentTopicCommentViewModel> Comments { get; set; }
    }
}
