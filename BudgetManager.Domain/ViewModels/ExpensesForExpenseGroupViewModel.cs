using System.Collections.Generic;

namespace BudgetManager.Domain.ViewModels
{
    public class ExpensesForExpenseGroupViewModel
    {
        public List<Expense> Expenses { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
