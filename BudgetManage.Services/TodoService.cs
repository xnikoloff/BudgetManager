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
    public class TodoService : ITodoService
    {
        private readonly BudgetManagerDbContext _context;

        public TodoService(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> GetById(int? id)
        {
            return await _context.Todos.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Todo>> GetAll()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<int> Add(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            return await SaveChanges();
        }

        public async Task<int> Update(Todo todo)
        {
            _context.Todos.Update(todo);
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
