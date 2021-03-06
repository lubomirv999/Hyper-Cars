﻿namespace HyperCars.Web.Areas.Parts.Controllers
{
    using HyperCars.Web.Infrastructure.Extensions;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Parts;
    using System;
    using System.Threading.Tasks;

    [Area("Parts")]
    [Authorize]
    public class PartsController : Controller
    {
        private const int PageSize = 6;

        private readonly IPartService parts;

        public PartsController(IPartService parts)
        {
            this.parts = parts;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 6)
            => View(new PartListingModel
            {
                Parts = await this.parts.AllAsync(page, pageSize),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.parts.Total() / (double)PageSize)
            });

        public IActionResult Create()
            => View();

        [Authorize]
        [HttpPost]
        public IActionResult Create(PartFormModel addPartModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(addPartModel);
            }

            var success = this.parts.Add(
                addPartModel.Name,
                addPartModel.Price,
                addPartModel.Condition,
                addPartModel.ImageUrl,
                this.User.Identity.GetUserId());

            if (!success)
            {
                return this.BadRequest();
            }

            TempData.AddSuccessMessage($"Your part {addPartModel.Name} has been successfully added for sale.");

            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult SuccessfullyBought()
        {
            TempData.AddSuccessMessage($"You have successfully bought your wanted part.");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buy(int id)
        {
            var partToBuy = this.parts.Buy(id);

            return View(new PartFormModel
            {
                Name = partToBuy.Name,
                Price = partToBuy.Price,
                Condition = partToBuy.Condition,
                ImageUrl = partToBuy.ImageUrl
            });
        }

        public IActionResult Edit(int id)
        {
            var part = this.parts.FindById(id);

            if (part == null)
            {
                return NotFound();
            }

            return this.View(new PartFormModel
            {
                Name = part.Name,
                Price = part.Price,
                Condition = part.Condition,
                ImageUrl = part.ImageUrl
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, PartFormModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(editModel);
            }

            var partExists = this.parts.Exists(id);

            if (!partExists)
            {
                return NotFound();
            }

            this.parts.Edit(id, editModel.Name, editModel.Price, editModel.Condition, editModel.ImageUrl);

            TempData.AddSuccessMessage("You have succesfully edited your part.");

            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var part = this.parts.FindById(id);

            if (part == null)
            {
                return NotFound();
            }

            return View(new PartFormModel
            {
                Name = part.Name,
                Price = part.Price,
                Condition = part.Condition,
                ImageUrl = part.ImageUrl
            });
        }

        [HttpPost]
        public IActionResult Delete(int id, PartFormModel partModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(partModel);
            }

            var partExists = this.parts.Exists(id);

            if (!partExists)
            {
                return NotFound();
            }

            var result = this.parts.DeletePart(id);

            TempData.AddSuccessMessage("You have successfully removed your part.");

            return this.RedirectToAction(nameof(Index));
        }
    }
}