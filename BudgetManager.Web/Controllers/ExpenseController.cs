using BudgetManage.Services;
using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using BudgetManager.Domain.Enumerations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public class ExpenseController : ControllerBase<Expense>
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async override Task<IActionResult> All()
        {
            var result = await _service.GetAll();
            ViewData["total"] = _service.CalculateTotal(result);

            return this.View(result.OrderByDescending(e => e.Id).ToList());
        }
        
        [HttpGet]
        public async Task<IActionResult> ExpenseForExpenseGroup(int? expenseGroupId)
        {
            TempData["expenseGroupId"] = expenseGroupId;
            return View(await _service.ExpenseForExpenseGroup(expenseGroupId));
        }

        public async Task<IActionResult> GetAllExtra()
        {
            var result = await _service.GetAll();
            ViewData["total"] = _service.CalculateTotal(result.Where(e => e.Reason == Reason.Extra).ToList());
            return this.View(nameof(All), result.Where(e => e.Reason == Reason.Extra).ToList());
        }

        [HttpGet]
        public override IActionResult Add()
        {
            ViewData["action"] = nameof(Add);
            return this.View("Edit");
        }

        [HttpPost]
        public async override Task<IActionResult> Add(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Edit", expense);
            }

            await _service.Add(expense);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async override Task<IActionResult> Update(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            ViewData["action"] = nameof(Update);
            var entity = await _service.GetById(id);
            return this.View("Edit", entity);
        }

        [HttpPost]
        public async override Task<IActionResult> Update(Expense expense)
        {
            await _service.Update(expense);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async override Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityToDelete = await _service.Delete(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Wishlist()
        {
            ViewData["wishListTotal"] = await _service.CalculateWishItemsTotal();
            return this.View("All", await _service.GetWishItems());
        }

        [HttpPost]
        public async Task<IActionResult> Own(int? id)
        {
            await _service.MarkAsOwned(id);
            return this.View(nameof(All));
        }
    }
}
