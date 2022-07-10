using BudgetManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManage.Services.Interfaces
{
    public interface IWishItemService : IServiceBase<WishItem>
    {
        Task<decimal> CalculateTotalPriceWishItems();
        Task<decimal> CalculateTotalPriceOwnedItems();
        Task<int> Own(WishItem entity);
    }
}
