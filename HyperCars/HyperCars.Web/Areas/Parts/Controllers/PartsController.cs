namespace HyperCars.Web.Areas.Parts.Controllers
{
    using Services.Parts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Models;
    using Microsoft.AspNet.Identity;
    using HyperCars.Web.Infrastructure.Extensions;

    [Area("Parts")]
    [Authorize]
    public class PartsController : Controller
    {
        private readonly IPartService parts;

        public PartsController(IPartService parts)
        {
            this.parts = parts;
        }

        public async Task<IActionResult> Index()
            => View(await this.parts.AllAsync());

        public IActionResult Create()
            => View();

        [Authorize]
        [HttpPost]
        public IActionResult Create(AddPartFormModel model)
        {
            var success = this.parts.Add(
                model.Name,
                model.Price,
                model.Condition,
                model.ImageUrl,
                this.User.Identity.GetUserId());

            if (!success)
            {
                return this.BadRequest();
            }

            TempData.AddSuccessMessage($"Your part {model.Name} has been successfully added for sale.");

            return this.RedirectToAction(nameof(Index));
        }
    }
}