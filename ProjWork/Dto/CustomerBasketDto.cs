using ProjWork.Entities.Basket;
using System.ComponentModel.DataAnnotations;

namespace ProjWork.Dto
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentId { get; set; }
    }
}
