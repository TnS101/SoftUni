namespace Persistance
{
    using Application.Common.Interfaces;
    using Common;

    public class Connection : IConnection
    {
        public string String { get; set; } = GConst.ConnectionString;
    }
}
