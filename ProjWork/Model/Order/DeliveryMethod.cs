namespace ProjWork.Model.Order
{
    public class DeliveryMethod:BaseEntities
    {
        public string Name {  get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
