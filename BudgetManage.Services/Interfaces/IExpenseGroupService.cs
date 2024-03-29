﻿using BudgetManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetManage.Services.Interfaces
{
    public interface IExpenseGroupService : IServiceBase<ExpenseGroup>
    {
        Task<decimal> GetTotalAmount();
        Task<List<decimal>> GetTotalAmountForExpenseGroups();
    }
}