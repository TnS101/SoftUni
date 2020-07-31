namespace Persistance
{
    using Application.Common.Interfaces;

    public class Connection : IConnection
    {
        public string String { get; set; } = @"Server=.;Database=WebsiteDb;Integrated Security=True";
    }
}
