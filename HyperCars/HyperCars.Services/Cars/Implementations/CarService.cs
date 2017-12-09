namespace HyperCars.Services.Cars.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Services.Cars.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarService : ICarService
    {
        private readonly HyperCarsDbContext db;
        
        public CarService(
            HyperCarsDbContext db,
            UserManager<User> userManager)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CarAllListingServiceModel>> AllAsync() => await this.db
                .Cars
                .ProjectTo<CarAllListingServiceModel>()
                .ToListAsync();

        public bool Add(string model, decimal price, BodyType bodyType, TypeOfTransmission typeOfTransmission, double travelledDistance, int yearOfProduction, int horsePower, string color, string imageUrl, string userId)
        {
            if (!this.db.Users.Any(u => u.Id == userId))
            {
                return false;
            }

            var car = new Car
            {
                Model = model,
                Price = price,
                BodyType = bodyType,
                TypeOfTransmission = typeOfTransmission,
                TravelledDistance = travelledDistance,
                YearOfProduction = yearOfProduction,
                HorsePower = horsePower,
                Color = color,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();

            return true;
        }
    }
}