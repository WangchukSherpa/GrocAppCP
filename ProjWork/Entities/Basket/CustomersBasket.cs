using ProjWork.Entities.Order;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace ProjWork.Entities.Basket
{
    public class CustomersBasket
    {
        public CustomersBasket()
        {
        }

        public CustomersBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        [ConcurrencyCheck]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public int? DeliveryMethodId {  get; set; }
      
        public string? ClientSecret { get; set; }
        public string? PaymentId { get; set; }

    }

}
