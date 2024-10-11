using ProjWork.Entities;
using ProjWork.Entities.Basket;
using ProjWork.Entities.Order;
using ProjWork.Repo.Interface;

namespace ProjWork.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<DeliveryMethod> _delRepo;
        private readonly IGenericRepository<Product> _prRepo;
        private readonly IBasketRepo _basketRepo;

        public OrderService(IGenericRepository<Order> orderRepo,
            IGenericRepository<DeliveryMethod> delRepo, 
            IGenericRepository<Product> prRepo
            ,IBasketRepo basketRepo) {
            _orderRepo = orderRepo;
            _delRepo = delRepo;
            _prRepo = prRepo;
            _basketRepo = basketRepo;
        }
        /* public async Task<Order> CreateOrderAsync(string buyerEmail, int delMId, string basketId, Address shipingAddress)
         {
             //get basket from repo
             var basket= await _basketRepo.GetBasketAsync(basketId);

             if (basket == null)
             {
                 throw new Exception("Basket not found");
             }

             //get items from product repo
             var items = new List<OrderItem>();
             *//* var items = new List<BasketItem>();*//*
             foreach (var item in basket.Items) {
                 var productItem = await _prRepo.GetByIdAsync(item.Id);

                 // Check if the product exists
                 if (productItem == null)
                 {
                     throw new Exception($"Product with Id {item.Id} not found.");
                 }
                 var itemOrder = new ProductItemOrdered(productItem.Id,productItem.Name,
                     productItem.PictureUrl);
                 var orderItem = new OrderItem(itemOrder, productItem.Price, item.Quantity);
                 items.Add(orderItem);
             }
             //get del method from repo
             var deliveryMethod = await _delRepo.GetByIdAsync(delMId);
             //cal subtotal
             var subtotal=items.Sum(item=>item.Price*item.Quantity);
             //create ord
             var order =new Order(buyerEmail,shipingAddress,deliveryMethod,items,subtotal);
             //save to db
             // Save the order to the database
             await _orderRepo.AddAsync(order);

             // Optionally, save changes if required
             await _orderRepo.SaveChangesAsync();


             //return order
             return order;
         }
 */
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
                var productItem = await _prRepo.GetByIdAsync(item.Id);
             // Use ProductId instead of Id
                if (productItem == null)
                {
                    throw new Exception($"Product with Id {item.Id} not found.");
                }

                var itemOrder = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrder, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            var deliveryMethod = await _delRepo.GetByIdAsync(delMId);
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            var order = new Order(buyerEmail, shipingAddress, deliveryMethod, items, subtotal);

            await _orderRepo.AddAsync(order);
            await _orderRepo.SaveChangesAsync();

            return order;
        }
        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(string id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderForUsersAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
