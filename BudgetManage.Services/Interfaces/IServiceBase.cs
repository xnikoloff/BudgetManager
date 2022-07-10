using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetManage.Services.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        Task<T> GetById(int? id);
        Task<List<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int? id);
        Task<int> SaveChanges();
    }
}