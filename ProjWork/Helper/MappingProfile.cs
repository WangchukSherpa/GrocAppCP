﻿using AutoMapper;
using ProjWork.Dto;
using ProjWork.Entities.Order;

namespace ProjWork.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<AddressDto, Address>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod,o=>o.MapFrom(s=>s.DeliveryMethod.Name))
                .ForMember(d => d.ShippingPrice,o=>o.MapFrom(s=>s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d=>d.ProductId,o=>o.MapFrom(s=>s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName , o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl));
        }
    }
}