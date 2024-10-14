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
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrdersForUser() { 
            var email = HttpContext.User.RetriveEmailFromPrinciple();
            var orders = await _orderServices.GetOrderForUsersAsync(email);
            return Ok(_mapper.Map<IReadOnlyList<Order>,IReadOnlyList<OrderToReturnDto>>(orders));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdUser(int id) {
            var email = HttpContext.User.RetriveEmailFromPrinciple();
            var order= await _orderServices.GetOrderByIdAsync(id, email);
            if (order == null)  return NotFound($"order witd {id} not found");
            return _mapper.Map<Order,OrderToReturnDto>(order);
        }
        [HttpGet("deliveryMethod")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethod() {
            var deliveryMethod = await _orderServices.GetDeliveryMethodsAsync();
            return Ok(deliveryMethod);
        }
        [HttpGet("byEmail/{email}")]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersByEmail(string email)
        {
            var orders = await _orderServices.GetOrderForUsersAsync(email);
            if (orders == null || orders.Count == 0)
            {
                return NotFound($"No orders found for email: {email}");
            }

            return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders));
        }

    }
}
