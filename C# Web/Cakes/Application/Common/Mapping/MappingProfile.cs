namespace Application.Common.Mapping
{
    using Application.Cakes.Queries;
    using Application.Cart.Queries;
    using Application.Comments.Queries;
    using Application.Employees.Queries;
    using Application.Forum.Queries;
    using AutoMapper;
    using Domain.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShoppingCart, CartViewModel>();
            CreateMap<Cake, CakesFullViewModel>();
            CreateMap<Comment, CommentsViewModel>();
            CreateMap<ShoppingCart, CartViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Comment, CurrentTopicCommentViewModel>();
            CreateMap<Topic, TopicViewModel>();
            CreateMap<Topic, CurrentTopicViewModel>();
            CreateMap<Topic, CustomerTopicViewModel>();
        }
    }
}
