using BudgetManage.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;
using System;

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
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped((serviceProvider) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                return new SmtpClient()
                {
                    Host = config.GetValue<string>("Email:Smtp:Host"),
                    Port = config.GetValue<int>("Email:Smtp:Port"),
                };
            });

            return services;
        }
    }
}
