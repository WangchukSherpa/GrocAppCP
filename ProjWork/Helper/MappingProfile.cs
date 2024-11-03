using AutoMapper;
using ProjWork.Dto;
using ProjWork.Entities.Order;

namespace ProjWork.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map AddressDto to Address
            CreateMap<AddressDto, Address>();

            // Map Order to OrderToReturnDto
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.Name))//d-prop DelMethod ==> source  
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price))
                .ForMember(d => d.OrderedItems, o => o.MapFrom(s => s.OrderedItems))  // Map OrderItems to OrderedItems
                .ForMember(d => d.ShipToAddress, o => o.MapFrom(s => s.ShipToAddress))  // Map ShipToAddress
                .ForMember(d => d.Total, o => o.MapFrom(s => s.SubTotal + s.DeliveryMethod.Price));  // Calculate Total

            // Map OrderItem to OrderItemDto
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl));
        }
    }
}
