using BudgetManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManage.Services.Interfaces
{
    public interface ICheckItemService : IServiceBase<CheckItem>
    {
        Task<List<CheckItem>> GetCheckItemsForChecklist(int? id);
        Task<int> Check(int? id);
    }
}
