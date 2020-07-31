namespace Domain.Entities
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
            Comments = new HashSet<Comment>();
            Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public decimal Balance { get; set; }

        public string ImageURL { get; set; }

        public ICollection<Comment> Comments { get; private set; }

        public ICollection<Reply> Replies { get; private set; }
    }
}
