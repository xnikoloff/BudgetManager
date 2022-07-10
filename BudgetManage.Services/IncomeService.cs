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
    public class IncomeService : IIncomeService
    {
        private readonly BudgetManagerDbContext _context;

        public IncomeService(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Income> GetById(int? id)
        {
            return await _context.Incomes.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Income>> GetAll()
        {
            return await _context.Incomes.ToListAsync();
        }

        public async Task<int> Add(Income income)
        {
            await _context.Incomes.AddAsync(income);
            return await SaveChanges();
        }

        public async Task<int> Update(Income income)
        {
            _context.Incomes.Update(income);
            return await SaveChanges();
        }

        public async Task<int> Delete(int? id)
        {
            var entity = await _context.Incomes.Where(i => i.Id == id).FirstOrDefaultAsync();
            _context.Incomes.Remove(entity);
            var result = await SaveChanges();

            return result;
        }

        public async Task<int> SaveChanges()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
