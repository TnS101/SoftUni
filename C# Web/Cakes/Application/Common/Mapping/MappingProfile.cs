namespace Application.Common.Mapping
{
    using Application.Cart.Queries;
    using AutoMapper;
    using Domain.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShoppingCart, CartViewModel>();
        }
    }
}
