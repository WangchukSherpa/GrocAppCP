﻿using ProjWork.Entities.Order;

namespace ProjWork.Services
{
    public interface IOrderServices
    {
        Task<Order> CreateOrderAsync(string buyerEmail, int diliveryMethod, string basketId,
        Address shippingAddress);
        Task<IReadOnlyList<Order>> GetOrderForUsersAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync(string id,string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();


    }
}
