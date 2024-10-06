namespace ProjWork.Model
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
    }
}
