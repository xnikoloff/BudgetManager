using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManager.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Expense> Expense { get; set; }
        public IEnumerable<Income> Income { get; set; }
        public IEnumerable<Todo> Todos { get; set; }
        public IEnumerable<WishItem> WishItems { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal MaxMonthlyExpense { get; set; }
    }
}
