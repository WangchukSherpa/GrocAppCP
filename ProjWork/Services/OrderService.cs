using ProjWork.Entities.Order;
using ProjWork.Repo.Interface;

namespace ProjWork.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<DeliveryMethod> _delRepo;
        private readonly IProductRepo _prRepo;
        private readonly IBasketRepo _basketRepo;

        public OrderService(IGenericRepository<Order> orderRepo,
            IGenericRepository<DeliveryMethod> delRepo,IProductRepo prRepo,IBasketRepo basketRepo) {
            _orderRepo = orderRepo;
            _delRepo = delRepo;
            _prRepo = prRepo;
            _basketRepo = basketRepo;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int delMId, string basketId, Address shipingAddress)
        {
            //get basket from repo
            var basket= await _basketRepo.GetBasketAsync(basketId);
            //get items from product repo
            var items=new List<OrderItem>();
            foreach(var i in basket.Items) {
                var productItem = await _prRepo.GetProductByIdAsync(i.Id);
                var itemOrder = new ProductItemOrdered(productItem.Id,productItem.Name,
                    productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrder, productItem.Price, i.Quantity);
                items.Add(orderItem);
            }
            //get del method from repo
            var deliveryMethod = await _delRepo.GetByIdAsync(delMId);
            //cal subtotal
            var subtotal=items.Sum(item=>item.Price*item.Quantity);
            //create ord
            var order =new Order(buyerEmail,shipingAddress,deliveryMethod,items,subtotal);
            //save to db

            //return order
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
