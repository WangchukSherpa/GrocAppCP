﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProjWork.Data;
using ProjWork.Entities.Basket;
using ProjWork.Model;
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

     

        public async Task<bool> DeleteItemBasketAsync(int id)
        {
            var basketItem = await _context.BasketItems.SingleOrDefaultAsync(b => b.Id == id);

            if (basketItem == null)
            {
                return false;
            }

            // Remove the item from the basket
            _context.BasketItems.Remove(basketItem);

            // Save changes
            var result = await _context.SaveChangesAsync() > 0;
            return result;

        }

        public async Task<CustomersBasket> GetBasketAsync(string basketId)
        {
         return await _context.CustomersBaskets
                .Include(b=>b.Items)
                .FirstOrDefaultAsync(b => b.Id == basketId);
        }

        public async Task<CustomersBasket> UpdateBasketAsync(CustomersBasket customersBasket)
        {
            const int maxRetries = 5;
            int currentAttempt = 0;

            while (currentAttempt < maxRetries)
            {
                try
                {
                    var existingBasket = await _context.CustomersBaskets
                        .Include(b => b.Items)
                        .SingleOrDefaultAsync(b => b.Id == customersBasket.Id);

                    if (existingBasket == null)
                    {
                        _context.CustomersBaskets.Add(customersBasket);
                    }
                    else
                    {
                        // Process each new item
                        foreach (var newItem in customersBasket.Items)
                        {
                            // Try to find matching item
                            var existingItem = existingBasket.Items
                                .SingleOrDefault(i => i.ProductName == newItem.ProductName);

                            if (existingItem == null)
                            {
                                // If no matching item found, add new item
                                existingBasket.Items.Add(new BasketItem
                                {
                                    ProductName = newItem.ProductName,
                                    Quantity = newItem.Quantity,
                                    Price = newItem.Price,
                                    PictureUrl = newItem.PictureUrl,
                                    Brand = newItem.Brand,
                                    Type = newItem.Type
                                });
                            }
                            else
                            {
                                // If matching item found, update its properties
                                existingItem.Quantity += newItem.Quantity;
                                existingItem.Price = newItem.Price;
                                existingItem.PictureUrl = newItem.PictureUrl;
                                existingItem.Brand = newItem.Brand;
                                existingItem.Type = newItem.Type;
                            }
                        }

                        existingBasket.LastModified = DateTime.UtcNow;
                    }

                    await _context.SaveChangesAsync();
                    return await GetBasketAsync(customersBasket.Id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    currentAttempt++;

                    if (currentAttempt >= maxRetries)
                    {
                        throw new Exception("Failed to update basket after multiple attempts due to concurrent modifications. Please try again.");
                    }

                    _context.ChangeTracker.Clear();
                    await Task.Delay(100 * currentAttempt);
                }
            }

            throw new Exception("Unexpected error in basket update.");
        }
        


    }
}
