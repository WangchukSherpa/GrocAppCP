using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            basket.DeliveryMethod = deliveryMethodUpdate.DeliveryMethod;

            await _basketRepo.UpdateBasketAsync(basket);

            return await _paymentService.CreateOrUpdatePayment(basketId);
        }
    }

    public class DeliveryMethodUpdateDto
    {
        public int DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
     
}
}
