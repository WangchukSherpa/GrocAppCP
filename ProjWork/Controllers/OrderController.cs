using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjWork.Dto;
using ProjWork.Entities.Order;
using ProjWork.Extensions;
using ProjWork.Services;
using System.Security.Claims;

namespace ProjWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;

        public OrderController(IOrderServices orderServices,IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetriveEmailFromPrinciple();
            var address = _mapper.Map<AddressDto, Address>(orderDto.shiptoAddress);
            var order=await _orderServices.CreateOrderAsync(email, orderDto.DeliveryMethodId,orderDto.BasketId,address);
            if (order == null) {
                return BadRequest("Problem creating order");
            }
            return  Ok(order);
        }
    }
}
