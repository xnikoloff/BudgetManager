using BudgetManager.Domain.ViewModels;
using System.Threading.Tasks;

namespace BudgetManage.Services.Interfaces
{
    public interface IEmailService
    {
        Task Send(string topic, EmailTemplateViewModel dto);
    }
}
