using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public class ExpenseGroupController : Controller
    {
        private readonly IExpenseGroupService _expenseGroupService;

        public ExpenseGroupController(IExpenseGroupService expenseGroupService)
        {
            _expenseGroupService = expenseGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View(await _expenseGroupService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["action"] = "Add";
            return View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpenseGroup expenseGroup)
        {
            if (!ModelState.IsValid)
            {
                return View(expenseGroup);
            }

            await _expenseGroupService.Add(expenseGroup);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int expenseGroupId)
        {
            await _expenseGroupService.Delete(expenseGroupId);
            return RedirectToAction(nameof(All));
        }
    }
}
