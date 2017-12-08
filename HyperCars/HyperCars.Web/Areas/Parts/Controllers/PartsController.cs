namespace HyperCars.Web.Areas.Parts.Controllers
{
    using Services.Parts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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
    }
}