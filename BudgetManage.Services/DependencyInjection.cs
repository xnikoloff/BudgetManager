using BudgetManage.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManage.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<IIncomeService, IncomeService>();
            services.AddTransient<IWishItemService, WishItemService>();

            return services;
        }
    }
}
