using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public class CheckItemController : Controller
    {
        private readonly ICheckItemService _service;

        public CheckItemController(ICheckItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> CheckItemsForChecklist(int? checklistid)
        {
            TempData["checkListId"] = checklistid;
            return this.View(await _service.GetCheckItemsForChecklist(checklistid));
        }

        [HttpGet]
        public IActionResult Add(int checklistId)
        {
            ViewData["action"] = "Add";
            return this.View("Edit", new CheckItem { CheckListId = checklistId });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]CheckItem entity)
        {
            await _service.Add(entity);
            return RedirectToAction(nameof(Add), new { entity.CheckListId });
        }

        [HttpGet]
        public Task<IActionResult> All()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<IActionResult> Update(int? id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> Update(CheckItem entity)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> ToggleCheck(int id)
        {
            int checkListId = await _service.ToggleCheck(id);
            return RedirectToAction(nameof(CheckItemsForChecklist), new { checkListId });
        }
    }
}
