using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public class ChecklistController : Controller
    {
        private readonly IChecklistService _service;

        public ChecklistController(IChecklistService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Add(int? checklistId)
        {
            ViewData["action"] = "Add";
            return this.View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Add(Checklist entity)
        {
            await _service.Add(entity);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var checklists = await _service.GetAll();
            return this.View(checklists.Where(ch => ch.IsCompleted == false).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Archive()
        {
            var checklists = await _service.GetAll();
            return this.View(checklists.Where(ch => ch.IsCompleted == true).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            ViewData["action"] = "Update";
            var checklist = await _service.GetById(id);
            return this.View("Edit", checklist);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Checklist entity)
        {
            await _service.Update(entity);
            return RedirectToAction(nameof(All));
        }
    }
}
