namespace HyperCars.Services.Parts.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Parts.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PartService : IPartService
    {
        private readonly HyperCarsDbContext db;

        public PartService(HyperCarsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<PartAllListingServiceModel>> AllAsync() => await this.db
                .Parts
                .ProjectTo<PartAllListingServiceModel>()
                .ToListAsync();
    }
}