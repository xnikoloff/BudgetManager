using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetManage.Services.Interfaces;
using BudgetManager.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Web.Controllers
{
    public class WishItemController : ControllerBase<WishItem>
    {
        private readonly IWishItemService _service;

        public WishItemController(IWishItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public override IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public override async Task<IActionResult> Add(WishItem entity)
        {
            if (!ModelState.IsValid)
            {
                return this.View(entity);
            }

            await _service.Add(entity);
            return RedirectToAction(nameof(Add));
        }

        [HttpGet]
        public override async Task<IActionResult> All()
        {
            ViewData["totalPrice"] = await _service.CalculateTotalPriceWishItems();
            var allItems = await _service.GetAll();
            return this.View(allItems.Where(i => i.IsOwned == false).OrderByDescending(i => i.Id).ToList());
        }

        public override Task<IActionResult> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public override async Task<IActionResult> Update(int? id)
        {

            return this.View(await _service.GetById(id));
        }

        [HttpPost]
        public override async Task<IActionResult> Update(WishItem entity)
        {
            await _service.Update(entity);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Own(WishItem entity)
        {
            await _service.Own(entity);
            return RedirectToAction(nameof(All));
        }
        

        [HttpGet]
        public async Task<IActionResult> OwnedItems()
        {
            ViewData["totalPrice"] = await _service.CalculateTotalPriceOwnedItems();
            var allItems = await _service.GetAll();
            return this.View(allItems.Where(i => i.IsOwned == true).ToList());
        }
    }
}
