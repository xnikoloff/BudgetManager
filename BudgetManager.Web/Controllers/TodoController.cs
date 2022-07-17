using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public class TodoController : ControllerBase<Todo>
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }
        [HttpGet]
        public override IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async override Task<IActionResult> Add(Todo entity)
        {
            await _service.Add(entity);
            return RedirectToAction(nameof(Add));
        }

        public override async Task<IActionResult> All()
        {
            var todos = await _service.GetAll();
            return this.View(todos.Where(t => t.IsCompelted == false).ToList());
        }

        public async Task<IActionResult> Archive()
        {
            var todos = await _service.GetAll();
            return this.View(todos.Where(t => t.IsCompelted == true).ToList());
        }

        public override Task<IActionResult> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Update(int? id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Update(Todo entity)
        {
            throw new NotImplementedException();
        }
    }
}
