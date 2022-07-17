using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using BudgetManager.Infastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManage.Services
{
    public class ChecklistService : IChecklistService
    {
        private readonly BudgetManagerDbContext _context;

        public ChecklistService(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Checklist entity)
        {
            await _context.AddAsync(entity);
            return await SaveChanges();
        }

        public Task<List<Checklist>> GetAll()
        {
            return _context.Checklists.ToListAsync();
        }

        public async Task<Checklist> GetById(int? id)
        {
            return await _context.Checklists.Where(ch => ch.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Update(Checklist entity)
        {
            var checklist = await _context.Checklists.Where(ch => ch.Id == entity.Id).FirstOrDefaultAsync();
            checklist.Title = entity.Title;
            checklist.Description = entity.Description;

            return await SaveChanges();
        }

        public async Task<int> Delete(int? id)
        {
            var checklist = await _context.Checklists.Where(ch => ch.Id == id).FirstOrDefaultAsync();
            _context.Checklists.Remove(checklist);
            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
