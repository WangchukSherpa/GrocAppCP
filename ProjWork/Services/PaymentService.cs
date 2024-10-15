using Microsoft.Extensions.Options;
using ProjWork.Entities.Basket;
using ProjWork.Repo.Interface;
using Stripe;

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
            // Retrieve and check Stripe API key
            var stripeApiKey = "sk_test_51Q93OaKpfiqounxCQrsmj4jiVH8kGB4TXLCIOrvpWAEYpmULjf3qF2sJPetU7PzvOfodVlSiAbVnqi16cR55FxFK000i7ikT8F";
           /* var stripeApiKey = _config["StripeSettings.SecretKey"];*/
            if (string.IsNullOrEmpty(stripeApiKey))
            {
                throw new Exception("Stripe API key is not configured.");
            }
            Console.WriteLine(stripeApiKey);

            // Set the Stripe API key
            StripeConfiguration.ApiKey = stripeApiKey;

            // Get the customer's basket
            var basket = await _basketRepo.GetBasketAsync(basketId);
            if (basket == null || basket.Items == null || !basket.Items.Any())
            {
                throw new Exception("Basket is empty or not found.");
            }

            // Calculate shipping price if delivery method is selected
            var shippingPrice = 0m;
            /*if (basket.DeliveryMethodId.HasValue)*/
            /*  if (basket.DeliveryMethod!=null)
              {
                  var delMethod = await _delRepo.GetByIdDeliveryAsync((int)basket.DeliveryMethod.Id);
                  if (delMethod != null)
                  {
                      shippingPrice = delMethod.Price;
                  }
                  else
                  {
                      throw new Exception("Delivery method not found.");
                  }
              }*/
            if (basket.DeliveryMethod != null)
            {
                var delMethod = await _delRepo.GetByIdDeliveryAsync(basket.DeliveryMethod.Id);
                if (delMethod != null)
                {
                    shippingPrice = delMethod.Price;
                    basket.DeliveryMethodId = delMethod.Id;
                    basket.DeliveryMethod = delMethod;
                }
                else
                {
                    throw new Exception("Delivery method not found.");
                }
            }
            // Validate product prices in the basket
            foreach (var item in basket.Items)
            {
                var productItem = await _prodRepo.GetProductByIdAsync(item.Id);
                if (productItem == null)
                {
                    throw new Exception($"Product with ID {item.Id} not found.");
                }

                if (item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }

            // Initialize PaymentIntent service
            var service = new PaymentIntentService();
            PaymentIntent intent;

            if (string.IsNullOrEmpty(basket.PaymentId))
            {
                // Create new payment intent
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) +
                             (long)shippingPrice * 100,
                    Currency = "inr",
                    PaymentMethodTypes = new List<string> { "card" }
                };

                intent = await service.CreateAsync(options);
                basket.PaymentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                // Update existing payment intent
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) +
                             (long)shippingPrice * 100
                };

                await service.UpdateAsync(basket.PaymentId, options);
            }

            // Update the basket in the repository
            await _basketRepo.UpdateBasketAsync(basket);
            return basket;
        }
    }
}
