using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjWork.Dto;
using ProjWork.Entities.Basket;
using ProjWork.Entities.Order;
using ProjWork.Repo.Interface;
using ProjWork.Services;

namespace ProjWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IBasketRepo _basketRepo;

        public PaymentController(IPaymentService paymentService, IBasketRepo basketRepo)
        {
            _paymentService = paymentService;
            _basketRepo = basketRepo;
        }
        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomersBasket>> CreateOrUpdatePayment(string basketId, [FromBody] DeliveryMethodUpdateDto deliveryMethodUpdate)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);
            if (basket == null)
            {
                return NotFound("Basket not found");
            }

            basket.DeliveryMethodId = deliveryMethodUpdate.DeliveryMethodId;
     

            await _basketRepo.UpdateBasketAsync(basket);
            // Call payment service to create or update the payment
            var paymentResult = await _paymentService.CreateOrUpdatePayment(basketId);

            if (paymentResult == null)
            {
                return BadRequest("Payment failed");
            }

            // Clear the basket after successful payment
            basket.Items.Clear();  // Clear all items from the basket
            await _basketRepo.UpdateBasketAsync(basket);  // Save the empty basket to the database

            return Ok(basket);  // Return the cleared basket
        }
    }


}
