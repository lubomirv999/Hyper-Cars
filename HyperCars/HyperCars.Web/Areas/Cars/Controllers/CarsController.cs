namespace HyperCars.Web.Areas.Cars.Controllers
{
    using HyperCars.Web.Areas.Cars.Models;
    using HyperCars.Web.Infrastructure.Extensions;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Cars;
    using System;
    using System.Threading.Tasks;

    [Area("Cars")]
    [Authorize]
    public class CarsController : Controller
    {
        private const int PageSize = 6;

        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 6)
            => View(new CarListingModel
            {
                Cars = await this.cars.AllAsync(page, pageSize),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.cars.Total() / (double)PageSize)
            });

        public IActionResult Create()
            => View();

        [HttpPost]
        public IActionResult Create(CarFormModel addCarFormModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(addCarFormModel);
            }

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

        public IActionResult SuccessfullyBought()
        {
            TempData.AddSuccessMessage($"You have successfully bought your wanted car.");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buy(int id)
        {
            var carToBuy = this.cars.Buy(id);

            return View(new CarFormModel
            {
                Model = carToBuy.Model,
                Price = carToBuy.Price,
                BodyType = carToBuy.BodyType,
                TypeOfTransmission = carToBuy.TypeOfTransmission,
                TravelledDistance = carToBuy.TravelledDistance,
                ProductionYear = carToBuy.ProductionYear,
                HorsePower = carToBuy.HorsePower,
                Color = carToBuy.Color,
                ImageUrl = carToBuy.ImageUrl
            });
        }        

        public IActionResult Edit(int id)
        {
            var car = this.cars.FindById(id);

            if (car == null)
            {
                return NotFound();
            }

            return this.View(new CarFormModel
            {
                Model = car.Model,
                Price = car.Price,
                BodyType = car.BodyType,
                TypeOfTransmission = car.TypeOfTransmission,
                TravelledDistance = car.TravelledDistance,
                ProductionYear = car.ProductionYear,
                HorsePower = car.HorsePower,
                Color = car.Color,
                ImageUrl = car.ImageUrl
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, CarFormModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(editModel);
            }

            var carExists = this.cars.Exists(id);

            if (!carExists)
            {
                return NotFound();
            }

            this.cars.Edit(id, editModel.Model, editModel.Price, editModel.BodyType, editModel.TypeOfTransmission, editModel.TravelledDistance, editModel.ProductionYear, editModel.HorsePower, editModel.Color, editModel.ImageUrl);

            TempData.AddSuccessMessage("You have succesfully edited your car.");

            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var car = this.cars.FindById(id);

            if (car == null)
            {
                return NotFound();
            }

            return View(new CarFormModel
            {
                Model = car.Model,
                Price = car.Price,
                BodyType = car.BodyType,
                TypeOfTransmission = car.TypeOfTransmission,
                TravelledDistance = car.TravelledDistance,
                ProductionYear = car.ProductionYear,
                HorsePower = car.HorsePower,
                Color = car.Color,
                ImageUrl = car.ImageUrl
            });
        }

        [HttpPost]
        public IActionResult Delete(int id, CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(carModel);
            }

            var carExists = this.cars.Exists(id);

            if (!carExists)
            {
                return NotFound();
            }

            var result = this.cars.DeleteCar(id);

            TempData.AddSuccessMessage("You have successfully removed your car.");

            return this.RedirectToAction(nameof(Index));
        }
    }
}