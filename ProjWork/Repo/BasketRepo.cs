using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProjWork.Data;
using ProjWork.Entities.Basket;
using ProjWork.Repo.Interface;
using System.Text.Json;

namespace ProjWork.Repo
{
    public class BasketRepo : IBasketRepo
    {
        private readonly ProductDbContext _context;
        public BasketRepo(ProductDbContext context) {
        _context = context;
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
           var basket=await _context.CustomersBaskets.FirstOrDefaultAsync(b => b.Id == id);
            if (basket == null) {
                return false;
            }
            _context.CustomersBaskets.Remove(basket);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CustomersBasket> GetBasketAsync(string basketId)
        {
         return await _context.CustomersBaskets
                .Include(b=>b.Items)
                .FirstOrDefaultAsync(b => b.Id == basketId);
        }

      public async Task<CustomersBasket> UpdateBasketAsync(CustomersBasket customersBasket)
        {
            var existingBasket = await _context.CustomersBaskets
            .SingleOrDefaultAsync(b => b.Id == customersBasket.Id);//Check if the basket already exists
            if (existingBasket == null)
            {
                _context.CustomersBaskets.Add(customersBasket);
                //adds basket if doesnot exist
            }
            else
            {
             _context.Entry(existingBasket).CurrentValues.SetValues(customersBasket);
                //updates in the same if exist
            }
            await _context.SaveChangesAsync();

            // Return the updated or created basket
            return await GetBasketAsync(customersBasket.Id);
        }

    }
}
