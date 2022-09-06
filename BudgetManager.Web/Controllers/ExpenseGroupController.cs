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
            ViewData["totalAmount"] = await _expenseGroupService.GetTotalAmount();
            ViewData["expenseGroupAmounts"] = await _expenseGroupService.GetTotalAmountForExpenseGroups();
            return View(await _expenseGroupService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["action"] = nameof(Add);
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
        public async Task<IActionResult> Delete(int id)
        {
            await _expenseGroupService.Delete(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["action"] = nameof(Update);
            return View("Edit", await _expenseGroupService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExpenseGroup expenseGroup)
        {
            await _expenseGroupService.Update(expenseGroup);
            return RedirectToAction(nameof(All));
        }
    }
}
