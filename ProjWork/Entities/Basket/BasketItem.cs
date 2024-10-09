using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjWork.Entities.Basket
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string PictureUrl { get; set; }
        public string Brand { get; set; }

        public string Type { get; set; }
        [JsonPropertyName("customersBasketId")]
        public string CustomersBasketId { get; set; }  // Foreign key to CustomersBasket
        [JsonIgnore]
        public CustomersBasket? CustomersBasket { get; set; }
    }
}