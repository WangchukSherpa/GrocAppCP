using Microsoft.EntityFrameworkCore;
using ProjWork.Entities;
using ProjWork.Entities.Basket;
using ProjWork.Entities.Order;
using ProjWork.Repo.Interface;

namespace ProjWork.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IDeliveryMethodRepo _delRepo;
        private readonly IProductRepo _prRepo;
        private readonly IBasketRepo _basketRepo;

        public OrderService(IOrderRepo orderRepo,
            IDeliveryMethodRepo delRepo, 
            IProductRepo prRepo
            ,IBasketRepo basketRepo) {
            _orderRepo = orderRepo;
            _delRepo = delRepo;
            _prRepo = prRepo;
            _basketRepo = basketRepo;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int delMId, string basketId, Address shipingAddress)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);
            if (basket == null)
            {
                throw new Exception($"Basket not found for ID: {basketId}");
            }

            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                
                var productItem= await _prRepo.GetProductByIdAsync(item.Id);
             // Use ProductId instead of Id
                if (productItem == null)
                {
                    throw new Exception($"Product with Id {item.Id} not found.");
                }

                var itemOrder = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrder, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            var deliveryMethod = await _delRepo.GetByIdDeliveryAsync(delMId);
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            var order = new Order(buyerEmail, shipingAddress, deliveryMethod, items, subtotal);

            await _orderRepo.AddAsync(order);
            await _orderRepo.SaveChangesAsync();

            return order;
        }
        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _delRepo.ListAllDeliveryAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var order = await _orderRepo.GetByIdAsync(id);

            // Check if the order is null or if the buyerEmail does not match
            if (order == null || order.BuyerEmail != buyerEmail)
            {
                throw new InvalidOperationException($"Order with ID {id} not found or does not belong to the buyer with email {buyerEmail}.");
            }

            return order; // Return the found order
        }

        public async Task<IReadOnlyList<Order>> GetOrderForUsersAsync(string buyerEmail)
        {
            var orders=_orderRepo.GetOrders().Where(o=>o.BuyerEmail==buyerEmail);
            var orderList = await orders.ToListAsync();
            return orderList.AsReadOnly();
        }
    }
}
