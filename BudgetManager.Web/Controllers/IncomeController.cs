using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public class IncomeController : ControllerBase<Income>
    {
        private readonly IIncomeService _service;

        public IncomeController(IIncomeService service)
        {
            _service = service;
        }

        [HttpGet]
        public override async Task<IActionResult> All()
        {
            var result = await _service.GetAll();
            return this.View(result);
        }

        [HttpGet]
        public override IActionResult Add()
        {
            ViewData["action"] = nameof(Add);
            return this.View("Edit");
        }

        [HttpPost]
        public async override Task<IActionResult> Add(Income entity)
        {
            await _service.Add(entity);
            return RedirectToAction(nameof(Add));
        }

        [HttpGet]
        public override async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["action"] = nameof(Update);
            var entity = await _service.GetById(id);
            return this.View("Edit", entity);
        }

        [HttpPost]
        public async override Task<IActionResult> Update(Income entity)
        {
            await _service.Update(entity);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public override async Task<IActionResult> Delete(int? id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(All));
        }
        
    }
}
