using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProjWork.Model;
using ProjWork.Repo.Interface;

namespace ProjWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepo _basketRepo;
        public BasketController(IBasketRepo basketRepo) {
            _basketRepo = basketRepo;
        }
        [HttpGet]
        public async Task<ActionResult<CustomersBasket>> GetCustomerBasketById(string id) { 
        var basket=await _basketRepo.GetBasketAsync(id);
            if (basket == null) {
                return NotFound();
            }
         return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<CustomersBasket>> UpdateCustomerBasket(CustomersBasket basket) { 
            var updateBasket= await _basketRepo.UpdateBasketAsync(basket);
            return Ok(updateBasket);
        }
        [HttpDelete]
        public async Task DeleteBasketAsync(string Id) { 
          await _basketRepo.DeleteBasketAsync(Id);
          
        }
        
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjWork.Entities.Basket;
using ProjWork.Repo.Interface;

namespace ProjWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepo _basketRepo;
        public BasketController(IBasketRepo basketRepo) {
            _basketRepo = basketRepo;
        }
        [HttpGet]
        public async Task<ActionResult<CustomersBasket>> GetCustomerBasketById(string id) { 
        var basket=await _basketRepo.GetBasketAsync(id);
            if (basket == null) {
                return NotFound();
            }
         return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<CustomersBasket>> UpdateCustomerBasket(CustomersBasket basket) { 
            var updateBasket= await _basketRepo.UpdateBasketAsync(basket);
            return Ok(updateBasket);
        }
        [HttpDelete]
        public async Task DeleteBasketAsync(string Id) { 
          await _basketRepo.DeleteBasketAsync(Id);
          
        }
        
    }
}
