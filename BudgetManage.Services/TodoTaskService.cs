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
    public class TodoTaskService : ITodoTaskService
    {
        private readonly BudgetManagerDbContext _context;

        public TodoTaskService(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(TodoTask entity)
        {
            await _context.AddAsync(entity);
            return await SaveChanges();
        }

        public Task<int> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TodoTask>> GetAll()
        {
            return await _context.TodoTasks.ToListAsync();
        }

        public Task<TodoTask> GetById(int? id)
        {
            return _context.TodoTasks.Where(tt => tt.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TodoTask>> GetTodoTasksForTodo(int taskId)
        {
            return await _context.TodoTasks.Where(tt => tt.TodoId == taskId).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<int> Update(TodoTask entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Complete(int id)
        {
            var todoTask = await _context.TodoTasks.Where(tt => tt.Id == id).FirstOrDefaultAsync();
            todoTask.IsCompleted = true;

            return await SaveChanges();
        }
    }
}
