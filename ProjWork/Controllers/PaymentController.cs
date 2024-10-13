using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjWork.Entities.Basket;
using ProjWork.Services;

namespace ProjWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomersBasket>> CreateOrUpdatePayment(string basketId) {
            return await _paymentService.CreateOrUpdatePayment(basketId); 
            
        }
    }
}
