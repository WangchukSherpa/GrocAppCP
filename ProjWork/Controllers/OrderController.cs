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
        /* [HttpPost]
         public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
         {
             var email = HttpContext.User.RetriveEmailFromPrinciple();
             var address = _mapper.Map<AddressDto, Address>(orderDto.shiptoAddress);
             var order=await _orderServices.CreateOrderAsync(email, orderDto.DeliveryMethodId,orderDto.BasketId,address);
             if (order == null) {
                 return BadRequest("Problem creating order");
             }
             return  Ok(order);
         }*/
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto, [FromQuery] bool useStoredAddress = false)
        {
            var email = HttpContext.User.RetriveEmailFromPrinciple();

            Address address;
            if (useStoredAddress)
            {
               
                var storedAddress = await _orderServices.GetUserStoredAddressAsync(email);

                if (storedAddress == null)
                {
                    return BadRequest("No stored address found for the user."); // Return an error if no address found
                }

                // Assign the fetched address to the address variable
                address = storedAddress;
            }
            else
            {
                // If not using stored address, check if shiptoAddress is provided in the DTO
                if (orderDto.shiptoAddress == null)
                {
                    return BadRequest("Please provide an address."); // Return an error if address not provided
                }

                // Map the provided shiptoAddress from the DTO to the Address entity
                address = _mapper.Map<AddressDto, Address>(orderDto.shiptoAddress);
            }

            // Proceed with creating the order using the specified email, delivery method, basket ID, and address
            var order = await _orderServices.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

            // Check if the order creation was successful
            if (order == null)
            {
                return BadRequest("Problem creating order"); // Return an error if order creation fails
            }

            // Return the created order
            return Ok(order);
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
