namespace HyperCars.Services.Parts.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Parts.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HyperCars.Data.Models.Enums;
    using System.Linq;
    using HyperCars.Data.Models;

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

        public bool Add(string name, decimal price, Condition condition, string imageUrl, string userId)
        {
            if (!this.db.Users.Any(u => u.Id == userId))
            {
                return false;
            }

            var part = new Part()
            {
                Name = name,
                Price = price,
                Condition = condition,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(part);
            this.db.SaveChanges();

            return true;
        }

        public PartAllListingServiceModel FindById(int id)
            => this.db
                .Parts
                .Where(p => p.Id == id)
                .ProjectTo<PartAllListingServiceModel>()
                .FirstOrDefault();

        public bool Exists(int id)
            => this.db.Parts.Any(p => p.Id == id);

        public void Edit(int id, string name, decimal price, Condition condition, string imageUrl)
        {
            if (!this.db.Parts.Any(p => p.Id == id))
            {
                return;
            }

            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            // Editing the part

            part.Name = name;
            part.Price = price;
            part.Condition = condition;
            part.ImageUrl = imageUrl;

            this.db.SaveChanges();
        }

        public bool DeletePart(int id)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return false;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();

            return true;
        }
    }
}