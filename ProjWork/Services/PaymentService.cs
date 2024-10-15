using Microsoft.Extensions.Options;
using ProjWork.Entities.Basket;
using ProjWork.Repo.Interface;
using Stripe;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjWork.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBasketRepo _basketRepo;
        private readonly IConfiguration _config;
        private readonly IDeliveryMethodRepo _delRepo;
        private readonly IProductRepo _prodRepo;

        public PaymentService(IBasketRepo basketRepo,
            IConfiguration config,
            IDeliveryMethodRepo delRepo,
            IProductRepo prodRepo)
        {
            _basketRepo = basketRepo;
            _config = config;
            _delRepo = delRepo;
            _prodRepo = prodRepo;
        }

        public async Task<CustomersBasket> CreateOrUpdatePayment(string basketId)
        {
            // Retrieve and check Stripe API key from configuration (using a hardcoded key for now)
            var stripeApiKey = _config["StripeSettings:SecretKey"];
            if (string.IsNullOrEmpty(stripeApiKey))
            {
                throw new Exception("Stripe API key is not configured.");
            }
            StripeConfiguration.ApiKey = stripeApiKey;

            // Get the customer's basket
            var basket = await _basketRepo.GetBasketAsync(basketId);
            if (basket == null || basket.Items == null || !basket.Items.Any())
            {
                throw new Exception("Basket is empty or not found.");
            }

            // Calculate shipping price based on selected delivery method
            var shippingPrice = 0m;
            if (basket.DeliveryMethodId.HasValue)
            {
                var delMethod = await _delRepo.GetByIdDeliveryAsync((int)basket.DeliveryMethodId);
                if (delMethod != null)
                {
                    shippingPrice = delMethod.Price;
                }
                else
                {
                    throw new Exception("Delivery method not found.");
                }
            }

            // Validate and update product prices
            foreach (var item in basket.Items)
            {
                var productItem = await _prodRepo.GetProductByIdAsync(item.Id);
                if (productItem == null)
                {
                    throw new Exception($"Product with ID {item.Id} not found.");
                }

                // Ensure the price is up-to-date
                if (item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }

            // Create or update the PaymentIntent
            var service = new PaymentIntentService();
            PaymentIntent intent;

            // If no payment exists, create one
            if (string.IsNullOrEmpty(basket.PaymentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = CalculateTotalAmount(basket, shippingPrice),
                    Currency = "inr",
                    PaymentMethodTypes = new List<string> { "card" }
                };

                intent = await service.CreateAsync(options);
                basket.PaymentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                // Update the existing payment intent
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = CalculateTotalAmount(basket, shippingPrice)
                };

                await service.UpdateAsync(basket.PaymentId, options);
            }

            // Update the basket with the payment information
            await _basketRepo.UpdateBasketAsync(basket);
            return basket;
        }

        // Helper function to calculate the total payment amount including shipping
        private long CalculateTotalAmount(CustomersBasket basket, decimal shippingPrice)
        {
            // Calculate total by summing up product prices and quantities, plus shipping cost
            var itemsTotal = basket.Items.Sum(i => i.Quantity * (i.Price * 100));
            var totalAmount = (long)(itemsTotal + (shippingPrice * 100)); // Stripe expects amounts in cents
            return totalAmount;
        }
    }
}
