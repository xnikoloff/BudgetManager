using BudgetManager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BudgetManager.Application
{
    public interface IBudgetManagerDbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        Task<int> SaveChangesAsync();
    }
}
