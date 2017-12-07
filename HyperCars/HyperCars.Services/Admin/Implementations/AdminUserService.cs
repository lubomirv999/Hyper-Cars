namespace HyperCars.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdminUserService : IAdminUserService
    {
        private HyperCarsDbContext db;

        public AdminUserService(HyperCarsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
            => await this.db
                .Users
                .ProjectTo<AdminUserListingServiceModel>()
                .ToListAsync();
    }
}