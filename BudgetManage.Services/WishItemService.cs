using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using BudgetManager.Infastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManage.Services
{
    public class WishItemService : IWishItemService
    {
        private readonly BudgetManagerDbContext _context;

        public WishItemService(BudgetManagerDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(WishItem entity)
        {
            await _context.AddAsync(entity);
            return await SaveChanges();
        }

        public Task<int> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WishItem>> GetAll()
        {
            return await _context.WishItems.ToListAsync();
        }

        public async Task<WishItem> GetById(int? id)
        {
            return await _context.WishItems.FindAsync(id);
        }
        
        public async Task<int> Update(WishItem entity)
        {
            var wishItem = await GetById(entity.Id);

            wishItem.Name = entity.Name;
            wishItem.Price = entity.Price;
            wishItem.Description = entity.Description;
            wishItem.Priority = entity.Priority;

            return await SaveChanges();
        }

        public async Task<decimal> CalculateTotalPriceWishItems()
        {
            return await _context.WishItems.Where(wi => wi.IsOwned == false).SumAsync(wi => wi.Price);
        }

        public async Task<decimal> CalculateTotalPriceOwnedItems()
        {
            return await _context.WishItems.Where(wi => wi.IsOwned == true).SumAsync(wi => wi.Price);
        }

        public async Task<int> Own(WishItem entity)
        {
            var wishItem = await _context.WishItems.FindAsync(entity.Id);
            wishItem.IsOwned = true;
            wishItem.DateOwned = DateTime.Now;
            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
