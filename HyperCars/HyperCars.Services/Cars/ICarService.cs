namespace HyperCars.Services.Cars
{
    using HyperCars.Data.Models.Enums;
    using Services.Cars.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task<IEnumerable<CarAllListingServiceModel>> AllAsync();
    }
}