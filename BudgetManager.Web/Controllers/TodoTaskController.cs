using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public class TodoTaskController : Controller
    { 
        private readonly ITodoTaskService _service;

        public TodoTaskController(ITodoTaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Add(int? todoId)
        {
            return this.View(new TodoTask { TodoId = todoId});
        }

        [HttpPost]
        public async Task<IActionResult> Add(TodoTask entity)
        {
            await _service.Add(entity);
            return RedirectToAction(nameof(Add), new { entity.TodoId });
        }

        [HttpGet]
        public async Task<IActionResult> TodoTaskForTodo(int todoId)
        {
            return this.View(await _service.GetTodoTasksForTodo(todoId));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return this.View(await _service.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Complete(int id)
        {
            var todoTask = await _service.GetById(id);
            await _service.Complete(id);
            return RedirectToAction(nameof(TodoTaskForTodo), new { todoTask.TodoId });
        }
    }
}
