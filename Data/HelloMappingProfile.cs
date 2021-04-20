using AutoMapper;
using Hello.Data.Entities;
using Hello.ViewModel;

namespace Hello.Data
{
    public class HelloMappingProfile : Profile
    {
        public HelloMappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                                              .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
        }
    }
}