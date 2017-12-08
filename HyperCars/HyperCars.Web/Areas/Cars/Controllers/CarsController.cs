namespace HyperCars.Web.Areas.Cars.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Cars;
    using System.Threading.Tasks;

    [Area("Cars")]
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        public async Task<IActionResult> Index()
            => View(await this.cars.AllAsync());
    }
}