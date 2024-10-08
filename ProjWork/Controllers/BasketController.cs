using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjWork.Entities.Basket;
using ProjWork.Repo.Interface;
using System.Security.Claims;

namespace ProjWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Require authentication for all endpoints
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepo _basketRepo;

        public BasketController(IBasketRepo basketRepo)
        {
            _basketRepo = basketRepo;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.Email) ??
                   throw new UnauthorizedAccessException("User not authenticated");
        }

        // Get current user's basket without requiring ID
        [HttpGet("my")]
        public async Task<ActionResult<CustomersBasket>> GetMyBasket()
        {
            try
            {
                var userId = GetUserId();
                var basket = await _basketRepo.GetBasketAsync(userId);

                if (basket == null)
                {
                    // Create a new basket for the user if one doesn't exist
                    basket = new CustomersBasket(userId);
                    await _basketRepo.UpdateBasketAsync(basket);
                }

                return Ok(basket);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }
        }

        // Get specific basket by ID (with authorization check)
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomersBasket>> GetCustomerBasketById([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new { message = "Basket ID is required" });
            }

            try
            {
                var userId = GetUserId();
                if (id != userId)
                {
                    
                    return StatusCode(403, new { message = "You can only access your own basket" });
                }

                var basket = await _basketRepo.GetBasketAsync(id);
                if (basket == null)
                {
                    return NotFound(new { message = "Basket not found" });
                }

                return Ok(basket);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }
        }

        // Update basket
        [HttpPost]
        public async Task<ActionResult<CustomersBasket>> UpdateCustomerBasket([FromBody] CustomersBasket basket)
        {
            if (basket == null)
            {
                return BadRequest(new { message = "Invalid basket data" });
            }

            try
            {
                var userId = GetUserId();

                // Ensure the basket ID matches the authenticated user
                basket.Id = userId; // Force the basket ID to be the user's ID

                var updatedBasket = await _basketRepo.UpdateBasketAsync(basket);
                return Ok(updatedBasket);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the basket" });
            }
        }

        // Delete specific item from basket
        [HttpDelete("items/{id}")]
        public async Task<IActionResult> DeleteItemBasketAsync([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new { message = "Invalid item ID" });
                }

                var userId = GetUserId();
                var basket = await _basketRepo.GetBasketAsync(userId);

                if (basket == null)
                {
                    return NotFound(new { message = "Basket not found" });
                }

            
                var itemBelongsToUser = basket.Items.Any(item => item.Id == id);
                if (!itemBelongsToUser)
                {
                    return StatusCode(403, new { message = "You can only delete items from your own basket" });
                }

                var result = await _basketRepo.DeleteItemBasketAsync(id);
                if (!result)
                {
                    return NotFound(new { message = "Item not found" });
                }

                return Ok(new { message = "Item deleted successfully" });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request" });
            }
        }
    }
}