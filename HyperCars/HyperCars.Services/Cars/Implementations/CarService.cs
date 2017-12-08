namespace HyperCars.Services.Cars.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using HyperCars.Services.Cars.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CarService : ICarService
    {
        private readonly HyperCarsDbContext db;

        public CarService(HyperCarsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CarAllListingServiceModel>> AllAsync() => await this.db
                .Cars
                .ProjectTo<CarAllListingServiceModel>()
                .ToListAsync();
    }
}