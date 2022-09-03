using BudgetManager.Domain;
using BudgetManager.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetManage.Services.Interfaces
{
    public interface IExpenseService : IServiceBase<Expense>
    {
        decimal CalculateTotal(List<Expense> expenses);
        Task<decimal> CalculateWishItemsTotal();
        Task<List<Expense>> GetWishItems();
        Task<int> MarkAsOwned(int? id);
        Task<ExpensesForExpenseGroupViewModel> ExpenseForExpenseGroup(int? expenseGroupId);
    }
}
