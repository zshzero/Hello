using AutoMapper;
using YoloShop.Data.Entities;
using YoloShop.ViewModel;

namespace YoloShop.Data
{
    public class YoloShopMappingProfile : Profile
    {
        public YoloShopMappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                                              .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
        }
    }
}