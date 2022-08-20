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
    public class ExpenseService : IExpenseService
    {
        private readonly BudgetManagerDbContext _context;

        public ExpenseService(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Expense> GetById(int? id)
        {
            return await _context.Expenses.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Expense>> GetAll()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses.Where(e => e.IsWishItem == false).ToList();
        }
        
        public async Task<List<Expense>> ExpenseForExpenseGroup(int? expenseGroupId)
        {
            if (expenseGroupId == null)
            {
                throw new NullReferenceException($"{nameof(expenseGroupId)} is null");
            }

            return await _context.Expenses.Where(e => e.ExpenseGroupId == expenseGroupId).ToListAsync();
        }

        public async Task<int> Add(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            var result = await SaveChanges();
            return result;
        }

        public async Task<int> Update(Expense expense)
        {
            var entity = await _context.Expenses.Where(e => e.Id == expense.Id).FirstOrDefaultAsync();

            entity.Amount = expense.Amount;
            entity.Reason = expense.Reason;
            entity.ExpenseType = expense.ExpenseType;
            entity.Date = expense.Date;
            entity.Description = expense.Description;
            entity.IsWishItem = expense.IsWishItem;

            _context.Expenses.Update(entity);
            var result = await SaveChanges();
            return result;
        }

        public async Task<int> Delete(int? id)
        {
            var entity = await _context.Expenses.Where(e => e.Id == id).FirstOrDefaultAsync();
            _context.Expenses.Remove(entity);
            var result = await SaveChanges();

            return result;
        }

        public decimal CalculateTotal(List<Expense> expenses)
        {
            return expenses.Select(e => e.Amount).Sum();
        }

        public async Task<decimal> CalculateWishItemsTotal()
        {
            var expenses = await _context.Expenses.Where(e => e.IsWishItem).ToListAsync();
            return expenses.Select(e => e.Amount).Sum();
        }


        public async Task<List<Expense>> GetWishItems()
        {
            return await _context.Expenses.Where(e => e.IsWishItem).ToListAsync();
        }

        public async Task<int> MarkAsOwned(int? id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            expense.IsWishItem = false;

            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
