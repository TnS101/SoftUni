namespace Application.Cakes.Queries
{
    using System.Collections.Generic;

    public class CakesListViewModel
    {
        public IEnumerable<CakesFullViewModel> Cakes { get; set; }
    }
}
