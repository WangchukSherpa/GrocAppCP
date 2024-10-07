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

    }

}
