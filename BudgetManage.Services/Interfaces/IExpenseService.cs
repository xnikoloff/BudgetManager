using BudgetManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManage.Services.Interfaces
{
    public interface IExpenseService : IServiceBase<Expense>
    {
        decimal CalculateTotal(List<Expense> expenses);
    }
}
