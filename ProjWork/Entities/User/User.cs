using ProjWork.Entities.Basket;
using ProjWork.Entities.Order;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjWork.Entities.User
{
    [Table("Users")]
    public class User : BaseEntities
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
       
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNum { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonIgnore]
        public ICollection<CustomersBasket> Baskets { get; set; } = new List<CustomersBasket>();
        [JsonIgnore]
        public ICollection<Entities.Order.Order> Orders { get; set; } = new List<Entities.Order.Order>(); 

    }
}
