﻿namespace ProjWork.Dto
{
    public class OrderDto
    {
        public string BasketId {  get; set; }
        public int DeliveryMethodId { get; set; }
        public  AddressDto shiptoAddress {  get; set; }
    }
}
