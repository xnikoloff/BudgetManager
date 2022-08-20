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
    public class CheckItemService : ICheckItemService
    {
        private readonly BudgetManagerDbContext _context;

        public CheckItemService(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(CheckItem entity)
        {
            await _context.AddAsync(entity);
            return await SaveChanges();
        }

        public async Task<List<CheckItem>> GetAll()
        {
            return await _context.CheckItems.ToListAsync();
        }

        public async Task<CheckItem> GetById(int? id)
        {
            return await _context.CheckItems.Where(ch => ch.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CheckItem>> GetCheckItemsForChecklist(int? id)
        {
            return await _context.CheckItems.Where(ci => ci.CheckListId == id).ToListAsync();
        }

        public async Task<int> Update(CheckItem entity)
        {
            var checkItem = await _context.CheckItems.Where(ch => ch.Id == entity.Id).FirstOrDefaultAsync();
            checkItem.Text = entity.Text;
            return await SaveChanges();
        }

        public async Task<int> Delete(int? id)
        {
            var checkItem = await _context.CheckItems.Where(ch => ch.Id == id).FirstOrDefaultAsync();
            _context.Remove(checkItem);
            return await SaveChanges();
        }

        public async Task<int> ToggleCheck(int? id)
        {
            var checkItem = await _context.CheckItems.FindAsync(id);

            if (checkItem.IsChecked)
            {
                checkItem.IsChecked = false;
            }

            else
            {
                checkItem.IsChecked = true;
            }

            await SaveChanges();
            return checkItem.CheckListId.Value;
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
