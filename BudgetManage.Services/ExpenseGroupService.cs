using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using BudgetManager.Infastructure;
using Microsoft.EntityFrameworkCore;

namespace BudgetManage.Services
{
    public class ExpenseGroupService : IExpenseGroupService
    {
        private readonly BudgetManagerDbContext _context;

        public ExpenseGroupService(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(ExpenseGroup entity)
        {
            _context.Add(entity);
            return await SaveChanges();
        }

        public async Task<int> Delete(int? id)
        {
            if(id == null)
            {
                throw new NullReferenceException($"{nameof(id)} is null");
            }

            var expenseGroup = _context.ExpenseGroups.FindAsync(id);
            _context.Remove(expenseGroup);

            return await SaveChanges();
        }

        public async Task<List<ExpenseGroup>> GetAll()
        {
            return await _context.ExpenseGroups.ToListAsync();
        }

        public Task<ExpenseGroup> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<int> Update(ExpenseGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}
