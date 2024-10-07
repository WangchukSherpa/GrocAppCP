namespace ProjWork.Entities.Order
{
    public class Order : BaseEntities
    {
        public Order()
        {
        }

        public Order(string buyerEmail,
            Address shipToAddress, DeliveryMethod deliveryMethod,
            IReadOnlyList<OrderItem> orderedItems, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderedItems = orderedItems;
            SubTotal = subTotal;
        }

        public string BuyerEmail { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderedItems { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentId { get; set; }
        public decimal getTotal()
        {
            return SubTotal + DeliveryMethod.Price;
        }
    }
}
