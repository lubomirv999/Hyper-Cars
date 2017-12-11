namespace HyperCars.Web.Areas.Cars.Controllers
{
    using HyperCars.Data.Models;
    using HyperCars.Web.Areas.Cars.Models;
    using HyperCars.Web.Infrastructure.Extensions;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Cars;
    using System.Threading.Tasks;

    [Area("Cars")]
    [Authorize]
    public class CarsController : Controller
    {        
        private readonly ICarService cars;

        public CarsController(
            ICarService cars)
        {
            this.cars = cars;
        }

        public async Task<IActionResult> Index()
            => View(await this.cars.AllAsync());

        public IActionResult Create()
            => View();

        [Authorize]
        [HttpPost]
        public IActionResult Create(AddCarFormModel addCarFormModel)
        {
            var success = this.cars.Add(
                addCarFormModel.Model,
                addCarFormModel.Price,
                addCarFormModel.BodyType,
                addCarFormModel.TypeOfTransmission,
                addCarFormModel.TravelledDistance,
                addCarFormModel.ProductionYear,
                addCarFormModel.HorsePower,
                addCarFormModel.Color,
                addCarFormModel.ImageUrl,
                this.User.Identity.GetUserId());

            if (!success)
            {
                return this.BadRequest();
            }

            TempData.AddSuccessMessage($"Your car {addCarFormModel.Model} has been successfully added for sale.");

            return this.RedirectToAction(nameof(Index));
        }
    }
}