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
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepo orderRepo,
            IDeliveryMethodRepo delRepo,
            IProductRepo prRepo,
            IBasketRepo basketRepo,
            IUserRepository userRepository)
        {
            _orderRepo = orderRepo;
            _delRepo = delRepo;
            _prRepo = prRepo;
            _basketRepo = basketRepo;
            _userRepository = userRepository;
        }
        public async Task<Address> GetUserStoredAddressAsync(string email)
        {
            // Fetch the user by email from the user repository
            var add = await _userRepository.GetUserStoredAddressAsync(email);

            // If the user is found, return their stored address
            if (add !=null)
            {
                return add;
            }

            // If no stored address is found, return null
            return null;
        }


        public async Task<Order> CreateOrderAsync(string buyerEmail, int delMId, string basketId, Address shippingAddress)
        {
            // Fetch the basket
            var basket = await _basketRepo.GetBasketAsync(basketId);
            if (basket == null)
            {
                throw new Exception($"Basket not found for ID: {basketId}");
            }

            // Prepare the order items
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _prRepo.GetProductByIdAsync(item.Id);
                if (productItem == null)
                {
                    throw new Exception($"Product with Id {item.Id} not found.");
                }

                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            // Fetch the delivery method
            var deliveryMethod = await _delRepo.GetByIdDeliveryAsync(delMId);
            if (deliveryMethod == null)
            {
                throw new Exception($"Delivery method with ID {delMId} not found.");
            }

            // Calculate subtotal (without including the delivery price)
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            // Create the order
            var order = new Order(buyerEmail, shippingAddress, deliveryMethod, items, subtotal);

            // Add the order to the database
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
            // Fetch the order with eager loading for related data
            var order = await _orderRepo.GetOrders()
                .Include(o => o.DeliveryMethod)  
                .Include(o => o.OrderedItems)       
                    .ThenInclude(i => i.ItemOrdered) // Include the nested ProductItemOrdered
                .Include(o => o.ShipToAddress)    
                .FirstOrDefaultAsync(o => o.Id == id && o.BuyerEmail == buyerEmail);

            if (order == null)
            {
                throw new InvalidOperationException($"Order with ID {id} not found or does not belong to the buyer with email {buyerEmail}.");
            }

            return order; // Return the found order
        }

        public async Task<IReadOnlyList<Order>> GetOrderForUsersAsync(string buyerEmail)
        {
            // Fetch all orders for the specified buyer with eager loading
            var orders = _orderRepo.GetOrders()
                .Where(o => o.BuyerEmail == buyerEmail)
                .Include(o => o.DeliveryMethod)  
                .Include(o => o.OrderedItems)      
                    .ThenInclude(i => i.ItemOrdered) // Include ProductItemOrdered
                .Include(o => o.ShipToAddress);  

            var orderList = await orders.ToListAsync();
            return orderList.AsReadOnly();
        }
    }
}
