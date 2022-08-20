using BudgetManage.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManage.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<IExpenseGroupService, ExpenseGroupService>();
            services.AddTransient<IIncomeService, IncomeService>();
            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<ITodoTaskService, TodoTaskService>();
            services.AddTransient<IChecklistService, ChecklistService>();
            services.AddTransient<ICheckItemService, CheckItemService>();

            return services;
        }
    }
}
