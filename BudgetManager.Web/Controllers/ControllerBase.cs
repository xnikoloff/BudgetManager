using BudgetManage.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public abstract class ControllerBase<T> : Controller where T : class
    {
        public abstract Task<IActionResult> All();
        public abstract IActionResult Add();
        public abstract Task<IActionResult> Add(T entity);
        public abstract Task<IActionResult> Update(int? id);
        public abstract Task<IActionResult> Update(T entity);
        public abstract Task<IActionResult> Delete(int? id);
    }
}
