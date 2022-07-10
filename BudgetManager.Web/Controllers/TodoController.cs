using BudgetManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public class TodoController : ControllerBase<Todo>
    {
        [HttpGet]
        public override IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public override Task<IActionResult> Add(Todo entity)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> All()
        {
            throw new NotImplementedException();
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
