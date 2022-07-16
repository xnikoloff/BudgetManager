using BudgetManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManage.Services.Interfaces
{
    public interface ITodoTaskService : IServiceBase<TodoTask>
    {
        Task<List<TodoTask>> GetTodoTasksForTodo(int taskId);
        Task<int> Complete(int taskId);
    }
}
