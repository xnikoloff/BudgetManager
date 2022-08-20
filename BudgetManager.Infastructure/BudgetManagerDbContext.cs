using BudgetManager.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Infastructure
{
    public class BudgetManagerDbContext : IdentityDbContext
    {
        public BudgetManagerDbContext(DbContextOptions<BudgetManagerDbContext> options)
            :base(options){}

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseGroup> ExpenseGroups { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<CheckItem> CheckItems { get; set; }
    }
}
